using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACG.Core.WinForm.Data.Static
{
    public class StaticDataMap : IStaticDataMap
    {
        #region Properties

        private IDictionary<string, object> keyDataMap = new Dictionary<string, object>();

        private IDictionary<string, IStaticData> keyFunctionMap = new Dictionary<string, IStaticData>();

        #endregion

        #region IStaticData Members

        public void Add(string key, IStaticData function)
        {
            if (this.keyFunctionMap.ContainsKey(key))
            {
                throw new Exception(String.Format("Key '{0}' already existed", key));
            }

            this.keyFunctionMap.Add(key, function);
        }

        public object Get(string key)
        {
            if (!keyDataMap.ContainsKey(key) || keyDataMap[key] == null)
            {
                IStaticData staticData = keyFunctionMap[key];
                object data = staticData.Retrieve();
                this.keyDataMap.Add(key, data);
            }

            return this.keyDataMap[key];
        }

        #endregion
    }
}
