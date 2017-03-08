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
using QLMamNon.Facade;

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
                Object truongIdObj = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "TruongId");

                if (!DBNull.Value.Equals(truongIdObj))
                {
                    int truongId = (int)truongIdObj;
                    e.DisplayText = StaticDataUtil.GetTruongNameByTruongId(truongId);
                }
            }
        }

        private void loadKhoiData()
        {
            QLMamNon.Dao.QLMamNonDs.KhoiDataTable dataTable = this.khoiTableAdapter.GetData();

            foreach (QLMamNon.Dao.QLMamNonDs.KhoiRow row in dataTable)
            {
                int? truongId = StaticDataUtil.GetTruongIdByKhoiId(this.khoiTruongTableAdapter, row.KhoiId);
                if (truongId.HasValue)
                {
                    row.TruongId = truongId.Value;
                }
            }

            this.khoiRowBindingSource.DataSource = dataTable;
        }

        protected override void onSaving()
        {
            DataTable table = this.DataTable.GetChanges();
            if (table != null)
            {
                List<DataRow> deletedRow = new List<DataRow>();
                List<DataRow> addedRow = new List<DataRow>();
                List<DataRow> modifiedRow = new List<DataRow>();

                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        deletedRow.Add(row);
                    }
                    else if (row.RowState == DataRowState.Added)
                    {
                        addedRow.Add(row);
                    }
                    if (row.RowState == DataRowState.Modified)
                    {
                        modifiedRow.Add(row);
                    }
                }

                base.onSaving();

                foreach (DataRow row in deletedRow)
                {
                    QLMamNon.Dao.QLMamNonDs.KhoiRow khoiRow = row as QLMamNon.Dao.QLMamNonDs.KhoiRow;
                    this.khoiTruongTableAdapter.DeleteKhoiTruongByKhoiId(khoiRow.KhoiId);
                }

                foreach (DataRow row in modifiedRow)
                {
                    QLMamNon.Dao.QLMamNonDs.KhoiRow khoiRow = row as QLMamNon.Dao.QLMamNonDs.KhoiRow;
                    QLMamNon.Dao.QLMamNonDs.KhoiTruongRow khoiTruongRow = StaticDataUtil.GetKhoiTruongByKhoiId(this.khoiTruongTableAdapter, khoiRow.KhoiId);

                    if (khoiTruongRow != null)
                    {
                        this.khoiTruongTableAdapter.DeleteKhoiTruongByKhoiId(khoiRow.KhoiId);
                    }

                    if (!khoiRow.IsTruongIdNull())
                    {
                        this.khoiTruongTableAdapter.Insert(khoiRow.KhoiId, khoiRow.TruongId);
                    }
                }

                foreach (DataRow row in addedRow)
                {
                    QLMamNon.Dao.QLMamNonDs.KhoiRow khoiRow = row as QLMamNon.Dao.QLMamNonDs.KhoiRow;

                    if (!khoiRow.IsTruongIdNull())
                    {
                        this.khoiTruongTableAdapter.Insert(khoiRow.KhoiId, khoiRow.TruongId);
                    }
                }
            }
        }
    }
}