using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLThuChi
{
    public partial class RptSoTheoDoiTaiSan : DevExpress.XtraReports.UI.XtraReport
    {
        public RptSoTheoDoiTaiSan()
        {
            InitializeComponent();
        }

        private void RptSoTheoDoiTaiSan_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
    }
}
