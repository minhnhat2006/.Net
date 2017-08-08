using System;
using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Constant;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmKhoanThuHangNam : CRUDForm
    {
        public FrmKhoanThuHangNam()
        {
            InitializeComponent();

            this.TablePrimaryKey = "KhoanThuHangNamId";
            this.DanhMuc = DanhMucConstant.KhoanThuHangNam;
            this.FormKey = AppForms.FormDanhMucKhoanThuHangNam;

            this.khoanThuHangNamRowBindingSource.DataSource = this.khoanThuHangNamTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormKhoanThuHangNam();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.khoanThuHangNamTableAdapter.Adapter, this.khoanThuHangNamRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamDataTable);
        }

        private void FrmKhoanThuHangNam_Load(object sender, EventArgs e)
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