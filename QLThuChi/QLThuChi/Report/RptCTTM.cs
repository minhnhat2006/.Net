using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLThuChi
{
    public partial class RptCTTM : DevExpress.XtraReports.UI.XtraReport
    {
        public RptCTTM()
        {
            InitializeComponent();
        }

        private void RptCTTM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.cTTMTheoNgayTableAdapter.Fill(this.thuChi.CTTMTheoNgay, (DateTime)this.Ngay.Value);

            long tongNo = 0;
            long tongCo = 0;

            foreach (QLThuChi.Dao.ThuChi.CTTMTheoNgayRow row in this.thuChi.CTTMTheoNgay)
            {
                tongNo += (long)row.TienNo;
                tongCo += (long)row.TienCo;
            }

            long tongPhatSinh = long.Parse(this.TienTCS.Value.ToString()) + tongNo;
            long soDuCuoiNgay = long.Parse(this.SoDuDauNgay.Value.ToString()) + tongPhatSinh - tongCo;

            this.lblTongPhatSinh.Text = String.Format("{0:#,#}", tongPhatSinh);
            this.lblSoDuCuoiNgay.Text = String.Format("{0:#,#}", soDuCuoiNgay);
            this.lblSoDuCuoiNgayBangChu.Text = "Tổng số tiền bằng chữ: " + VNCurrency.ToString(decimal.Parse(this.lblSoDuCuoiNgay.Text));
        }
    }
}
