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
        #region Ma Tai Khoan

        private void gridView2_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.UpdateDatasource(grdMaTaiKhoan, maTaiKhoanTableAdapter.Adapter, "MaTaiKhoan");
        }

        #endregion
    }
}
