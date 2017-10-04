using System;
using System.Collections.Generic;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Facade;
using QLMamNon.Service.Data;
using QLMamNon.UserControls;
using DataRow = System.Data.DataRow;
using DataTable = System.Data.DataTable;
using UserRow = QLMamNon.Dao.QLMamNonDs.UserRow;

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

        protected override void onSaving()
        {
            try
            {
                DataTable table = this.DataTable.GetChanges();

                if (table != null)
                {
                    UserPrivilegeTableAdapter userPrivilegeTableAdapter = (UserPrivilegeTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterUserPrivilege);
                    AuthenService authenService = new AuthenService();

                    foreach (DataRow row in table.Rows)
                    {
                        UserRow userRow = (UserRow)row;
                        authenService.UpdateUserPrivileges(userPrivilegeTableAdapter, userRow.UserId, (List<int>)userRow.UserPrivileges);
                    }

                    this.DataAdapter.Update(table);
                    this.DataTable.Merge(table);
                }

                this.DataTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                this.onSavingError(ex);
            }

            FormMainFacade.SetStatusCaption(this.FormKey, StatusCaptions.SavedCaption);
        }
    }
}