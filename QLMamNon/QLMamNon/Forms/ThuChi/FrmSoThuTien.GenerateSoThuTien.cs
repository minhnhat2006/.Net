using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using QLMamNon.Properties;
using QLMamNon.Service.Data;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmSoThuTien
    {
        private void btnTaoSoThuTien_Click(object sender, EventArgs e)
        {
            if (this.isValidNgayTinhAndLop())
            {
                this.showFormGenerateSoThuTiens(false);
            }
        }

        private bool isValidNgayTinh()
        {
            DateTime ngayTinh = this.GetNgayTinh();

            if (!DateTimeUtil.IsDateBetweenRange(DateTimeUtil.DateStartOfMonth(Settings.Default.AppLannchDate), DateTimeUtil.DateEndOfMonth(DateTime.Now), ngayTinh))
            {
                MessageBox.Show(String.Format("Xin vui lòng chọn năm tháng sau {0:MM/yyyy} và trước {1:MM/yyyy}", Settings.Default.AppLannchDate.AddMonths(-1), DateTime.Now.AddMonths(1)),
                    "Chọn năm tháng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            return true;
        }

        private bool isValidNgayTinhAndLop()
        {
            bool isValidNgayTinh = this.isValidNgayTinh();

            if (!isValidNgayTinh)
            {
                return false;
            }

            if (ControlUtil.IsEditValueNull(this.cmbLop))
            {
                MessageBox.Show("Xin vui lòng chọn Lớp", "Chọn lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            return true;
        }

        private bool isNeedToGenerateSoThuTiens(DateTime ngayTinh, int lop)
        {
            long genHistoryCount = (long)bangThuTienGenHistoryTableAdapter.CountBangThuTienGenHistoryByLopAndNgayTinh(lop, ngayTinh);

            if (genHistoryCount == 0)
            {
                if (!DateTimeUtil.IsSameMonthYear(ngayTinh, Settings.Default.AppLannchDate))
                {
                    long prevMonthGenHistoryCount = (long)bangThuTienGenHistoryTableAdapter.CountBangThuTienGenHistoryByLopAndNgayTinh(lop, DateTimeUtil.DateEndOfMonth(ngayTinh.AddMonths(-1)));

                    if (prevMonthGenHistoryCount == 0)
                    {
                        MessageBox.Show(String.Format("Xin vui lòng tạo sổ thu tiền cho lớp {0} tháng {1:MM/yyyy} trước", cmbLop.Text, ngayTinh.AddMonths(-1)),
                        "Tạo số thu tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }

                return true;
            }

            return false;
        }

        private void showFormGenerateSoThuTiens(bool needToCheckGenerated)
        {
            if (this.isValidNgayTinhAndLop())
            {
                DateTime ngayTinh = this.GetNgayTinh();
                int lop = (int)this.cmbLop.EditValue;

                if (!(needToCheckGenerated && this.isNeedToGenerateSoThuTiens(ngayTinh, lop) || !needToCheckGenerated))
                {
                    return;
                }

                using (FrmSelectHocSinhsToGenerate frmSelectHocSinhsToGenerate = new FrmSelectHocSinhsToGenerate())
                {
                    List<int> selectedHocSinhIds = new List<int>();
                    QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable viewBangThuTienTable = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(ngayTinh, lop);

                    foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow in viewBangThuTienTable)
                    {
                        selectedHocSinhIds.Add(viewBangThuTienRow.HocSinhId);
                    }

                    frmSelectHocSinhsToGenerate.GeneratedHocSinhIds = selectedHocSinhIds;

                    QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable = hocSinhTableAdapter.GetHocSinhByLopAndNgay(lop, ngayTinh);
                    frmSelectHocSinhsToGenerate.HocSinhTable = hocSinhTable;
                    DialogResult result = frmSelectHocSinhsToGenerate.ShowDialog(this);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.ShowGridLoadingPanel();

                        BackgroundWorker bw = new BackgroundWorker();
                        bw.DoWork += new DoWorkEventHandler(generateSoThuTiens);
                        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(generatedSoThuTiens);
                        bw.RunWorkerAsync(frmSelectHocSinhsToGenerate.HocSinhRows);
                    }
                }
            }
        }

        private void generateSoThuTiens(object sender, DoWorkEventArgs e)
        {
            this.persistNgayTinhAndLop();
            List<QLMamNon.Dao.QLMamNonDs.HocSinhRow> hocSinhRows = e.Argument as List<QLMamNon.Dao.QLMamNonDs.HocSinhRow>;
            SoThuTienService soThuTienService = new SoThuTienService();
            int generatedRowsCount = soThuTienService.GenerateSoThuTienByHocSinhRows(ngayTinh, hocSinhRows);
            this.bangThuTienGenHistoryTableAdapter.Insert(ngayTinh, lop, DateTime.Now, Settings.Default.TienAnSang, Settings.Default.TienAnToi, Settings.Default.TienAnChinh);
        }

        private void generatedSoThuTiens(object sender, RunWorkerCompletedEventArgs e)
        {
            this.HideGridLoadingPanel();
            this.loadViewBangThuTiens(this.ngayTinh, this.lop);
        }
    }
}
