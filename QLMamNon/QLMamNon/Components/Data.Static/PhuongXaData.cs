using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class PhuongXaData : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.PhuongXaTableAdapter tableAdapter;

        public PhuongXaData(QLMamNon.Dao.QLMamNonDsTableAdapters.PhuongXaTableAdapter tableAdapter)
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
