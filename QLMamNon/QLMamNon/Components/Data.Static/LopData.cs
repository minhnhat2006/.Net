using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class LopData : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.LopTableAdapter tableAdapter;

        public LopData(QLMamNon.Dao.QLMamNonDsTableAdapters.LopTableAdapter tableAdapter)
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
