using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class TruongData : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.TruongTableAdapter tableAdapter;

        public TruongData(QLMamNon.Dao.QLMamNonDsTableAdapters.TruongTableAdapter tableAdapter)
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
