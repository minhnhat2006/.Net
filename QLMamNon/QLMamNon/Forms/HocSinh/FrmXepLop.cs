using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Components.Data.Static;
using QLMamNon.Facade;
using QLMamNon.Forms.Resource;
using QLMamNon.Constant;
using QLMamNon.UserControls;

namespace QLMamNon.Forms.HocSinh
{
    public partial class FrmXepLop : CRUDForm
    {
        public FrmXepLop()
        {
            InitializeComponent();

            this.FormKey = AppForms.FormXepLop;
            this.InitForm(null, null, null, this.btnSave, null, this.gvDen, null, null);
        }

        private void FrmXepLop_Load(object sender, EventArgs e)
        {

            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridViewMain_CustomDrawCell);
            this.gridView1.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gvMain_CustomColumnDisplayText);

            this.gvDen.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridViewMain_CustomDrawCell);
            this.gvDen.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gvMain_CustomColumnDisplayText);
            this.gvDen.OptionsEditForm.CustomEditFormLayout = new UCEditFormXepLop();

            this.hocSinhRowBindingSourceDi.DataSource = this.hocSinhTableAdapter.GetData();
            this.namHocBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.NamHoc);
            this.lopRowBindingSourceDi.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
            this.lopRowBindingSourceDen.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);

            this.cmbNamHocDi.EditValue = DateTime.Now.Year;
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
            if (ControlUtil.IsEditValueNull(this.cmbLopHocDen))
            {
                MessageBox.Show("Xin vui long chọn Lớp học", "Chọn lớp học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
            copyHocSinhRow(oldRow, newRow);
            newRow.LopDangHoc = this.cmbLopHocDen.Text;
            newRow.NgayVaoLop = DateTime.Now;

            this.gvDen.ShowEditForm();
        }

        private static void copyHocSinhRow(QLMamNon.Dao.QLMamNonDs.HocSinhRow oldRow, QLMamNon.Dao.QLMamNonDs.HocSinhRow newRow)
        {
            newRow.HocSinhId = oldRow.HocSinhId;
            newRow.HoDem = oldRow.HoDem;
            newRow.Ten = oldRow.Ten;
            newRow.HoTen = String.Format("{0} {1}", oldRow.HoDem, oldRow.Ten);
            newRow.GioiTinh = oldRow.GioiTinh;
            newRow.ThoiHoc = oldRow.ThoiHoc;

            if (!oldRow.IsNgaySinhNull())
            {
                newRow.NgaySinh = oldRow.NgaySinh;
            }
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
                QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable = this.hocSinhRowBindingSourceDi.DataSource as QLMamNon.Dao.QLMamNonDs.HocSinhDataTable;
                QLMamNon.Dao.QLMamNonDs.HocSinhRow[] hocSinhRows = hocSinhTable.Select(String.Format("HocSinhId={0}", oldRow.HocSinhId)) as QLMamNon.Dao.QLMamNonDs.HocSinhRow[];
                hocSinhRows[0].LopDangHoc = CommonConstant.EMPTY;
                this.hocSinhRowBindingSourceDen.RemoveCurrent();

                return;
            }

            DataRowView newRowView = this.hocSinhRowBindingSourceDi.AddNew() as DataRowView;
            QLMamNon.Dao.QLMamNonDs.HocSinhRow newRow = newRowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;
            copyHocSinhRow(oldRow, newRow);

            this.hocSinhRowBindingSourceDen.RemoveCurrent();
        }

        private void cmbLopHocDi_EditValueChanged(object sender, EventArgs e)
        {
            this.loadHocSinhToGridDi();
        }

        private void cmbNamHocDi_EditValueChanged(object sender, EventArgs e)
        {
            this.loadHocSinhToGridDi();
        }

        private void cmbLopHocDen_EditValueChanged(object sender, EventArgs e)
        {
            this.loadHocSinhToGridDen();
        }

        protected override void onSaving()
        {
            if (ControlUtil.IsEditValueNull(this.cmbLopHocDen))
            {
                MessageBox.Show("Xin vui long chọn Lớp học", "Chọn lớp học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<int> hocSinhIds = new List<int>();
            int lop = (int)cmbLopHocDen.EditValue;
            QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable = this.hocSinhTableAdapter.GetHocSinhByParams(DateTime.Now, null, lop, null);

            foreach (DataRowView rowView in hocSinhRowBindingSourceDen)
            {
                QLMamNon.Dao.QLMamNonDs.HocSinhRow hocSinhRow = rowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;
                int hocSinh = hocSinhRow.HocSinhId;
                hocSinhIds.Add(hocSinh);

                if (hocSinhRow.RowState == DataRowState.Modified || hocSinhRow.RowState == DataRowState.Added)
                {
                    this.hocSinhTableAdapter.InsertHocSinhToLop(hocSinh, lop, hocSinhRow.NgayVaoLop);
                }
            }

            ((QLMamNon.Dao.QLMamNonDs.HocSinhDataTable)this.hocSinhRowBindingSourceDen.DataSource).AcceptChanges();

            List<int> deletingHocSinhIds = new List<int>();

            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow hsRow in hocSinhTable)
            {
                if (!hocSinhIds.Contains(hsRow.HocSinhId))
                {
                    deletingHocSinhIds.Add(hsRow.HocSinhId);
                }
            }

            if (!ListUtil.IsEmpty(deletingHocSinhIds))
            {
                this.hocSinhLopTableAdapter.DeleteHocSinhLopByHocSinhIds(StringUtil.Join(deletingHocSinhIds, ","), DateTime.Now);
            }

            FormMainFacade.SetStatusCaption(this.FormKey, StatusCaptions.SavedCaption);
        }

        private void gvDen_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (this.gvDen.IsNewItemRow(e.RowHandle))
            {
                this.hocSinhRowBindingSourceDi.RemoveCurrent();
            }
        }
    }
}