using QLMamNon.Constant;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmTaiSan : CRUDForm
    {
        public FrmTaiSan()
        {
            InitializeComponent();

            this.TablePrimaryKey = "TaiSanId";
            this.DanhMuc = DanhMucConstant.QuanLyTaiSan;
            this.FormKey = AppForms.FormTaiSan;

            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormTaiSan();
            this.loadTaiSanData();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.viewTaiSanTableAdapter.Adapter, this.viewTaiSanRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.ViewTaiSanDataTable);
        }

        private void loadTaiSanData()
        {
            QLMamNon.Dao.QLMamNonDs.ViewTaiSanDataTable dataTable = this.viewTaiSanTableAdapter.GetData();
            this.viewTaiSanRowBindingSource.DataSource = dataTable;
            fillRelativeMainDataTable();
        }

        protected override void fillRelativeMainDataTable()
        {
            QLMamNon.Dao.QLMamNonDs.ViewTaiSanDataTable dataTable = (QLMamNon.Dao.QLMamNonDs.ViewTaiSanDataTable)this.viewTaiSanRowBindingSource.DataSource;

            foreach (QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow row in dataTable)
            {
                row.PhanLoaiTaiSan = StaticDataUtil.GetPhanLoaiChiNameByPhieuChiId(this.phieuChiTableAdapter, row.PhieuChiId);
            }
        }
    }
}