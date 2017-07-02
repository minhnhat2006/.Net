using System;
using System.Collections.Generic;
using System.Data;
using ACG.Core.WinForm.Util;
using QLMamNon.Entity.Form;
using QLThuChi;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmSoThuTien
    {
        private void fillReportBangKeTongHopThuTien(RptBangKeTongHopThuTienHS rpt)
        {
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = evaluateViewBangThuTienRowsForReport();
            List<BangKeThuTienItem> rowsToDisplay = new List<BangKeThuTienItem>();
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> hocSinhIdsToViewBangThuTienRows = new Dictionary<int, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow>();

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow in rows)
            {
                hocSinhIdsToViewBangThuTienRows.Add(viewBangThuTienRow.HocSinhId, viewBangThuTienRow);
            }

            QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable = phieuThuTableAdapter.GetDataByHocSinhIdsAndThangNam(StringUtil.Join(new List<int>(hocSinhIdsToViewBangThuTienRows.Keys), ","), this.ngayTinh.Year, this.ngayTinh.Month);
            int stt = 1;

            foreach (QLMamNon.Dao.QLMamNonDs.PhieuThuRow phieuThuRow in phieuThuDataTable)
            {
                QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow = hocSinhIdsToViewBangThuTienRows[phieuThuRow.HocSinhId];
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
                    BangKeThuTienItem prevVangKeThuTienItem = rowsToDisplay[rowsToDisplay.Count - 1];

                    if (prevVangKeThuTienItem.HocSinhId == bangKeThuTienItem.HocSinhId)
                    {
                        bangKeThuTienItem.TruyThu = prevVangKeThuTienItem.ConNo;
                        bangKeThuTienItem.PhaiThu = prevVangKeThuTienItem.ConNo;
                        bangKeThuTienItem.ConNo = bangKeThuTienItem.PhaiThu - bangKeThuTienItem.DaThu;
                    }
                }

                rowsToDisplay.Add(bangKeThuTienItem);
            }

            rpt.viewBangThuTienRowbindingSource.DataSource = rowsToDisplay;
            rpt.Ngay.Value = this.ngayTinh;
        }

        private List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> evaluateViewBangThuTienRowsForReport()
        {
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = new List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow>(this.GridViewMain.RowCount);
            List<int> hocSinhIds = new List<int>(this.GridViewMain.DataRowCount);
            for (int i = 0; i < this.GridViewMain.DataRowCount; i++)
            {
                object dataRow = this.GridViewMain.GetRow(this.GridViewMain.GetVisibleRowHandle(i));
                QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow = (dataRow as DataRowView).Row as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow;
                rows.Add(viewBangThuTienRow);
                hocSinhIds.Add(viewBangThuTienRow.HocSinhId);
            }

            Dictionary<int, QLMamNon.Dao.QLMamNonDs.LopRow> hocSinhIdsToLopNames = StaticDataUtil.GetLopsByHocSinhIds(hocSinhLopTableAdapter, hocSinhIds, this.ngayTinh);

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow in rows)
            {
                viewBangThuTienRow.HoTen = StaticDataUtil.getHocSinhFullNameByHocSinhId(this.hocSinhDataTable, viewBangThuTienRow.HocSinhId);

                if (hocSinhIdsToLopNames.ContainsKey(viewBangThuTienRow.HocSinhId))
                {
                    viewBangThuTienRow.Lop = hocSinhIdsToLopNames[viewBangThuTienRow.HocSinhId].Name;
                }
            }

            return rows;
        }

        private void fillRptSoThuTienTrang1(RptSoThuTienTrang1 rpt)
        {
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = evaluateViewBangThuTienRowsForReport();
            rpt.viewBangThuTienRowbindingSource.DataSource = rows;
            rpt.Ngay.Value = this.ngayTinh;
        }

        private void fillRptSoThuTienTrang2(RptSoThuTienTrang2 rpt)
        {
            rpt.viewBangThuTienRowbindingSource.DataSource = this.viewBangThuTienRowBindingSource.DataSource;
            rpt.Ngay.Value = this.ngayTinh;
        }

        private void fillRptGiayBaoNopTien(RptGiayBaoNopTien rpt)
        {
            rpt.NgayLapPhieu.Value = DateTime.Now;
            DateTime ngayTinh = this.ngayTinh;
            rpt.NgayNop.Value = ngayTinh;
            rpt.SoXuat.Value = DateTime.DaysInMonth(ngayTinh.Year, ngayTinh.Month) - DateTimeUtil.GetNumberDayOfWeekInMonth(ngayTinh.Year, ngayTinh.Month, DayOfWeek.Sunday);

            List<GiayBaoNopTientem> giayBaoNopTiens = new List<GiayBaoNopTientem>();
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = evaluateViewBangThuTienRowsForReport();

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow in rows)
            {
                if (!viewBangThuTienRow.IsNgayNopLan2Null())
                {
                    continue;
                }

                GiayBaoNopTientem giayBaoNopTien = new GiayBaoNopTientem()
                {
                    HoTen = viewBangThuTienRow.HoTen,
                    Lop = viewBangThuTienRow.Lop,
                    Lan = viewBangThuTienRow.IsNgayNopLan1Null() ? 1 : 2,
                    SoTienAnSang = viewBangThuTienRow.SoTienAnSangThangNay,
                    SoTienAnToi = viewBangThuTienRow.SoTienAnToiThangNay,
                    SoTienKhoanThuChinh = viewBangThuTienRow.KhoanThuChinh,
                    SoTienDieuHoa = viewBangThuTienRow.SoTienDieuHoa,
                    SoTienNangKhieu = viewBangThuTienRow.SoTienNangKhieu,
                    SoTienNoThangTruoc = viewBangThuTienRow.SoTienTruyThu,
                    SoTienAnSangThuaThangTruoc = viewBangThuTienRow.SoTienAnSangThangTruoc,
                    SoTienAnToiThuaThangTruoc = viewBangThuTienRow.SoTienAnToiThangTruoc,
                    SoTienAnTruaThuaThangTruoc = viewBangThuTienRow.SoTienSXThangTruoc,
                    SoXuatAnSangThuaThangTruoc = viewBangThuTienRow.AnSangThangTruoc,
                    SoXuatAnToiThuaThangTruoc = viewBangThuTienRow.AnToiThangTruoc,
                    SoXuatAnTruaThuaThangTruoc = viewBangThuTienRow.SXThangTruoc
                };

                giayBaoNopTiens.Add(giayBaoNopTien);
            }

            rpt.GiayBaoNopTienDataSource.DataSource = giayBaoNopTiens;
        }
    }
}
