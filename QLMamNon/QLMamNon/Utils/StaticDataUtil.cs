
using System;
using System.Data;
using QLMamNon.Constant;
namespace QLMamNon
{
    public static class StaticDataUtil
    {
        public static string GetThanhPhoById(QLMamNon.Dao.QLMamNonDs.ThanhPhoDataTable table, Int32 id)
        {
            if (id < 0)
            {
                return CommonConstant.EMPTY;
            }

            DataRow[] rows = table.Select(String.Format("ThanhPhoId={0}", id));
            if (rows != null && rows.Length > 0)
            {
                return rows[0]["Name"] as String;
            }

            return CommonConstant.EMPTY;
        }

        public static string GetQuanHuyenById(QLMamNon.Dao.QLMamNonDs.QuanHuyenDataTable table, Int32 id)
        {
            if (id < 0)
            {
                return CommonConstant.EMPTY;
            }

            DataRow[] rows = table.Select(String.Format("QuanHuyenId={0}", id));
            if (rows != null && rows.Length > 0)
            {
                return rows[0]["Name"] as String;
            }

            return CommonConstant.EMPTY;
        }

        public static string GetPhuongXaById(QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable table, Int32 id)
        {
            if (id < 0)
            {
                return CommonConstant.EMPTY;
            }

            DataRow[] rows = table.Select(String.Format("PhuongXaId={0}", id));
            if (rows != null && rows.Length > 0)
            {
                return rows[0]["Name"] as String;
            }

            return CommonConstant.EMPTY;
        }
    }
}
