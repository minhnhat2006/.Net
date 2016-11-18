using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
    }
}