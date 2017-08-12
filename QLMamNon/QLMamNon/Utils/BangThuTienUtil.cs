using System;
using ACG.Core.WinForm.Util;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Facade;
using QLMamNon.Properties;
using BangThuTienGenHistoryDataTable = QLMamNon.Dao.QLMamNonDs.BangThuTienGenHistoryDataTable;
using BangThuTienGenHistoryRow = QLMamNon.Dao.QLMamNonDs.BangThuTienGenHistoryRow;

namespace QLMamNon
{
    public static class BangThuTienUtil
    {
        public static long SXToSoTienSX(int sx, long tienAnChinh)
        {
            return sx * tienAnChinh;
        }

        public static long SXAnSangToSoTienAnSang(int sx, long tienAnSang)
        {
            return sx * tienAnSang;
        }

        public static long SXAnToiToSoTienAnToi(int sx, long tienAnToi)
        {
            return sx * tienAnToi;
        }

        public static long CalculateThanhTien(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienRow)
        {
            return bangThuTienRow.TienAnSua + bangThuTienRow.PhuPhi + bangThuTienRow.BanTru + bangThuTienRow.HocPhi -
                        bangThuTienRow.SoTienSXThangTruoc + bangThuTienRow.SoTienAnSangConLai + bangThuTienRow.SoTienAnToiConLai +
                        bangThuTienRow.SoTienNangKhieu + bangThuTienRow.SoTienTruyThu + bangThuTienRow.SoTienDieuHoa + bangThuTienRow.SoTienDoDung;
        }

        public static long CalculateTruyThu(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienThangTruocRow)
        {
            if (Settings.Default.AppLannchDate.Year == row.NgayTinh.Year && Settings.Default.AppLannchDate.Month == row.NgayTinh.Month)
            {
                return row.SoTienTruyThu;
            }

            if (bangThuTienThangTruocRow != null)
            {
                return bangThuTienThangTruocRow.ThanhTien - bangThuTienThangTruocRow.SoTienNopLan1 - bangThuTienThangTruocRow.SoTienNopLan2;
            }

            return 0;
        }

        public static void CalculateSummaryFields(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row)
        {
            BangThuTienGenHistoryTableAdapter bangThuTienGenHistoryTableAdapter = (BangThuTienGenHistoryTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterBangThuTienGenHistory);
            BangThuTienGenHistoryDataTable bangThuTienGenHistoryDataTable = bangThuTienGenHistoryTableAdapter.GetDataByLopAndNgay(row.LopId, row.NgayTinh);

            if (!ListUtil.IsEmpty(bangThuTienGenHistoryDataTable.Rows))
            {
                BangThuTienGenHistoryRow bangThuTienGenHistoryRow = bangThuTienGenHistoryDataTable[0];
                row.SoTienSXThangTruoc = BangThuTienUtil.SXToSoTienSX(row.SXThangTruoc, (long)bangThuTienGenHistoryRow.SoTienAnChinh);
                row.SoTienAnSangThangTruoc = BangThuTienUtil.SXAnSangToSoTienAnSang(row.AnSangThangTruoc, (long)bangThuTienGenHistoryRow.SoTienAnSang);
                row.SoTienAnToiThangTruoc = BangThuTienUtil.SXAnToiToSoTienAnToi(row.AnToiThangTruoc, (long)bangThuTienGenHistoryRow.SoTienAnSang);
            }

            row.SoTienAnSangConLai = row.SoTienAnSangThangNay - row.SoTienAnSangThangTruoc;
            row.SoTienAnToiConLai = row.SoTienAnToiThangNay - row.SoTienAnToiThangTruoc;
            row.KhoanThuChinh = row.TienAnSua + row.PhuPhi + row.BanTru + row.HocPhi;
            row.ThanhTien = BangThuTienUtil.CalculateThanhTien(row);
        }

        public static void EvaluateValuesForViewBangThuTienRow(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row,
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienThangTruocRow,
            QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable,
            QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable,
            bool ignoreTruyThu, bool isCalculateAnSangAnToi, bool isCalculateHocPhi)
        {
            evaluateValuesForAdditionalFields(row, bTTKTDataTable, isCalculateAnSangAnToi, isCalculateHocPhi);
            evaluateValuesForTienNop(row, phieuThuDataTable);

            if (!ignoreTruyThu)
            {
                row.SoTienTruyThu = BangThuTienUtil.CalculateTruyThu(row, bangThuTienThangTruocRow);
            }

            CalculateSummaryFields(row);
        }

        private static void evaluateValuesForAdditionalFields(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row,
            QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable,
            bool isCalculateAnSangAnToi, bool isCalculateHocPhi)
        {
            if (isCalculateHocPhi)
            {
                row.TienAnSua = 0;
                row.PhuPhi = 0;
                row.BanTru = 0;
                row.HocPhi = 0;
            }

            if (isCalculateAnSangAnToi)
            {
                row.SoTienAnSangThangNay = 0;
                row.SoTienAnToiThangNay = 0;
            }

            QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow[] bangThuTienKhoanThuRows = bTTKTDataTable.Select(String.Format("BangThuTienId={0}", row.BangThuTienId)) as QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow[];

            if (!ListUtil.IsEmpty(bangThuTienKhoanThuRows))
            {
                foreach (QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow bangThuTienKhoanThuRow in bangThuTienKhoanThuRows)
                {
                    switch (bangThuTienKhoanThuRow.KhoanThuId)
                    {
                        case BangThuTienConstant.KhoanThuIdTienAnSua:
                            if (isCalculateHocPhi)
                            {
                                row.TienAnSua = bangThuTienKhoanThuRow.SoTien;
                            }
                            break;
                        case BangThuTienConstant.KhoanThuIdPhuPhi:
                            if (isCalculateHocPhi)
                            {
                                row.PhuPhi = bangThuTienKhoanThuRow.SoTien;
                            }
                            break;
                        case BangThuTienConstant.KhoanThuIdBanTru:
                            if (isCalculateHocPhi)
                            {
                                row.BanTru = bangThuTienKhoanThuRow.SoTien;
                            }
                            break;
                        case BangThuTienConstant.KhoanThuIdHocPhi:
                            if (isCalculateHocPhi)
                            {
                                row.HocPhi = bangThuTienKhoanThuRow.SoTien;
                            }
                            break;
                        case BangThuTienConstant.KhoanThuIdAnSang:
                            if (isCalculateAnSangAnToi)
                            {
                                row.SoTienAnSangThangNay = bangThuTienKhoanThuRow.SoTien;
                            }
                            break;
                        case BangThuTienConstant.KhoanThuIdAnToi:
                            if (isCalculateAnSangAnToi)
                            {
                                row.SoTienAnToiThangNay = bangThuTienKhoanThuRow.SoTien;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void evaluateValuesForTienNop(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row, QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable)
        {
            row.SoTienNopLan1 = 0;
            row.SoTienNopLan2 = 0;

            QLMamNon.Dao.QLMamNonDs.PhieuThuRow[] phieuThuRows = phieuThuDataTable.Select(String.Format("HocSinhId={0}", row.HocSinhId)) as QLMamNon.Dao.QLMamNonDs.PhieuThuRow[];

            if (ListUtil.IsEmpty(phieuThuRows))
            {
                return;
            }

            QLMamNon.Dao.QLMamNonDs.PhieuThuRow firstRow = phieuThuRows[0] as QLMamNon.Dao.QLMamNonDs.PhieuThuRow;
            row.NgayNopLan1 = firstRow.Ngay;
            row.SoTienNopLan1 = firstRow.SoTien;

            if (phieuThuRows.Length > 1)
            {
                QLMamNon.Dao.QLMamNonDs.PhieuThuRow secondRow = phieuThuRows[1] as QLMamNon.Dao.QLMamNonDs.PhieuThuRow;
                row.NgayNopLan2 = secondRow.Ngay;
                row.SoTienNopLan2 = 0;

                for (int i = 1; i < phieuThuRows.Length; i++)
                {
                    QLMamNon.Dao.QLMamNonDs.PhieuThuRow phieuThuRow = phieuThuRows[i] as QLMamNon.Dao.QLMamNonDs.PhieuThuRow;
                    row.SoTienNopLan2 += phieuThuRow.SoTien;
                }
            }
        }

        public static long CalculateSoTienPhi(int? khoiId, int soNgayNghiThang, long orgSoTien, int khoanThuId)
        {
            long soTien = orgSoTien;

            if (khoiId.HasValue)
            {
                QLMamNon.Dao.QLMamNonDs.BangTinhPhiDataTable bangTinhPhiTable = StaticDataFacade.Get(StaticDataKeys.BangTinhPhi) as QLMamNon.Dao.QLMamNonDs.BangTinhPhiDataTable;
                QLMamNon.Dao.QLMamNonDs.BangTinhPhiRow[] bangTinhPhiRows = bangTinhPhiTable.Select(String.Format("KhoiId={0} AND SoNgayNghiMin<={1} AND SoNgayNghiMax>={1} AND KhoanThuId={2}", khoiId.Value, soNgayNghiThang, khoanThuId)) as QLMamNon.Dao.QLMamNonDs.BangTinhPhiRow[];
                if (!ArrayUtil.IsEmpty(bangTinhPhiRows))
                {
                    soTien = bangTinhPhiRows[0].SoTien;
                }
            }

            return soTien;
        }

        public static void RecalculateBangThuTienKhoanThuList(LopKhoiTableAdapter lopKhoiTableAdapter,
            KhoanThuHangNamTableAdapter khoanThuHangNamTableAdapter,
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow)
        {
            int khoiId = StaticDataUtil.GetKhoiIdByLopId(lopKhoiTableAdapter, viewBangThuTienRow.LopId).Value;
            int[] khoanThuIds = new int[] { BangThuTienConstant.KhoanThuIdBanTru, BangThuTienConstant.KhoanThuIdHocPhi, BangThuTienConstant.KhoanThuIdPhuPhi, BangThuTienConstant.KhoanThuIdTienAnSua, BangThuTienConstant.KhoanThuIdAnSang, BangThuTienConstant.KhoanThuIdAnToi };
            QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamDataTable khoanThuHangNamTable = khoanThuHangNamTableAdapter.GetKhoanThuHangNamByParams(String.Join(",", khoanThuIds), khoiId, viewBangThuTienRow.NgayTinh);

            foreach (QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamRow row in khoanThuHangNamTable)
            {
                long soTien = BangThuTienUtil.CalculateSoTienPhi(khoiId, viewBangThuTienRow.SXThangTruoc, row.SoTien, row.KhoanThuId);
                switch (row.KhoanThuId)
                {
                    case BangThuTienConstant.KhoanThuIdTienAnSua:
                        viewBangThuTienRow.TienAnSua = soTien;
                        break;
                    case BangThuTienConstant.KhoanThuIdPhuPhi:
                        viewBangThuTienRow.PhuPhi = soTien;
                        break;
                    case BangThuTienConstant.KhoanThuIdBanTru:
                        viewBangThuTienRow.BanTru = soTien;
                        break;
                    case BangThuTienConstant.KhoanThuIdHocPhi:
                        viewBangThuTienRow.HocPhi = soTien;
                        break;
                    default:
                        break;
                }
            }

            viewBangThuTienRow.KhoanThuChinh = viewBangThuTienRow.TienAnSua + viewBangThuTienRow.PhuPhi + viewBangThuTienRow.BanTru + viewBangThuTienRow.HocPhi;
            viewBangThuTienRow.ThanhTien = BangThuTienUtil.CalculateThanhTien(viewBangThuTienRow);
        }
    }
}
