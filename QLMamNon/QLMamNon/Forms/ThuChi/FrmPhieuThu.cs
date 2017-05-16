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

            this._hocSinhTable = this.hocSinhTableAdapter.GetData();
            this.loadPhieuThu();
            this.InitForm(this.btnThem, this.btnChinhSua, null, null, null, this.gvMain, this.phieuThuTableAdapter.Adapter, this.phieuThuRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable);
        }

        private void loadPhieuThu()
        {
            QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable table = this.phieuThuTableAdapter.GetData();

            foreach (QLMamNon.Dao.QLMamNonDs.PhieuThuRow row in table)
            {
                if (!row.IsHocSinhIdNull())
                {
                    row.HocSinh = StaticDataUtil.getHocSinhFullNameByHocSinhId(this._hocSinhTable, row.HocSinhId);
                }
            }

            this.phieuThuRowBindingSource.DataSource = table;
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

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            this.onEditing();
        }
    }
}