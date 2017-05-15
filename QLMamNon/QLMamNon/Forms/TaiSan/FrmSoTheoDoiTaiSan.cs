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
    public partial class FrmSoTheoDoiTaiSan : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        protected string FormKey { get; set; }

        public GridView GridView { get; set; }

        public bool IsEditing { get; set; }

        public QLMamNon.Dao.QLMamNonDs.PhieuThuRow PhieuThuRow { get; set; }

        #endregion

        public FrmSoTheoDoiTaiSan()
        {
            this.FormKey = AppForms.FormBaoCaoChiTietHoatDongTaiChinh;
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (ControlUtil.IsEditValueNull(this.dateTuNgay))
            {
                MessageBox.Show("Xin vui lòng chọn năm", "Chọn năm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RptBaoCaoChiTietHoatDongTaiChinh rpt = new RptBaoCaoChiTietHoatDongTaiChinh();
            rpt.TuNgay.Value = this.dateTuNgay.DateTime;

            FormMainFacade.ShowReport(rpt);
        }

        private void FrmBaoCaoHoatDongTaiChinh_Load(object sender, EventArgs e)
        {
            this.phanLoaiChiRowBindingSource.DataSource = this.phanLoaiChiTableAdapter.GetData();
        }
    }
}