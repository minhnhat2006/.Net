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
            this.khoiRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.KhoiHoc);
        }

        private void UCEditFormLopHoc_Enter(object sender, EventArgs e)
        {
            int lopId = (int)this.GridView.GetFocusedRowCellValue("LopId");
            this.cmbKhoi.EditValue = StaticDataUtil.GetKhoiIdByLopId(this.lopKhoiTableAdapter, lopId);
        }
    }
}
