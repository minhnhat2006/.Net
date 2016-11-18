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
using MySql.Data.MySqlClient;
using QLMamNon.UserControls;
using QLMamNon.Facade;
using DevExpress.XtraGrid;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmTruongHoc : CRUDForm
    {
        public FrmTruongHoc()
        {
            InitializeComponent();

            this.TablePrimaryKey = "TruongId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.TruongHoc;
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