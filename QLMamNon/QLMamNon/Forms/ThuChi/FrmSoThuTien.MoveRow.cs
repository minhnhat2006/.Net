using System;
using System.Data;
using System.Threading;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmSoThuTien
    {
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (this.viewBangThuTienRowBindingSource.Current == null)
            {
                return;
            }

            this.setCurrentViewBangThuTienRowSTT(this.viewBangThuTienRowBindingSource.Current, 0);

            for (int i = 0; i < this.GridViewMain.RowCount - 1; i++)
            {
                if (this.viewBangThuTienRowBindingSource.Position < this.viewBangThuTienRowBindingSource.Count - 1)
                {
                    this.viewBangThuTienRowBindingSource.MoveNext();
                    this.setCurrentViewBangThuTienRowSTT(this.viewBangThuTienRowBindingSource.Current, i + 2);
                }
            }

            this.viewBangThuTienRowBindingSource.MoveFirst();
            this.setCurrentViewBangThuTienRowSTT(this.viewBangThuTienRowBindingSource.Current, 1);
        }

        private void setCurrentViewBangThuTienRowSTT(object current, int stt)
        {
            DataRowView rowView = current as DataRowView;
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow;

            if (bangThuTienRow.STT != stt)
            {
                bangThuTienRow.STT = stt;
            }
        }

        private int getCurrentViewBangThuTienRowSTT(object current)
        {
            DataRowView rowView = current as DataRowView;
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow;
            return bangThuTienRow.STT;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (this.viewBangThuTienRowBindingSource.Current == null)
            {
                return;
            }

            int stt = this.getCurrentViewBangThuTienRowSTT(this.viewBangThuTienRowBindingSource.Current);

            if (stt == 1)
            {
                return;
            }

            object row = this.GridViewMain.GetRow(this.GridViewMain.FocusedRowHandle);
            object prevRow = this.GridViewMain.GetRow(this.GridViewMain.FocusedRowHandle - 1);
            this.setCurrentViewBangThuTienRowSTT(prevRow, stt);
            this.setCurrentViewBangThuTienRowSTT(row, stt - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.viewBangThuTienRowBindingSource.Current == null)
            {
                return;
            }

            int stt = this.getCurrentViewBangThuTienRowSTT(this.viewBangThuTienRowBindingSource.Current);

            if (stt == this.viewBangThuTienRowBindingSource.Count)
            {
                return;
            }

            object row = this.GridViewMain.GetRow(this.GridViewMain.FocusedRowHandle);
            object nextRow = this.GridViewMain.GetRow(this.GridViewMain.FocusedRowHandle + 1);
            this.setCurrentViewBangThuTienRowSTT(nextRow, stt);
            this.setCurrentViewBangThuTienRowSTT(row, stt + 1);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (this.viewBangThuTienRowBindingSource.Current == null)
            {
                return;
            }

            this.setCurrentViewBangThuTienRowSTT(this.viewBangThuTienRowBindingSource.Current, this.viewBangThuTienRowBindingSource.Count + 1);
            this.viewBangThuTienRowBindingSource.MoveFirst();

            for (int i = 0; i < this.GridViewMain.RowCount; i++)
            {
                this.setCurrentViewBangThuTienRowSTT(this.viewBangThuTienRowBindingSource.Current, i + 1);
                this.viewBangThuTienRowBindingSource.MoveNext();
            }
        }
    }
}
