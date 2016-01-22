using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.OleDb;

namespace DuToanNSNN
{
    public partial class RptBaoCao : DevExpress.XtraReports.UI.XtraReport
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string MaChuong { get; set; }
        public string MaCapNS { get; set; }
        public string MaQHNS { get; set; }

        public RptBaoCao()
        {
            InitializeComponent();
        }

        private void RptBaoCao_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (FromDate.Month == 1 && ToDate.Month == 12)
            {
                this.DataSource = bangDoiChieuTableAdapter1.GetDataByDuLieuDonViByYear(FromDate.Year.ToString(), MaChuong, MaQHNS, MaCapNS);
                this.rptKBNN1.DataSource = bangDoiChieuTableAdapter1.GetDataByDuLieuKBNNByYear(FromDate.Year.ToString(), MaChuong, MaQHNS, MaCapNS);
            }
            else
            {
                this.DataSource = bangDoiChieuTableAdapter1.GetDataByDuLieuDonVi(FromDate, ToDate, MaChuong, MaQHNS, MaCapNS);
                this.rptKBNN1.DataSource = bangDoiChieuTableAdapter1.GetDataByDuLieuKBNN(FromDate, ToDate, MaChuong, MaQHNS, MaCapNS);
            }

            if ((this.rptKBNN1.DataSource as DuToanNSNN.BangDoiChieuKBNN.BangDoiChieuDataTable).Count == 0)
            {
                this.rptKBNN1.Visible = false;
            }

            if ((this.DataSource as DuToanNSNN.BangDoiChieuKBNN.BangDoiChieuDataTable).Count == 0)
            {
                this.xrTable2.Visible = false;
                this.xrTable3.Visible = false;
            }
        }
    }
}
