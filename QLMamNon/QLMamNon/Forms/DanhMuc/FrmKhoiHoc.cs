using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLMamNon.Forms.Resource;
using QLMamNon.UserControls;
using DevExpress.XtraGrid.Views.Base;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmKhoiHoc : CRUDForm
    {
        public FrmKhoiHoc()
        {
            InitializeComponent();

            this.TablePrimaryKey = "KhoiId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.KhoiHoc;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormKhoiHoc();
            this.loadKhoiData();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.khoiTableAdapter.Adapter, this.khoiRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.KhoiDataTable);
        }

        private void gvMain_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "TruongId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                int truongId = (int)view.GetListSourceRowCellValue(e.ListSourceRowIndex, "TruongId");
                e.DisplayText = StaticDataUtil.GetTruongNameByTruongId(truongId);
            }
        }

        private void loadKhoiData()
        {
            QLMamNon.Dao.QLMamNonDs.KhoiDataTable dataTable = this.khoiTableAdapter.GetData();

            foreach (QLMamNon.Dao.QLMamNonDs.KhoiRow row in dataTable)
            {
                row.TruongId = StaticDataUtil.GetTruongIdByKhoiId(this.khoiTruongTableAdapter, row.KhoiId);
            }

            this.khoiRowBindingSource.DataSource = dataTable;
        }

        protected override void onSaving()
        {
            base.onSaving();
        }
    }
}