using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using QLMamNon.Constant;
using QLMamNon.Forms.ThuChi;
using QLMamNon.Properties;
using System.Data;

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

        private bool isValidNgayTinhAndLop()
        {
            DateTime ngayTinh = this.GetNgayTinh();

            if (!DateTimeUtil.IsDateBetweenRange(DateTimeUtil.DateStartOfMonth(Settings.Default.AppLannchDate), DateTimeUtil.DateEndOfMonth(DateTime.Now), ngayTinh))
            {
                MessageBox.Show(String.Format("Xin vui lòng chọn năm tháng sau {0:MM/yyyy} và trước {1:MM/yyyy}", Settings.Default.AppLannchDate.AddMonths(-1), DateTime.Now.AddMonths(1)),
                    "Chọn năm tháng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            if (ControlUtil.IsEditValueNull(this.cmbLop))
            {
                MessageBox.Show("Xin vui lòng chọn Lớp", "Chọn lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            return true;
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

        private bool isNeedToGenerateSoThuTiens(DateTime ngayTinh, int lop)
        {
            long genHistoryCount = (long)bangThuTienGenHistoryTableAdapter.countBangThuTienGenHistoryByLopAndNgayTinh(lop, ngayTinh);

            if (genHistoryCount == 0)
            {
                if (!DateTimeUtil.IsSameMonthYear(ngayTinh, Settings.Default.AppLannchDate))
                {
                    long prevMonthGenHistoryCount = (long)bangThuTienGenHistoryTableAdapter.countBangThuTienGenHistoryByLopAndNgayTinh(lop, ngayTinh.AddMonths(-1));

                    if (prevMonthGenHistoryCount == 0)
                    {
                        MessageBox.Show(String.Format("Xin vui lòng tạo sổ thu tiền cho lớp {0} tháng {1:MM/yyyy} trước", lop, ngayTinh.AddMonths(-1)),
                        "Tạo số thu tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }

                return true;
            }

            return false;
        }

        private void generateSoThuTiens(object sender, DoWorkEventArgs e)
        {
            this.persistNgayTinhAndLop();
            List<QLMamNon.Dao.QLMamNonDs.HocSinhRow> hocSinhRows = e.Argument as List<QLMamNon.Dao.QLMamNonDs.HocSinhRow>;
            int generatedRowsCount = this.generateSoThuTienByHocSinhRows(ngayTinh, hocSinhRows);

            if (this.isNeedToGenerateSoThuTiens(ngayTinh, lop))
            {
                this.bangThuTienGenHistoryTableAdapter.Insert(ngayTinh, lop, DateTime.Now);
            }
        }

        private void generatedSoThuTiens(object sender, RunWorkerCompletedEventArgs e)
        {
            this.HideGridLoadingPanel();
            this.loadViewBangThuTiens(this.ngayTinh, this.lop);
        }

        private int generateSoThuTienByHocSinhRows(DateTime ngayTinh, List<QLMamNon.Dao.QLMamNonDs.HocSinhRow> hocSinhRows)
        {
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable viewBangThuTienTable = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(this.ngayTinh, null);

            List<int> hocSinhIds = new List<int>();
            List<QLMamNon.Dao.QLMamNonDs.HocSinhRow> needToGenerateHocSinhRows = new List<Dao.QLMamNonDs.HocSinhRow>();

            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow hocSinh in hocSinhRows)
            {
                DataRow[] rows = viewBangThuTienTable.Select(String.Format("HocSinhId={0}", hocSinh.HocSinhId));

                if (ArrayUtil.IsEmpty(rows))
                {
                    hocSinhIds.Add(hocSinh.HocSinhId);
                    needToGenerateHocSinhRows.Add(hocSinh);
                }
            }

            Dictionary<int, QLMamNon.Dao.QLMamNonDs.HocSinhLopRow> hocSinhIdsToHocSinhLops = StaticDataUtil.GetHocSinhLopsByHocSinhIds(hocSinhLopTableAdapter, hocSinhIds, this.ngayTinh);

            int stt = viewBangThuTienTable.Rows.Count + 1;
            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow hocSinh in needToGenerateHocSinhRows)
            {
                if (hocSinhIdsToHocSinhLops.ContainsKey(hocSinh.HocSinhId))
                {
                    this.generateSoThuTienByHocSinhAndLopAndNgayTinh(hocSinh.HocSinhId, hocSinhIdsToHocSinhLops[hocSinh.HocSinhId].LopId, ngayTinh, stt);
                    stt++;
                }
            }

            return hocSinhIds.Count;
        }

        private void generateSoThuTienByHocSinhAndLopAndNgayTinh(int hocSinhId, int lopId, DateTime ngayTinh, int stt)
        {
            int sXThangTruoc = 0;
            long soTienSXThangTruoc = 0;
            int anSangThangTruoc = 0;
            long soTienAnSangThangTruoc = 0;
            long soTienAnSangThangNay = 0;
            int anToiThangTruoc = 0;
            long soTienAnToiThangTruoc = 0;
            long soTienAnToiThangNay = 0;
            long soTienNangKhieu = 0;
            long soTienTruyThu = 0;
            long soTienDieuHoa = 0;
            long soTienDoDung = 0;
            String ghiChu = "";
            bangThuTienTableAdapter.Insert(hocSinhId, lopId, sXThangTruoc, soTienSXThangTruoc, anSangThangTruoc, soTienAnSangThangTruoc, soTienAnSangThangNay, soTienAnToiThangTruoc, anToiThangTruoc, soTienAnToiThangNay, soTienDoDung, soTienNangKhieu, soTienTruyThu, soTienDieuHoa, ngayTinh, stt, 0, DateTime.Now, ghiChu);
            int bangThuTienId = (int)bangThuTienTableAdapter.Adapter.InsertCommand.LastInsertedId;
            int khoiId = StaticDataUtil.GetKhoiIdByLopId(lopKhoiTableAdapter, lopId).Value;
            this.generateBangThuTienKhoanThu(bangThuTienId, khoiId, ngayTinh, 0);
        }

        private void generateBangThuTienKhoanThu(int bangThuTienId, int khoiId, DateTime ngayTinh, int soNgayNghiThang)
        {
            int[] khoanThuIds = new int[] { BangThuTienConstant.KhoanThuIdBanTru, BangThuTienConstant.KhoanThuIdHocPhi, BangThuTienConstant.KhoanThuIdPhuPhi, BangThuTienConstant.KhoanThuIdTienAnSua, BangThuTienConstant.KhoanThuIdAnSang, BangThuTienConstant.KhoanThuIdAnToi };
            QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamDataTable khoanThuHangNamTable = khoanThuHangNamTableAdapter.GetKhoanThuHangNamByParams(String.Join(",", khoanThuIds), khoiId, ngayTinh);

            foreach (QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamRow row in khoanThuHangNamTable)
            {
                long soTien = BangThuTienUtil.CalculateSoTienPhi(khoiId, soNgayNghiThang, row.SoTien, row.KhoanThuId);
                bangThuTienKhoanThuTableAdapter.Insert(row.KhoanThuId, bangThuTienId, soTien);
            }
        }
    }
}
