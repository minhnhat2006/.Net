using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Facade;
using QLMamNon.Forms.Resource;
using QLThuChi;
using System.Data;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmSelectHocSinhsToGenerate : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        public QLMamNon.Dao.QLMamNonDs.HocSinhDataTable HocSinhTable { get; set; }

        public List<int> GeneratedHocSinhIds { get; set; }

        public List<QLMamNon.Dao.QLMamNonDs.HocSinhRow> HocSinhRows { get; set; }

        #endregion

        public FrmSelectHocSinhsToGenerate()
        {
            InitializeComponent();
        }

        private void FrmSelectHocSinhsToGenerate_Load(object sender, EventArgs e)
        {
            this.hocSinhRowBindingSource.DataSource = HocSinhTable;
        }

        private void FrmSelectHocSinhsToGenerate_Shown(object sender, EventArgs e)
        {
            this.gvMain.SelectAll();

            foreach (int rowHandler in this.gvMain.GetSelectedRows())
            {
                DataRowView rowView = (DataRowView)this.gvMain.GetRow(rowHandler);
                QLMamNon.Dao.QLMamNonDs.HocSinhRow hocSinhRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;

                if (this.GeneratedHocSinhIds.Contains(hocSinhRow.HocSinhId))
                {
                    this.gvMain.UnselectRow(rowHandler);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            this.HocSinhRows = new List<Dao.QLMamNonDs.HocSinhRow>();
            int[] selectedRowHandlers = this.gvMain.GetSelectedRows();

            for (int i = 0; i < selectedRowHandlers.Length; i++)
            {
                DataRowView rowView = (DataRowView)this.gvMain.GetRow(selectedRowHandlers[i]);
                this.HocSinhRows.Add((QLMamNon.Dao.QLMamNonDs.HocSinhRow)rowView.Row);
            }

            if (ListUtil.IsEmpty(this.HocSinhRows))
            {
                MessageBox.Show("Bạn chưa chọn học sinh", "Chọn học sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}