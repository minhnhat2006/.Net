using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using QLMamNon.Entity.Form;
using QLMamNon.Constant;

namespace QLThuChi
{
    public partial class RptBaoCaoChiTietHoatDongTaiChinh : DevExpress.XtraReports.UI.XtraReport
    {
        public RptBaoCaoChiTietHoatDongTaiChinh()
        {
            InitializeComponent();
        }

        private void RptBaoCaoHoatDongTaiChinh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime tuNgay = (DateTime)TuNgay.Value;
            DateTime denNgay = (DateTime)DenNgay.Value;
            this.lblNgay.Text = String.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", tuNgay, denNgay);

            List<PhieuChiBCHDTC> phieuChiList = new List<PhieuChiBCHDTC>();
            QLMamNon.Dao.QLMamNonDs.UnknownColumnViewDataTable phieuChiTable = unknownColumnViewTableAdapter.GetPhieuChiListForReportBCHDTC(tuNgay, denNgay, CommonConstant.EMPTY);

            foreach (QLMamNon.Dao.QLMamNonDs.UnknownColumnViewRow row in phieuChiTable)
            {
                int phanLoaiChiId = (int)row["PhanLoaiChiId"];
                string dienGiai = (string)row["DienGiai"];
                string maLoaiChi = null;
                long soTien = Convert.ToInt64(row["SoTien"]);
                PhieuChiBCHDTC phieuChiBCHDTC = new PhieuChiBCHDTC(phanLoaiChiId, dienGiai, maLoaiChi, soTien);
                phieuChiList.Add(phieuChiBCHDTC);
            }

            this.phieuChiBCHDTCDataSource.DataSource = phieuChiList;
            this.phieuChiBCHDTCDataSource.Fill();
        }
    }
}
