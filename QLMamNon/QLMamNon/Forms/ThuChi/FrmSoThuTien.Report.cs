using System;
using System.Collections.Generic;
using System.Data;
using ACG.Core.WinForm.Util;
using QLMamNon.Entity.Form;
using QLMamNon.Properties;
using QLMamNon.Service.Data;
using QLThuChi;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmSoThuTien
    {
        private List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> getViewBangThuTienRowsFromMainGrid()
        {
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = new List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow>();
            for (int i = 0; i < this.GridViewMain.DataRowCount; i++)
            {
                object dataRow = this.GridViewMain.GetRow(this.GridViewMain.GetVisibleRowHandle(i));
                QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow = (dataRow as DataRowView).Row as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow;
                rows.Add(viewBangThuTienRow);
            }

            return rows;
        }

        private void fillRptSoThuTienTrang1(RptSoThuTienTrang1 rpt)
        {
            SoThuTienService soThuTienService = new SoThuTienService();
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = soThuTienService.EvaluateViewBangThuTienRowsForReport(this.getViewBangThuTienRowsFromMainGrid(), this.ngayTinh);
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
            rpt.ShowDieuHoa.Value = Settings.Default.ShowGiayBaoNopTienDieuHoa;
            rpt.ShowNote.Value = Settings.Default.ShowGiayBaoNopTienNote;
            rpt.NgayLapPhieu.Value = DateTime.Now;
            DateTime ngayTinh = this.ngayTinh;
            rpt.NgayNop.Value = ngayTinh;
            rpt.SoXuat.Value = DateTime.DaysInMonth(ngayTinh.Year, ngayTinh.Month) - DateTimeUtil.GetNumberDayOfWeekInMonth(ngayTinh.Year, ngayTinh.Month, DayOfWeek.Sunday);

            List<GiayBaoNopTientem> giayBaoNopTiens = new List<GiayBaoNopTientem>();

            SoThuTienService soThuTienService = new SoThuTienService();
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = soThuTienService.EvaluateViewBangThuTienRowsForReport(this.getViewBangThuTienRowsFromMainGrid(), this.ngayTinh);

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
                    SoTienDoDung = viewBangThuTienRow.SoTienDoDung,
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
