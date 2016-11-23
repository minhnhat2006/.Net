using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Forms.Resource;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmLopHoc : CRUDForm
    {
        public FrmLopHoc()
        {
            InitializeComponent();

            this.TablePrimaryKey = "LopId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.LopHoc;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.lopRowBindingSource.DataSource = this.lopTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormLopHoc();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.lopTableAdapter.Adapter, this.lopRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.LopDataTable);
        }

        private void gvMain_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.Caption == "Khối" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                int lopId = (int)view.GetListSourceRowCellValue(e.ListSourceRowIndex, "LopId");
                e.DisplayText = StaticDataUtil.GetKhoiByLopId(this.lopKhoiTableAdapter, lopId);
            }
        }
    }
}