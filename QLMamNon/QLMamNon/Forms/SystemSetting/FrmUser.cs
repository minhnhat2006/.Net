using System;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Facade;
using QLMamNon.UserControls;
using ACG.Core.WinForm.Util;
using System.Windows.Forms;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using DevExpress.XtraEditors;
using QLMamNon.Forms.HocSinh;

namespace QLMamNon.Forms.SystemSetting
{
    public partial class FrmUser : CRUDForm
    {
        public FrmUser()
        {
            InitializeComponent();

            this.TablePrimaryKey = "UserId";
            this.DanhMuc = DanhMucConstant.User;
            this.FormKey = AppForms.FormUser;

            UserTableAdapter userTableAdapter = (UserTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterUser);
            this.userRowBindingSource.DataSource = userTableAdapter.GetData();

            UCEditFormUser ucEditFormUser = new UCEditFormUser();
            ucEditFormUser.GridView = this.gvMain;
            this.gvMain.OptionsEditForm.CustomEditFormLayout = ucEditFormUser;
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, userTableAdapter.Adapter, this.userRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.UserDataTable);
        }
    }
}