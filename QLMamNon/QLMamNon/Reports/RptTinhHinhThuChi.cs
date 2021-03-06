using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using QLMamNon.Entity.Form;

namespace QLThuChi
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
