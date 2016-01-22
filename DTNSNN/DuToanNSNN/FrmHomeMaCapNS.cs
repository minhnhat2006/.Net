using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;

namespace DuToanNSNN
{
    public partial class FrmHome
    {
        #region Ma Cap NS

        private void gridView3_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.UpdateDatasource(grdMaCapNS, maCapNSTableAdapter.Adapter, "MaCapNS");
        }

        #endregion
    }
}
