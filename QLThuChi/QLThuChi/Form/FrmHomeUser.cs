using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;

namespace QLThuChi
{
    public partial class FrmHome
    {
        #region User

        private bool IsCurrentUserAddingNew
        {
            get
            {
                if (this.userBindingSource.Current != null)
                {
                    QLThuChi.Dao.ThuChi.userRow row = (this.userBindingSource.Current as DataRowView).Row as QLThuChi.Dao.ThuChi.userRow;
                    return row.RowState == DataRowState.Detached;
                }

                return false;
            }
        }

        private bool IsProcessChangingCurrentUserRow { get; set; }

        private void onUserRowUpdated(object sender, MySqlRowUpdatedEventArgs e)
        {
            // Conditionally execute this code block on inserts only. 
            if (e.StatementType == StatementType.Insert)
            {
                MySqlCommand cmdNewID = new MySqlCommand("SELECT @@IDENTITY", this.userTableAdapter.Connection);
                // Retrieve the Autonumber and store it in the CategoryID column.
                e.Row["UserId"] = cmdNewID.ExecuteScalar();
                e.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        private void iUserTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isUserTab())
            {
                this.gridView3.OptionsView.ShowAutoFilterRow = !this.gridView3.OptionsView.ShowAutoFilterRow;
            }
        }

        private void HuyUser()
        {
            if (this.isUserTab())
            {
                if (this.IsCurrentUserAddingNew)
                {
                    this.IsProcessChangingCurrentUserRow = false;
                    this.userBindingSource.RemoveCurrent();
                    this.IsProcessChangingCurrentUserRow = true;
                }

                this.thuChi.user.RejectChanges();
                this.thuChi.user.AcceptChanges();

                this.iUserXoa.Enabled = true;
                this.gcUser.Enabled = true;
                this.dxErrorProvider1.ClearErrors();
            }
        }

        private void iUserHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.HuyUser();
        }

        private void iUserThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isUserTab() && !this.IsCurrentUserAddingNew)
            {
                DataRowView rowView = (DataRowView)this.userBindingSource.AddNew();
                QLThuChi.Dao.ThuChi.userRow row = rowView.Row as QLThuChi.Dao.ThuChi.userRow;
                row.FullName = "";
                row.Code = "";
                row.Password = "";

                this.iUserXoa.Enabled = false;
                this.gcUser.Enabled = false;
            }
        }

        private bool ValidateUserFields()
        {
            bool isFullName = Validate_EmptyStringRule(txtUserFullname);
            bool isCode = Validate_EmptyStringRule(txtUserCode);
            return isFullName && isCode;
        }

        private void iUserXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.userBindingSource.Current == null)
            {
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa Người dùng này không ?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (this.IsCurrentUserAddingNew)
                {
                    this.iUserHuy_ItemClick(sender, e);
                }
                else
                {
                    this.IsProcessChangingCurrentUserRow = false;
                    this.userBindingSource.RemoveCurrent();
                    this.userBindingSource.EndEdit();
                    this.thuChi.user.GetChanges();
                    this.userTableAdapter.Update(this.thuChi.user);
                    this.thuChi.user.AcceptChanges();
                    this.IsProcessChangingCurrentUserRow = true;
                }
            }
        }

        private void LuuUser(object sender, ItemClickEventArgs e)
        {
            if (this.isUserTab() && this.userBindingSource.Current != null)
            {
                if (this.ValidateUserFields())
                {
                    QLThuChi.Dao.ThuChi.userRow row = (QLThuChi.Dao.ThuChi.userRow)((DataRowView)this.userBindingSource.Current).Row;

                    if (this.txtUserPassword.Text != "")
                    {
                        row.Password = CommonUtil.GetMd5Hash(this.txtUserPassword.Text.Trim());
                    }

                    this.userBindingSource.EndEdit();
                    this.thuChi.user.GetChanges();
                    this.userTableAdapter.Update(this.thuChi.user);
                    this.thuChi.user.AcceptChanges();

                    this.iUserXoa.Enabled = true;
                    this.gcUser.Enabled = true;
                }
            }
            else if (this.userBindingSource.Current == null)
            {
                var confirmResult = MessageBox.Show("Không có Nhân viên nào trong danh sách hiện tại. Bạn có tạo một Nhân viên mới không ?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    this.iUserThem_ItemClick(sender, e);
                }
            }
        }

        #endregion
    }
}
