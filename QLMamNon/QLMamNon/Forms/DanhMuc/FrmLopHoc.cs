using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Constant;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmLopHoc : CRUDForm
    {
        public FrmLopHoc()
        {
            InitializeComponent();

            this.TablePrimaryKey = "LopId";
            this.DanhMuc = DanhMucConstant.LopHoc;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormLopHoc();
            this.loadLopData();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.lopTableAdapter.Adapter, this.lopRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.LopDataTable);
        }

        private void gvMain_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "KhoiId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                Object khoiIdObj = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "KhoiId");

                if (!DBNull.Value.Equals(khoiIdObj))
                {
                    int khoiId = (int)khoiIdObj;
                    e.DisplayText = StaticDataUtil.GetKhoiNameByKhoiId(khoiId);
                }
            }
        }

        private void loadLopData()
        {
            QLMamNon.Dao.QLMamNonDs.LopDataTable dataTable = this.lopTableAdapter.GetData();

            foreach (QLMamNon.Dao.QLMamNonDs.LopRow row in dataTable)
            {
                int? khoiId = StaticDataUtil.GetKhoiIdByLopId(this.lopKhoiTableAdapter, row.LopId);
                if (khoiId.HasValue)
                {
                    row.KhoiId = khoiId.Value;
                }
            }

            this.lopRowBindingSource.DataSource = dataTable;
        }

        protected override void onSaving()
        {
            if (this.DataTable != null)
            {
                List<DataRow> deletedRow = new List<DataRow>();
                List<DataRow> addedRow = new List<DataRow>();
                List<DataRow> modifiedRow = new List<DataRow>();

                foreach (DataRow row in this.DataTable.Rows)
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
                    QLMamNon.Dao.QLMamNonDs.LopRow lopRow = row as QLMamNon.Dao.QLMamNonDs.LopRow;
                    this.lopKhoiTableAdapter.DeleteLopKhoiByLopId(lopRow.LopId);
                }

                foreach (DataRow row in modifiedRow)
                {
                    QLMamNon.Dao.QLMamNonDs.LopRow lopRow = row as QLMamNon.Dao.QLMamNonDs.LopRow;
                    int? khoiId = StaticDataUtil.GetKhoiIdByLopId(this.lopKhoiTableAdapter, lopRow.LopId);

                    if (khoiId != null)
                    {
                        this.lopKhoiTableAdapter.DeleteLopKhoiByLopId(lopRow.LopId);
                    }

                    if (!lopRow.IsKhoiIdNull())
                    {
                        this.lopKhoiTableAdapter.Insert(lopRow.LopId, lopRow.KhoiId);
                    }
                }

                foreach (DataRow row in addedRow)
                {
                    QLMamNon.Dao.QLMamNonDs.LopRow lopRow = row as QLMamNon.Dao.QLMamNonDs.LopRow;

                    if (!lopRow.IsKhoiIdNull())
                    {
                        this.lopKhoiTableAdapter.Insert(lopRow.LopId, lopRow.KhoiId);
                    }
                }
            }
        }
    }
}