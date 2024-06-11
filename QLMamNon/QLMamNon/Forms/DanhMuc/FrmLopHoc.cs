using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao;
using QLMamNon.Facade;
using QLMamNon.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmLopHoc : CRUDForm<lop>
    {
        public FrmLopHoc()
        {
            InitializeComponent();

            this.TablePrimaryKey = "LopId";
            this.DanhMuc = DanhMucConstant.LopHoc;
            this.FormKey = AppForms.FormDanhMucTruongHoc;

            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormLopHoc();
            this.loadLopData();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.lopRowBindingSource.DataSource);
        }

        private void gvMain_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "KhoiId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                Object khoiIdObj = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "KhoiId");

                if (khoiIdObj != null)
                {
                    int khoiId = (int)khoiIdObj;
                    e.DisplayText = StaticDataUtil.GetKhoiNameByKhoiId(khoiId);
                }
            }
        }

        private void loadLopData()
        {
            Entities.lops.Load();
            BindingList<lop> dataTable = Entities.lops.Local.ToBindingList();

            foreach (lop row in dataTable)
            {
                int? khoiId = StaticDataUtil.GetKhoiIdByLopId(Entities, row.LopId);
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
                List<lop> deletedRow = new List<lop>();
                List<lop> addedRow = new List<lop>();
                List<lop> modifiedRow = new List<lop>();

                foreach (lop row in this.DataTable)
                {
                    if (Entities.Entry(row).State == EntityState.Deleted)
                    {
                        deletedRow.Add(row);
                    }
                    else if (Entities.Entry(row).State == EntityState.Added)
                    {
                        addedRow.Add(row);
                    }
                    if (Entities.Entry(row).State == EntityState.Modified)
                    {
                        modifiedRow.Add(row);
                    }
                }


                foreach (lop row in deletedRow)
                {
                    Entities.deleteLopKhoiByLopId(row.LopId);
                }

                foreach (lop row in modifiedRow)
                {
                    int? khoiId = StaticDataUtil.GetKhoiIdByLopId(Entities, row.LopId);

                    if (khoiId != null)
                    {
                        Entities.deleteLopKhoiByLopId(row.LopId);
                    }

                    if (row.KhoiId != null)
                    {
                        lop_khoi lopKhoi = new lop_khoi()
                        {
                            LopId = row.LopId,
                            KhoiId = row.KhoiId.Value
                        };
                        Entities.lop_khoi.Add(lopKhoi);
                    }
                }

                foreach (lop row in addedRow)
                {
                    if (row.KhoiId != null)
                    {
                        lop_khoi lopKhoi = new lop_khoi()
                        {
                            LopId = row.LopId,
                            KhoiId = row.KhoiId.Value
                        };
                        Entities.lop_khoi.Add(lopKhoi);
                    }
                }

                base.onSaving();

                // Reload StaticData for Lop
                StaticDataFacade.Reload(StaticDataKeys.LopHoc);
            }
        }
    }
}