using System;
using ACG.Core.WinForm.Util;

namespace QLMamNon.UserControls
{
    public partial class UCEditFormUser : UCCRUDBase
    {
        public UCEditFormUser()
        {
            InitializeComponent();
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            this.GridView.SetFocusedRowCellValue("Password", PasswordUtil.GetMd5Hash(txtPassword.Text));
        }
    }
}
