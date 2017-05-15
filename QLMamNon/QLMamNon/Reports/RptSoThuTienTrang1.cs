using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLThuChi
{
    public partial class RptSoThuTienTrang1 : DevExpress.XtraReports.UI.XtraReport
    {
        public RptSoThuTienTrang1()
        {
            InitializeComponent();
        }

        private void RptSoThuTienTrang1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime ngayThangNam = (DateTime)this.Ngay.Value;
            this.lblTitle.Text = String.Format("SỔ THU HỌC PHÍ THÁNG {0}-{1}", ngayThangNam.Month, ngayThangNam.Year);
        }
    }
}
