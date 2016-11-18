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
    public partial class FrmTinhThanhPho : CRUDForm
    {
        public FrmTinhThanhPho()
        {
            InitializeComponent();

            this.TablePrimaryKey = "ThanhPhoId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.TinhThanhPho;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.thanhPhoRowBindingSource.DataSource = this.thanhPhoTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormTinhThanhPho();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.thanhPhoTableAdapter.Adapter, this.thanhPhoRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.ThanhPhoDataTable);
        }
    }
}