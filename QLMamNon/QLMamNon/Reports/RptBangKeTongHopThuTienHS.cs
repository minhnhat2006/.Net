using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLThuChi
{
    public partial class RptBangKeTongHopThuTienHS : DevExpress.XtraReports.UI.XtraReport
    {
        public RptBangKeTongHopThuTienHS()
        {
            InitializeComponent();
        }

        private void RptBangKeTongHopThuTienHS_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime ngayThangNam = (DateTime)this.Ngay.Value;
            this.lblTitle.Text = String.Format("BẢNG KÊ THU HỌC PHÍ THÁNG {0}-{1}", ngayThangNam.Month, ngayThangNam.Year);
        }
    }
}
