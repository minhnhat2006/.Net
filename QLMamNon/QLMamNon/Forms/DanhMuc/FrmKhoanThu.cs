using System;
using QLMamNon.Constant;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmKhoanThu : CRUDForm
    {
        public FrmKhoanThu()
        {
            InitializeComponent();

            this.TablePrimaryKey = "KhoanThuId";
            this.DanhMuc = DanhMucConstant.KhoanThu;
            this.FormKey = AppForms.FormDanhMucKhoanThu;

            this.khoanThuRowBindingSource.DataSource = this.khoanThuTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormKhoanThu();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.khoanThuTableAdapter.Adapter, this.khoanThuRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.KhoanThuDataTable);
        }

        private void FrmKhoanThu_Load(object sender, EventArgs e)
        {

        }
    }
}