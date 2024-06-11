using System;

namespace QLMamNon.Reports
{
    public partial class RptTinhHinhThuChi : DevExpress.XtraReports.UI.XtraReport
    {
        public RptTinhHinhThuChi()
        {
            InitializeComponent();
        }

        private void RptTinhHinhThuChi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime tuNgay = (DateTime)TuNgay.Value;
            DateTime denNgay = (DateTime)DenNgay.Value;
            this.lblNgay.Text = String.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", tuNgay, denNgay);
        }
    }
}
