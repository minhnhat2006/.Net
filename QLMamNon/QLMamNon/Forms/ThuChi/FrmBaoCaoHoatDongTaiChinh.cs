using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Facade;
using QLMamNon.Forms.Resource;
using QLThuChi;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmBaoCaoHoatDongTaiChinh : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        protected string FormKey { get; set; }

        public GridView GridView { get; set; }

        public bool IsEditing { get; set; }

        public QLMamNon.Dao.QLMamNonDs.PhieuThuRow PhieuThuRow { get; set; }

        #endregion

        public FrmBaoCaoHoatDongTaiChinh()
        {
            this.FormKey = AppForms.FormBaoCaoHoatDongTaiChinh;
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (this.dateTuNgay.DateTime == null || this.dateDenNgay.DateTime == null)
            {
                MessageBox.Show("Xin vui lòng chọn ngày", "Chọn ngày", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RptBaoCaoHoatDongTaiChinh rpt = new RptBaoCaoHoatDongTaiChinh();
            rpt.TuNgay.Value = this.dateTuNgay.DateTime;
            rpt.DenNgay.Value = this.dateDenNgay.DateTime;

            List<int> phanLoaiChiIds = new List<int>();
            int[] selectedRowHandlers = this.gvMain.GetSelectedRows();

            if (ArrayUtil.IsEmpty(selectedRowHandlers))
            {
                MessageBox.Show("Xin vui lòng chọn Mã loại chi", "Chọn Mã loại chi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (int rowHandler in selectedRowHandlers)
            {
                int phanLoaiChiId = (int)this.gvMain.GetRowCellValue(rowHandler, "PhanLoaiChiId");
                phanLoaiChiIds.Add(phanLoaiChiId);
            }

            rpt.PhanLoaiChiIds.Value = StringUtil.Join(phanLoaiChiIds, ",");

            FormMainFacade.ShowReport(rpt);
        }

        private void FrmBaoCaoHoatDongTaiChinh_Load(object sender, EventArgs e)
        {
            this.phanLoaiChiRowBindingSource.DataSource = this.phanLoaiChiTableAdapter.GetData();
        }

        private void FrmBaoCaoHoatDongTaiChinh_Shown(object sender, EventArgs e)
        {
            this.gvMain.SelectAll();
        }
    }
}