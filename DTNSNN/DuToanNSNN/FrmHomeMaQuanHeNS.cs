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
        #region Ma Quan He NS

        private void gridView4_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.UpdateDatasource(grdMaQuanHeNS, maQuanHeNSTableAdapter.Adapter, "MaQuanHeNS");
        }

        #endregion
    }
}
