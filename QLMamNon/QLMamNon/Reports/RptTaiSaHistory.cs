using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLThuChi
{
    public partial class RptTaiSaHistory : DevExpress.XtraReports.UI.XtraReport
    {
        public RptTaiSaHistory()
        {
            InitializeComponent();
        }

        private void RptTaiSaHistory_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
    }
}
