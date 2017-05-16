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
            this.hocSinhRowBindingSource.DataSource = this.hocSinhTableAdapter.GetData();

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
            this.cmbHocSinh.EditValue = hocSinhId;
        }

        protected void FrmTaoPhieuThu_Activated(object sender, EventArgs e)
        {
            FormMainFacade.SetManHinhCaption(this.FormKey);
        }

        private void FrmTaoPhieuThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.IsEditing = false;
        }

        private void btnLuuTao_Click(object sender, EventArgs e)
        {
            if (!this.dxValidationProvider.Validate())
            {
                return;
            }

            this.luuPhieuThu();
            this.resetForm();
            FormMainFacade.SetTrangThaiCaption(StatusCaptions.AddedAndAddingPhieuThuCaption);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!this.dxValidationProvider.Validate())
            {
                return;
            }

            this.btnLuuTao_Click(sender, e);
            this.Close();
            FormMainFacade.SetTrangThaiCaption(StatusCaptions.AddedPhieuThuCaption);
        }

        private void loadPhieuThu()
        {
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
                this.txtConLai.Text = String.Format("{0:n0}", this.unknownColumnViewTableAdapter.GetSoTienTruyThuByHocSinhId(this.PhieuThuRow.HocSinhId));
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
                BindingSource phieuThuBindingSource = this.GridView.GridControl.DataSource as BindingSource;
                phieuThuBindingSource.DataSource = this.phieuThuTableAdapter.GetData();
            }
        }

        private void insertPhieuThu()
        {
            DateTime ngay = this.dateNgay.DateTime;
            long soTien = (long)this.txtSoTien.Value;
            string maPhieu = this.txtMaPhieu.Text;
            string ghiChu = this.txtGhiChu.Text;
            int? hocSinhId = (int?)this.cmbHocSinh.EditValue;
            this.phieuThuTableAdapter.Insert(ngay, soTien, maPhieu, ghiChu, hocSinhId, DateTime.Now);
        }

        private void updatePhieuThu()
        {
            DateTime ngay = this.dateNgay.DateTime;
            long soTien = (long)this.txtSoTien.Value;
            string maPhieu = this.txtMaPhieu.Text;
            string ghiChu = this.txtGhiChu.Text;
            int? hocSinhId = (int?)this.cmbHocSinh.EditValue;
            int? origHocSinhId = this.PhieuThuRow.IsHocSinhIdNull() ? (int?)null : this.PhieuThuRow.HocSinhId;
            this.phieuThuTableAdapter.Update(ngay, soTien, maPhieu, ghiChu, hocSinhId, DateTime.Now, this.PhieuThuRow.PhieuThuId, this.PhieuThuRow.Ngay, this.PhieuThuRow.SoTien, this.PhieuThuRow.MaPhieu, origHocSinhId, this.PhieuThuRow.CreatedDate);
        }

        private void resetForm()
        {
            this.txtSoTien.Value = 0;
            this.txtMaPhieu.Text = "";
            this.txtGhiChu.Text = "";
            this.txtConLai.Text = "";
            this.cmbHocSinh.EditValue = null;
        }
    }
}