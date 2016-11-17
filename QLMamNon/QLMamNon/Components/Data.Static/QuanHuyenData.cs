using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Components.Data.Static
{
    public class QuanHuyenData : IStaticData
    {
        private QLMamNon.Dao.QLMamNonDsTableAdapters.QuanHuyenTableAdapter tableAdapter;

        public QuanHuyenData(QLMamNon.Dao.QLMamNonDsTableAdapters.QuanHuyenTableAdapter tableAdapter)
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
