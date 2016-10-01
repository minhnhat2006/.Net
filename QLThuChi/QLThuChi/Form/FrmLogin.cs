using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLThuChi.Form
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            QLThuChi.Dao.ThuChi.userDataTable userDataTable = new QLThuChi.Dao.ThuChi.userDataTable();
            string username = txtUsername.Text;
            string password = CommonUtil.GetMd5Hash(txtPassword.Text);
            int userCount = userTableAdapter.getUserByUsernameAndPassword(userDataTable, username, password);

            if (userCount == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng. Xin vui lòng thử lại.", "Lỗi đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                FrmHome home = new FrmHome();
                home.UserId = userDataTable[0].UserId;
                home.LoginFullName = userDataTable[0].FullName;
                home.LoginUserCode = userDataTable[0].Code;
                home.IsAdmin = userDataTable[0].IsAdmin;
                home.Show();
            }
        }
    }
}