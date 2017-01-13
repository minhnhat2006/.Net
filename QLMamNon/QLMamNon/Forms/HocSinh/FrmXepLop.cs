using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Facade;
using QLMamNon.Components.Data.Static;
using ACG.Core.WinForm.Util;
using QLMamNon.Forms.Resource;

namespace QLMamNon.Forms.HocSinh
{
    public partial class FrmXepLop : CRUDForm
    {
        public FrmXepLop()
        {
            InitializeComponent();

            this.FormKey = AppForms.FormXepLop;
            this.InitForm(null, null, null, this.btnSave, null, null, null, null);
        }

        private bool isHocSinhExisted(BindingSource hocSinhRowBindingSource, int hocSinhId)
        {
            foreach (var item in hocSinhRowBindingSource)
            {
                DataRowView rowView = item as DataRowView;
                QLMamNon.Dao.QLMamNonDs.HocSinhRow row = rowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;
                if (hocSinhId == row.HocSinhId)
                {
                    return true;
                }
            }

            return false;
        }

        private void loadHocSinhToGridDi()
        {
            int? namHoc = (int?)this.cmbNamHocDi.EditValue;
            int? khoiHoc = (int?)this.cmbKhoiHocDi.EditValue;
            int? lopHoc = (int?)this.cmbLopHocDi.EditValue;
            this.hocSinhRowBindingSourceDi.DataSource = this.hocSinhTableAdapter.GetDataByParams(namHoc, khoiHoc, lopHoc, null);
        }

        private void loadHocSinhToGridDen()
        {
            if (ControlUtil.IsEditValueNull(this.cmbNamHocDen) || ControlUtil.IsEditValueNull(this.cmbKhoiHocDen) || ControlUtil.IsEditValueNull(this.cmbLopHocDen)
                || ControlUtil.IsEditValueNull(this.dateNgayVaoLop))
            {
                return;
            }

            this.hocSinhRowBindingSourceDen.DataSource = this.hocSinhTableAdapter.GetDataByParams(
                (int)this.cmbNamHocDen.EditValue, (int)this.cmbKhoiHocDen.EditValue, (int)this.cmbLopHocDen.EditValue, this.dateNgayVaoLop.DateTime);
        }

        private void FrmXepLop_Load(object sender, EventArgs e)
        {

            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridViewMain_CustomDrawCell);
            this.gridView2.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridViewMain_CustomDrawCell);
            this.gridView1.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gvMain_CustomColumnDisplayText);
            this.gridView2.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gvMain_CustomColumnDisplayText);
            this.hocSinhRowBindingSourceDi.DataSource = this.hocSinhTableAdapter.GetData();

            this.namHocBindingSource.DataSource = StaticDataFacade.Get(DataKeys.NamHoc);
            this.khoiRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.KhoiHoc);
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

            if (this.hocSinhRowBindingSourceDi.Current == null)
            {
                return;
            }

            DataRowView rowView = this.hocSinhRowBindingSourceDi.Current as DataRowView;
            QLMamNon.Dao.QLMamNonDs.HocSinhRow oldRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;

            if (this.isHocSinhExisted(this.hocSinhRowBindingSourceDen, oldRow.HocSinhId))
            {
                return;
            }

            DataRowView newRowView = this.hocSinhRowBindingSourceDen.AddNew() as DataRowView;
            QLMamNon.Dao.QLMamNonDs.HocSinhRow newRow = newRowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;
            newRow.HocSinhId = oldRow.HocSinhId;
            newRow.HoDem = oldRow.HoDem;
            newRow.Ten = oldRow.Ten;
            newRow.GioiTinh = oldRow.GioiTinh;

            if (!oldRow.IsNgaySinhNull())
            {
                newRow.NgaySinh = oldRow.NgaySinh;
            }

            this.hocSinhRowBindingSourceDi.RemoveCurrent();
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if (this.hocSinhRowBindingSourceDen.Current == null)
            {
                return;
            }

            DataRowView rowView = this.hocSinhRowBindingSourceDen.Current as DataRowView;
            QLMamNon.Dao.QLMamNonDs.HocSinhRow oldRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;

            if (this.isHocSinhExisted(this.hocSinhRowBindingSourceDi, oldRow.HocSinhId))
            {
                return;
            }

            DataRowView newRowView = this.hocSinhRowBindingSourceDi.AddNew() as DataRowView;
            QLMamNon.Dao.QLMamNonDs.HocSinhRow newRow = newRowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;
            newRow.HocSinhId = oldRow.HocSinhId;
            newRow.HoDem = oldRow.HoDem;
            newRow.Ten = oldRow.Ten;
            newRow.GioiTinh = oldRow.GioiTinh;

            if (!oldRow.IsNgaySinhNull())
            {
                newRow.NgaySinh = oldRow.NgaySinh;
            }

            this.hocSinhRowBindingSourceDen.RemoveCurrent();
        }

        private void cmbKhoiHocDi_EditValueChanged(object sender, EventArgs e)
        {
            this.lopRowBindingSourceDi.DataSource = StaticDataFacade.Get(DataKeys.LopHoc);
            this.loadHocSinhToGridDi();
        }

        private void cmbLopHocDi_EditValueChanged(object sender, EventArgs e)
        {
            this.loadHocSinhToGridDi();
        }

        private void cmbNamHocDi_EditValueChanged(object sender, EventArgs e)
        {
            this.loadHocSinhToGridDi();
        }

        private void cmbNamHocDen_EditValueChanged(object sender, EventArgs e)
        {
            this.loadHocSinhToGridDen();
        }

        private void cmbKhoiHocDen_EditValueChanged(object sender, EventArgs e)
        {
            this.lopRowBindingSourceDen.DataSource = StaticDataFacade.Get(DataKeys.LopHoc);
            this.loadHocSinhToGridDen();
        }

        private void cmbLopHocDen_EditValueChanged(object sender, EventArgs e)
        {
            this.loadHocSinhToGridDen();
        }

        private void dateNgayVaoLop_EditValueChanged(object sender, EventArgs e)
        {
            this.loadHocSinhToGridDen();
        }

        protected override void onSaving()
        {
            if (ControlUtil.IsEditValueNull(this.cmbNamHocDen) || ControlUtil.IsEditValueNull(this.cmbKhoiHocDen) || ControlUtil.IsEditValueNull(this.cmbLopHocDen)
                || ControlUtil.IsEditValueNull(this.dateNgayVaoLop))
            {
                MessageBox.Show("Xin vui long chọn Năm học, Lớp học, và Ngày vào lớp", "Không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var item in hocSinhRowBindingSourceDen)
            {
                DataRowView rowView = item as DataRowView;
                QLMamNon.Dao.QLMamNonDs.HocSinhRow row = rowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;
                int hocSinh = row.HocSinhId;
                int lop = (int)cmbLopHocDen.EditValue;
                int tuNam = (int)cmbNamHocDen.EditValue;
                int denNam = (int)cmbNamHocDen.EditValue + 1;
                DateTime ngayVaoLop = dateNgayVaoLop.DateTime;
                this.hocSinhTableAdapter.InsertHocSinhToLop(hocSinh, lop, ngayVaoLop, tuNam, denNam);
            }

            base.onSaving();
        }

    }
}