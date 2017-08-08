using System;
using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Facade;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmBangTinhPhi : CRUDForm
    {
        public FrmBangTinhPhi()
        {
            InitializeComponent();

            this.TablePrimaryKey = "BangTinhPhiId";
            this.DanhMuc = DanhMucConstant.BangTinhPhi;
            this.FormKey = AppForms.FormBangTinhPhi;

            BangTinhPhiTableAdapter bangTinhPhiTableAdapter = (BangTinhPhiTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterBangTinhPhi);
            this.bangTinhPhiRowBindingSource.DataSource = bangTinhPhiTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormBangTinhPhi();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, bangTinhPhiTableAdapter.Adapter, this.bangTinhPhiRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.BangTinhPhiDataTable);
        }

        private void FrmBangTinhPhi_Load(object sender, EventArgs e)
        {

        }

        private void gvMain_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "KhoiId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                Object khoiIdObj = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "KhoiId");

                if (!DBNull.Value.Equals(khoiIdObj))
                {
                    int khoiId = (int)khoiIdObj;
                    e.DisplayText = StaticDataUtil.GetKhoiNameByKhoiId(khoiId);
                }
            }
            else if (e.Column.FieldName == "KhoanThuId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                Object khoanThuIdObj = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "KhoanThuId");

                if (!DBNull.Value.Equals(khoanThuIdObj))
                {
                    int khoanThuId = (int)khoanThuIdObj;
                    e.DisplayText = StaticDataUtil.GetKhoanThuNameByKhoanThuId(khoanThuId);
                }
            }
        }
    }
}