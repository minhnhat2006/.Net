
using System;
using System.Data;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Facade;
using QLMamNon.Components.Data.Static;
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
            if (truongId != null)
            {
                QLMamNon.Dao.QLMamNonDs.TruongDataTable truongTable = StaticDataFacade.Get(DataKeys.TruongHoc) as QLMamNon.Dao.QLMamNonDs.TruongDataTable;
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
                QLMamNon.Dao.QLMamNonDs.TruongDataTable truongTable = StaticDataFacade.Get(DataKeys.TruongHoc) as QLMamNon.Dao.QLMamNonDs.TruongDataTable;
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

            QLMamNon.Dao.QLMamNonDs.KhoiDataTable khoiTable = StaticDataFacade.Get(DataKeys.KhoiHoc) as QLMamNon.Dao.QLMamNonDs.KhoiDataTable;
            QLMamNon.Dao.QLMamNonDs.KhoiRow khoiRow = khoiTable.FindByKhoiId(khoiId);

            if (khoiRow != null)
            {
                return khoiRow.Name;
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

            QLMamNon.Dao.QLMamNonDs.KhoanThuDataTable khoanThuTable = StaticDataFacade.Get(DataKeys.KhoanThu) as QLMamNon.Dao.QLMamNonDs.KhoanThuDataTable;
            QLMamNon.Dao.QLMamNonDs.KhoanThuRow khoanThuRow = khoanThuTable.FindByKhoanThuId(khoanThuId);

            if (khoanThuRow != null)
            {
                return khoanThuRow.Ten;
            }

            return CommonConstant.EMPTY;
        }

        public static string getHocSinhFullNameByHocSinhId(QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhDataTable, int hocSinhId)
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
    }
}
