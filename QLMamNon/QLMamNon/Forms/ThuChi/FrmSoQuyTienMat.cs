﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using DevExpress.XtraEditors;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Entity.Form;
using QLMamNon.Facade;
using QLMamNon.Service.Data;
using QLThuChi;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmSoQuyTienMat : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private const int NumberOfDateToGroupPhieuThu = 10;

        protected string FormKey { get; set; }

        #endregion

        public FrmSoQuyTienMat()
        {
            this.FormKey = AppForms.FormSoQuyTienMat;
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

            if (chkTon.Checked && StringUtil.IsEmpty(txtTon.Text))
            {
                MessageBox.Show("Xin vui lòng nhập số tiền tồn tháng trước", "Nhập số tiền tồn tháng trước", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<int> phanLoaiThuIds = new List<int>();
            int[] selectedThuRowHandlers = this.gvThu.GetSelectedRows();

            if (ArrayUtil.IsEmpty(selectedThuRowHandlers))
            {
                MessageBox.Show("Xin vui lòng chọn Phân loại thu", "Chọn Phân loại thu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (int rowHandler in selectedThuRowHandlers)
            {
                int phanLoaiThuId = (int)this.gvThu.GetRowCellValue(rowHandler, "PhanLoaiThuId");
                phanLoaiThuIds.Add(phanLoaiThuId);
            }

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

            DateTime fromDate = DateTimeUtil.StartOfDate(this.dateTuNgay.DateTime);
            DateTime toDate = DateTimeUtil.EndOfDate(this.dateDenNgay.DateTime);

            decimal soTienTonDauKy = findSoTienTonDauKy(toDate);

            SortedList soQuyTienMatMap = new SortedList();
            SoQuyTienMatItem soQuyTienMatDauKy = new SoQuyTienMatItem()
            {
                DienGiai = "Số tồn đầu kỳ",
                SoTienTon = (double)soTienTonDauKy
            };
            soQuyTienMatMap.Add(DateTime.MinValue, soQuyTienMatDauKy);

            addPhieuThuToReport(soQuyTienMatMap, fromDate, toDate, phanLoaiThuIds);
            addPhieuChiToReport(soQuyTienMatMap, fromDate, toDate, phanLoaiChiIds);
            List<SoQuyTienMatItem> soQuyTienMat = calculateSoTienTonForSoQuyTienMatItems(soQuyTienMatMap);

            RptSoQuyTienMat rpt = new RptSoQuyTienMat();
            rpt.FromDate.Value = fromDate;
            rpt.ToDate.Value = toDate;
            rpt.bindingSource.DataSource = soQuyTienMat;
            FormMainFacade.ShowReport(rpt);
        }

        private decimal findSoTienTonDauKy(DateTime toDate)
        {
            decimal soTienTonDauKy = txtTon.Value;

            if (!chkTon.Checked)
            {
                SoThuTienService soThuTienService = new SoThuTienService();
                soTienTonDauKy = soThuTienService.GetSoTienTonDauKy(toDate);
            }
            return soTienTonDauKy;
        }

        private static List<SoQuyTienMatItem> calculateSoTienTonForSoQuyTienMatItems(SortedList soQuyTienMatMap)
        {
            List<SoQuyTienMatItem> soQuyTienMat = new List<SoQuyTienMatItem>();
            SoQuyTienMatItem prevSoQuyTienMatItem = null;

            foreach (var item in soQuyTienMatMap.GetValueList())
            {
                SoQuyTienMatItem soQuyTienMatItem = item as SoQuyTienMatItem;

                if (prevSoQuyTienMatItem != null)
                {
                    soQuyTienMatItem.SoTienTon = prevSoQuyTienMatItem.SoTienTon + soQuyTienMatItem.SoTienThu - soQuyTienMatItem.SoTienChi;
                }

                prevSoQuyTienMatItem = soQuyTienMatItem;
                soQuyTienMat.Add(soQuyTienMatItem);
            }
            return soQuyTienMat;
        }

        private void addPhieuChiToReport(SortedList soQuyTienMatMap, DateTime fromDate, DateTime toDate, List<int> phanLoaiChiIds)
        {
            PhieuChiService phieuChiService = new PhieuChiService();
            QLMamNon.Dao.QLMamNonDs.PhieuChiDataTable phieuChiDataTable = phieuChiService.LoadPhieuChiByDateRange(fromDate, toDate, phanLoaiChiIds);
            foreach (QLMamNon.Dao.QLMamNonDs.PhieuChiRow phieuChiRow in phieuChiDataTable)
            {
                SoQuyTienMatItem soQuyTienMatItemChi = new SoQuyTienMatItem()
                {
                    DienGiai = phieuChiRow.NoiDung,
                    GhiChu = phieuChiRow.GhiChu,
                    NgayChungTu = phieuChiRow.Ngay.AddMilliseconds(soQuyTienMatMap.Count),
                    SoChungTuChi = phieuChiRow.MaPhieu,
                    SoTienChi = phieuChiRow.SoTien
                };
                soQuyTienMatMap.Add(soQuyTienMatItemChi.NgayChungTu, soQuyTienMatItemChi);
            }
        }

        private void addPhieuThuToReport(SortedList soQuyTienMatMap, DateTime fromDate, DateTime toDate, List<int> phanLoaiThuIds)
        {
            PhieuThuTableAdapter phieuThuTableAdapter = (PhieuThuTableAdapter)StaticDataFacade.Get(StaticDataKeys.AdapterPhieuThu);
            QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable = phieuThuTableAdapter.GetDataForSoQuyTienMat(fromDate, toDate, StringUtil.JoinWithCommas(phanLoaiThuIds));
            Dictionary<string, SoQuyTienMatItem> groupDateToSoQuyTienMatItemsMap = new Dictionary<string, SoQuyTienMatItem>();

            foreach (QLMamNon.Dao.QLMamNonDs.PhieuThuRow phieuThuRow in phieuThuDataTable)
            {
                phieuThuRow.PhanLoaiThu = phieuThuRow.IsPhanLoaiThuIdNull() ? "Thu tiền học phí" : StaticDataUtil.GetPhanLoaiThuById(phieuThuRow.PhanLoaiThuId);

                int groupDate = getGroupDate(fromDate, phieuThuRow);
                DateTime dateOfGroup = fromDate.AddDays((groupDate + 1) * NumberOfDateToGroupPhieuThu - 1);

                if (dateOfGroup > toDate)
                {
                    dateOfGroup = toDate;
                }

                string key = StringUtil.Join(new int[] { groupDate, phieuThuRow.PhanLoaiThuId }, "~");

                if (!groupDateToSoQuyTienMatItemsMap.ContainsKey(key))
                {
                    groupDateToSoQuyTienMatItemsMap.Add(key, new SoQuyTienMatItem()
                    {
                        DienGiai = phieuThuRow.PhanLoaiThu,
                        NgayChungTu = dateOfGroup,
                        SoTienThu = 0
                    });
                }
            }

            foreach (QLMamNon.Dao.QLMamNonDs.PhieuThuRow phieuThuRow in phieuThuDataTable)
            {
                int groupDate = getGroupDate(fromDate, phieuThuRow);
                string key = StringUtil.Join(new int[] { groupDate, phieuThuRow.PhanLoaiThuId }, "~");
                SoQuyTienMatItem soQuyTienMatItemThu = groupDateToSoQuyTienMatItemsMap[key];
                soQuyTienMatItemThu.SoTienThu += phieuThuRow.SoTien;
            }

            int addedCount = 0;
            foreach (SoQuyTienMatItem soQuyTienMatItemThu in groupDateToSoQuyTienMatItemsMap.Values)
            {
                soQuyTienMatMap.Add(soQuyTienMatItemThu.NgayChungTu.AddMilliseconds(addedCount++), soQuyTienMatItemThu);
            }
        }

        private static int getGroupDate(DateTime fromDate, QLMamNon.Dao.QLMamNonDs.PhieuThuRow phieuThuRow)
        {
            int numberOfDays = (int)(phieuThuRow.Ngay - fromDate).TotalDays;
            int groupDate = numberOfDays / NumberOfDateToGroupPhieuThu;
            return groupDate;
        }

        private void FrmBaoCaoHoatDongTaiChinh_Load(object sender, EventArgs e)
        {
            this.phanLoaiChiRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.PhanLoaiChi);
            this.phanLoaiThuRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.PhanLoaiThu);
        }

        private void FrmSoQuyTienMat_Shown(object sender, EventArgs e)
        {
            this.gvThu.SelectAll();
            this.gvMain.SelectAll();
        }

        private void chkTon_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit chk = (CheckEdit)sender;
            txtTon.Enabled = chk.Checked;
        }
    }
}