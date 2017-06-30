
using System;
using ACG.Core.WinForm.Util;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Facade;
using QLMamNon.Properties;

namespace QLMamNon
{
    public static class BangThuTienUtil
    {
        public static long SXToSoTienSX(int sx)
        {
            return sx * Settings.Default.TienAnChinh;
        }

        public static long SXAnSangToSoTienAnSang(int sx)
        {
            return sx * Settings.Default.TienAnSang;
        }

        public static long SXAnToiToSoTienAnToi(int sx)
        {
            return sx * Settings.Default.TienAnToi;
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

        public static void EvaluateValuesForViewBangThuTienRow(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienThangTruocRow, QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable, QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable, bool ignoreTruyThu)
        {
            row.TienAnSua = 0;
            row.PhuPhi = 0;
            row.BanTru = 0;
            row.HocPhi = 0;
            row.KhoanThuChinh = 0;
            row.SoTienNopLan1 = 0;
            row.SoTienNopLan2 = 0;
            evaluateValuesForAdditionalFields(row, bTTKTDataTable);
            evaluateValuesForTienNop(row, phieuThuDataTable);
            row.KhoanThuChinh = row.TienAnSua + row.PhuPhi + row.BanTru + row.HocPhi;
            row.SoTienSXThangTruoc = BangThuTienUtil.SXToSoTienSX(row.SXThangTruoc);
            row.SoTienAnSangThangTruoc = BangThuTienUtil.SXAnSangToSoTienAnSang(row.AnSangThangTruoc);
            row.SoTienAnToiThangTruoc = BangThuTienUtil.SXAnToiToSoTienAnToi(row.AnToiThangTruoc);
            row.SoTienAnSangConLai = row.SoTienAnSangThangNay - row.SoTienAnSangThangTruoc;
            row.SoTienAnToiConLai = row.SoTienAnToiThangNay - row.SoTienAnToiThangTruoc;

            if (!ignoreTruyThu)
            {
                row.SoTienTruyThu = BangThuTienUtil.CalculateTruyThu(row, bangThuTienThangTruocRow);
            }

            row.ThanhTien = BangThuTienUtil.CalculateThanhTien(row);
        }

        private static void evaluateValuesForAdditionalFields(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row, QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable)
        {
            QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow[] bangThuTienKhoanThuRows = bTTKTDataTable.Select(String.Format("BangThuTienId={0}", row.BangThuTienId)) as QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow[];

            if (!ListUtil.IsEmpty(bangThuTienKhoanThuRows))
            {
                foreach (QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow bangThuTienKhoanThuRow in bangThuTienKhoanThuRows)
                {
                    switch (bangThuTienKhoanThuRow.KhoanThuId)
                    {
                        case BangThuTienConstant.KhoanThuIdTienAnSua:
                            row.TienAnSua = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdPhuPhi:
                            row.PhuPhi = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdBanTru:
                            row.BanTru = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdHocPhi:
                            row.HocPhi = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdAnSang:
                            row.SoTienAnSangThangNay = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdAnToi:
                            row.SoTienAnToiThangNay = bangThuTienKhoanThuRow.SoTien;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void evaluateValuesForTienNop(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row, QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable)
        {
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
    }
}
