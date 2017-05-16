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
    public partial class FrmThongTinHocTap : CRUDForm
    {
        #region Properties

        #endregion

        #region Events

        public FrmThongTinHocTap()
            : base()
        {
            InitializeComponent();

            this.TablePrimaryKey = "HocTapId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.ThongTinHocTap;
            this.FormKey = AppForms.FormThongTinHocTap;
            this.loadThongTinHocTap();
            this.InitForm(null, null, null, this.btnLuu, this.btnHuyBo, this.gvMain, this.viewHocTapTableAdapter.Adapter, this.viewHocTapRowBindingSource.DataSource as DataTable);
        }

        private void FrmThongTinHocTap_Load(object sender, EventArgs e)
        {
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
            this.namHocBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.NamHoc);
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
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.loadThongTinHocTap();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.cmbNam.EditValue = DBNull.Value;
            this.cmbThang.EditValue = DBNull.Value;
            this.cmbLop.EditValue = DBNull.Value;
        }

        #endregion

        #region Validation

        #endregion

        #region Helper

        private void loadThongTinHocTap()
        {
            if (ControlUtil.IsEditValueNull(cmbLop) || ControlUtil.IsEditValueNull(cmbNam) || ControlUtil.IsEditValueNull(cmbThang))
            {
                return;
            }

            int lopId = (int)cmbLop.EditValue;
            int nam = (int)cmbNam.EditValue;
            int thang = IntUtil.StringToInt((string)cmbThang.EditValue).Value;
            DateTime ngay = new DateTime(nam, thang, DateTime.DaysInMonth(nam, thang));
            this.viewHocTapRowBindingSource.DataSource = this.viewHocTapTableAdapter.GetDataByLopAndNgay(lopId, ngay);
            this.DataTable = this.viewHocTapRowBindingSource.DataSource as DataTable;

            foreach (QLMamNon.Dao.QLMamNonDs.ViewHocTapRow row in (this.DataTable as QLMamNon.Dao.QLMamNonDs.ViewHocTapDataTable))
            {
                if (row.IsNgayTinhNull())
                {
                    row.NgayTinh = new MySql.Data.Types.MySqlDateTime(nam, thang, DateTime.DaysInMonth(nam, thang), 0, 0, 0, 0);
                }

                if (row.IsSoNgayNghiThangNull())
                {
                    row.SoNgayNghiThang = 0;
                }
            }
        }

        #endregion
    }
}