using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class KhoiData : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.KhoiTableAdapter tableAdapter;

        public KhoiData(QLMamNon.Dao.QLMamNonDsTableAdapters.KhoiTableAdapter tableAdapter)
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
