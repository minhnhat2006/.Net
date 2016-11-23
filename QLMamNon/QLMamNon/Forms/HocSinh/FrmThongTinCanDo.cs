﻿using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using MySql.Data.MySqlClient;
using QLMamNon.Facade;
using QLMamNon.Forms.Resource;
using QLMamNon.UserControls;
using QLMamNon.Workflow;
using QLMamNon.Components.Data.Static;
using DevExpress.XtraPrinting;
using System.Collections.Generic;
using ACG.Core.WinForm.Util;

namespace QLMamNon.Forms.HocSinh
{
    public partial class FrmThongTinCanDo : CRUDForm
    {
        #region Properties

        #endregion

        #region Events

        public FrmThongTinCanDo()
            : base()
        {
            InitializeComponent();

            this.TablePrimaryKey = "HocSinhId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.ThongTinHocSinh;
            this.FormKey = AppForms.FormThongTinHocSinh;

            this.hocSinhRowBindingSource.DataSource = this.hocSinhTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormThongTinHocSinh();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.hocSinhTableAdapter.Adapter, this.hocSinhRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.HocSinhDataTable);
        }

        private void FrmThongTinCanDo_Load(object sender, EventArgs e)
        {
            this.thanhPhoRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.TinhThanhPho);
            this.truongRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.TruongHoc);
            this.namHocBindingSource.DataSource = StaticDataFacade.Get(DataKeys.NamHoc);
        }

        private void gvMain_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "GioiTinh" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                sbyte gioiTinh = (sbyte)view.GetListSourceRowCellValue(e.ListSourceRowIndex, "GioiTinh");
                switch (gioiTinh)
                {
                    case 0: e.DisplayText = "Nữ"; break;
                    case 1: e.DisplayText = "Nam"; break;
                }
            }
            else if (e.Column.FieldName == "TinhThanhPhoId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object tinhId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "TinhThanhPhoId");
                if (tinhId != DBNull.Value)
                {
                    e.DisplayText = StaticDataUtil.GetThanhPhoById(StaticDataFacade.Get(DataKeys.TinhThanhPho) as QLMamNon.Dao.QLMamNonDs.ThanhPhoDataTable, (int)tinhId);
                }
            }
            else if (e.Column.FieldName == "QuanHuyenId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object quanHuyenId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "QuanHuyenId");
                if (quanHuyenId != DBNull.Value)
                {
                    e.DisplayText = StaticDataUtil.GetQuanHuyenById(StaticDataFacade.Get(DataKeys.QuanHuyen) as QLMamNon.Dao.QLMamNonDs.QuanHuyenDataTable, (int)quanHuyenId);
                }
            }
            else if (e.Column.FieldName == "PhuongXaId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object phuongXaId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "PhuongXaId");
                if (phuongXaId != DBNull.Value)
                {
                    e.DisplayText = StaticDataUtil.GetPhuongXaById(StaticDataFacade.Get(DataKeys.PhuongXa) as QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable, (int)phuongXaId);
                }
            }
            else if (e.Column.FieldName == "NgaySinh" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle && e.Value != DBNull.Value)
            {
                DateTime ngaySinh = (DateTime)e.Value;
                if (e.Column.Caption == "Ngay")
                {
                    e.DisplayText = ngaySinh.Day.ToString();
                }
                else if (e.Column.Caption == "Thang")
                {
                    e.DisplayText = ngaySinh.Month.ToString();
                }
                else if (e.Column.Caption == "Nam")
                {
                    e.DisplayText = ngaySinh.Year.ToString();
                }
            }
            else if (e.Column.Caption == this.GridViewColumnSequenceName && e.ListSourceRowIndex >= 0)
            {
                e.DisplayText = String.Format("{0}", e.ListSourceRowIndex + 1);
            }
        }

        private void cmbThanhPho_EditValueChanged(object sender, EventArgs e)
        {
            QLMamNon.Dao.QLMamNonDs.QuanHuyenDataTable table = StaticDataFacade.Get(DataKeys.QuanHuyen) as QLMamNon.Dao.QLMamNonDs.QuanHuyenDataTable;
            if (cmbThanhPho.EditValue != DBNull.Value && cmbThanhPho.EditValue != null)
            {
                this.quanHuyenRowBindingSource.DataSource = table.Select(String.Format("ThanhPhoId={0}", cmbThanhPho.EditValue));
            }
            else
            {
                this.quanHuyenRowBindingSource.DataSource = null;
            }
        }

        private void cmbQuanHuyen_EditValueChanged(object sender, EventArgs e)
        {
            QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable table = StaticDataFacade.Get(DataKeys.PhuongXa) as QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable;
            if (cmbQuanHuyen.EditValue != DBNull.Value && cmbQuanHuyen.EditValue != null)
            {
                this.phuongXaRowBindingSource.DataSource = table.Select(String.Format("QuanHuyenId={0}", cmbQuanHuyen.EditValue));
            }
            else
            {
                this.phuongXaRowBindingSource.DataSource = null;
            }
        }

        private void cmbTruongHoc_EditValueChanged(object sender, EventArgs e)
        {
            this.khoiRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.KhoiHoc);
        }

        private void cmbKhoiHoc_EditValueChanged(object sender, EventArgs e)
        {
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.LopHoc);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();
            if (!ControlUtil.IsEditValueNull(this.cmbThanhPho))
            {
                filters.Add(string.Format("[TinhThanhPhoId] = {0}", this.cmbThanhPho.EditValue));
            }

            if (!ControlUtil.IsEditValueNull(this.cmbQuanHuyen))
            {
                filters.Add(string.Format("[QuanHuyenId] = {0}", this.cmbQuanHuyen.EditValue));
            }

            if (!ControlUtil.IsEditValueNull(this.cmbPhuongXa))
            {
                filters.Add(string.Format("[PhuongXaId] = {0}", this.cmbPhuongXa.EditValue));
            }

            this.gvMain.ActiveFilterString = String.Join(" AND ", filters);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.cmbThanhPho.EditValue = DBNull.Value;
            this.cmbQuanHuyen.EditValue = DBNull.Value;
            this.cmbPhuongXa.EditValue = DBNull.Value;
            this.cmbTruongHoc.EditValue = DBNull.Value;
            this.cmbKhoiHoc.EditValue = DBNull.Value;
            this.cmbLopHoc.EditValue = DBNull.Value;
            this.cmbNamHoc.EditValue = DBNull.Value;
            this.cmbSoLuong.EditValue = DBNull.Value;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            dialog.FileName = "ThongTinHocSinh.xlsx";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.gvMain.ExportToXlsx(dialog.FileName, new XlsxExportOptions(TextExportMode.Text));
            }
        }

        #endregion

        #region Validations

        #endregion
    }
}