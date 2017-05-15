using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class PhanLoaiChi : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.PhanLoaiChiTableAdapter tableAdapter;

        public PhanLoaiChi(QLMamNon.Dao.QLMamNonDsTableAdapters.PhanLoaiChiTableAdapter tableAdapter)
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
