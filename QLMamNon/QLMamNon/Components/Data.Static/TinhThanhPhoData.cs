using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class TinhThanhPhoData : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.ThanhPhoTableAdapter tableAdapter;

        public TinhThanhPhoData(QLMamNon.Dao.QLMamNonDsTableAdapters.ThanhPhoTableAdapter tableAdapter)
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
