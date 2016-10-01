using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace QLThuChi.Form
{
    public partial class FrmCTTMTheoNgay : DevExpress.XtraEditors.XtraForm
    {
        public FrmCTTMTheoNgay()
        {
            InitializeComponent();
        }

        private bool Validate_EmptyStringRule(BaseEdit control)
        {
            if (control.Text == null || control.Text.Trim().Length == 0)
            {
                this.dxErrorProvider1.SetError(control, "Thông tin này không được bỏ trống", ErrorType.Critical);
                return false;
            }
            else
            {
                dxErrorProvider1.SetError(control, "");
                return true;
            }
        }

        private void FrmCTTMTheoNgay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thuChi.setting' table. You can move, or remove it, as needed.
            this.settingTableAdapter.Fill(this.thuChi.setting);
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            bool isValidatePass = this.ValidateInputs();

            if (!isValidatePass)
            {
                return;
            }

            this.Hide();
            FrmHome home = this.Owner as FrmHome;
            RptCTTM rpt = new RptCTTM();
            this.fillReportUser(rpt);
            home.ucReport1.printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();
            home.xtraTabControl1.SelectedTabPageIndex = 4;
            home.xtraTabControl1.TabPages[4].Text = "Xem trước Bảng kê tồn quỹ tiền mặt cuối ngày";
        }

        private bool ValidateInputs()
        {
            bool isNgay = Validate_EmptyStringRule(this.txtNgay);
            bool isValidatePass = isNgay;
            return isValidatePass;
        }

        private void fillReportUser(RptCTTM rpt)
        {
            this.calulateSoDuBanDau(rpt);

            this.tientcsTableAdapter.FillByNgay(this.thuChi.tientcs, this.txtNgay.DateTime);

            if (this.thuChi.tientcs.Rows.Count > 0)
            {
                QLThuChi.Dao.ThuChi.tientcsRow row = this.thuChi.tientcs[0];
                rpt.TienTCS.Value = row.ThuPhat + row.ThuTCS;
            }
            else
            {
                rpt.TienTCS.Value = 0;
            }

            rpt.Ngay.Value = txtNgay.DateTime;
            rpt.lblNgay.Text = string.Format("Ngày {0} tháng {1} năm {2}", txtNgay.DateTime.Day, txtNgay.DateTime.Month, txtNgay.DateTime.Year);
        }

        private void calulateSoDuBanDau(RptCTTM rpt)
        {
            decimal soDuBanDau = 0;
            QLThuChi.Dao.ThuChi.settingRow[] rowSoDubanDau = (QLThuChi.Dao.ThuChi.settingRow[])this.thuChi.setting.Select("name='" + FrmHome.SettingSoDuBanDau + "'");

            if (rowSoDubanDau != null && rowSoDubanDau.Length > 0)
            {
                soDuBanDau = Decimal.Parse(rowSoDubanDau[0].Value);
            }

            object tienTCS = this.tientcsTableAdapter.sumTienTCSTheoNgay(this.txtNgay.DateTime);

            if (tienTCS != null)
            {
                soDuBanDau += (decimal)tienTCS;
            }

            object tienNoTruocNgay = this.cttmTheoNgayTableAdapter.sumCTTMTienNoTruocNgay(this.txtNgay.DateTime);

            if (tienNoTruocNgay == null)
            {
                rpt.SoDuDauNgay.Value = soDuBanDau;
            }
            else
            {
                rpt.SoDuDauNgay.Value = (decimal)this.cttmTheoNgayTableAdapter.sumCTTMTienNoTruocNgay(txtNgay.DateTime) + soDuBanDau;
            }
        }
    }
}