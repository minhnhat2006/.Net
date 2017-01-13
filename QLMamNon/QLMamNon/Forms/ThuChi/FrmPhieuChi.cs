using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Forms.Resource;
using QLMamNon.UserControls;
using System;
using DevExpress.XtraGrid;
using QLMamNon.Facade;
using QLMamNon.Forms.ThuChi;
using System.Data;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmPhieuChi : CRUDForm
    {
        #region Properties

        private QLMamNon.Dao.QLMamNonDs.HocSinhDataTable _hocSinhTable;

        #endregion

        public FrmPhieuChi()
        {
            InitializeComponent();

            this.TablePrimaryKey = "PhieuChiId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.PhieuChi;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.phieuChiRowBindingSource.DataSource = this.phieuChiTableAdapter.GetData();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.phieuChiTableAdapter.Adapter, this.phieuChiRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable);
            this._hocSinhTable = this.hocSinhTableAdapter.GetData();
        }

        private void gvMain_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "HocSinhId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object hocSinhId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "HocSinhId");
                if (hocSinhId != null && DBNull.Value != hocSinhId)
                {
                    e.DisplayText = StaticDataUtil.GetHocSinhById(this._hocSinhTable, (int)hocSinhId);
                }
            }
        }

        protected override void onAdding()
        {
            FrmTaoPhieuChi frm = (FrmTaoPhieuChi)FormMainFacade.GetForm(AppForms.FormTaoPhieuChi);
            frm.GridView = this.GridViewMain;
            frm.IsEditing = false;

            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuChi);
            FormMainFacade.SetTrangThaiCaption(StatusCaptions.AddedCaption);
        }

        protected override void onEditing()
        {
            FrmTaoPhieuChi frm = (FrmTaoPhieuChi)FormMainFacade.GetForm(AppForms.FormTaoPhieuChi);
            frm.GridView = this.GridViewMain;
            frm.IsEditing = true;
            DataRowView rowView = this.phieuChiRowBindingSource.Current as DataRowView;
            frm.PhieuChiRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.PhieuChiRow;

            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuChi);
            FormMainFacade.SetTrangThaiCaption(StatusCaptions.ModifiedCaption);
        }
    }
}