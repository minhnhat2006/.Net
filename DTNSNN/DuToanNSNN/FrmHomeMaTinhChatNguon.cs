using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace DuToanNSNN
{
    public partial class FrmHome
    {
        #region Ma Tinh Chat Nguon


        private void gridView9_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.UpdateDatasource(grdTinhChatNguon, maTinhChatNguonTableAdapter.Adapter, "MaTinhChatNguon");
        }

        #endregion
    }
}
