using System;
using QLMamNon.Constant;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmPhanLoaiChi : CRUDForm
    {
        public FrmPhanLoaiChi()
        {
            InitializeComponent();

            this.TablePrimaryKey = "PhanLoaiChiId";
            this.DanhMuc = DanhMucConstant.PhanLoaiChi;
            this.FormKey = AppForms.FormDanhMucPhanLoaiChi;

            this.phanLoaiChiRowBindingSource.DataSource = this.phanLoaiChiTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormPhanLoaiChi();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.phanLoaiChiTableAdapter.Adapter, this.phanLoaiChiRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.PhanLoaiChiDataTable);
        }

        private void FrmPhanLoaiChi_Load(object sender, EventArgs e)
        {

        }
    }
}