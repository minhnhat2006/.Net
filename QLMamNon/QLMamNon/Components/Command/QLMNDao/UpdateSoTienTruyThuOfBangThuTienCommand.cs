using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLMamNon.Dao.QLMamNonDsTableAdapters;

namespace QLMamNon.Components.Command.QLMNDao
{
    public class UpdateSoTienTruyThuOfBangThuTienCommand : QLMNDaoCommand
    {
        public const string ParameterCurrentViewBangThuTien = "CurrentViewBangThuTien";
        public const string ParameterViewBangThuTienTableAdapter = "ViewBangThuTienTableAdapter";
        public const string ParameterSoTienAdded = "SoTienAdded";

        protected override void onExecute()
        {
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow currentViewBangThuTien = this.CommandParameter[ParameterCurrentViewBangThuTien] as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow;
            ViewBangThuTienTableAdapter viewBangThuTienTableAdapter = this.CommandParameter[ParameterViewBangThuTienTableAdapter] as ViewBangThuTienTableAdapter;
            long soTienAdded = (long)this.CommandParameter[ParameterSoTienAdded];
            viewBangThuTienTableAdapter.UpdateSoTienTruyThuByHocSinhAndNgayUpdated(currentViewBangThuTien.HocSinhId, currentViewBangThuTien.NgayTinh, soTienAdded);
        }
    }
}
