using System;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using QLMamNon.Components.Data.Static;
using QLMamNon.Facade;
using QLMamNon.Service.Data;
using FormShowType = QLMamNon.Facade.FormMainFacade.FormShowType;
using UserDataTable = QLMamNon.Dao.QLMamNonDs.UserDataTable;
using UserPrivilegeDataTable = QLMamNon.Dao.QLMamNonDs.UserPrivilegeDataTable;

namespace QLMamNon.Forms.Authenticate
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenService authenService = new AuthenService();
            string username = txtUsername.Text;
            string password = PasswordUtil.GetMd5Hash(txtPassword.Text);
            UserDataTable userDataTable = authenService.GetUsersForLogin(this.userTableAdapter, username, password);

            if (userDataTable.Count == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng. Xin vui lòng thử lại.", "Lỗi đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UserPrivilegeDataTable upTable = authenService.LoadUserPrivileges(this.userPrivilegeTableAdapter, userDataTable[0].UserId);
                authenService.SetAuthenticatedUser(userDataTable[0], upTable);
                this.Close();

                showCurrentForm();
            }
        }

        private static void showCurrentForm()
        {
            String form = (String)StaticDataFacade.Get(StaticDataKeys.CurrentForm);
            FormShowType showType = (FormShowType)StaticDataFacade.Get(StaticDataKeys.CurrentFormShowType);

            if (FormShowType.Normal == showType)
            {
                FormMainFacade.ShowForm(form);
            }
            else
            {
                FormMainFacade.ShowDialog(form);
            }
        }
    }
}