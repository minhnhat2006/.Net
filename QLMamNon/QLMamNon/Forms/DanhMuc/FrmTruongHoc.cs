using System;
using QLMamNon.Constant;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmTruongHoc : CRUDForm
    {
        public FrmTruongHoc()
        {
            InitializeComponent();

            this.TablePrimaryKey = "TruongId";
            this.DanhMuc = DanhMucConstant.TruongHoc;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.truongRowBindingSource.DataSource = this.truongTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormTruongHoc();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.truongTableAdapter.Adapter, this.truongRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.TruongDataTable);
        }

        private void FrmTruongHoc_Load(object sender, EventArgs e)
        {

        }
    }
}