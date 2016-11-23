using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace QLMamNon.UserControls
{
    public partial class UCCRUDBase : EditFormUserControl
    {
        #region Properties

        public GridView GridView { get; set; }

        #endregion
    }
}
