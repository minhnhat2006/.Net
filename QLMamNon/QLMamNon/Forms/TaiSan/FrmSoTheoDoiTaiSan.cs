using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Facade;
using QLMamNon.Forms.Resource;
using QLThuChi;
using QLMamNon.Components.Data.Static;

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
            if (ControlUtil.IsEditValueNull(this.cmbYear))
            {
                MessageBox.Show("Xin vui lòng chọn năm", "Chọn năm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RptSoTheoDoiTaiSan rpt = new RptSoTheoDoiTaiSan();
            QLMamNon.Dao.QLMamNonDs.ViewBanGiaoTaiSanDataTable table = this.viewBanGiaoTaiSanTableAdapter.GetDataByYear((int)cmbYear.EditValue);

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBanGiaoTaiSanRow row in table)
            {
                row.LopName = StaticDataUtil.GetLopNameByLopId(row.LopId);
            }

            rpt.bindingSource.DataSource = table;
            FormMainFacade.ShowReport(rpt);
        }

        private void FrmBaoCaoHoatDongTaiChinh_Load(object sender, EventArgs e)
        {
            this.namHocBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.NamHoc);
        }
    }
}