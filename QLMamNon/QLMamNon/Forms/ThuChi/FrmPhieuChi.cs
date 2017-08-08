using System;
using System.Data;
using System.Windows.Forms;
using QLMamNon.Constant;
using QLMamNon.Facade;
using QLMamNon.Forms.ThuChi;
using QLMamNon.Service.Data;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmPhieuChi : CRUDForm
    {
        #region Properties

        #endregion

        public FrmPhieuChi()
        {
            InitializeComponent();

            this.TablePrimaryKey = "PhieuChiId";
            this.DanhMuc = DanhMucConstant.PhieuChi;
            this.FormKey = AppForms.FormPhieuChi;

            this.loadPhieuChi();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, null, null, this.gvMain, this.phieuChiTableAdapter.Adapter, this.phieuChiRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable);
        }

        private void loadPhieuChi()
        {
            PhieuChiService phieuChiService = new PhieuChiService();
            this.phieuChiRowBindingSource.DataSource = phieuChiService.LoadPhieuChi(this.phieuChiTableAdapter);
        }

        protected override void onAdding()
        {
            FrmTaoPhieuChi frm = (FrmTaoPhieuChi)FormMainFacade.GetForm(AppForms.FormTaoPhieuChi);
            frm.GridView = this.GridViewMain;
            frm.IsEditing = false;

            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuChi);
            FormMainFacade.SetStatusCaption(this.FormKey, StatusCaptions.AddedCaption);
        }

        protected override void onEditing()
        {
            FrmTaoPhieuChi frm = (FrmTaoPhieuChi)FormMainFacade.GetForm(AppForms.FormTaoPhieuChi);
            frm.GridView = this.GridViewMain;
            frm.IsEditing = true;
            DataRowView rowView = this.phieuChiRowBindingSource.Current as DataRowView;
            frm.PhieuChiRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.PhieuChiRow;

            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuChi);
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
                int phieuChiId = (int)this.GridViewMain.GetFocusedRowCellValue("PhieuChiId");
                string maPhieu = (string)this.GridViewMain.GetFocusedRowCellValue("MaPhieu");
                int phanLoaiChiId = (int)this.GridViewMain.GetFocusedRowCellValue("PhanLoaiChiId");
                DateTime ngay = (DateTime)this.GridViewMain.GetFocusedRowCellValue("Ngay");
                long soTien = (long)this.GridViewMain.GetFocusedRowCellValue("SoTien");
                double soLuong = (double)this.GridViewMain.GetFocusedRowCellValue("SoLuong");
                double donGia = (double)this.GridViewMain.GetFocusedRowCellValue("DonGia");
                DateTime createdDate = (DateTime)this.GridViewMain.GetFocusedRowCellValue("CreatedDate");

                this.phieuChiTableAdapter.Delete(phieuChiId, maPhieu, soTien, phanLoaiChiId, soLuong, donGia, ngay, createdDate);
                this.loadPhieuChi();
                FormMainFacade.SetStatusCaption(this.FormKey, StatusCaptions.DeletedCaption);
            }
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            this.onEditing();
        }
    }
}