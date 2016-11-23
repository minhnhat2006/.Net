using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ACG.Core.WinForm.Util
{
    public class IntUtil
    {
        public static int? stringToInt(string value)
        {
            int intValue = 0;

            if (!int.TryParse(value, out intValue))
            {
                return null;
            }

            return intValue;
        }
    }
}
