using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Facade;
using QLMamNon.UserControls;
using QLThuChi;
using QLMamNon.Properties;

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
            this.DanhMuc = DanhMucConstant.ThongTinHocSinh;
            this.FormKey = AppForms.FormThongTinHocSinh;

            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormThongTinHocSinh();
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.hocSinhTableAdapter.Adapter, this.hocSinhRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.HocSinhDataTable);
        }

        private void FrmThongTinHocSinh_Load(object sender, EventArgs e)
        {
            this.quanHuyenRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.QuanHuyen);
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
            this.keyValuePairBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.TrangThaiHS);
            this.cmbThoiHoc.EditValue = 0;
            this.initCmbNamSinh();
            this.loadThongTinHocSinh(null, null, null, null, null, null, 0);
        }

        private void initCmbNamSinh()
        {
            List<int> namSinhs = new List<int>();

            for (int i = Settings.Default.NamSinhStart; i < DateTime.Now.Year; i++)
            {
                namSinhs.Add(i);
            }

            this.cmbNamSinh.Properties.Items.AddRange(namSinhs);
        }

        private void gvMain_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "GioiTinh" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object objGioiTinh = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "GioiTinh");
                if (objGioiTinh != DBNull.Value)
                {
                    sbyte gioiTinh = (sbyte)objGioiTinh;
                    switch (gioiTinh)
                    {
                        case 0: e.DisplayText = "Nữ"; break;
                        case 1: e.DisplayText = "Nam"; break;
                    }
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
                    e.DisplayText = StaticDataUtil.GetThanhPhoById(StaticDataFacade.Get(StaticDataKeys.TinhThanhPho) as QLMamNon.Dao.QLMamNonDs.ThanhPhoDataTable, (int)tinhId);
                }
            }
            else if (e.Column.FieldName == "QuanHuyenId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object quanHuyenId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "QuanHuyenId");
                if (quanHuyenId != DBNull.Value)
                {
                    e.DisplayText = StaticDataUtil.GetQuanHuyenById(StaticDataFacade.Get(StaticDataKeys.QuanHuyen) as QLMamNon.Dao.QLMamNonDs.QuanHuyenDataTable, (int)quanHuyenId);
                }
            }
            else if (e.Column.FieldName == "PhuongXaId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object phuongXaId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "PhuongXaId");
                if (phuongXaId != DBNull.Value)
                {
                    e.DisplayText = StaticDataUtil.GetPhuongXaById(StaticDataFacade.Get(StaticDataKeys.PhuongXa) as QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable, (int)phuongXaId);
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
            QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable table = StaticDataFacade.Get(StaticDataKeys.PhuongXa) as QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable;
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
            this.loadThongTinHocSinh((int?)cmbQuanHuyen.EditValue, (int?)cmbPhuongXa.EditValue, (int?)cmbLop.EditValue, IntUtil.StringToInt((string)cmbThang.Text), IntUtil.StringToInt((string)cmbNamSinh.Text),
                (DateTime?)cmbNgaySinh.EditValue, (int?)cmbThoiHoc.EditValue);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.cmbQuanHuyen.EditValue = null;
            this.cmbPhuongXa.EditValue = null;
            this.cmbLop.EditValue = null;
            this.cmbThang.EditValue = null;
            this.cmbNamSinh.EditValue = null;
            this.cmbThoiHoc.EditValue = null;
            this.cmbNgaySinh.EditValue = null;
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

        private void loadThongTinHocSinh(int? quan, int? phuong, int? lop, int? thangSinh, int? namSinh, DateTime? ngaySinh, int? thoiHoc)
        {
            QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable = this.hocSinhTableAdapter.GetDataForThongTinHocSinh(quan, phuong, ngaySinh, thangSinh, lop, thoiHoc, namSinh);
            hocSinhTable.CreatedDateColumn.DefaultValue = DateTime.Now;
            ThongTinHocSinhUtil.EvaluateLopInfoForHocSinhTable(hocSinhLopTableAdapter, hocSinhTable);
            hocSinhTable.AcceptChanges();
            this.DataTable = hocSinhTable;
            this.hocSinhRowBindingSource.DataSource = this.DataTable;
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
                    hocSinhRow.PhuongXa = StaticDataUtil.GetPhuongXaById(StaticDataFacade.Get(StaticDataKeys.PhuongXa) as QLMamNon.Dao.QLMamNonDs.PhuongXaDataTable, hocSinhRow.PhuongXaId);
                }

                if (!hocSinhRow.IsQuanHuyenIdNull())
                {
                    hocSinhRow.QuanHuyen = StaticDataUtil.GetQuanHuyenById(StaticDataFacade.Get(StaticDataKeys.QuanHuyen) as QLMamNon.Dao.QLMamNonDs.QuanHuyenDataTable, hocSinhRow.QuanHuyenId);
                }
            }

            rpt.hocSinhBindingSource.DataSource = rows;
        }

        #endregion
    }
}