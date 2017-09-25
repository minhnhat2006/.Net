using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ACG.Core.WinForm.Util;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Entity.Form;
using QLMamNon.Facade;
using QLMamNon.Properties;
using BangThuTienDataTable = QLMamNon.Dao.QLMamNonDs.BangThuTienDataTable;
using HocSinhDataTable = QLMamNon.Dao.QLMamNonDs.HocSinhDataTable;
using HocSinhLopRow = QLMamNon.Dao.QLMamNonDs.HocSinhLopRow;
using HocSinhRow = QLMamNon.Dao.QLMamNonDs.HocSinhRow;
using PhieuThuRow = QLMamNon.Dao.QLMamNonDs.PhieuThuRow;
using ViewBangThuTienDataTable = QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable;
using ViewBangThuTienRow = QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow;

namespace QLMamNon.Service.Data
{
    public class SoThuTienService : BaseDataService
    {
        #region Generate SoThuTien

        public int GenerateSoThuTienByHocSinhRows(DateTime ngayTinh, List<HocSinhRow> hocSinhRows)
        {
            ViewBangThuTienTableAdapter viewBangThuTienTableAdapter = (ViewBangThuTienTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterViewBangThuTien);
            ViewBangThuTienDataTable viewBangThuTienTable = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(ngayTinh, null);

            List<int> hocSinhIds = new List<int>();
            List<HocSinhRow> needToGenerateHocSinhRows = new List<Dao.QLMamNonDs.HocSinhRow>();

            foreach (HocSinhRow hocSinh in hocSinhRows)
            {
                DataRow[] rows = viewBangThuTienTable.Select(String.Format("HocSinhId={0}", hocSinh.HocSinhId));

                if (ArrayUtil.IsEmpty(rows))
                {
                    hocSinhIds.Add(hocSinh.HocSinhId);
                    needToGenerateHocSinhRows.Add(hocSinh);
                }
            }

            Dictionary<int, HocSinhLopRow> hocSinhIdsToHocSinhLops = StaticDataUtil.GetHocSinhLopsByHocSinhIds(hocSinhIds, ngayTinh);
            Dictionary<int, Dictionary<int, ViewBangThuTienRow>> lopToHocSinhToViewBangThuTienRowsMap = buildLopToHocSinhToViewBangThuTienRowsMap(viewBangThuTienTable, ngayTinh);
            Dictionary<int, Dictionary<int, ViewBangThuTienRow>> prevMonthLopToHocSinhToViewBangThuTienRowsMap = getAndSortPrevMonthViewBangThuTienRows(ngayTinh, viewBangThuTienTableAdapter, hocSinhIds, hocSinhIdsToHocSinhLops, lopToHocSinhToViewBangThuTienRowsMap);
            Dictionary<int, int> generatedLopToSTTs = buildGeneratedLopIdToSTTMap(lopToHocSinhToViewBangThuTienRowsMap);

            // Generate SoThuTien for HocSinhs that exist in previous month
            foreach (HocSinhRow hocSinh in needToGenerateHocSinhRows)
            {
                if (hocSinhIdsToHocSinhLops.ContainsKey(hocSinh.HocSinhId))
                {
                    int lopId = hocSinhIdsToHocSinhLops[hocSinh.HocSinhId].LopId;
                    ViewBangThuTienRow preMonthViewBangThuTien = null;

                    if (prevMonthLopToHocSinhToViewBangThuTienRowsMap.ContainsKey(lopId))
                    {
                        Dictionary<int, ViewBangThuTienRow> prevMonthhocSinhToViewBangThuTienRowsMap = prevMonthLopToHocSinhToViewBangThuTienRowsMap[lopId];

                        if (prevMonthhocSinhToViewBangThuTienRowsMap.ContainsKey(hocSinh.HocSinhId))
                        {
                            preMonthViewBangThuTien = prevMonthhocSinhToViewBangThuTienRowsMap[hocSinh.HocSinhId];
                        }
                    }

                    if (preMonthViewBangThuTien != null)
                    {
                        GenerateSoThuTienByHocSinhAndLopAndNgayTinh(hocSinh.HocSinhId, lopId, ngayTinh, preMonthViewBangThuTien.STT, preMonthViewBangThuTien);

                        if (!generatedLopToSTTs.ContainsKey(lopId))
                        {
                            generatedLopToSTTs.Add(lopId, 0);
                        }

                        int currentSTT = generatedLopToSTTs[lopId];

                        if (currentSTT < preMonthViewBangThuTien.STT)
                        {
                            generatedLopToSTTs[lopId] = preMonthViewBangThuTien.STT;
                        }
                    }
                }
            }

            // Generate SoThuTien for HocSinhs that NOT exist in previous month
            foreach (HocSinhRow hocSinh in needToGenerateHocSinhRows)
            {
                if (hocSinhIdsToHocSinhLops.ContainsKey(hocSinh.HocSinhId))
                {
                    int lopId = hocSinhIdsToHocSinhLops[hocSinh.HocSinhId].LopId;
                    ViewBangThuTienRow preMonthViewBangThuTien = null;

                    if (prevMonthLopToHocSinhToViewBangThuTienRowsMap.ContainsKey(lopId))
                    {
                        Dictionary<int, ViewBangThuTienRow> prevMonthhocSinhToViewBangThuTienRowsMap = prevMonthLopToHocSinhToViewBangThuTienRowsMap[lopId];

                        if (prevMonthhocSinhToViewBangThuTienRowsMap.ContainsKey(hocSinh.HocSinhId))
                        {
                            preMonthViewBangThuTien = prevMonthhocSinhToViewBangThuTienRowsMap[hocSinh.HocSinhId];
                        }
                    }

                    if (preMonthViewBangThuTien == null)
                    {
                        if (!generatedLopToSTTs.ContainsKey(lopId))
                        {
                            generatedLopToSTTs.Add(lopId, 0);
                        }

                        int stt = generatedLopToSTTs[lopId] + 1;
                        GenerateSoThuTienByHocSinhAndLopAndNgayTinh(hocSinh.HocSinhId, lopId, ngayTinh, stt, preMonthViewBangThuTien);
                        generatedLopToSTTs[lopId] = stt;
                    }
                }
            }

            return hocSinhIds.Count;
        }

        private static Dictionary<int, int> buildGeneratedLopIdToSTTMap(Dictionary<int, Dictionary<int, ViewBangThuTienRow>> lopToHocSinhToViewBangThuTienRowsMap)
        {
            Dictionary<int, int> generatedLopToSTTs = new Dictionary<int, int>();

            foreach (KeyValuePair<int, Dictionary<int, ViewBangThuTienRow>> lopToHocSinhToViewBangThuTienRow in lopToHocSinhToViewBangThuTienRowsMap)
            {
                generatedLopToSTTs.Add(lopToHocSinhToViewBangThuTienRow.Key, lopToHocSinhToViewBangThuTienRow.Value.Count);
            }

            return generatedLopToSTTs;
        }

        private static Dictionary<int, Dictionary<int, ViewBangThuTienRow>> buildLopToHocSinhToViewBangThuTienRowsMap(ViewBangThuTienDataTable viewBangThuTienTable, DateTime ngayTinh)
        {
            List<int> hocSinhIds = new List<int>();

            foreach (ViewBangThuTienRow viewBangThuTienRow in viewBangThuTienTable)
            {
                hocSinhIds.Add(viewBangThuTienRow.HocSinhId);
            }

            Dictionary<int, HocSinhLopRow> hocSinhIdsToHocSinhLops = StaticDataUtil.GetHocSinhLopsByHocSinhIds(hocSinhIds, ngayTinh);
            Dictionary<int, Dictionary<int, ViewBangThuTienRow>> lopToHocSinhViewBangThuTienRows = new Dictionary<int, Dictionary<int, ViewBangThuTienRow>>();

            foreach (ViewBangThuTienRow viewBangThuTienRow in viewBangThuTienTable)
            {
                if (!hocSinhIdsToHocSinhLops.ContainsKey(viewBangThuTienRow.HocSinhId))
                {
                    continue;
                }

                int lopId = hocSinhIdsToHocSinhLops[viewBangThuTienRow.HocSinhId].LopId;

                if (!lopToHocSinhViewBangThuTienRows.ContainsKey(lopId))
                {
                    lopToHocSinhViewBangThuTienRows.Add(lopId, new Dictionary<int, ViewBangThuTienRow>());
                }

                Dictionary<int, ViewBangThuTienRow> hocSinhToViewBangThuTienRows = lopToHocSinhViewBangThuTienRows[lopId];
                hocSinhToViewBangThuTienRows.Add(viewBangThuTienRow.HocSinhId, viewBangThuTienRow);
            }

            return lopToHocSinhViewBangThuTienRows;
        }

        private static Dictionary<int, Dictionary<int, ViewBangThuTienRow>> getAndSortPrevMonthViewBangThuTienRows(DateTime ngayTinh, ViewBangThuTienTableAdapter viewBangThuTienTableAdapter, List<int> hocSinhIds,
            Dictionary<int, HocSinhLopRow> hocSinhIdsToHocSinhLops, Dictionary<int, Dictionary<int, ViewBangThuTienRow>> lopToHocSinhToViewBangThuTienRowsMap)
        {
            ViewBangThuTienDataTable prevMonthViewBangThuTienTable = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(ngayTinh.AddMonths(-1), null);
            Dictionary<int, Dictionary<int, ViewBangThuTienRow>> lopToHocSinhViewBangThuTienRows = new Dictionary<int, Dictionary<int, ViewBangThuTienRow>>();

            foreach (ViewBangThuTienRow viewBangThuTienRow in prevMonthViewBangThuTienTable)
            {
                if (!hocSinhIds.Contains(viewBangThuTienRow.HocSinhId))
                {
                    continue;
                }

                int lopId = hocSinhIdsToHocSinhLops[viewBangThuTienRow.HocSinhId].LopId;

                if (!lopToHocSinhViewBangThuTienRows.ContainsKey(lopId))
                {
                    lopToHocSinhViewBangThuTienRows.Add(lopId, new Dictionary<int, ViewBangThuTienRow>());
                }

                Dictionary<int, ViewBangThuTienRow> hocSinhToViewBangThuTienRows = lopToHocSinhViewBangThuTienRows[lopId];
                hocSinhToViewBangThuTienRows.Add(viewBangThuTienRow.HocSinhId, viewBangThuTienRow);
            }

            // Sort HocSinh in each Lop by STT ASC
            foreach (KeyValuePair<int, Dictionary<int, ViewBangThuTienRow>> lopToHocSinhViewBangThuTienRow in lopToHocSinhViewBangThuTienRows)
            {
                int lopId = lopToHocSinhViewBangThuTienRow.Key;
                Dictionary<int, ViewBangThuTienRow> hocSinhViewBangThuTienRows = lopToHocSinhToViewBangThuTienRowsMap.ContainsKey(lopId) ? lopToHocSinhToViewBangThuTienRowsMap[lopId] : null;
                SortedList<int, ViewBangThuTienRow> sortedViewBangThuTienRows = new SortedList<int, ViewBangThuTienRow>();
                int currentMaxSTT = ListUtil.IsEmpty(hocSinhViewBangThuTienRows) ? 0 : hocSinhViewBangThuTienRows.Count;

                foreach (KeyValuePair<int, ViewBangThuTienRow> hocSinhIdToViewBangThuTienRow in lopToHocSinhViewBangThuTienRow.Value)
                {
                    sortedViewBangThuTienRows.Add(hocSinhIdToViewBangThuTienRow.Value.STT, hocSinhIdToViewBangThuTienRow.Value);
                }

                for (int i = 0; i < sortedViewBangThuTienRows.Count; i++)
                {
                    sortedViewBangThuTienRows.Values[i].STT = i + currentMaxSTT + 1;
                }
            }

            return lopToHocSinhViewBangThuTienRows;
        }

        public void GenerateSoThuTienByHocSinhAndLopAndNgayTinh(int hocSinhId, int lopId, DateTime ngayTinh, int stt, ViewBangThuTienRow preMonthViewBangThuTien)
        {
            BangThuTienTableAdapter bangThuTienTableAdapter = (BangThuTienTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterBangThuTien);
            LopKhoiTableAdapter lopKhoiTableAdapter = (LopKhoiTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterLopKhoi);

            int sXThangTruoc = 0;
            long soTienSXThangTruoc = 0;
            int anSangThangTruoc = 0;
            long soTienAnSangThangTruoc = 0;
            long soTienAnSangThangNay = 0;
            int anToiThangTruoc = 0;
            long soTienAnToiThangTruoc = 0;
            long soTienAnToiThangNay = 0;
            long soTienNangKhieu = 0;
            long soTienTruyThu = 0;
            long soTienDieuHoa = 0;
            long soTienDoDung = 0;
            String ghiChu = "";
            bangThuTienTableAdapter.Insert(hocSinhId, lopId, sXThangTruoc, soTienSXThangTruoc, anSangThangTruoc, soTienAnSangThangTruoc, soTienAnSangThangNay, soTienAnToiThangTruoc, anToiThangTruoc, soTienAnToiThangNay, soTienDoDung, soTienNangKhieu, soTienTruyThu, soTienDieuHoa, ngayTinh, stt, 0, DateTime.Now, ghiChu);
            int bangThuTienId = (int)bangThuTienTableAdapter.Adapter.InsertCommand.LastInsertedId;
            int khoiId = StaticDataUtil.GetKhoiIdByLopId(lopKhoiTableAdapter, lopId).Value;
            this.generateBangThuTienKhoanThu(bangThuTienId, khoiId, ngayTinh, preMonthViewBangThuTien);
        }

        private void generateBangThuTienKhoanThu(int bangThuTienId, int khoiId, DateTime ngayTinh, ViewBangThuTienRow preMonthViewBangThuTien)
        {
            KhoanThuHangNamTableAdapter khoanThuHangNamTableAdapter = (KhoanThuHangNamTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterKhoanThuHangNam);
            BangThuTienTableAdapter bangThuTienTableAdapter = (BangThuTienTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterBangThuTien);
            BangThuTienKhoanThuTableAdapter bangThuTienKhoanThuTableAdapter = (BangThuTienKhoanThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterBangThuTienKhoanThu);
            int[] khoanThuIds = new int[] { BangThuTienConstant.KhoanThuIdBanTru, BangThuTienConstant.KhoanThuIdHocPhi, BangThuTienConstant.KhoanThuIdPhuPhi, BangThuTienConstant.KhoanThuIdTienAnSua, BangThuTienConstant.KhoanThuIdAnSang, BangThuTienConstant.KhoanThuIdAnToi };
            List<int> ignoreKhoanThuIds = getKhoanThuIdsToIgnoreGenerating(preMonthViewBangThuTien);
            QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamDataTable khoanThuHangNamTable = khoanThuHangNamTableAdapter.GetKhoanThuHangNamByParams(String.Join(",", khoanThuIds), khoiId, ngayTinh);
            BangThuTienDataTable bangThuTienTable = bangThuTienTableAdapter.GetDataById(bangThuTienId);
            QLMamNon.Dao.QLMamNonDs.BangThuTienRow bangThuTienRow = bangThuTienTable[0];

            foreach (QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamRow row in khoanThuHangNamTable)
            {
                long soTien = 0;

                if (!ignoreKhoanThuIds.Contains(row.KhoanThuId))
                {
                    soTien = BangThuTienUtil.CalculateSoTienPhi(khoiId, 0, row.SoTien, row.KhoanThuId);
                }

                bangThuTienKhoanThuTableAdapter.Insert(row.KhoanThuId, bangThuTienId, soTien);

                if (soTien != 0)
                {
                    switch (row.KhoanThuId)
                    {
                        case BangThuTienConstant.KhoanThuIdAnSang:
                            bangThuTienRow.SoTienAnSangThangNay = soTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdAnToi:
                            bangThuTienRow.SoTienAnToiThangNay = soTien;
                            break;
                        default:
                            break;
                    }
                }
            }

            bangThuTienTableAdapter.Update(bangThuTienRow);
        }

        private static List<int> getKhoanThuIdsToIgnoreGenerating(ViewBangThuTienRow preMonthViewBangThuTien)
        {
            List<int> ignoreKhoanThuIds = new List<int>();

            if (preMonthViewBangThuTien == null || preMonthViewBangThuTien.SoTienAnSangThangNay == 0)
            {
                ignoreKhoanThuIds.Add(BangThuTienConstant.KhoanThuIdAnSang);
            }

            if (preMonthViewBangThuTien == null || preMonthViewBangThuTien.SoTienAnToiThangNay == 0)
            {
                ignoreKhoanThuIds.Add(BangThuTienConstant.KhoanThuIdAnToi);
            }

            return ignoreKhoanThuIds;
        }

        #endregion

        public List<BangKeThuTienItem> GetBangKeTongHopThuTien(DateTime toDate, int? lopId)
        {
            List<ViewBangThuTienRow> viewBangThuTienRows = this.loadViewBangThuTiensToanTruong(toDate, lopId);
            List<ViewBangThuTienRow> rows = EvaluateViewBangThuTienRowsForReport(viewBangThuTienRows, toDate);
            List<BangKeThuTienItem> rowsToDisplay = new List<BangKeThuTienItem>();
            Dictionary<int, ViewBangThuTienRow> hocSinhIdsToViewBangThuTienRows = new Dictionary<int, ViewBangThuTienRow>();

            foreach (ViewBangThuTienRow viewBangThuTienRow in rows)
            {
                if (!hocSinhIdsToViewBangThuTienRows.ContainsKey(viewBangThuTienRow.HocSinhId))
                {
                    hocSinhIdsToViewBangThuTienRows.Add(viewBangThuTienRow.HocSinhId, viewBangThuTienRow);
                }
            }

            if (ListUtil.IsEmpty(hocSinhIdsToViewBangThuTienRows))
            {
                return rowsToDisplay;
            }

            PhieuThuTableAdapter phieuThuTableAdapter = (PhieuThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuThu);
            QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable = phieuThuTableAdapter.GetDataOfMonthByHocSinhIdsAndNgay(StringUtil.Join(new List<int>(hocSinhIdsToViewBangThuTienRows.Keys), ","), toDate);
            int stt = 1;

            foreach (PhieuThuRow phieuThuRow in phieuThuDataTable)
            {
                ViewBangThuTienRow viewBangThuTienRow = hocSinhIdsToViewBangThuTienRows[phieuThuRow.HocSinhId];
                BangKeThuTienItem bangKeThuTienItem = new BangKeThuTienItem()
                {
                    STT = stt++,
                    HocSinhId = viewBangThuTienRow.HocSinhId,
                    HoTen = viewBangThuTienRow.HoTen,
                    Lop = viewBangThuTienRow.Lop,
                    NgayNop = phieuThuRow.Ngay,
                    SoBienLai = phieuThuRow.MaPhieu,
                    PhuPhi = viewBangThuTienRow.PhuPhi,
                    BanTru = viewBangThuTienRow.BanTru,
                    HocPhi = viewBangThuTienRow.HocPhi,
                    AnChinh = viewBangThuTienRow.TienAnSua,
                    AnSang = viewBangThuTienRow.SoTienAnSangConLai,
                    AnToi = viewBangThuTienRow.SoTienAnToiConLai,
                    NangKhieu = viewBangThuTienRow.SoTienNangKhieu,
                    DoDung = viewBangThuTienRow.SoTienDoDung,
                    DieuHoa = viewBangThuTienRow.SoTienDieuHoa,
                    TruyThu = viewBangThuTienRow.SoTienTruyThu,
                    PhaiThu = viewBangThuTienRow.ThanhTien,
                    DaThu = phieuThuRow.SoTien,
                    ConNo = viewBangThuTienRow.ThanhTien - phieuThuRow.SoTien
                };

                if (!ListUtil.IsEmpty(rowsToDisplay))
                {
                    BangKeThuTienItem prevBangKeThuTienItem = rowsToDisplay[rowsToDisplay.Count - 1];

                    if (prevBangKeThuTienItem.HocSinhId == bangKeThuTienItem.HocSinhId)
                    {
                        bangKeThuTienItem.TruyThu = prevBangKeThuTienItem.ConNo;
                        bangKeThuTienItem.PhaiThu = prevBangKeThuTienItem.ConNo;
                        bangKeThuTienItem.ConNo = bangKeThuTienItem.PhaiThu - bangKeThuTienItem.DaThu;
                    }
                }

                rowsToDisplay.Add(bangKeThuTienItem);
            }

            return rowsToDisplay;
        }

        private List<ViewBangThuTienRow> loadViewBangThuTiensToanTruong(DateTime toDate, int? lopId)
        {
            ViewBangThuTienTableAdapter viewBangThuTienTableAdapter = (ViewBangThuTienTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterViewBangThuTien);
            BangThuTienKhoanThuTableAdapter bangThuTienKhoanThuTableAdapter = (BangThuTienKhoanThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterBangThuTienKhoanThu);
            PhieuThuTableAdapter phieuThuTableAdapter = (PhieuThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuThu);

            ViewBangThuTienDataTable table = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(toDate, lopId);
            List<int> bangThuTienIds = new List<int>(table.Rows.Count);

            foreach (ViewBangThuTienRow row in table)
            {
                bangThuTienIds.Add(row.BangThuTienId);
            }

            if (!ListUtil.IsEmpty(bangThuTienIds))
            {
                QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(String.Join(",", bangThuTienIds));
                QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable = phieuThuTableAdapter.GetDataByHocSinhIdAndNgayTinh(-1, toDate);

                Dictionary<int, ViewBangThuTienRow> prevMonthRowDictionary = this.EvaluatePrevMonthViewBangThuTienTable(toDate.AddMonths(-1), lopId);
                HocSinhDataTable hocSinhDataTable = this.getHocSinhData();

                foreach (ViewBangThuTienRow row in table)
                {
                    row.HoTen = StaticDataUtil.GetHocSinhFullNameByHocSinhId(hocSinhDataTable, row.HocSinhId);
                    BangThuTienUtil.EvaluateValuesForViewBangThuTienRow(row,
                        prevMonthRowDictionary != null && prevMonthRowDictionary.ContainsKey(row.HocSinhId) ? prevMonthRowDictionary[row.HocSinhId] : null,
                        bTTKTDataTable, phieuThuDataTable, false, false, true);
                }
            }

            List<ViewBangThuTienRow> viewBangThuTienRows = new List<Dao.QLMamNonDs.ViewBangThuTienRow>();

            foreach (ViewBangThuTienRow row in table)
            {
                viewBangThuTienRows.Add(row);
            }

            return viewBangThuTienRows;
        }

        public List<ViewBangThuTienRow> EvaluateViewBangThuTienRowsForReport(List<ViewBangThuTienRow> viewBangThuTienRows, DateTime toDate)
        {
            HashSet<int> hocSinhIds = new HashSet<int>();

            foreach (ViewBangThuTienRow viewBangThuTienRow in viewBangThuTienRows)
            {
                if (!hocSinhIds.Contains(viewBangThuTienRow.HocSinhId))
                {
                    hocSinhIds.Add(viewBangThuTienRow.HocSinhId);
                }
            }

            LoggerFacade.Info(string.Format("EvaluateViewBangThuTienRowsForReport for list HocSinhIds=[{0}]", StringUtil.JoinWithCommas(hocSinhIds.ToList())));

            HocSinhLopTableAdapter hocSinhLopTableAdapter = (HocSinhLopTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterHocSinhLop);
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.LopRow> hocSinhIdsToLopNames = StaticDataUtil.GetLopsByHocSinhIds(hocSinhIds.ToList(), toDate);
            HocSinhDataTable hocSinhDataTable = this.getHocSinhData();

            foreach (ViewBangThuTienRow viewBangThuTienRow in viewBangThuTienRows)
            {
                viewBangThuTienRow.HoTen = StaticDataUtil.GetHocSinhFullNameByHocSinhId(hocSinhDataTable, viewBangThuTienRow.HocSinhId);

                if (hocSinhIdsToLopNames.ContainsKey(viewBangThuTienRow.HocSinhId))
                {
                    viewBangThuTienRow.Lop = hocSinhIdsToLopNames[viewBangThuTienRow.HocSinhId].Name;
                }
            }

            return viewBangThuTienRows;
        }

        public Dictionary<int, ViewBangThuTienRow> EvaluatePrevMonthViewBangThuTienTable(DateTime ngayTinh, int? lop)
        {
            ViewBangThuTienTableAdapter viewBangThuTienTableAdapter = (ViewBangThuTienTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterViewBangThuTien);
            BangThuTienKhoanThuTableAdapter bangThuTienKhoanThuTableAdapter = (BangThuTienKhoanThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterBangThuTienKhoanThu);
            PhieuThuTableAdapter phieuThuTableAdapter = (PhieuThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuThu);

            Dictionary<int, ViewBangThuTienRow> prevMonthRowDictionary = new Dictionary<int, Dao.QLMamNonDs.ViewBangThuTienRow>();

            ViewBangThuTienDataTable prevMonthBangThuTienTable = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(ngayTinh, lop);
            List<int> prevMonthBangThuTienIds = new List<int>(prevMonthBangThuTienTable.Rows.Count);

            foreach (ViewBangThuTienRow row in prevMonthBangThuTienTable)
            {
                prevMonthBangThuTienIds.Add(row.BangThuTienId);
            }

            if (!ListUtil.IsEmpty(prevMonthBangThuTienIds))
            {
                QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable prevMonthBTTKTDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(String.Join(",", prevMonthBangThuTienIds));
                QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable prevMonthPhieuThuDataTable = phieuThuTableAdapter.GetDataByHocSinhIdAndNgayTinh(-1, ngayTinh);
                prevMonthRowDictionary = new Dictionary<int, Dao.QLMamNonDs.ViewBangThuTienRow>();

                foreach (ViewBangThuTienRow row in prevMonthBangThuTienTable)
                {
                    BangThuTienUtil.EvaluateValuesForViewBangThuTienRow(row, null, prevMonthBTTKTDataTable, prevMonthPhieuThuDataTable, true, false, true);
                    prevMonthRowDictionary.Add(row.HocSinhId, row);
                }
            }

            return prevMonthRowDictionary;
        }

        public void DeleteBangThuTienByHocSinhIdsAndDate(List<int> hocSinhIds, DateTime date)
        {
            BangThuTienTableAdapter bangThuTienTableAdapter = (BangThuTienTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterBangThuTien);
            bangThuTienTableAdapter.DeleteByHocSinhIdsAndDate(StringUtil.JoinWithCommas(hocSinhIds), date);
        }

        public decimal GetSoTienTonDauKy(DateTime toDate)
        {
            UnknownColumnViewTableAdapter unknownColumnViewTableAdapter = (UnknownColumnViewTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterUnknownColumnView);
            DateTime lastDayOfPrevMonth = DateTimeUtil.DateEndOfMonth(toDate.AddMonths(-1));
            decimal tongThu = (decimal)unknownColumnViewTableAdapter.GetSumSoTienThuByDateRange(Settings.Default.AppLannchDate, lastDayOfPrevMonth, null);
            decimal tongChi = (decimal)unknownColumnViewTableAdapter.GetSumSoTienChiByDateRange(Settings.Default.AppLannchDate, lastDayOfPrevMonth, null);
            decimal chenhLech = tongThu - tongChi + Settings.Default.SoTienTonDauKy;
            return chenhLech;
        }

        private HocSinhDataTable getHocSinhData()
        {
            HocSinhTableAdapter hocSinhTableAdapter = (HocSinhTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterHocSinh);
            return hocSinhTableAdapter.GetData();
        }
    }
}
