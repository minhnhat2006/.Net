using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLThuChi
{
    public partial class RptSoQuyTienMat : DevExpress.XtraReports.UI.XtraReport
    {
        public RptSoQuyTienMat()
        {
            InitializeComponent();
        }

        private void RptSoQuyTienMat_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime tuNgay = (DateTime)FromDate.Value;
            DateTime denNgay = (DateTime)ToDate.Value;
            lblNgay.Text = String.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", tuNgay, denNgay);
        }
    }
}
