using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Components.Data.Static;
using QLMamNon.Dao;
using QLMamNon.Facade;

namespace QLMamNon.UserControls
{
    public partial class UCCRUDBase : EditFormUserControl
    {
        #region Properties

        protected qlmamnonEntities Entities { get; set; }

        public GridView GridView { get; set; }

        #endregion

        public UCCRUDBase()
        {
            this.Entities = StaticDataFacade.GetQLMNEntities();
        }
    }
}
