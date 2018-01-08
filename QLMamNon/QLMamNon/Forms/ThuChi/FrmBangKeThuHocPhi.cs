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
using ACG.Core.WinForm.Util;

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
            if (this.dateTuNgay.DateTime == null || this.dateDenNgay.DateTime == null)
            {
                MessageBox.Show("Xin vui lòng chọn ngày", "Chọn ngày", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SoThuTienService soThuTienService = new SoThuTienService();
            RptBangKeTongHopThuTienHS rpt = new RptBangKeTongHopThuTienHS();
            DateTime fromDate = DateTimeUtil.StartOfDate(dateTuNgay.DateTime);
            DateTime toDate = DateTimeUtil.EndOfDate(dateDenNgay.DateTime);
            rpt.FromDate.Value = fromDate;
            rpt.ToDate.Value = toDate;

            List<BangKeThuTienItem> allBangKeThuTienItems = soThuTienService.GetBangKeTongHopThuTien(toDate, (int?)cmLop.EditValue);
            List<BangKeThuTienItem> displayedBangKeThuTienItems = new List<BangKeThuTienItem>();
            int stt = 1;

            foreach (BangKeThuTienItem item in allBangKeThuTienItems)
            {
                if (item.NgayNop >= fromDate && item.NgayNop <= toDate)
                {
                    item.STT = stt++;
                    displayedBangKeThuTienItems.Add(item);
                }
            }

            rpt.viewBangThuTienRowbindingSource.DataSource = displayedBangKeThuTienItems;
            FormMainFacade.ShowReport(rpt);
        }

        private void FrmBaoCaoHoatDongTaiChinh_Load(object sender, EventArgs e)
        {
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
        }
    }
}