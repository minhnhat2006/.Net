using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class BangTinhPhi : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.BangTinhPhiTableAdapter tableAdapter;

        public BangTinhPhi(QLMamNon.Dao.QLMamNonDsTableAdapters.BangTinhPhiTableAdapter tableAdapter)
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
