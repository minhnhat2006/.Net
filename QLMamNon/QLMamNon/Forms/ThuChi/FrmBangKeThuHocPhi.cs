using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using QLMamNon.Constant;
using QLMamNon.Entity.Form;
using QLMamNon.Facade;
using QLMamNon.Properties;
using QLMamNon.Service.Data;
using QLThuChi;
using QLMamNon.Components.Data.Static;
using QLMamNon.Dao.QLMamNonDsTableAdapters;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmBangKeThuHocPhi : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        protected string FormKey { get; set; }

        #endregion

        public FrmBangKeThuHocPhi()
        {
            this.FormKey = AppForms.FormBangKeThuHocPhi;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (this.dateDenNgay.DateTime == null)
            {
                MessageBox.Show("Xin vui lòng chọn ngày", "Chọn ngày", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SoThuTienService soThuTienService = new SoThuTienService();
            RptBangKeTongHopThuTienHS rpt = new RptBangKeTongHopThuTienHS();
            rpt.viewBangThuTienRowbindingSource.DataSource = soThuTienService.GetBangKeTongHopThuTien(dateDenNgay.DateTime, (int?)cmLop.EditValue);
            rpt.Ngay.Value = dateDenNgay.DateTime;
            FormMainFacade.ShowReport(rpt);
        }

        private void FrmBaoCaoHoatDongTaiChinh_Load(object sender, EventArgs e)
        {
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
        }
    }
}