using System;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Components.Data.Static;
using QLMamNon.Facade;
using System.Data;
using QLMamNon.Forms.Resource;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmTaoPhieuChi : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        protected string FormKey { get; set; }

        public GridView GridView { get; set; }

        public bool IsEditing { get; set; }

        public QLMamNon.Dao.QLMamNonDs.PhieuChiRow PhieuChiRow { get; set; }

        #endregion

        public FrmTaoPhieuChi()
        {
            this.FormKey = AppForms.FormTaoPhieuChi;
            InitializeComponent();
        }

        private void FrmTaoPhieuChi_Load(object sender, EventArgs e)
        {
            this.phanLoaiChiRowBindingSource.DataSource = this.phanLoaiChiTableAdapter.GetData();

            if (this.IsEditing)
            {
                this.loadPhieuChi();
            }
            else
            {
                this.resetForm();
            }
        }

        private void FrmTaoPhieuChi_Enter(object sender, EventArgs e)
        {
            int phanLoaiChiId = (int)this.GridView.GetFocusedRowCellValue("PhanLoaiChiId");
            this.cmbPhanLoaiChi.EditValue = phanLoaiChiId;
        }

        protected void FrmTaoPhieuChi_Activated(object sender, EventArgs e)
        {
            FormMainFacade.SetManHinhCaption(this.FormKey);
        }

        private void FrmTaoPhieuChi_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.IsEditing = false;
        }

        private void btnLuuTao_Click(object sender, EventArgs e)
        {
            if (!this.dxValidationProvider.Validate())
            {
                return;
            }

            this.luuPhieuChi();
            this.resetForm();
            FormMainFacade.SetTrangThaiCaption(StatusCaptions.AddedAndAddingPhieuChiCaption);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!this.dxValidationProvider.Validate())
            {
                return;
            }

            this.btnLuuTao_Click(sender, e);
            this.Close();
            FormMainFacade.SetTrangThaiCaption(StatusCaptions.AddedPhieuChiCaption);
        }

        private void loadPhieuChi()
        {
            this.dateNgay.DateTime = this.PhieuChiRow.Ngay;
            this.txtSoTien.Value = this.PhieuChiRow.SoTien;
            this.txtMaPhieu.Text = this.PhieuChiRow.MaPhieu;

            if (!this.PhieuChiRow.IsGhiChuNull())
            {
                this.txtGhiChu.Text = this.PhieuChiRow.GhiChu;
            }


            this.cmbPhanLoaiChi.EditValue = this.PhieuChiRow.PhanLoaiChiId;
        }

        private void luuPhieuChi()
        {
            if (this.IsEditing)
            {
                this.updatePhieuChi();
            }
            else
            {
                this.insertPhieuChi();
            }

            if (this.GridView != null)
            {
                BindingSource phieuChiBindingSource = this.GridView.GridControl.DataSource as BindingSource;
                phieuChiBindingSource.DataSource = this.phieuChiTableAdapter.GetData();
            }
        }

        private void insertPhieuChi()
        {
            DateTime ngay = this.dateNgay.DateTime;
            long soTien = (long)this.txtSoTien.Value;
            string maPhieu = this.txtMaPhieu.Text;
            string ghiChu = this.txtGhiChu.Text;
            int phanLoaiChiId = (int)this.cmbPhanLoaiChi.EditValue;
            this.phieuChiTableAdapter.Insert(maPhieu, ngay, soTien, ghiChu, phanLoaiChiId, DateTime.Now);
        }

        private void updatePhieuChi()
        {
            DateTime ngay = this.dateNgay.DateTime;
            long soTien = (long)this.txtSoTien.Value;
            string maPhieu = this.txtMaPhieu.Text;
            string ghiChu = this.txtGhiChu.Text;
            int phanLoaiChiId = (int)this.cmbPhanLoaiChi.EditValue;
            this.phieuChiTableAdapter.Update(maPhieu, ngay, soTien, ghiChu, phanLoaiChiId, DateTime.Now, this.PhieuChiRow.PhieuChiId, this.PhieuChiRow.MaPhieu, this.PhieuChiRow.Ngay, this.PhieuChiRow.SoTien, this.PhieuChiRow.PhanLoaiChiId, this.PhieuChiRow.CreatedDate);
        }

        private void resetForm()
        {
            this.txtSoTien.Value = 0;
            this.txtMaPhieu.Text = "";
            this.txtGhiChu.Text = "";
            this.cmbPhanLoaiChi.EditValue = null;
        }
    }
}