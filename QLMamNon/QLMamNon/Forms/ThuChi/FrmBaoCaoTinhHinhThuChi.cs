using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Facade;
using QLMamNon.Service.Data;
using QLThuChi;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmBaoCaoTinhHinhThuChi : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        protected string FormKey { get; set; }

        public GridView GridView { get; set; }

        public bool IsEditing { get; set; }

        public QLMamNon.Dao.QLMamNonDs.PhieuThuRow PhieuThuRow { get; set; }

        #endregion

        public FrmBaoCaoTinhHinhThuChi()
        {
            this.FormKey = AppForms.FormBaoCaoTinhHinhThuChi;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (this.dateTuNgay.DateTime == null || this.dateDenNgay.DateTime == null)
            {
                MessageBox.Show("Xin vui lòng chọn ngày", "Chọn ngày", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<int> phanLoaiChiIds = new List<int>();
            int[] selectedRowHandlers = this.gvMain.GetSelectedRows();

            if (ArrayUtil.IsEmpty(selectedRowHandlers))
            {
                MessageBox.Show("Xin vui lòng chọn Mã loại chi", "Chọn Mã loại chi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (int rowHandler in selectedRowHandlers)
            {
                int phanLoaiChiId = (int)this.gvMain.GetRowCellValue(rowHandler, "PhanLoaiChiId");
                phanLoaiChiIds.Add(phanLoaiChiId);
            }

            UnknownColumnViewTableAdapter unknownColumnViewTableAdapter = (UnknownColumnViewTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterUnknownColumnView);
            RptTinhHinhThuChi rpt = new RptTinhHinhThuChi();
            rpt.TuNgay.Value = this.dateTuNgay.DateTime;
            rpt.DenNgay.Value = this.dateDenNgay.DateTime;
            rpt.TongThu.Value = unknownColumnViewTableAdapter.GetPhieuThuForReportBCHDTC(this.dateTuNgay.DateTime, this.dateDenNgay.DateTime);
            rpt.TongChi.Value = unknownColumnViewTableAdapter.GetSumSoTienChiByDateRange(this.dateTuNgay.DateTime, this.dateDenNgay.DateTime, StringUtil.JoinWithCommas(phanLoaiChiIds));
            rpt.ChenhLech.Value = (decimal)rpt.TongThu.Value - (decimal)rpt.TongChi.Value;

            PhieuChiService phieuChiService = new PhieuChiService();
            rpt.objectDataSource.DataSource = phieuChiService.LoadPhieuChiByDateRangeWithGroupPhanLoaiChi(this.dateTuNgay.DateTime, this.dateDenNgay.DateTime, phanLoaiChiIds);

            FormMainFacade.ShowReport(rpt);
        }

        private void FrmBaoCaoTinhHinhThuChi_Load(object sender, EventArgs e)
        {
            this.phanLoaiChiRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.PhanLoaiChi);
        }

        private void FrmBaoCaoTinhHinhThuChi_Shown(object sender, EventArgs e)
        {
            this.gvMain.SelectAll();
        }
    }
}