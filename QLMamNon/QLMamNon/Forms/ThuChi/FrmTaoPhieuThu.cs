using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Facade;
using QLMamNon.Service.Data;
using LayoutVisibility = DevExpress.XtraLayout.Utils.LayoutVisibility;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmTaoPhieuThu : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        protected string FormKey { get; set; }

        public GridView GridView { get; set; }

        public bool IsEditing { get; set; }

        public QLMamNon.Dao.QLMamNonDs.PhieuThuRow PhieuThuRow { get; set; }

        #endregion

        public FrmTaoPhieuThu()
        {
            this.FormKey = AppForms.FormTaoPhieuThu;
            InitializeComponent();
        }

        private void FrmTaoPhieuThu_Load(object sender, EventArgs e)
        {
            HocSinhTableAdapter hocSinhTableAdapter = (HocSinhTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterHocSinh);
            HocSinhLopTableAdapter hocSinhLopTableAdapter = (HocSinhLopTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterHocSinhLop);

            QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable = hocSinhTableAdapter.GetData();
            ThongTinHocSinhUtil.EvaluateLopInfoForHocSinhTable(hocSinhLopTableAdapter, hocSinhTable);
            this.hocSinhRowBindingSource.DataSource = hocSinhTable;
            this.phanLoaiThuRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.PhanLoaiThu);

            if (this.IsEditing)
            {
                this.loadPhieuThu();
            }
            else
            {
                this.resetForm();
            }
        }

        private void FrmTaoPhieuThu_Enter(object sender, EventArgs e)
        {
            int hocSinhId = (int)this.GridView.GetFocusedRowCellValue("HocSinhId");
            int phanLoaiThuId = (int)this.GridView.GetFocusedRowCellValue("PhanLoaiThuId");
            this.cmbHocSinh.EditValue = hocSinhId;
            this.cmbPhanLoaiThu.EditValue = phanLoaiThuId;
        }

        protected void FrmTaoPhieuThu_Activated(object sender, EventArgs e)
        {
            FormMainFacade.SetFormCaption(this.FormKey);
        }

        private void FrmTaoPhieuThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.IsEditing = false;
        }

        private void btnLuuTao_Click(object sender, EventArgs e)
        {
            if (this.onSavePhieuThu())
            {
                this.resetForm();
                FormMainFacade.SetStatusCaption(this.FormKey, StatusCaptions.AddedAndAddingPhieuThuCaption);
                this.IsEditing = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (this.onSavePhieuThu())
            {
                this.Close();
                FormMainFacade.SetStatusCaption(this.FormKey, StatusCaptions.AddedPhieuThuCaption);
            }
        }

        private bool onSavePhieuThu()
        {
            if (!this.dxValidationProvider.Validate())
            {
                return false;
            }

            this.luuPhieuThu();

            if ((int)cmbPhanLoaiThu.EditValue == PhanLoaiThuConstant.PhanLoaiThuIdThuTienHocPhi)
            {
                this.updateSoTienTruyThuForBangThuTienNextMonths(this.dateNgay.DateTime, (int)this.cmbHocSinh.EditValue);
            }

            return true;
        }

        private void loadPhieuThu()
        {
            UnknownColumnViewTableAdapter unknownColumnViewTableAdapter = (UnknownColumnViewTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterUnknownColumnView);
            this.dateNgay.DateTime = this.PhieuThuRow.Ngay;
            this.txtSoTien.Value = this.PhieuThuRow.SoTien;

            if (!this.PhieuThuRow.IsMaPhieuNull())
            {
                this.txtMaPhieu.Text = this.PhieuThuRow.MaPhieu;
            }

            if (!this.PhieuThuRow.IsGhiChuNull())
            {
                this.txtGhiChu.Text = this.PhieuThuRow.GhiChu;
            }

            if (!this.PhieuThuRow.IsHocSinhIdNull())
            {
                this.cmbHocSinh.EditValue = this.PhieuThuRow.HocSinhId;
                this.txtConLai.Text = String.Format("{0:n0}", unknownColumnViewTableAdapter.GetSoTienTruyThuByHocSinhId(this.PhieuThuRow.HocSinhId));
            }

            if (!this.PhieuThuRow.IsPhanLoaiThuIdNull())
            {
                this.cmbPhanLoaiThu.EditValue = this.PhieuThuRow.PhanLoaiThuId;
            }
        }

        private void luuPhieuThu()
        {
            if (this.IsEditing)
            {
                this.updatePhieuThu();
            }
            else
            {
                this.insertPhieuThu();
            }

            if (this.GridView != null)
            {
                HocSinhTableAdapter hocSinhTableAdapter = (HocSinhTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterHocSinh);
                BindingSource phieuThuBindingSource = this.GridView.GridControl.DataSource as BindingSource;
                PhieuThuService phieuThuService = new PhieuThuService();
                phieuThuBindingSource.DataSource = phieuThuService.LoadPhieuThu(hocSinhTableAdapter.GetData());
            }
        }

        private void insertPhieuThu()
        {
            DateTime ngay = this.dateNgay.DateTime;
            long soTien = (long)this.txtSoTien.Value;
            string maPhieu = this.txtMaPhieu.Text;
            string ghiChu = this.txtGhiChu.Text;
            int? hocSinhId = (int?)this.cmbHocSinh.EditValue;
            int? phanLoaiThuId = (int?)this.cmbPhanLoaiThu.EditValue;
            PhieuThuService phieuThuService = new PhieuThuService();
            phieuThuService.InsertPhieuThu(ngay, soTien, maPhieu, ghiChu, hocSinhId, phanLoaiThuId);
        }

        private void updatePhieuThu()
        {
            DateTime ngay = this.dateNgay.DateTime;
            long soTien = (long)this.txtSoTien.Value;
            string maPhieu = this.txtMaPhieu.Text;
            string ghiChu = this.txtGhiChu.Text;
            int? hocSinhId = (int?)this.cmbHocSinh.EditValue;
            int? phanLoaiThuId = (int?)this.cmbPhanLoaiThu.EditValue;
            PhieuThuService phieuThuService = new PhieuThuService();
            phieuThuService.UpdatePhieuThu(this.PhieuThuRow, ngay, soTien, maPhieu, ghiChu, hocSinhId, phanLoaiThuId);
        }

        private void resetForm()
        {
            this.txtSoTien.Value = 0;
            this.txtMaPhieu.Text = "";
            this.txtGhiChu.Text = "";
            this.txtConLai.Text = "";
            this.cmbHocSinh.EditValue = null;
        }

        private void cmbPhanLoaiThu_EditValueChanged(object sender, EventArgs e)
        {
            LayoutVisibility enableCmbHocSinhId = (int)cmbPhanLoaiThu.EditValue == PhanLoaiThuConstant.PhanLoaiThuIdThuTienHocPhi ? LayoutVisibility.Always : LayoutVisibility.Never;
            lciCmbHocSinh.Visibility = enableCmbHocSinhId;
            lciTxtConLai.Visibility = enableCmbHocSinhId;
        }
    }
}