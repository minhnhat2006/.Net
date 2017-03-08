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
    public partial class FrmKhoanThu : CRUDForm
    {
        public FrmKhoanThu()
        {
            InitializeComponent();

            this.TablePrimaryKey = "KhoanThuId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.KhoanThu;
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