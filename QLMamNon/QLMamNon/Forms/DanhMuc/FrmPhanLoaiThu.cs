using System;
using QLMamNon.Constant;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmPhanLoaiThu : CRUDForm
    {
        public FrmPhanLoaiThu()
        {
            InitializeComponent();

            this.TablePrimaryKey = "PhanLoaiThuId";
            this.DanhMuc = DanhMucConstant.PhanLoaiThu;
            this.FormKey = AppForms.FormDanhMucPhanLoaiThu;

            this.phanLoaiThuRowBindingSource.DataSource = this.phanLoaiThuTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormPhanLoaiThu();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.phanLoaiThuTableAdapter.Adapter, this.phanLoaiThuRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.PhanLoaiThuDataTable);
        }

        private void FrmPhanLoaiThu_Load(object sender, EventArgs e)
        {

        }
    }
}