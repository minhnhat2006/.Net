using System;
using System.Data;
using System.Windows.Forms;
using QLMamNon.Constant;
using QLMamNon.Facade;
using QLMamNon.Forms.ThuChi;
using QLMamNon.Service.Data;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmPhieuThu : CRUDForm
    {
        #region Properties

        private QLMamNon.Dao.QLMamNonDs.HocSinhDataTable _hocSinhTable;

        #endregion

        public FrmPhieuThu()
        {
            InitializeComponent();

            this.TablePrimaryKey = "PhieuThuId";
            this.DanhMuc = DanhMucConstant.PhieuThu;
            this.FormKey = AppForms.FormPhieuThu;

            this._hocSinhTable = this.hocSinhTableAdapter.GetData();
            this.loadPhieuThu();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, null, null, this.gvMain, this.phieuThuTableAdapter.Adapter, this.phieuThuRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable);
        }

        private void loadPhieuThu()
        {
            PhieuThuService phieuThuService = new PhieuThuService();
            this.phieuThuRowBindingSource.DataSource = phieuThuService.LoadPhieuThu(this._hocSinhTable);
        }

        protected override void onAdding()
        {
            FrmTaoPhieuThu frm = (FrmTaoPhieuThu)FormMainFacade.GetForm(AppForms.FormTaoPhieuThu);
            frm.GridView = this.GridViewMain;
            frm.IsEditing = false;

            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuThu);
            FormMainFacade.SetStatusCaption(this.FormKey, StatusCaptions.AddedCaption);
        }

        protected override void onEditing()
        {
            FrmTaoPhieuThu frm = (FrmTaoPhieuThu)FormMainFacade.GetForm(AppForms.FormTaoPhieuThu);
            frm.GridView = this.GridViewMain;
            frm.IsEditing = true;
            DataRowView rowView = this.phieuThuRowBindingSource.Current as DataRowView;
            frm.PhieuThuRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.PhieuThuRow;

            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuThu);
            FormMainFacade.SetStatusCaption(this.FormKey, StatusCaptions.ModifiedCaption);
        }

        protected override void onDeleting()
        {
            if (this.GridViewMain.FocusedRowHandle < 0)
            {
                return;
            }

            var confirmResult = System.Windows.Forms.MessageBox.Show(String.Format("Bạn có chắc muốn xóa {0} được chọn không?", this.DanhMuc), String.Format("Xóa {0}", this.DanhMuc),
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                int phieuThuId = (int)this.GridViewMain.GetFocusedRowCellValue("PhieuThuId");
                DateTime ngay = (DateTime)this.GridViewMain.GetFocusedRowCellValue("Ngay");
                long soTien = (long)this.GridViewMain.GetFocusedRowCellValue("SoTien");
                string maPhieu = (string)this.GridViewMain.GetFocusedRowCellValue("MaPhieu");
                int hocSinhId = (int)this.GridViewMain.GetFocusedRowCellValue("HocSinhId");
                DateTime createdDate = (DateTime)this.GridViewMain.GetFocusedRowCellValue("CreatedDate");
                int phanLoaiThuId = (int)this.GridViewMain.GetFocusedRowCellValue("PhanLoaiThuId");

                this.phieuThuTableAdapter.Delete(phieuThuId, soTien, maPhieu, hocSinhId, phanLoaiThuId, ngay, createdDate);
                this.loadPhieuThu();
                FormMainFacade.SetStatusCaption(this.FormKey, StatusCaptions.DeletedCaption);
            }
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            this.onEditing();
        }
    }
}