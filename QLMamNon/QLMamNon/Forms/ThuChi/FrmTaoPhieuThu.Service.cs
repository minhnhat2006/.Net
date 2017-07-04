using System;
using System.Collections.Generic;
using System.Data;
using ACG.Core.WinForm.Util;
using QLMamNon.Components.Command;
using QLMamNon.Components.Command.QLMNDao;
using QLMamNon.Constant;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmTaoPhieuThu
    {
        private void updateSoTienTruyThuForBangThuTienNextMonths(DateTime ngay, int hocSinhId)
        {
            QLMNDaoJobInvoker qlmnDaoJobInvoker = new QLMNDaoJobInvoker();
            qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand = new UpdateSoTienTruyThuOfBangThuTienCommand();
            qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Add(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterViewBangThuTienTableAdapter, this.viewBangThuTienTableAdapter);
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable table = this.viewBangThuTienTableAdapter.GetDataByNgayTinhAndHocSinhId(ngay, hocSinhId);

            if (ListUtil.IsEmpty(table.Rows))
            {
                return;
            }

            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow = table[0];
            QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(viewBangThuTienRow.BangThuTienId.ToString());
            QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable = phieuThuTableAdapter.GetDataByHocSinhIdAndNgayTinh(-1, ngay);
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> prevMonthRowDictionary = evaluatePrevMonthViewBangThuTienTable(ngay.AddMonths(-1), hocSinhId);
            BangThuTienUtil.EvaluateValuesForViewBangThuTienRow(viewBangThuTienRow,
                prevMonthRowDictionary != null && prevMonthRowDictionary.ContainsKey(viewBangThuTienRow.HocSinhId) ? prevMonthRowDictionary[viewBangThuTienRow.HocSinhId] : null, 
                bTTKTDataTable, phieuThuDataTable, false, false, true);

            if (viewBangThuTienRow[ViewBangThuTienFieldName.ThanhTien, DataRowVersion.Original] != DBNull.Value && viewBangThuTienRow[ViewBangThuTienFieldName.ThanhTien, DataRowVersion.Current] != DBNull.Value)
            {
                long originalVersionToCompare = (long)viewBangThuTienRow[ViewBangThuTienFieldName.ThanhTien, DataRowVersion.Original];
                long currentVersionToCompare = (long)viewBangThuTienRow[ViewBangThuTienFieldName.ThanhTien, DataRowVersion.Current];

                if (originalVersionToCompare != currentVersionToCompare)
                {
                    qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Remove(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterCurrentViewBangThuTien);
                    qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Remove(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterSoTienAdded);
                    qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Add(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterCurrentViewBangThuTien, viewBangThuTienRow);
                    qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Add(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterSoTienAdded, currentVersionToCompare - originalVersionToCompare);
                    qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTien();
                }
            }
        }

        private Dictionary<int, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> evaluatePrevMonthViewBangThuTienTable(DateTime ngayTinh, int hocSinhId)
        {
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> prevMonthRowDictionary = null;
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable prevMonthBangThuTienTable = viewBangThuTienTableAdapter.GetDataByNgayTinhAndHocSinhId(ngayTinh, hocSinhId);
            List<int> prevMonthBangThuTienIds = new List<int>(prevMonthBangThuTienTable.Rows.Count);

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in prevMonthBangThuTienTable)
            {
                prevMonthBangThuTienIds.Add(row.BangThuTienId);
            }

            if (!ListUtil.IsEmpty(prevMonthBangThuTienIds))
            {
                QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable prevMonthBTTKTDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(String.Join(",", prevMonthBangThuTienIds));
                QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable prevMonthPhieuThuDataTable = phieuThuTableAdapter.GetDataByHocSinhIdAndNgayTinh(-1, ngayTinh);
                prevMonthRowDictionary = new Dictionary<int, Dao.QLMamNonDs.ViewBangThuTienRow>();

                foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in prevMonthBangThuTienTable)
                {
                    BangThuTienUtil.EvaluateValuesForViewBangThuTienRow(row, null, prevMonthBTTKTDataTable, prevMonthPhieuThuDataTable, true, false, true);
                    prevMonthRowDictionary.Add(row.HocSinhId, row);
                }
            }

            return prevMonthRowDictionary;
        }
    }
}
