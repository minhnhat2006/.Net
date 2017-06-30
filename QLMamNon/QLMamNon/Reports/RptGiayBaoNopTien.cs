using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLThuChi
{
    public partial class RptGiayBaoNopTien : DevExpress.XtraReports.UI.XtraReport
    {
        public RptGiayBaoNopTien()
        {
            InitializeComponent();
        }

        private void lblNgayAndXuatAn_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lblNgayAndXuatAn.Text = String.Format("Tháng {0:MM/yyyy} ({1} xuất ăn)", this.NgayNop.Value, this.SoXuat.Value);
        }


    }
}
