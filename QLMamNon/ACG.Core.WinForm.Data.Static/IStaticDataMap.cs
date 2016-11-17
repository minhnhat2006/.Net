using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACG.Core.WinForm.Data.Static
{
    public interface IStaticDataMap
    {
        void Add(string key, IStaticData function);

        object Get(string key);
    }
}
