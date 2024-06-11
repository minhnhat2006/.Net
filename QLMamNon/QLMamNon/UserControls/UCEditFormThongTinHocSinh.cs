using QLMamNon.Components.Data.Static;
using QLMamNon.Dao;
using QLMamNon.Facade;
using System;
using System.Collections.Generic;

namespace QLMamNon.UserControls
{
    public partial class UCEditFormThongTinHocSinh : UCCRUDBase
    {
        public UCEditFormThongTinHocSinh()
        {
            InitializeComponent();
        }

        private void UCEditFormThongTinHocSinh_Load(object sender, EventArgs e)
        {
            this.thanhPhoRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.TinhThanhPho);
        }

        private void cmbTinh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbTinh.EditValue != null)
            {
                List<quanhuyen> table = StaticDataFacade.Get(StaticDataKeys.QuanHuyen) as List<quanhuyen>;
                this.quanHuyenRowBindingSource.DataSource = table.FindAll(q => q.ThanhPhoId == (int?)cmbTinh.EditValue);
            }
        }

        private void cmbQuan_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbQuan.EditValue != null)
            {
                List<phuongxa> table = StaticDataFacade.Get(StaticDataKeys.PhuongXa) as List<phuongxa>;
                this.phuongXaRowBindingSource.DataSource = table.FindAll(p => p.QuanHuyenId == (int?)cmbQuan.EditValue);
            }
        }
    }
}
