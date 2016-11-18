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
    public partial class FrmKhoiHoc : CRUDForm
    {
        public FrmKhoiHoc()
        {
            InitializeComponent();

            this.TablePrimaryKey = "KhoiId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.KhoiHoc;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.khoiRowBindingSource.DataSource = this.khoiTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormKhoiHoc();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.khoiTableAdapter.Adapter, this.khoiRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.KhoiDataTable);
        }
    }
}