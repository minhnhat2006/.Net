using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using QLMamNon.Entity.Form;

namespace QLThuChi
{
    public partial class RptBaoCaoHoatDongTaiChinh : DevExpress.XtraReports.UI.XtraReport
    {
        public RptBaoCaoHoatDongTaiChinh()
        {
            InitializeComponent();
        }

        private void RptBaoCaoHoatDongTaiChinh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime tuNgay = (DateTime)TuNgay.Value;
            DateTime denNgay = (DateTime)DenNgay.Value;
            this.lblNgay.Text = String.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", tuNgay, denNgay);
            long soTienThu = Convert.ToInt64(this.unknownColumnViewTableAdapter.GetPhieuThuForReportBCHDTC(tuNgay, denNgay));
            this.lblSoTienThu.Text = String.Format("{0:n0}", soTienThu);

            List<PhieuChiBCHDTC> phieuChiList = new List<PhieuChiBCHDTC>();
            QLMamNon.Dao.QLMamNonDs.UnknownColumnViewDataTable phieuChiTable = unknownColumnViewTableAdapter.GetPhieuChiListForReportBCHDTC(tuNgay, denNgay, (string)this.PhanLoaiChiIds.Value);
            long totalSoTien = 0;
            foreach (QLMamNon.Dao.QLMamNonDs.UnknownColumnViewRow row in phieuChiTable)
            {
                int phanLoaiChiId = (int)row["PhanLoaiChiId"];
                string dienGiai = (string)row["DienGiai"];
                string maLoaiChi = (string)row["MaPhanLoai"];
                long soTien = Convert.ToInt64(row["SoTien"]);
                PhieuChiBCHDTC phieuChiBCHDTC = new PhieuChiBCHDTC(phanLoaiChiId, dienGiai, maLoaiChi, soTien);
                phieuChiList.Add(phieuChiBCHDTC);
                totalSoTien += soTien;
            }

            this.lblLoiNhuan.Text = String.Format("{0:n0}", soTienThu - totalSoTien);

            this.phieuChiBCHDTCDataSource.DataSource = phieuChiList;
            this.phieuChiBCHDTCDataSource.Fill();
        }
    }
}
