using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using QLMamNon.Facade;
using QLMamNon.Forms.Resource;
using QLMamNon.Components.Data.Static;
using DevExpress.XtraPrinting;
using System.Collections.Generic;
using ACG.Core.WinForm.Util;
using QLMamNon.Dao.QLMamNonDsTableAdapters;
using QLMamNon.Constant;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using QLThuChi;

namespace QLMamNon.Forms.HocSinh
{
    public partial class FrmSoThuTien : CRUDForm
    {
        #region Properties

        private QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhDataTable;
        private QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable;
        private Dictionary<int, int> hocSinhIdsToSoNgayNghiThang;

        #endregion

        #region Events

        public FrmSoThuTien()
            : base()
        {
            InitializeComponent();

            this.GridViewColumnSequenceName = null;
            this.TablePrimaryKey = "BangThuTienId";
            this.DanhMuc = QLMamNon.Forms.Resource.DanhMuc.SoThuTien;
            this.FormKey = AppForms.FormSoThuTien;

            this.loadLopData();
            this.loadHocSinhData();
            this.InitForm(null, null, null, this.btnLuu, this.btnHuyBo, this.gvMain, this.viewBangThuTienTableAdapter.Adapter, this.viewBangThuTienRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable);
        }

        private void FrmSoThuTien_Load(object sender, EventArgs e)
        {
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.LopHoc);
            this.namHocBindingSource.DataSource = StaticDataFacade.Get(DataKeys.NamHoc);
        }

        private void gvMain_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            List<String> fieldsToEvaluate = new List<string>() { "SXThangTruoc",
                "AnSangThangTruoc",
                "SoTienAnSangThangNay",
                "SoTienAnToiThangTruoc",
                "SoTienAnToiThangNay",
                "SoTienNangKhieu",
                "SoTienTruyThu",
                "SoTienDieuHoa" };

            if (fieldsToEvaluate.Contains(e.Column.FieldName) && e.RowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (e.Value != DBNull.Value)
                {
                    DataRowView rowView = gv.GetRow(e.RowHandle) as DataRowView;
                    this.evaluateValuesForViewBangThuTienRow(rowView.Row as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();
            DateTime ngayTinh = this.GetNgayTinh();
            if (ngayTinh != DateTime.MinValue)
            {
                this.loadViewBangThuTienData(ngayTinh);
            }
        }

        private DateTime GetNgayTinh()
        {
            if (!ControlUtil.IsEditValueNull(this.cmbNam) && !ControlUtil.IsEditValueNull(this.cmbThang))
            {
                Int32 nam = (Int32)cmbNam.EditValue;
                int thang = IntUtil.StringToInt((string)cmbThang.EditValue).Value;
                int ngay = DateTime.DaysInMonth(nam, thang);
                DateTime ngayTinh = new DateTime(nam, thang, ngay);
                return ngayTinh;
            }

            return DateTime.MinValue;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.cmbNam.EditValue = DBNull.Value;
            this.cmbThang.EditValue = DBNull.Value;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RptBangKeTongHopThuTienHS rpt = new RptBangKeTongHopThuTienHS();
            this.fillReportBangKeTongHopThuTien(rpt);
            FormMainFacade.ShowReport(rpt);
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            RptSoThuTienTrang1 rpt = new RptSoThuTienTrang1();
            this.fillRptSoThuTienTrang1(rpt);
            FormMainFacade.ShowReport(rpt);
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            RptSoThuTienTrang2 rpt = new RptSoThuTienTrang2();
            this.fillRptSoThuTienTrang2(rpt);
            FormMainFacade.ShowReport(rpt);
        }

        protected override void onSaving()
        {
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable table = this.DataTable as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable;
            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in table)
            {
                row.SoTienSXThangTruoc = this.sxToSoTienSX(row.SXThangTruoc);
                row.SoTienAnSangThangTruoc = this.sxAnSangToSoTienAnSang(row.AnSangThangTruoc);
            }

            base.onSaving();
        }

        #endregion

        #region Validation

        #endregion

        #region Helper

        private void loadLopData()
        {
            QLMamNon.Dao.QLMamNonDs.LopDataTable dataTable = StaticDataFacade.Get(DataKeys.LopHoc) as QLMamNon.Dao.QLMamNonDs.LopDataTable;

            foreach (QLMamNon.Dao.QLMamNonDs.LopRow row in dataTable)
            {
                int? khoiId = StaticDataUtil.GetKhoiIdByLopId(this.lopKhoiTableAdapter, row.LopId);
                if (khoiId.HasValue)
                {
                    row.KhoiId = khoiId.Value;
                }
            }

            this.lopRowBindingSource.DataSource = dataTable;
        }

        private void loadHocSinhData()
        {
            hocSinhDataTable = this.hocSinhTableAdapter.GetData();
        }

        private void loadViewBangThuTienData(DateTime ngayTinh)
        {
            long genHistoryCount = (long)bangThuTienGenHistoryTableAdapter.countBangThuTienGenHistoryByLopAndNgayTinh(null, ngayTinh);

            if (genHistoryCount == 0)
            {
                this.generateSoThuTienByLopAndThangNam(ngayTinh, this.bangThuTienTableAdapter);
                this.bangThuTienGenHistoryTableAdapter.Insert(ngayTinh, null, DateTime.Now);
            }

            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable table = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(ngayTinh, null);

            List<int> bangThuTienIds = new List<int>(table.Rows.Count);

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in table)
            {
                bangThuTienIds.Add(row.BangThuTienId);
            }

            if (!ListUtil.IsEmpty(bangThuTienIds))
            {
                bTTKTDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(String.Join(",", bangThuTienIds));

                foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in table)
                {
                    row.HoTen = StaticDataUtil.getHocSinhFullNameByHocSinhId(hocSinhDataTable, row.HocSinhId);
                    evaluateValuesForViewBangThuTienRow(row);
                }
            }

            this.viewBangThuTienRowBindingSource.DataSource = table;
            this.DataTable = table;
        }

        private void evaluateValuesForViewBangThuTienRow(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row)
        {
            row.TienAnSua = 0;
            row.PhuPhi = 0;
            row.BanTru = 0;
            row.HocPhi = 0;
            row.KhoanThuChinh = 0;
            evaluateValuesForAdditionalFields(row);
            row.KhoanThuChinh = row.TienAnSua + row.PhuPhi + row.BanTru + row.HocPhi;
            row.SoTienNopLan1 = 0;
            row.SoTienNopLan2 = 0;
            row.SoTienSXThangTruoc = this.sxToSoTienSX(row.SXThangTruoc);
            row.SoTienAnSangThangTruoc = this.sxAnSangToSoTienAnSang(row.AnSangThangTruoc);
            row.SoTienAnSangConLai = row.SoTienAnSangThangNay - row.SoTienAnSangThangTruoc;
            row.SoTienAnToiConLai = row.SoTienAnToiThangNay - row.SoTienAnToiThangTruoc;
            row.ThanhTien = this.calculateThanhTien(row);
        }

        private void evaluateValuesForAdditionalFields(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row)
        {
            QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow[] bangThuTienKhoanThuRows = bTTKTDataTable.Select(String.Format("BangThuTienId={0}", row.BangThuTienId)) as QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow[];

            if (!ListUtil.IsEmpty(bangThuTienKhoanThuRows))
            {
                foreach (QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow bangThuTienKhoanThuRow in bangThuTienKhoanThuRows)
                {
                    switch (bangThuTienKhoanThuRow.KhoanThuId)
                    {
                        case BangThuTienConstant.KhoanThuIdTienAnSua:
                            row.TienAnSua = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdPhuPhi:
                            row.PhuPhi = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdBanTru:
                            row.BanTru = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdHocPhi:
                            row.HocPhi = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdAnSang:
                            row.SoTienAnSangThangNay = bangThuTienKhoanThuRow.SoTien;
                            break;
                        case BangThuTienConstant.KhoanThuIdAnToi:
                            row.SoTienAnToiThangNay = bangThuTienKhoanThuRow.SoTien;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private long calculateSoTienPhi(int? khoiId, int soNgayNghiThang, long orgSoTien, int khoanThuId)
        {
            long soTien = orgSoTien;

            if (khoiId.HasValue)
            {
                QLMamNon.Dao.QLMamNonDs.BangTinhPhiDataTable bangTinhPhiTable = StaticDataFacade.Get(DataKeys.BangTinhPhi) as QLMamNon.Dao.QLMamNonDs.BangTinhPhiDataTable;
                QLMamNon.Dao.QLMamNonDs.BangTinhPhiRow[] bangTinhPhiRows = bangTinhPhiTable.Select(String.Format("KhoiId={0} AND SoNgayNghiMin<={1} AND SoNgayNghiMax>={1} AND KhoanThuId={2}", khoiId.Value, soNgayNghiThang, khoanThuId)) as QLMamNon.Dao.QLMamNonDs.BangTinhPhiRow[];
                if (!ArrayUtil.IsEmpty(bangTinhPhiRows))
                {
                    soTien = bangTinhPhiRows[0].SoTien;
                }
            }

            return soTien;
        }

        private void generateSoThuTienByLopAndThangNam(DateTime ngayTinh, BangThuTienTableAdapter bangThuTienTableAdapter)
        {
            QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable = hocSinhTableAdapter.GetHocSinhByLopAndNgay(null, ngayTinh);

            List<int> hocSinhIds = new List<int>(hocSinhTable.Rows.Count);

            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow hocSinh in hocSinhTable)
            {
                hocSinhIds.Add(hocSinh.HocSinhId);
            }

            if (!ListUtil.IsEmpty(hocSinhIds))
            {
                hocSinhIdsToSoNgayNghiThang = new Dictionary<int, int>(hocSinhIds.Count);
                QLMamNon.Dao.QLMamNonDs.UnknownColumnViewDataTable hocTapTable = soNgayNghiThangByHocSinhIdTableAdapter.GetData(StringUtil.Join(hocSinhIds, ","), ngayTinh) as QLMamNon.Dao.QLMamNonDs.UnknownColumnViewDataTable;

                foreach (QLMamNon.Dao.QLMamNonDs.UnknownColumnViewRow hocTapRow in hocTapTable)
                {
                    hocSinhIdsToSoNgayNghiThang.Add((int)hocTapRow["HocSinhId"], (int)hocTapRow["SoNgayNghiThang"]);
                }
            }

            Dictionary<int, QLMamNon.Dao.QLMamNonDs.HocSinhLopRow> hocSinhIdsToHocSinhLops = StaticDataUtil.GetHocSinhLopsByHocSinhIds(hocSinhLopTableAdapter, hocSinhIds, this.GetNgayTinh());

            int stt = 1;
            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow hocSinh in hocSinhTable)
            {
                if (hocSinhIdsToHocSinhLops.ContainsKey(hocSinh.HocSinhId))
                {
                    this.generateSoThuTienByHocSinhAndLopAndNgayTinh(hocSinh.HocSinhId, hocSinhIdsToHocSinhLops[hocSinh.HocSinhId].LopId, ngayTinh, stt);
                    stt++;
                }
            }
        }

        private void generateSoThuTienByHocSinhAndLopAndNgayTinh(int hocSinhId, int lopId, DateTime ngayTinh, int stt)
        {
            int sXThangTruoc = 0;
            long soTienSXThangTruoc = this.sxToSoTienSX(sXThangTruoc);
            int anSangThangTruoc = 0;
            long soTienAnSangThangTruoc = this.sxAnSangToSoTienAnSang(anSangThangTruoc);
            long soTienAnSangThangNay = 0;
            long soTienAnToiThangTruoc = 0;
            long soTienAnToiThangNay = 0;
            long soTienNangKhieu = 0;
            long soTienTruyThu = 0;
            long soTienDieuHoa = 0;
            long soTienDoDung = 0;
            String ghiChu = "";
            bangThuTienTableAdapter.Insert(hocSinhId, lopId, sXThangTruoc, soTienSXThangTruoc, anSangThangTruoc, soTienAnSangThangTruoc, soTienAnSangThangNay, soTienAnToiThangTruoc, soTienAnToiThangNay, soTienNangKhieu, soTienTruyThu, ngayTinh, stt, 0, DateTime.Now, ghiChu, soTienDieuHoa, soTienDoDung);
            int bangThuTienId = (int)bangThuTienTableAdapter.Adapter.InsertCommand.LastInsertedId;
            int khoiId = StaticDataUtil.GetKhoiIdByLopId(lopKhoiTableAdapter, lopId).Value;
            this.generateBangThuTienKhoanThu(bangThuTienId, khoiId, hocSinhId, ngayTinh, hocSinhIdsToSoNgayNghiThang);
        }

        private void generateBangThuTienKhoanThu(int bangThuTienId, int khoiId, int hocSinhId, DateTime ngayTinh, Dictionary<int, int> hocSinhIdsToSoNgayNghiThang)
        {
            int soNgayNghiThang = 0;

            if (hocSinhIdsToSoNgayNghiThang.ContainsKey(hocSinhId))
            {
                soNgayNghiThang = hocSinhIdsToSoNgayNghiThang[hocSinhId];
            }

            int[] khoanThuIds = new int[] { BangThuTienConstant.KhoanThuIdBanTru, BangThuTienConstant.KhoanThuIdHocPhi, BangThuTienConstant.KhoanThuIdPhuPhi, BangThuTienConstant.KhoanThuIdTienAnSua, BangThuTienConstant.KhoanThuIdAnSang, BangThuTienConstant.KhoanThuIdAnToi };
            QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamDataTable khoanThuHangNamTable = khoanThuHangNamTableAdapter.GetKhoanThuHangNamByParams(String.Join(",", khoanThuIds), khoiId, ngayTinh);

            foreach (QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamRow row in khoanThuHangNamTable)
            {
                long soTien = this.calculateSoTienPhi(khoiId, soNgayNghiThang, row.SoTien, row.KhoanThuId);
                bangThuTienKhoanThuTableAdapter.Insert(row.KhoanThuId, bangThuTienId, soTien);
            }
        }

        private long sxToSoTienSX(int sx)
        {
            return sx * 20000;
        }

        private long sxAnSangToSoTienAnSang(int sx)
        {
            return sx * 6000;
        }

        private long calculateThanhTien(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienRow)
        {
            return bangThuTienRow.TienAnSua + bangThuTienRow.PhuPhi + bangThuTienRow.BanTru + bangThuTienRow.HocPhi -
                        bangThuTienRow.SoTienSXThangTruoc + bangThuTienRow.SoTienAnSangConLai + bangThuTienRow.SoTienAnToiConLai +
                        bangThuTienRow.SoTienNangKhieu + bangThuTienRow.SoTienTruyThu + bangThuTienRow.SoTienDieuHoa;
        }

        private void fillReportBangKeTongHopThuTien(RptBangKeTongHopThuTienHS rpt)
        {
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = new List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow>(this.GridViewMain.RowCount);
            List<int> hocSinhIds = new List<int>(this.GridViewMain.DataRowCount);
            for (int i = 0; i < this.GridViewMain.DataRowCount; i++)
            {
                object dataRow = this.GridViewMain.GetRow(this.GridViewMain.GetVisibleRowHandle(i));
                QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow = (dataRow as DataRowView).Row as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow;
                rows.Add(viewBangThuTienRow);
                hocSinhIds.Add(viewBangThuTienRow.HocSinhId);
            }

            Dictionary<int, QLMamNon.Dao.QLMamNonDs.LopRow> hocSinhIdsToLopNames = StaticDataUtil.GetLopsByHocSinhIds(hocSinhLopTableAdapter, hocSinhIds, this.GetNgayTinh());

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow in rows)
            {
                viewBangThuTienRow.HoTen = StaticDataUtil.getHocSinhFullNameByHocSinhId(this.hocSinhDataTable, viewBangThuTienRow.HocSinhId);

                if (hocSinhIdsToLopNames.ContainsKey(viewBangThuTienRow.HocSinhId))
                {
                    viewBangThuTienRow.Lop = hocSinhIdsToLopNames[viewBangThuTienRow.HocSinhId].Name;
                }
            }

            rpt.viewBangThuTienRowbindingSource.DataSource = rows;
            rpt.Ngay.Value = this.GetNgayTinh();
        }

        private void fillRptSoThuTienTrang1(RptSoThuTienTrang1 rpt)
        {
            rpt.viewBangThuTienRowbindingSource.DataSource = this.viewBangThuTienRowBindingSource.DataSource;
            rpt.Ngay.Value = this.GetNgayTinh();
        }

        private void fillRptSoThuTienTrang2(RptSoThuTienTrang2 rpt)
        {
            rpt.viewBangThuTienRowbindingSource.DataSource = this.viewBangThuTienRowBindingSource.DataSource;
            rpt.Ngay.Value = this.GetNgayTinh();
        }

        #endregion
    }
}