using UserPrivilegeDataTable = QLMamNon.Dao.QLMamNonDs.UserPrivilegeDataTable;
using UserRow = QLMamNon.Dao.QLMamNonDs.UserRow;

namespace QLMamNon.Entity
{
    public class AuthenticatedEntity
    {
        public AuthenticatedEntity(UserRow user, UserPrivilegeDataTable table)
        {
            this.User = user;
            this.UserPrivilegeTable = table;
        }

        public UserRow User { get; set; }

        public UserPrivilegeDataTable UserPrivilegeTable { get; set; }
    }
}
