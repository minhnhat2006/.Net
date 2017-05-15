using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;

namespace ACG.Core.WinForm.Util
{
    public class StringUtil
    {
        public static bool IsEmpty(string value)
        {
            return value == null || value == "";
        }

        public static String Join(IList list, string separator)
        {
            List<string> listStr = new List<string>();

            if (ListUtil.IsEmpty(list))
            {
                return "";
            }

            foreach (object item in list)
            {
                listStr.Add(String.Format("{0}", item));
            }

            return String.Join(separator, listStr);
        }
    }
}
