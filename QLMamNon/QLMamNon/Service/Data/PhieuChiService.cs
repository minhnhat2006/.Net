using System;
using System.Collections.Generic;
using ACG.Core.WinForm.Util;
using QLMamNon.Components.Data.Static;
using QLMamNon.Facade;
using PhieuChiRow = QLMamNon.Dao.QLMamNonDs.PhieuChiRow;
using PhieuChiTableAdapter = QLMamNon.Dao.QLMamNonDsTableAdapters.PhieuChiTableAdapter;


namespace QLMamNon.Service.Data
{
    public class PhieuChiService : BaseDataService
    {
        public QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable LoadPhieuChi(PhieuChiTableAdapter phieuChiTableAdapter)
        {
            QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable table = phieuChiTableAdapter.GetData();
            fillPhanLoaiChiForPhieuChiRows(phieuChiTableAdapter, table);

            return table;
        }

        public QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable LoadPhieuChiByDateRange(DateTime? fromDate, DateTime? toDate, List<int> phanLoaiChiIds)
        {
            PhieuChiTableAdapter phieuChiTableAdapter = (PhieuChiTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuChi);
            QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable table = phieuChiTableAdapter.GetDataByDateRange(fromDate, toDate, StringUtil.JoinWithCommas(phanLoaiChiIds));
            fillPhanLoaiChiForPhieuChiRows(phieuChiTableAdapter, table);

            return table;
        }

        public QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable LoadPhieuChiByDateRangeWithGroupPhanLoaiChi(DateTime? fromDate, DateTime? toDate, List<int> phanLoaiChiIds)
        {
            PhieuChiTableAdapter phieuChiTableAdapter = (PhieuChiTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuChi);
            QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable table = phieuChiTableAdapter.GetDataByByDateRangeWithGroupPhanLoaiChi(fromDate, toDate, StringUtil.JoinWithCommas(phanLoaiChiIds));

            return table;
        }

        private static void fillPhanLoaiChiForPhieuChiRows(PhieuChiTableAdapter phieuChiTableAdapter, QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable table)
        {
            foreach (QLMamNon.Dao.QLMamNonDs.PhieuChiRow row in table)
            {
                row.PhanLoaiChi = StaticDataUtil.GetMaPhanLoaiChiNameByPhieuChiId(phieuChiTableAdapter, row.PhieuChiId);
            }
        }

        public void InsertPhieuChi(PhieuChiTableAdapter phieuChiTableAdapter, DateTime ngay, long soTien, string maPhieu, string ghiChu, int phanLoaiChiId, string noiDung, double soLuong, double donGia)
        {
            phieuChiTableAdapter.Insert(maPhieu, ngay, soTien, ghiChu, phanLoaiChiId, DateTime.Now, noiDung, soLuong, donGia);
        }

        public void UpdatePhieuChi(PhieuChiTableAdapter phieuChiTableAdapter, PhieuChiRow phieuChiRow, DateTime ngay, long soTien, string maPhieu, string ghiChu, int phanLoaiChiId, string noiDung, double soLuong, double donGia)
        {
            phieuChiTableAdapter.Update(maPhieu, soTien, ghiChu, phanLoaiChiId, noiDung, soLuong, donGia, ngay, DateTime.Now, phieuChiRow.PhieuChiId, phieuChiRow.IsMaPhieuNull() ? null : phieuChiRow.MaPhieu,
                phieuChiRow.SoTien, phieuChiRow.PhanLoaiChiId, phieuChiRow.SoLuong, phieuChiRow.DonGia, phieuChiRow.Ngay, phieuChiRow.CreatedDate);
        }
    }
}
