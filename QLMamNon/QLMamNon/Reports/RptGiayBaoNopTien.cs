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

        private void report_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lblNangKhieuDieuHoa.Text = (Boolean)this.ShowDieuHoa.Value ? "Năng khiếu + Điều hòa" : "Năng khiếu";
            this.lblNgayAndXuatAn.Text = String.Format("Tháng {0:MM/yyyy} ({1} suất ăn)", this.NgayNop.Value, this.SoXuat.Value);

            if ((bool)ShowNote.Value)
            {
                this.lblNote.DataBindings["Text"].FormatString = "Hỗ trợ 01 suất ăn cho hoạt động dã ngoại\nSơn Trà, ngày {0:dd} tháng {0:MM} năm {0:yyyy}";
            }
            else
            {
                this.lblNote.DataBindings["Text"].FormatString = "Sơn Trà, ngày {0:dd} tháng {0:MM} năm {0:yyyy}";
            }
        }


    }
}
