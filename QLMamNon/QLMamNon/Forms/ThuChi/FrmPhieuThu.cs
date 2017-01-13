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
    public partial class FrmPhieuThu : CRUDForm
    {
        #region Properties

        private QLMamNon.Dao.QLMamNonDs.HocSinhDataTable _hocSinhTable;

        #endregion

        public FrmPhieuThu()
        {
            InitializeComponent();

            this.TablePrimaryKey = "PhieuThuId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.PhieuThu;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.phieuThuRowBindingSource.DataSource = this.phieuThuTableAdapter.GetData();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.phieuThuTableAdapter.Adapter, this.phieuThuRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable);
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
            FrmTaoPhieuThu frm = (FrmTaoPhieuThu)FormMainFacade.GetForm(AppForms.FormTaoPhieuThu);
            frm.GridView = this.GridViewMain;
            frm.IsEditing = false;

            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuThu);
            FormMainFacade.SetTrangThaiCaption(StatusCaptions.AddedCaption);
        }

        protected override void onEditing()
        {
            FrmTaoPhieuThu frm = (FrmTaoPhieuThu)FormMainFacade.GetForm(AppForms.FormTaoPhieuThu);
            frm.GridView = this.GridViewMain;
            frm.IsEditing = true;
            DataRowView rowView = this.phieuThuRowBindingSource.Current as DataRowView;
            frm.PhieuThuRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.PhieuThuRow;

            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuThu);
            FormMainFacade.SetTrangThaiCaption(StatusCaptions.ModifiedCaption);
        }
    }
}