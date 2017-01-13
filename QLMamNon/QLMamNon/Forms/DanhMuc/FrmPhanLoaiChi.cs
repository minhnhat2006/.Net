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
    public partial class FrmPhanLoaiChi : CRUDForm
    {
        public FrmPhanLoaiChi()
        {
            InitializeComponent();

            this.TablePrimaryKey = "PhanLoaiChiId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.PhanLoaiChi;
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