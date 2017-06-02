using System;
using System.Drawing;
using QLMamNon.Components.Data.Static;
using QLMamNon.Facade;
using QLMamNon.Properties;
using System.Net;
using System.IO;
using ACG.Core.WinForm.Util;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QLMamNon.Forms.TinNhan
{
    public partial class FrmTinNhanPhuHuynh : DevExpress.XtraEditors.XtraForm
    {
        public FrmTinNhanPhuHuynh()
        {
            InitializeComponent();
        }

        private void FrmTinNhanPhuHuynh_Load(object sender, EventArgs e)
        {
            fillTxtGuide();

            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
        }

        private void fillTxtGuide()
        {
            object[,] textAndColors = new object[8, 2] 
            { 
                {"Vui lòng sử dụng mẫu tin nhắn với cú pháp như sau: ", Color.Black},
                {"{Tên đơn vị} ", Color.Blue},
                {"{Từ khóa} ", Color.Green},
                {"{Nội dung tin nhắn}\n", Color.Orange},
                {"Ví dụ tin nhẵn mẫu: ", Color.Black},
                {"Trường MN Hồng Minh ", Color.Blue},
                {"Thông báo ", Color.Green},
                {"Thứ 5 ngày 20/11, các bé nghỉ học do trường tổ chức ngày Nhà giáo Việt nam", Color.Orange}
            };

            for (int i = 0; i < textAndColors.GetLength(0); i++)
            {
                string text = (string)textAndColors[i, 0];
                Color color = (Color)textAndColors[i, 1];
                txtGuide.SelectionStart = txtGuide.TextLength;
                txtGuide.SelectionLength = text.Length;
                txtGuide.SelectionColor = color;
                txtGuide.AppendText(text);
            }
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            this.hocSinhRowBindingSource.DataSource = this.hocSinhTableAdapter.GetHocSinhByLopAndNgay((int)this.cmbLop.EditValue, DateTime.Now);
            this.gvMain.SelectAll();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (StringUtil.IsEmpty(this.txtNoiDung.Text))
            {
                MessageBox.Show("Xin vui lòng nhập nội dung tin nhắn", "Nội dung tin nhắn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<string> soDienThoais = new List<string>();
            int[] selectedRowHandlers = this.gvMain.GetSelectedRows();

            if (ArrayUtil.IsEmpty(selectedRowHandlers))
            {
                MessageBox.Show("Xin vui lòng chọn học sinh", "Chọn học sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (int rowHandler in selectedRowHandlers)
            {
                string soDienThoai = (string)this.gvMain.GetRowCellValue(rowHandler, "DienThoai");
                soDienThoais.Add(soDienThoai);
            }

            string requestUrl = String.Format(Settings.Default.SMSWSSendMessageUrl, StringUtil.Join(soDienThoais, ","), this.txtNoiDung.Text);

            try
            {
                this.sendGetRequest(requestUrl);
                MessageBox.Show("Tin nhắn đã được gửi", "Gửi tin nhắn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    String.Format("Xuất hiện lỗi trong quá trình gửi tin nhắn. Chi tiết: {0}", ex.Message),
                    "Gửi tin nhắn không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string sendGetRequest(string RequestUrl)
        {
            Uri address = new Uri(RequestUrl);
            HttpWebRequest request;
            HttpWebResponse response = null;
            StreamReader reader;

            if (address == null)
            {
                throw new ArgumentNullException("address");
            }

            try
            {
                request = WebRequest.Create(address) as HttpWebRequest;
                request.UserAgent = "QLMamNon";
                request.KeepAlive = false;
                request.Timeout = 15 * 1000;
                response = request.GetResponse() as HttpWebResponse;

                if (request.HaveResponse == true && response != null)
                {
                    reader = new StreamReader(response.GetResponseStream());
                    string result = reader.ReadToEnd();
                    result = result.Replace("</string>", "");
                    Console.WriteLine("The SMS was sent with returned message [{0}]", result);
                    return null;
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                    {
                        string errorMsg = String.Format("The server returned '{0}' with the status code {1} ({2:d}).",
                            errorResponse.StatusDescription, errorResponse.StatusCode,
                            errorResponse.StatusCode);
                        Console.WriteLine(errorMsg);
                        throw new ApplicationException(errorMsg);
                    }
                }
            }
            finally
            {
                if (response != null) { response.Close(); }
            }

            return null;
        }

        private void txtNoiDung_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            this.lblKiTu.Text = String.Format("Nội dung tin nhắn tối đa 160 kí tự (số kí tự còn lại: {0})", StringUtil.IsEmpty(this.txtNoiDung.Text) ? 160 : 160 - this.txtNoiDung.Text.Length);
        }
    }
}