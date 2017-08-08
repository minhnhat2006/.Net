using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class PhanLoaiThu : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.PhanLoaiThuTableAdapter tableAdapter;

        public PhanLoaiThu(QLMamNon.Dao.QLMamNonDsTableAdapters.PhanLoaiThuTableAdapter tableAdapter)
        {
            this.tableAdapter = tableAdapter;
        }

        #region IStaticData Members

        public object Retrieve()
        {
            return tableAdapter.GetData();
        }

        #endregion
    }
}
