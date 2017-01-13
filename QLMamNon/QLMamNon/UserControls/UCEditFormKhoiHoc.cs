using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Facade;
using QLMamNon.Components.Data.Static;
using ACG.Core.WinForm.Util;

namespace QLMamNon.UserControls
{
    public partial class UCEditFormKhoiHoc : UCCRUDBase
    {
        public UCEditFormKhoiHoc()
        {
            InitializeComponent();
        }

        private void UCEditFormKhoiHoc_Load(object sender, EventArgs e)
        {
            this.truongRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.TruongHoc);
        }

        private void UCEditFormKhoiHoc_Enter(object sender, EventArgs e)
        {
            QLMamNon.Dao.QLMamNonDs.KhoiRow row = this.GridView.GetFocusedDataRow() as QLMamNon.Dao.QLMamNonDs.KhoiRow;

            if (row != null)
            {
                this.cmbTruong.EditValue = StaticDataUtil.GetTruongIdByKhoiId(this.khoiTruongTableAdapter, row.KhoiId);
            }
        }
    }
}
