using QLMamNon.Components.Data.Static;
using QLMamNon.Facade;
using System;
using System.Data;

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
            DataRow row = this.GridView.GetFocusedDataRow();

            if (row != null)
            {
                this.cmbKhoi.EditValue = StaticDataUtil.GetKhoiIdByLopId(Entities, (int)row["LopId"]);
            }
        }
    }
}
