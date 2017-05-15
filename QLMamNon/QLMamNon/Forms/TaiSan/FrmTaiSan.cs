using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Forms.Resource;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmTaiSan : CRUDForm
    {
        public FrmTaiSan()
        {
            InitializeComponent();

            this.TablePrimaryKey = "TaiSanId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.QuanLyTaiSan;
            this.FormKey = AppForms.FormTaiSan;

            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormTaiSan();
            this.loadTaiSanData();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.viewTaiSanTableAdapter.Adapter, this.viewTaiSanRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.ViewTaiSanDataTable);
        }

        private void loadTaiSanData()
        {
            QLMamNon.Dao.QLMamNonDs.ViewTaiSanDataTable dataTable = this.viewTaiSanTableAdapter.GetData();

            foreach (QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow row in dataTable)
            {
                row.PhanLoaiTaiSan = StaticDataUtil.GetPhanLoaiChiNameByPhieuChiId(this.phieuChiTableAdapter, row.PhieuChiId);
            }

            this.viewTaiSanRowBindingSource.DataSource = dataTable;
        }
    }
}