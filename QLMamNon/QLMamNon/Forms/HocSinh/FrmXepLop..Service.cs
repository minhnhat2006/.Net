using System;
using System.Data;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using System.Collections.Generic;

namespace QLMamNon.Forms.HocSinh
{
    public partial class FrmXepLop
    {
        private bool isHocSinhExisted(BindingSource hocSinhRowBindingSource, int hocSinhId)
        {
            foreach (DataRowView rowView in hocSinhRowBindingSource)
            {
                QLMamNon.Dao.QLMamNonDs.HocSinhRow row = rowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;

                if (hocSinhId == row.HocSinhId)
                {
                    return true;
                }
            }

            return false;
        }

        private void loadHocSinhToGridDi()
        {
            if (this.hocSinhRowBindingSourceDi.DataSource != null)
            {
                ((QLMamNon.Dao.QLMamNonDs.HocSinhDataTable)this.hocSinhRowBindingSourceDi.DataSource).Clear();
            }

            int? namHoc = (int?)this.cmbNamHocDi.EditValue;
            int? lopHoc = (int?)this.cmbLopHocDi.EditValue;
            QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable;

            if (lopHoc == null)
            {
                hocSinhTable = this.hocSinhTableAdapter.GetHocSinhNotAssignedToLop();
            }
            else
            {
                hocSinhTable = this.hocSinhTableAdapter.GetHocSinhByParams(new DateTime(namHoc.Value + 1, 1, 1), null, lopHoc, null);
            }

            ThongTinHocSinhUtil.evaluateLopInfoForHocSinhTable(hocSinhLopTableAdapter, hocSinhTable);

            this.hocSinhRowBindingSourceDi.DataSource = hocSinhTable;
        }

        private void loadHocSinhToGridDen()
        {
            if (ControlUtil.IsEditValueNull(this.cmbLopHocDen))
            {
                return;
            }

            QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable = this.hocSinhTableAdapter.GetHocSinhByParams(DateTime.Now, null, (int)this.cmbLopHocDen.EditValue, null);

            ThongTinHocSinhUtil.evaluateLopInfoForHocSinhTable(hocSinhLopTableAdapter, hocSinhTable);

            this.hocSinhRowBindingSourceDen.DataSource = hocSinhTable;
        }
    }
}
