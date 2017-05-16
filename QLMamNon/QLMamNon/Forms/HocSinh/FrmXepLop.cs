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
            int? lopHoc = (int?)this.cmbLopHocDi.EditValue;

            if (namHoc != null)
            {
                this.hocSinhRowBindingSourceDi.DataSource = this.hocSinhTableAdapter.GetHocSinhByParams(new DateTime(namHoc.Value + 1, 1, 1), null, lopHoc, null);
            }
            else
            {
                this.hocSinhRowBindingSourceDi.DataSource = this.hocSinhTableAdapter.GetHocSinhByParams(null, null, lopHoc, null);
            }
        }

        private void loadHocSinhToGridDen()
        {
            if (ControlUtil.IsEditValueNull(this.dateNgayVaoLop) || ControlUtil.IsEditValueNull(this.cmbLopHocDen))
            {
                return;
            }

            this.hocSinhRowBindingSourceDen.DataSource = this.hocSinhTableAdapter.GetHocSinhByParams(null, null, (int)this.cmbLopHocDen.EditValue, this.dateNgayVaoLop.DateTime);
        }

        private void FrmXepLop_Load(object sender, EventArgs e)
        {

            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridViewMain_CustomDrawCell);
            this.gridView2.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridViewMain_CustomDrawCell);
            this.gridView1.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gvMain_CustomColumnDisplayText);
            this.gridView2.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gvMain_CustomColumnDisplayText);
            this.hocSinhRowBindingSourceDi.DataSource = this.hocSinhTableAdapter.GetData();

            this.namHocBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.NamHoc);
            this.lopRowBindingSourceDi.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
            this.lopRowBindingSourceDen.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
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
                this.hocSinhRowBindingSourceDen.RemoveCurrent();
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
            if (ControlUtil.IsEditValueNull(this.dateNgayVaoLop) || ControlUtil.IsEditValueNull(this.cmbLopHocDen))
            {
                MessageBox.Show("Xin vui long chọn Năm học và Lớp học", "Không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<int> hocSinhIds = new List<int>();
            int lop = (int)cmbLopHocDen.EditValue;
            DateTime ngayVaoLop = dateNgayVaoLop.DateTime;
            QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable = this.hocSinhTableAdapter.GetHocSinhByLopAndNgay(lop, ngayVaoLop);

            foreach (var item in hocSinhRowBindingSourceDen)
            {
                DataRowView rowView = item as DataRowView;
                QLMamNon.Dao.QLMamNonDs.HocSinhRow row = rowView.Row as QLMamNon.Dao.QLMamNonDs.HocSinhRow;
                int hocSinh = row.HocSinhId;
                this.hocSinhTableAdapter.InsertHocSinhToLop(hocSinh, lop, ngayVaoLop);
                hocSinhIds.Add(hocSinh);
            }

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
                this.hocSinhLopTableAdapter.DeleteHocSinhLopByHocSinhIds(StringUtil.Join(deletingHocSinhIds, ","), ngayVaoLop);
            }

            FormMainFacade.SetTrangThaiCaption(StatusCaptions.SavedCaption);
        }

    }
}