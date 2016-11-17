using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACG.Core.WinForm.Mediator;
using ACG.Core.WinForm.Data.Static;

namespace QLMamNon.Facade
{
    public class StaticDataFacade
    {
        private static IStaticDataMap staticDataMap = new StaticDataMap();

        public static void Add(string key, IStaticData staticData)
        {
            staticDataMap.Add(key, staticData);
        }

        public static object Get(string key)
        {
            return staticDataMap.Get(key);
        }
    }
}
