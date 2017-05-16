using System;
using QLMamNon.Components.Data.Static;
using QLMamNon.Facade;

namespace QLMamNon.UserControls
{
    public partial class UCEditFormLopHoc : UCCRUDBase
    {
        public UCEditFormLopHoc()
        {
            InitializeComponent();
        }

        private void UCEditFormLopHoc_Load(object sender, EventArgs e)
        {
            this.khoiRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.KhoiHoc);
        }

        private void UCEditFormLopHoc_Enter(object sender, EventArgs e)
        {
            QLMamNon.Dao.QLMamNonDs.LopRow row = this.GridView.GetFocusedDataRow() as QLMamNon.Dao.QLMamNonDs.LopRow;

            if (row != null)
            {
                this.cmbKhoi.EditValue = StaticDataUtil.GetKhoiIdByLopId(this.lopKhoiTableAdapter, row.LopId);
            }
        }
    }
}
