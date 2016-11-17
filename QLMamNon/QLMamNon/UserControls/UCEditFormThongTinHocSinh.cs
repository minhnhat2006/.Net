﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Facade;
using QLMamNon.Components.Data.Static;

namespace QLMamNon.UserControls
{
    public partial class UCEditFormThongTinHocSinh : EditFormUserControl
    {
        public UCEditFormThongTinHocSinh()
        {
            InitializeComponent();
        }

        private void UCEditFormThongTinHocSinh_Load(object sender, EventArgs e)
        {
            this.thanhPhoRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.TinhThanhPho);
        }

        private void cmbTinh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbTinh.EditValue != DBNull.Value)
            {
                QLMamNon.Dao.QLMamNonDs.QuanHuyenDataTable table = StaticDataFacade.Get(DataKeys.QuanHuyen) as QLMamNon.Dao.QLMamNonDs.QuanHuyenDataTable;
                this.quanHuyenRowBindingSource.DataSource = table.Select(String.Format("ThanhPhoId={0}", cmbTinh.EditValue));
            }
        }

        private void cmbQuan_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbQuan.EditValue != DBNull.Value)
            {
                QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable table = StaticDataFacade.Get(DataKeys.PhuongXa) as QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable;
                this.phuongXaRowBindingSource.DataSource = table.Select(String.Format("QuanHuyenId={0}", cmbQuan.EditValue));
            }
        }
    }
}
