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

        #endregion

        public FrmPhieuChi()
        {
            InitializeComponent();

            this.TablePrimaryKey = "PhieuChiId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.PhieuChi;
            this.FormKey = AppForms.FormPhieuChi;

            this.loadPhieuChi();
            this.InitForm(this.btnThem, this.btnChinhSua, null, null, null, this.gvMain, this.phieuChiTableAdapter.Adapter, this.phieuChiRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable);
        }

        private void loadPhieuChi()
        {
            QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable table = this.phieuChiTableAdapter.GetData();

            foreach (QLMamNon.Dao.QLMamNonDs.PhieuChiRow row in table)
            {
                row.PhanLoaiChi = StaticDataUtil.GetPhanLoaiChiNameByPhieuChiId(this.phieuChiTableAdapter, row.PhieuChiId);
            }

            this.phieuChiRowBindingSource.DataSource = table;
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

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            this.onEditing();
        }
    }
}