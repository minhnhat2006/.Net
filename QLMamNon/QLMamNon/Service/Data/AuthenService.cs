using System;
using ACG.Core.WinForm.Util;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Entity;
using QLMamNon.Facade;
using UserPrivilegeDataTable = QLMamNon.Dao.QLMamNonDs.UserPrivilegeDataTable;
using UserPrivilegeRow = QLMamNon.Dao.QLMamNonDs.UserPrivilegeRow;
using UserRow = QLMamNon.Dao.QLMamNonDs.UserRow;
using UserTableAdapter = QLMamNon.Dao.QLMamNonDsTableAdapters.UserTableAdapter;

namespace QLMamNon.Service.Data
{
    public class AuthenService : BaseDataService
    {
        public bool IsAuthenticated()
        {
            bool isAuthenticated = false;

            if (StaticDataFacade.Contains(StaticDataKeys.AuthenticatedData))
            {
                isAuthenticated = true;
            }

            return isAuthenticated;
        }

        public void SetAuthenticatedUser(UserRow user, UserPrivilegeDataTable table)
        {
            StaticDataFacade.Remove(StaticDataKeys.AuthenticatedData);
            StaticDataFacade.Add(StaticDataKeys.AuthenticatedData, new AuthenticatedEntity(user, table));
        }

        public bool CanAccess(String formKey, UserPrivilegeDataTable table)
        {
            if (!FormPrivilegeConstant.FormKeyToPrivilegeId.ContainsKey(formKey))
            {
                return true;
            }

            int privilegeId = FormPrivilegeConstant.FormKeyToPrivilegeId[formKey];

            return CanAccess(privilegeId, table);
        }

        public bool CanAccess(int privilegeId, UserPrivilegeDataTable table)
        {
            bool canAccess = false;

            if (table != null)
            {
                UserPrivilegeRow[] rows = table.Select(String.Format("PrivilegeId={0}", privilegeId)) as UserPrivilegeRow[];

                if (!ArrayUtil.IsEmpty(rows))
                {
                    canAccess = rows[0].Value;
                }
            }

            return canAccess;
        }

        public QLMamNon.Dao.QLMamNonDs.UserDataTable GetUsersForLogin(UserTableAdapter userTableAdapter,
            string userName, string password)
        {
            QLMamNon.Dao.QLMamNonDs.UserDataTable table = userTableAdapter.GetDataForLogin(userName, password);
            return table;
        }

        public QLMamNon.Dao.QLMamNonDs.UserDataTable LoadUsers(UserTableAdapter userTableAdapter,
            int? tinhTPId, int? quanHuyenId, int? phuongXaId, DateTime? ngaySinh)
        {
            QLMamNon.Dao.QLMamNonDs.UserDataTable table = userTableAdapter.GetData();
            return table;
        }

        public QLMamNon.Dao.QLMamNonDs.UserPrivilegeDataTable LoadUserPrivileges(UserPrivilegeTableAdapter userPrivilegeTableAdapter,
            int uerId)
        {
            QLMamNon.Dao.QLMamNonDs.UserPrivilegeDataTable table = userPrivilegeTableAdapter.GetDataByUserId(uerId);
            return table;
        }
    }
}
