using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLThuChi
{
    public partial class RptCTTMNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public RptCTTMNhanVien()
        {
            InitializeComponent();
        }

        private void RptCTTMNhanVien_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.cTTMNhanVienTableAdapter.FillByUserCode(this.thuChi.CTTMNhanVien, this.UserCode.Value as string
                , (DateTime)this.FromDate.Value, (DateTime)this.ToDate.Value);
        }
    }
}
