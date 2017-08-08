
using System;
using System.Data;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Facade;
using QLMamNon.Components.Data.Static;
using System.Collections.Generic;
using ACG.Core.WinForm.Util;
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

        public static int? GetTruongIdByKhoiId(KhoiTruongTableAdapter khoiTruongTableAdapter, Int32 khoiId)
        {
            if (khoiId < 0)
            {
                return null;
            }

            QLMamNon.Dao.QLMamNonDs.KhoiTruongDataTable table = khoiTruongTableAdapter.GetDataByKhoiId(khoiId);

            if (table != null && table.Rows.Count > 0)
            {
                QLMamNon.Dao.QLMamNonDs.KhoiTruongRow row = table[0];
                return row.TruongId;
            }

            return null;
        }

        public static QLMamNon.Dao.QLMamNonDs.KhoiTruongRow GetKhoiTruongByKhoiId(KhoiTruongTableAdapter khoiTruongTableAdapter, Int32 khoiId)
        {
            if (khoiId < 0)
            {
                return null;
            }

            QLMamNon.Dao.QLMamNonDs.KhoiTruongDataTable table = khoiTruongTableAdapter.GetDataByKhoiId(khoiId);

            if (table != null && table.Rows.Count > 0)
            {
                QLMamNon.Dao.QLMamNonDs.KhoiTruongRow row = table[0];
                return row;
            }

            return null;
        }

        public static string GetTruongNameByTruongId(Int32 truongId)
        {
            if (truongId > 0)
            {
                QLMamNon.Dao.QLMamNonDs.TruongDataTable truongTable = StaticDataFacade.Get(StaticDataKeys.TruongHoc) as QLMamNon.Dao.QLMamNonDs.TruongDataTable;
                QLMamNon.Dao.QLMamNonDs.TruongRow truongRow = truongTable.FindByTruongId(truongId);
                return truongRow.Name;
            }

            return CommonConstant.EMPTY;
        }

        public static string GetTruongByKhoiId(KhoiTruongTableAdapter khoiTruongTableAdapter, Int32 khoiId)
        {
            int? truongId = GetTruongIdByKhoiId(khoiTruongTableAdapter, khoiId);

            if (truongId != null)
            {
                QLMamNon.Dao.QLMamNonDs.TruongDataTable truongTable = StaticDataFacade.Get(StaticDataKeys.TruongHoc) as QLMamNon.Dao.QLMamNonDs.TruongDataTable;
                QLMamNon.Dao.QLMamNonDs.TruongRow truongRow = truongTable.FindByTruongId(truongId.Value);
                return truongRow.Name;
            }

            return CommonConstant.EMPTY;
        }

        public static int? GetKhoiIdByLopId(LopKhoiTableAdapter lopKhoiTableAdapter, Int32 lopId)
        {
            if (lopId < 0)
            {
                return null;
            }

            QLMamNon.Dao.QLMamNonDs.LopKhoiDataTable table = lopKhoiTableAdapter.GetDataByLopId(lopId);

            if (table != null && table.Rows.Count > 0)
            {
                QLMamNon.Dao.QLMamNonDs.LopKhoiRow row = table[0];
                return row.KhoiId;
            }

            return null;
        }

        public static string GetKhoiNameByKhoiId(Int32 khoiId)
        {
            if (khoiId < 0)
            {
                return CommonConstant.EMPTY;
            }

            QLMamNon.Dao.QLMamNonDs.KhoiDataTable khoiTable = StaticDataFacade.Get(StaticDataKeys.KhoiHoc) as QLMamNon.Dao.QLMamNonDs.KhoiDataTable;
            QLMamNon.Dao.QLMamNonDs.KhoiRow khoiRow = khoiTable.FindByKhoiId(khoiId);

            if (khoiRow != null)
            {
                return khoiRow.Name;
            }

            return CommonConstant.EMPTY;
        }

        public static string GetLopNameByLopId(Int32 lopId)
        {
            if (lopId < 0)
            {
                return CommonConstant.EMPTY;
            }

            QLMamNon.Dao.QLMamNonDs.LopDataTable lopTable = StaticDataFacade.Get(StaticDataKeys.LopHoc) as QLMamNon.Dao.QLMamNonDs.LopDataTable;
            QLMamNon.Dao.QLMamNonDs.LopRow lopRow = lopTable.FindByLopId(lopId);

            if (lopRow != null)
            {
                return lopRow.Name;
            }

            return CommonConstant.EMPTY;
        }

        public static string GetHocSinhById(QLMamNon.Dao.QLMamNonDs.HocSinhDataTable table, Int32 id)
        {
            if (id < 0)
            {
                return CommonConstant.EMPTY;
            }

            DataRow[] rows = table.Select(String.Format("HocSinhId={0}", id));
            if (rows != null && rows.Length > 0)
            {
                return String.Format("{0} {1}", (rows[0]["HoDem"] as String), (rows[0]["Ten"] as String));
            }

            return CommonConstant.EMPTY;
        }

        public static string GetKhoanThuNameByKhoanThuId(Int32 khoanThuId)
        {
            if (khoanThuId < 0)
            {
                return CommonConstant.EMPTY;
            }

            QLMamNon.Dao.QLMamNonDs.KhoanThuDataTable khoanThuTable = StaticDataFacade.Get(StaticDataKeys.KhoanThu) as QLMamNon.Dao.QLMamNonDs.KhoanThuDataTable;
            QLMamNon.Dao.QLMamNonDs.KhoanThuRow khoanThuRow = khoanThuTable.FindByKhoanThuId(khoanThuId);

            if (khoanThuRow != null)
            {
                return khoanThuRow.Ten;
            }

            return CommonConstant.EMPTY;
        }

        public static string GetHocSinhFullNameByHocSinhId(QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhDataTable, int hocSinhId)
        {
            if (hocSinhId < 0)
            {
                return CommonConstant.EMPTY;
            }

            QLMamNon.Dao.QLMamNonDs.HocSinhRow hocSinhRow = hocSinhDataTable.FindByHocSinhId(hocSinhId);

            if (hocSinhRow != null)
            {
                return hocSinhRow.HoTen;
            }

            return CommonConstant.EMPTY;
        }

        public static Dictionary<int, QLMamNon.Dao.QLMamNonDs.HocSinhLopRow> GetHocSinhLopsByHocSinhIds(List<int> hocSinhIds, DateTime ngay)
        {
            if (ListUtil.IsEmpty(hocSinhIds))
            {
                return null;
            }

            HocSinhLopTableAdapter hocSinhLopTableAdapter = (HocSinhLopTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterHocSinhLop);
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.HocSinhLopRow> hocSinhIdsToHocSinhLops = new Dictionary<int, QLMamNon.Dao.QLMamNonDs.HocSinhLopRow>();
            QLMamNon.Dao.QLMamNonDs.HocSinhLopDataTable table = hocSinhLopTableAdapter.GetHocSinhLopByHocSinhIdsAndNgay(StringUtil.Join(hocSinhIds, ","), ngay);

            if (!ListUtil.IsEmpty(table.Rows))
            {
                foreach (QLMamNon.Dao.QLMamNonDs.HocSinhLopRow row in table)
                {
                    hocSinhIdsToHocSinhLops.Add(row.HocSinhId, row);
                }
            }

            return hocSinhIdsToHocSinhLops;
        }

        public static Dictionary<int, QLMamNon.Dao.QLMamNonDs.LopRow> GetLopsByHocSinhIds(List<int> hocSinhIds, DateTime ngay)
        {
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.HocSinhLopRow> hocSinhIdsToLopIds = GetHocSinhLopsByHocSinhIds(hocSinhIds, ngay);
            QLMamNon.Dao.QLMamNonDs.LopDataTable lopTable = StaticDataFacade.Get(StaticDataKeys.LopHoc) as QLMamNon.Dao.QLMamNonDs.LopDataTable;
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.LopRow> hocSinhIdsToLopNames = new Dictionary<int, QLMamNon.Dao.QLMamNonDs.LopRow>();

            if (ListUtil.IsEmpty(hocSinhIdsToLopIds))
            {
                return hocSinhIdsToLopNames;
            }

            foreach (KeyValuePair<int, QLMamNon.Dao.QLMamNonDs.HocSinhLopRow> pair in hocSinhIdsToLopIds)
            {
                if (pair.Value == null)
                {
                    continue;
                }

                QLMamNon.Dao.QLMamNonDs.LopRow[] rows = lopTable.Select(String.Format("LopId={0}", pair.Value.LopId)) as QLMamNon.Dao.QLMamNonDs.LopRow[];
                if (!ArrayUtil.IsEmpty(rows))
                {
                    hocSinhIdsToLopNames.Add(pair.Key, rows[0]);
                }
            }

            return hocSinhIdsToLopNames;
        }

        public static string GetPhanLoaiChiNameByPhieuChiId(PhieuChiTableAdapter adapter, Int32 phieuChiId)
        {
            if (phieuChiId < 0)
            {
                return CommonConstant.EMPTY;
            }

            QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable phieChiTable = adapter.GetPhieuChiById(phieuChiId);

            if (ListUtil.IsEmpty(phieChiTable.Rows))
            {
                return CommonConstant.EMPTY;
            }

            QLMamNon.Dao.QLMamNonDs.PhieuChiRow phieChiRow = phieChiTable.Rows[0] as QLMamNon.Dao.QLMamNonDs.PhieuChiRow;

            if (phieChiRow != null)
            {
                QLMamNon.Dao.QLMamNonDs.PhanLoaiChiDataTable table = StaticDataFacade.Get(StaticDataKeys.PhanLoaiChi) as QLMamNon.Dao.QLMamNonDs.PhanLoaiChiDataTable;
                QLMamNon.Dao.QLMamNonDs.PhanLoaiChiRow[] rows = (QLMamNon.Dao.QLMamNonDs.PhanLoaiChiRow[])table.Select(String.Format("PhanLoaiChiId={0}", phieChiRow.PhanLoaiChiId));

                if (!ArrayUtil.IsEmpty(rows))
                {
                    return rows[0].DienGiai;
                }
            }

            return CommonConstant.EMPTY;
        }

        public static string GetMaPhanLoaiChiNameByPhieuChiId(PhieuChiTableAdapter adapter, Int32 phieuChiId)
        {
            if (phieuChiId < 0)
            {
                return CommonConstant.EMPTY;
            }

            QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable phieChiTable = adapter.GetPhieuChiById(phieuChiId);

            if (ListUtil.IsEmpty(phieChiTable.Rows))
            {
                return CommonConstant.EMPTY;
            }

            QLMamNon.Dao.QLMamNonDs.PhieuChiRow phieChiRow = phieChiTable.Rows[0] as QLMamNon.Dao.QLMamNonDs.PhieuChiRow;

            if (phieChiRow != null)
            {
                QLMamNon.Dao.QLMamNonDs.PhanLoaiChiDataTable table = StaticDataFacade.Get(StaticDataKeys.PhanLoaiChi) as QLMamNon.Dao.QLMamNonDs.PhanLoaiChiDataTable;
                QLMamNon.Dao.QLMamNonDs.PhanLoaiChiRow[] rows = (QLMamNon.Dao.QLMamNonDs.PhanLoaiChiRow[])table.Select(String.Format("PhanLoaiChiId={0}", phieChiRow.PhanLoaiChiId));

                if (!ArrayUtil.IsEmpty(rows))
                {
                    return rows[0].MaPhanLoai;
                }
            }

            return CommonConstant.EMPTY;
        }

        public static string GetPhanLoaiThuById(Int32 phanLoaiThuId)
        {
            if (phanLoaiThuId < 0)
            {
                return CommonConstant.EMPTY;
            }

            QLMamNon.Dao.QLMamNonDs.PhanLoaiThuDataTable table = StaticDataFacade.Get(StaticDataKeys.PhanLoaiThu) as QLMamNon.Dao.QLMamNonDs.PhanLoaiThuDataTable;
            QLMamNon.Dao.QLMamNonDs.PhanLoaiThuRow[] rows = (QLMamNon.Dao.QLMamNonDs.PhanLoaiThuRow[])table.Select(String.Format("PhanLoaiThuId={0}", phanLoaiThuId));

            if (!ArrayUtil.IsEmpty(rows))
            {
                return rows[0].DienGiai;
            }

            return CommonConstant.EMPTY;
        }
    }
}
