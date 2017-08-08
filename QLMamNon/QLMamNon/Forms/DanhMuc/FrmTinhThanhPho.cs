using QLMamNon.Constant;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmTinhThanhPho : CRUDForm
    {
        public FrmTinhThanhPho()
        {
            InitializeComponent();

            this.TablePrimaryKey = "ThanhPhoId";
            this.DanhMuc = DanhMucConstant.TinhThanhPho;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.thanhPhoRowBindingSource.DataSource = this.thanhPhoTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormTinhThanhPho();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.thanhPhoTableAdapter.Adapter, this.thanhPhoRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.ThanhPhoDataTable);
        }
    }
}