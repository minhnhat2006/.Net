namespace QLMamNon.Reports
{
    public partial class RptBangKeCacLoaiChi : DevExpress.XtraReports.UI.XtraReport
    {
        public RptBangKeCacLoaiChi()
        {
            InitializeComponent();
        }

        private void RptBangKeCacLoaiChi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (string.IsNullOrEmpty((string)Week5.Value))
            {
                tblCellWeek5.DataBindings.Clear();
            }

            if (string.IsNullOrEmpty((string)Week6.Value))
            {
                tblCellWeek6.DataBindings.Clear();
            }
        }
    }
}
