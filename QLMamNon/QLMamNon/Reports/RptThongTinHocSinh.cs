using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLThuChi
{
    public partial class RptThongTinHocSinh : DevExpress.XtraReports.UI.XtraReport
    {
        public RptThongTinHocSinh()
        {
            InitializeComponent();
        }

        private void RptThongTinHocSinh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
    }
}
