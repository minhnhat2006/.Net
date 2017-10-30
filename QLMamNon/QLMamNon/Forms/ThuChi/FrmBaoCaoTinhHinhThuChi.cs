using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using DevExpress.XtraEditors;
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

            List<int> phanLoaiThuIds = new List<int>();
            int[] selectedThuRowHandlers = this.gvThu.GetSelectedRows();

            if (ArrayUtil.IsEmpty(selectedThuRowHandlers))
            {
                MessageBox.Show("Xin vui lòng chọn Phân loại thu", "Chọn Phân loại thu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (int rowHandler in selectedThuRowHandlers)
            {
                int phanLoaiThuId = (int)this.gvThu.GetRowCellValue(rowHandler, "PhanLoaiThuId");
                phanLoaiThuIds.Add(phanLoaiThuId);
            }

            List<int> phanLoaiChiIds = new List<int>();
            int[] selectedRowHandlers = this.gvMain.GetSelectedRows();

            if (ArrayUtil.IsEmpty(selectedRowHandlers))
            {
                MessageBox.Show("Xin vui lòng chọn Mã loại chi", "Chọn Mã loại chi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (chkTon.Checked && StringUtil.IsEmpty(txtTon.Text))
            {
                MessageBox.Show("Xin vui lòng nhập số tiền tồn tháng trước", "Nhập số tiền tồn tháng trước", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (int rowHandler in selectedRowHandlers)
            {
                int phanLoaiChiId = (int)this.gvMain.GetRowCellValue(rowHandler, "PhanLoaiChiId");
                phanLoaiChiIds.Add(phanLoaiChiId);
            }

            DateTime fromDate = DateTimeUtil.StartOfDate(this.dateTuNgay.DateTime);
            DateTime toDate = DateTimeUtil.EndOfDate(this.dateDenNgay.DateTime);

            UnknownColumnViewTableAdapter unknownColumnViewTableAdapter = (UnknownColumnViewTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterUnknownColumnView);
            RptTinhHinhThuChi rpt = new RptTinhHinhThuChi();
            rpt.TuNgay.Value = fromDate;
            rpt.DenNgay.Value = toDate;
            rpt.TongThu.Value = unknownColumnViewTableAdapter.GetSumSoTienThuByDateRange(fromDate, toDate, StringUtil.JoinWithCommas(phanLoaiThuIds));
            rpt.TongChi.Value = unknownColumnViewTableAdapter.GetSumSoTienChiByDateRange(fromDate, toDate, StringUtil.JoinWithCommas(phanLoaiChiIds));

            rpt.Ton.Value = findSoTienTonDauKy(toDate);
            rpt.ChenhLech.Value = (decimal)rpt.Ton.Value + (decimal)rpt.TongThu.Value - (decimal)rpt.TongChi.Value;

            PhieuThuService phieuThuService = new PhieuThuService();
            rpt.thuDataSource.DataSource = phieuThuService.LoadPhieuThuByDateRangeWithGroupPhanLoaiThu(fromDate, toDate, phanLoaiThuIds);

            PhieuChiService phieuChiService = new PhieuChiService();
            rpt.chiDataSource.DataSource = phieuChiService.LoadPhieuChiByDateRangeWithGroupPhanLoaiChi(fromDate, toDate, phanLoaiChiIds);

            FormMainFacade.ShowReport(rpt);
        }

        private decimal findSoTienTonDauKy(DateTime toDate)
        {
            decimal soTienTonDauKy = txtTon.Value;

            if (!chkTon.Checked)
            {
                SoThuTienService soThuTienService = new SoThuTienService();
                soTienTonDauKy = soThuTienService.GetSoTienTonDauKy(toDate);
            }
            return soTienTonDauKy;
        }

        private void FrmBaoCaoTinhHinhThuChi_Load(object sender, EventArgs e)
        {
            this.phanLoaiChiRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.PhanLoaiChi);
            this.phanLoaiThuRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.PhanLoaiThu);
        }

        private void FrmBaoCaoTinhHinhThuChi_Shown(object sender, EventArgs e)
        {
            this.gvThu.SelectAll();
            this.gvMain.SelectAll();
        }

        private void chkTon_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit chk = (CheckEdit)sender;
            txtTon.Enabled = chk.Checked;
        }
    }
}