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

        public static void Add(string key, object staticData)
        {
            staticDataMap.Add(key, staticData);
        }

        public static void Save(string key, object staticData)
        {
            staticDataMap.Save(key, staticData);
        }

        public static void Remove(string key)
        {
            staticDataMap.Remove(key);
        }

        public static object Get(string key)
        {
            return staticDataMap.Get(key);
        }

        public static bool Contains(string key)
        {
            return staticDataMap.Contains(key);
        }
    }
}
