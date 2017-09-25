using System;
using System.Collections.Generic;
using ACG.Core.WinForm.Util;
using QLMamNon.Components.Data.Static;
using QLMamNon.Facade;
using HocSinhDataTable = QLMamNon.Dao.QLMamNonDs.HocSinhDataTable;
using PhieuThuDataTable = QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable;
using PhieuThuRow = QLMamNon.Dao.QLMamNonDs.PhieuThuRow;
using PhieuThuTableAdapter = QLMamNon.Dao.QLMamNonDsTableAdapters.PhieuThuTableAdapter;

namespace QLMamNon.Service.Data
{
    public class PhieuThuService : BaseDataService
    {
        public QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable LoadPhieuThu(HocSinhDataTable hocSinhTable)
        {
            PhieuThuTableAdapter phieuThuTableAdapter = (PhieuThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuThu);
            PhieuThuDataTable table = phieuThuTableAdapter.GetData();

            foreach (PhieuThuRow row in table)
            {
                if (!row.IsHocSinhIdNull())
                {
                    row.HocSinh = StaticDataUtil.GetHocSinhFullNameByHocSinhId(hocSinhTable, row.HocSinhId);
                }

                if (!row.IsPhanLoaiThuIdNull())
                {
                    row.PhanLoaiThu = StaticDataUtil.GetPhanLoaiThuById(row.PhanLoaiThuId);
                }
            }

            return table;
        }

        public void InsertPhieuThu(DateTime ngay, long soTien, string maPhieu, string ghiChu, int? hocSinhId, int? phanLoaiThuId)
        {
            PhieuThuTableAdapter phieuThuTableAdapter = (PhieuThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuThu);
            phieuThuTableAdapter.Insert(ngay, soTien, maPhieu, ghiChu, hocSinhId, DateTime.Now, phanLoaiThuId);
        }

        public void UpdatePhieuThu(PhieuThuRow phieuThuRow, DateTime ngay, long soTien, string maPhieu, string ghiChu, int? hocSinhId, int? phanLoaiThuId)
        {
            PhieuThuTableAdapter phieuThuTableAdapter = (PhieuThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuThu);
            int? origHocSinhId = phieuThuRow.IsHocSinhIdNull() ? (int?)null : phieuThuRow.HocSinhId;
            int? origPhanLoaiThuId = phieuThuRow.IsPhanLoaiThuIdNull() ? (int?)null : phieuThuRow.PhanLoaiThuId;
            phieuThuTableAdapter.Update(soTien, maPhieu, ghiChu, hocSinhId, phanLoaiThuId, ngay, DateTime.Now,
                phieuThuRow.PhieuThuId, phieuThuRow.SoTien, phieuThuRow.MaPhieu, origHocSinhId, origPhanLoaiThuId, phieuThuRow.Ngay, phieuThuRow.CreatedDate);
        }

        public QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable LoadPhieuThuByDateRangeWithGroupPhanLoaiThu(DateTime? fromDate, DateTime? toDate, List<int> phanLoaiThuIds)
        {
            PhieuThuTableAdapter phieuThuTableAdapter = (PhieuThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuThu);
            QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable table = phieuThuTableAdapter.GetDataByDateRangeWithGroupPhanLoaiThu(fromDate, toDate, StringUtil.JoinWithCommas(phanLoaiThuIds));

            foreach (PhieuThuRow phieuThuRow in table)
            {
                phieuThuRow.PhanLoaiThu = StaticDataUtil.GetPhanLoaiThuById(phieuThuRow.PhanLoaiThuId);
            }

            return table;
        }
    }
}
