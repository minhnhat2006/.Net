using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class KhoanThuData : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.KhoanThuTableAdapter tableAdapter;

        public KhoanThuData(QLMamNon.Dao.QLMamNonDsTableAdapters.KhoanThuTableAdapter tableAdapter)
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
