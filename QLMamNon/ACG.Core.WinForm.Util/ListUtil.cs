using System;
using System.Collections.Generic;
using System.Collections;

namespace ACG.Core.WinForm.Util
{
    public class ListUtil
    {
        public static bool IsEmpty(ICollection list)
        {
            return list == null || list.Count == 0;
        }
    }
}
