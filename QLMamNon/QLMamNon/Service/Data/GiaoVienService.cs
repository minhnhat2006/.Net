using System;
using GiaoVienRow = QLMamNon.Dao.QLMamNonDs.GiaoVienRow;
using GiaoVienTableAdapter = QLMamNon.Dao.QLMamNonDsTableAdapters.GiaoVienTableAdapter;


namespace QLMamNon.Service.Data
{
    public class GiaoVienService : BaseDataService
    {
        public QLMamNon.Dao.QLMamNonDs.GiaoVienDataTable LoadGiaoVien(GiaoVienTableAdapter giaoVienTableAdapter, 
            int? tinhTPId, int? quanHuyenId, int? phuongXaId, DateTime? ngaySinh)
        {
            QLMamNon.Dao.QLMamNonDs.GiaoVienDataTable table = giaoVienTableAdapter.GetDataByParams(tinhTPId, quanHuyenId, phuongXaId, ngaySinh);
            this.evaluateLopInfoForGiaoVienTable(table);
            return table;
        }

        private void evaluateLopInfoForGiaoVienTable(QLMamNon.Dao.QLMamNonDs.GiaoVienDataTable giaoVienTable)
        {
            foreach (QLMamNon.Dao.QLMamNonDs.GiaoVienRow row in giaoVienTable)
            {
            }

            giaoVienTable.AcceptChanges();
        }
    }
}
