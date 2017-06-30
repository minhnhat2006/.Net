using System;
using System.Collections.Generic;
using QLMamNon.Dao.QLMamNonDsTableAdapters;

namespace QLMamNon
{
    public static class ThongTinHocSinhUtil
    {
        public static void EvaluateLopInfoForHocSinhTable(HocSinhLopTableAdapter hocSinhLopTableAdapter, QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable)
        {
            List<int> hocSinhIds = new List<int>(hocSinhTable.Rows.Count);
            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow row in hocSinhTable)
            {
                hocSinhIds.Add(row.HocSinhId);
            }

            Dictionary<int, QLMamNon.Dao.QLMamNonDs.HocSinhLopRow> hocSinhIdsToHocSinhLops = StaticDataUtil.GetHocSinhLopsByHocSinhIds(hocSinhLopTableAdapter, hocSinhIds, DateTime.Now);
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.LopRow> hocSinhIdsToLops = StaticDataUtil.GetLopsByHocSinhIds(hocSinhLopTableAdapter, hocSinhIds, DateTime.Now);

            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow row in hocSinhTable)
            {
                if (hocSinhIdsToLops.ContainsKey(row.HocSinhId))
                {
                    QLMamNon.Dao.QLMamNonDs.LopRow lop = hocSinhIdsToLops[row.HocSinhId];
                    row.LopDangHoc = lop.Name;
                }

                if (hocSinhIdsToHocSinhLops.ContainsKey(row.HocSinhId))
                {
                    QLMamNon.Dao.QLMamNonDs.HocSinhLopRow hocSinhLop = hocSinhIdsToHocSinhLops[row.HocSinhId];
                    row.NgayVaoLop = hocSinhLop.DateJoin;
                }
            }

            hocSinhTable.AcceptChanges();
        }
    }
}
