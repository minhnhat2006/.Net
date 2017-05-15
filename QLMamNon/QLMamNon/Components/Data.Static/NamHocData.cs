using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Data.Static;
using QLMamNon.Entity.Form;

namespace QLMamNon.Components.Data.Static
{
    public class NamHocData : IStaticData
    {
        #region IStaticData Members

        public object Retrieve()
        {
            List<NamHoc> namHocList = new List<NamHoc>();

            for (int i = 2010; i < 2049; i++)
            {
                namHocList.Add(new NamHoc(i, i + 1));
            }

            return namHocList;
        }

        #endregion
    }
}
