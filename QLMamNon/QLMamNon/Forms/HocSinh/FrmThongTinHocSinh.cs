using System;
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
using QLThuChi;

namespace QLMamNon.Forms.HocSinh
{
    public partial class FrmThongTinHocSinh : CRUDForm
    {
        #region Properties

        #endregion

        #region Events

        public FrmThongTinHocSinh()
            : base()
        {
            InitializeComponent();

            this.TablePrimaryKey = "HocSinhId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.ThongTinHocSinh;
            this.FormKey = AppForms.FormThongTinHocSinh;

            this.hocSinhRowBindingSource.DataSource = this.hocSinhTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormThongTinHocSinh();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.hocSinhTableAdapter.Adapter, this.hocSinhRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.HocSinhDataTable);
            this.loadThongTinHocSinh(this.DataTable as QLMamNon.Dao.QLMamNonDs.HocSinhDataTable);
        }

        private void FrmThongTinHocSinh_Load(object sender, EventArgs e)
        {
            this.quanHuyenRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.QuanHuyen);
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.LopHoc);
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
            else if (e.Column.FieldName == "ThoiHoc" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                Object thoiHoc = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThoiHoc");
                e.DisplayText = (thoiHoc != null && thoiHoc.Equals(true)) ? "Thôi học" : "Đang học";
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
            else if (e.Column.Caption == "NgaySinh" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle && e.Value != DBNull.Value)
            {
                object ngaySinhObj = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "NgaySinh");
                if (ngaySinhObj != DBNull.Value)
                {
                    DateTime ngaySinh = (DateTime)ngaySinhObj;
                    e.DisplayText = ngaySinh.Day.ToString();
                }
            }
            else if (e.Column.Caption == "ThangSinh" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle && e.Value != DBNull.Value)
            {
                object ngaySinhObj = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "NgaySinh");
                if (ngaySinhObj != DBNull.Value)
                {
                    DateTime ngaySinh = (DateTime)ngaySinhObj;
                    e.DisplayText = ngaySinh.Month.ToString();
                }
            }
            else if (e.Column.Caption == "NamSinh" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle && e.Value != DBNull.Value)
            {
                object ngaySinhObj = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "NgaySinh");
                if (ngaySinhObj != DBNull.Value)
                {
                    DateTime ngaySinh = (DateTime)ngaySinhObj;
                    e.DisplayText = ngaySinh.Year.ToString();
                }
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();
            if (!ControlUtil.IsEditValueNull(this.cmbQuanHuyen))
            {
                filters.Add(string.Format("[QuanHuyenId] = {0}", this.cmbQuanHuyen.EditValue));
            }

            if (!ControlUtil.IsEditValueNull(this.cmbPhuongXa))
            {
                filters.Add(string.Format("[PhuongXaId] = {0}", this.cmbPhuongXa.EditValue));
            }

            if (!ControlUtil.IsEditValueNull(this.cmbLop))
            {
                filters.Add(string.Format("[LopDangHoc] = '{0}'", this.cmbLop.Text));
            }

            if (!StringUtil.IsEmpty(this.cmbThang.Text))
            {
                filters.Add(string.Format("[ThangSinh] = {0}", this.cmbThang.Text));
            }

            if (!StringUtil.IsEmpty(this.cmbNgaySinh.Text))
            {
                filters.Add(string.Format("[NgaySinh] = #{0}#", this.cmbNgaySinh.Text));
            }

            this.gvMain.ActiveFilterString = String.Join(" AND ", filters);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.cmbQuanHuyen.EditValue = DBNull.Value;
            this.cmbPhuongXa.EditValue = DBNull.Value;
            this.cmbLop.EditValue = DBNull.Value;
            this.cmbNgaySinh.EditValue = DBNull.Value;
            this.cmbThang.EditValue = DBNull.Value;
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            RptThongTinHocSinh rpt = new RptThongTinHocSinh();
            this.fillReportHocSinh(rpt);
            FormMainFacade.ShowReport(rpt);
        }

        #endregion

        #region Validation

        #endregion

        #region Helper

        private void loadThongTinHocSinh(QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable)
        {
            List<int> hocSinhIds = new List<int>(hocSinhTable.Rows.Count);
            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow row in hocSinhTable)
            {
                hocSinhIds.Add(row.HocSinhId);
            }

            Dictionary<int, QLMamNon.Dao.QLMamNonDs.HocSinhLopRow> hocSinhIdsToHocSinhLops = StaticDataUtil.GetHocSinhLopsByHocSinhIds(hocSinhLopTableAdapter, hocSinhIds, DateTime.Now); ;
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.LopRow> hocSinhIdsToLops = StaticDataUtil.GetLopsByHocSinhIds(hocSinhLopTableAdapter, hocSinhIds, DateTime.Now);

            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow row in hocSinhTable)
            {
                row.ThangSinh = row.NgaySinh.Month;

                if (hocSinhIdsToLops.ContainsKey(row.HocSinhId))
                {
                    QLMamNon.Dao.QLMamNonDs.LopRow lop = hocSinhIdsToLops[row.HocSinhId];
                    row.LopDangHoc = lop.Name;
                }

                if (hocSinhIdsToHocSinhLops.ContainsKey(row.HocSinhId))
                {
                    QLMamNon.Dao.QLMamNonDs.HocSinhLopRow hocSinhLop = hocSinhIdsToHocSinhLops[row.HocSinhId];
                    row.NgayVaoLop = hocSinhLop.DateJoin;
                }
            }
        }

        private void fillReportHocSinh(RptThongTinHocSinh rpt)
        {
            List<object> rows = new List<object>(this.GridViewMain.RowCount);

            for (int i = 0; i < this.GridViewMain.DataRowCount; i++)
            {
                object dataRow = this.GridViewMain.GetRow(this.GridViewMain.GetVisibleRowHandle(i));
                rows.Add(dataRow);

                QLMamNon.Dao.QLMamNonDs.HocSinhRow hocSinhRow = (dataRow as DataRowView).Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;
                hocSinhRow.STT = i + 1;

                if (!hocSinhRow.IsPhuongXaIdNull())
                {
                    hocSinhRow.PhuongXa = StaticDataUtil.GetPhuongXaById(StaticDataFacade.Get(DataKeys.PhuongXa) as QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable, hocSinhRow.PhuongXaId);
                }

                if (!hocSinhRow.IsQuanHuyenIdNull())
                {
                    hocSinhRow.QuanHuyen = StaticDataUtil.GetQuanHuyenById(StaticDataFacade.Get(DataKeys.QuanHuyen) as QLMamNon.Dao.QLMamNonDs.QuanHuyenDataTable, hocSinhRow.QuanHuyenId);
                }
            }

            rpt.hocSinhBindingSource.DataSource = rows;
        }

        #endregion
    }
}