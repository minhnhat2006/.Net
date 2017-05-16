using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Facade;
using QLMamNon.Components.Data.Static;
using ACG.Core.WinForm.Util;
using QLMamNon.Forms.Resource;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.HocSinh
{
    public partial class FrmPhanBoTaiSan : CRUDForm
    {
        public FrmPhanBoTaiSan()
        {
            InitializeComponent();

            this.TablePrimaryKey = "TaiSanLopId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.PhanBoTaiSan;
            this.FormKey = AppForms.FormPhanBoTaiSan;
            this.gvLop.OptionsEditForm.CustomEditFormLayout = new UCEditFormBanGiaoTaiSan();
            this.InitForm(null, null, null, this.btnSave, null, this.gvLop, this.viewBanGiaoTaiSanTableAdapter.Adapter, this.viewBanGiaoTaiSanRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.ViewBanGiaoTaiSanDataTable);
            this.loadTaiSanToGridTaiSan();
        }

        private void loadTaiSanToGridTaiSan()
        {
            this.viewTaiSanRowBindingSource.DataSource = viewTaiSanTableAdapter.GetDataForBanGiaoTaiSan();
        }

        private void loadTaiSanToGridLop()
        {
            if (ControlUtil.IsEditValueNull(this.cmbLopHoc))
            {
                return;
            }

            this.viewBanGiaoTaiSanRowBindingSource.DataSource = this.viewBanGiaoTaiSanTableAdapter.GetByLopId((int)this.cmbLopHoc.EditValue);
            this.DataTable = this.viewBanGiaoTaiSanRowBindingSource.DataSource as DataTable;
        }

        private void FrmPhanBoTaiSan_Load(object sender, EventArgs e)
        {
            this.gvTaiSan.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridViewMain_CustomDrawCell);
            this.gvLop.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridViewMain_CustomDrawCell);
            this.gvTaiSan.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gvMain_CustomColumnDisplayText);
            this.gvLop.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gvMain_CustomColumnDisplayText);
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
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

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            if (ControlUtil.IsEditValueNull(cmbLopHoc))
            {
                MessageBox.Show("Xin vui lòng chọn lớp", "Chọn lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.viewTaiSanRowBindingSource.Current == null)
            {
                return;
            }

            DataRowView rowView = this.viewTaiSanRowBindingSource.Current as DataRowView;
            QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow oldRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow;

            int existedIndex = this.viewBanGiaoTaiSanRowBindingSource.Find("TaiSanId", oldRow.TaiSanId);

            if (existedIndex >= 0)
            {
                this.viewBanGiaoTaiSanRowBindingSource.Position = existedIndex;
            }
            else
            {
                DataRowView newRowView = this.viewBanGiaoTaiSanRowBindingSource.AddNew() as DataRowView;
                QLMamNon.Dao.QLMamNonDs.ViewBanGiaoTaiSanRow newRow = newRowView.Row as QLMamNon.Dao.QLMamNonDs.ViewBanGiaoTaiSanRow;
                newRow.Ten = oldRow.Ten;
                newRow.TaiSanId = oldRow.TaiSanId;
                newRow.LopId = (Int32)cmbLopHoc.EditValue;
                newRow.SoChungTu = oldRow.SoChungTu;
                newRow.NgayChungTu = oldRow.NgayChungTu;
                newRow.DonViTinh = oldRow.DonViTinh;
                newRow.DonGia = oldRow.DonGia;
                newRow.SoLuong = oldRow.SoLuong;
                newRow.NgayNhap = oldRow.NgayNhap;
                newRow.LopId = (int)cmbLopHoc.EditValue;
                newRow.LopName = cmbLopHoc.Text;
                newRow.TaiSanLopId = 0;
            }

            gvLop.ShowEditForm();
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if (this.viewBanGiaoTaiSanRowBindingSource.Current == null)
            {
                return;
            }

            DataRowView oldRowView = this.viewBanGiaoTaiSanRowBindingSource.Current as DataRowView;
            QLMamNon.Dao.QLMamNonDs.ViewBanGiaoTaiSanRow oldRow = oldRowView.Row as QLMamNon.Dao.QLMamNonDs.ViewBanGiaoTaiSanRow;

            int existedIndex = this.viewTaiSanRowBindingSource.Find("TaiSanId", oldRow.TaiSanId);

            if (existedIndex >= 0)
            {
                this.viewTaiSanRowBindingSource.Position = existedIndex;
                DataRowView rowView = this.viewTaiSanRowBindingSource.Current as DataRowView;
                QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow newRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow;
                newRow.SoLuong += oldRow.SoLuongBanGiao;
            }
            else
            {
                DataRowView newRowView = this.viewTaiSanRowBindingSource.AddNew() as DataRowView;
                QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow newRow = newRowView.Row as QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow;
                newRow.Ten = oldRow.Ten;
                newRow.TaiSanId = oldRow.TaiSanId;
                newRow.SoChungTu = oldRow.SoChungTu;
                newRow.NgayChungTu = oldRow.NgayChungTu;
                newRow.DonViTinh = oldRow.DonViTinh;
                newRow.DonGia = oldRow.DonGia;
                newRow.SoLuong = oldRow.SoLuong;
                newRow.NgayNhap = oldRow.NgayNhap;
            }

            this.viewBanGiaoTaiSanRowBindingSource.RemoveCurrent();
        }

        private void cmbLopHoc_EditValueChanged(object sender, EventArgs e)
        {
            this.loadTaiSanToGridLop();
        }
    }
}