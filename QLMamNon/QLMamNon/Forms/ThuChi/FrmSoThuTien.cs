using System;
using System.Collections.Generic;
using System.Data;
using ACG.Core.WinForm.Util;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Components.Command;
using QLMamNon.Components.Command.QLMNDao;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Entity.Form;
using QLMamNon.Facade;
using QLMamNon.Forms.Resource;
using QLThuChi;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmSoThuTien : CRUDForm
    {
        #region Properties

        private QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhDataTable;
        private QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable;
        private Dictionary<int, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> prevMonthRowDictionary;
        private QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable;

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
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
            this.namHocBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.NamHoc);
        }

        private void gvMain_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            List<String> fieldsToEvaluate = new List<string>() { ViewBangThuTienFieldName.SXThangTruoc,
                ViewBangThuTienFieldName.AnSangThangTruoc,
                ViewBangThuTienFieldName.SoTienAnSangThangNay,
                ViewBangThuTienFieldName.AnToiThangTruoc,
                ViewBangThuTienFieldName.SoTienAnToiThangNay,
                ViewBangThuTienFieldName.SoTienNangKhieu,
                ViewBangThuTienFieldName.SoTienTruyThu,
                ViewBangThuTienFieldName.SoTienDieuHoa,
                ViewBangThuTienFieldName.SoTienDoDung
            };

            if (fieldsToEvaluate.Contains(e.Column.FieldName) && e.RowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (e.Value != DBNull.Value)
                {
                    DataRowView rowView = gv.GetRow(e.RowHandle) as DataRowView;
                    QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row = rowView.Row as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow;
                    BangThuTienUtil.EvaluateValuesForViewBangThuTienRow(row, prevMonthRowDictionary != null && prevMonthRowDictionary.ContainsKey(row.HocSinhId) ? prevMonthRowDictionary[row.HocSinhId] : null, bTTKTDataTable, phieuThuDataTable, false);

                    if (ViewBangThuTienFieldName.SXThangTruoc.Equals(e.Column.FieldName))
                    {
                        this.recalculateBangThuTienKhoanThuList(row);
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();
            DateTime ngayTinh = this.GetNgayTinh();
            if (ngayTinh != DateTime.MinValue)
            {
                this.loadViewBangThuTiens(ngayTinh);
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
            if (this.isValidNgayTinh())
            {
                RptBangKeTongHopThuTienHS rpt = new RptBangKeTongHopThuTienHS();
                this.fillReportBangKeTongHopThuTien(rpt);
                FormMainFacade.ShowReport(rpt);
            }
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            if (this.isValidNgayTinh())
            {
                RptSoThuTienTrang1 rpt = new RptSoThuTienTrang1();
                this.fillRptSoThuTienTrang1(rpt);
                FormMainFacade.ShowReport(rpt);
            }
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            if (this.isValidNgayTinh())
            {
                RptSoThuTienTrang2 rpt = new RptSoThuTienTrang2();
                this.fillRptSoThuTienTrang2(rpt);
                FormMainFacade.ShowReport(rpt);
            }
        }

        protected override void onSaving()
        {
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable table = this.DataTable as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable;
            List<int> bangThuTienIds = new List<int>();
            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow in table)
            {
                viewBangThuTienRow.SoTienSXThangTruoc = BangThuTienUtil.SXToSoTienSX(viewBangThuTienRow.SXThangTruoc);
                viewBangThuTienRow.SoTienAnSangThangTruoc = BangThuTienUtil.SXAnSangToSoTienAnSang(viewBangThuTienRow.AnSangThangTruoc);
                viewBangThuTienRow.SoTienAnToiThangTruoc = BangThuTienUtil.SXAnToiToSoTienAnToi(viewBangThuTienRow.AnToiThangTruoc);

                if (viewBangThuTienRow[ViewBangThuTienFieldName.SXThangTruoc, DataRowVersion.Original] != DBNull.Value && viewBangThuTienRow[ViewBangThuTienFieldName.SXThangTruoc, DataRowVersion.Current] != DBNull.Value)
                {
                    int originalVersionToCompare = (int)viewBangThuTienRow[ViewBangThuTienFieldName.SXThangTruoc, DataRowVersion.Original];
                    int currentVersionToCompare = (int)viewBangThuTienRow[ViewBangThuTienFieldName.SXThangTruoc, DataRowVersion.Current];

                    if (originalVersionToCompare != currentVersionToCompare)
                    {
                        bangThuTienIds.Add(viewBangThuTienRow.BangThuTienId);
                    }
                }
            }

            if (!ListUtil.IsEmpty(bangThuTienIds))
            {
                QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bangThuTienKhoanThuDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(StringUtil.Join(bangThuTienIds, ","));

                foreach (QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow bangThuTienKhoanThuRow in bangThuTienKhoanThuDataTable)
                {
                    QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow[] viewBangThuTienRows = (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow[])table.Select(String.Format("BangThuTienId={0}", bangThuTienKhoanThuRow.BangThuTienId));
                    QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow = viewBangThuTienRows[0];
                    switch (bangThuTienKhoanThuRow.KhoanThuId)
                    {
                        case BangThuTienConstant.KhoanThuIdTienAnSua:
                            bangThuTienKhoanThuRow.SoTien = viewBangThuTienRow.TienAnSua;
                            break;
                        case BangThuTienConstant.KhoanThuIdPhuPhi:
                            bangThuTienKhoanThuRow.SoTien = viewBangThuTienRow.PhuPhi;
                            break;
                        case BangThuTienConstant.KhoanThuIdBanTru:
                            bangThuTienKhoanThuRow.SoTien = viewBangThuTienRow.BanTru;
                            break;
                        case BangThuTienConstant.KhoanThuIdHocPhi:
                            bangThuTienKhoanThuRow.SoTien = viewBangThuTienRow.HocPhi;
                            break;
                        default:
                            break;
                    }
                }

                bangThuTienKhoanThuTableAdapter.Update(bangThuTienKhoanThuDataTable);
            }

            // Start Updating SoTienTruyThu for each BangThuTienRow
            QLMNDaoJobInvoker qlmnDaoJobInvoker = new QLMNDaoJobInvoker();
            qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand = new UpdateSoTienTruyThuOfBangThuTienCommand();
            qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Add(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterViewBangThuTienTableAdapter, this.viewBangThuTienTableAdapter);

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow in table)
            {
                if (viewBangThuTienRow[ViewBangThuTienFieldName.ThanhTien, DataRowVersion.Original] != DBNull.Value && viewBangThuTienRow[ViewBangThuTienFieldName.ThanhTien, DataRowVersion.Current] != DBNull.Value)
                {
                    long originalVersionToCompare = (long)viewBangThuTienRow[ViewBangThuTienFieldName.ThanhTien, DataRowVersion.Original];
                    long currentVersionToCompare = (long)viewBangThuTienRow[ViewBangThuTienFieldName.ThanhTien, DataRowVersion.Current];

                    if (originalVersionToCompare != currentVersionToCompare)
                    {
                        qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Remove(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterCurrentViewBangThuTien);
                        qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Remove(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterSoTienAdded);
                        qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Add(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterCurrentViewBangThuTien, viewBangThuTienRow);
                        qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTienCommand.CommandParameter.Add(UpdateSoTienTruyThuOfBangThuTienCommand.ParameterSoTienAdded, currentVersionToCompare - originalVersionToCompare);
                        qlmnDaoJobInvoker.UpdateSoTienTruyThuOfBangThuTien();
                    }
                }
            }
            // Finished Updating SoTienTruyThu for each BangThuTien

            base.onSaving();
        }

        #endregion

        #region Validation

        #endregion

        #region Helper

        private void loadLopData()
        {
            QLMamNon.Dao.QLMamNonDs.LopDataTable dataTable = StaticDataFacade.Get(StaticDataKeys.LopHoc) as QLMamNon.Dao.QLMamNonDs.LopDataTable;

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

        private void loadViewBangThuTiens(DateTime ngayTinh)
        {
            if (!this.isValidNgayTinh())
            {
                return;
            }

            if (this.isNeedToGenerateSoThuTiens(ngayTinh))
            {
                this.showFormGenerateSoThuTiens(true);
                return;
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
                phieuThuDataTable = phieuThuTableAdapter.GetDataByHocSinhIdAndNgayTinh(-1, ngayTinh);

                evaluatePrevMonthViewBangThuTienTable(ngayTinh.AddMonths(-1));

                foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in table)
                {
                    row.HoTen = StaticDataUtil.getHocSinhFullNameByHocSinhId(hocSinhDataTable, row.HocSinhId);
                    BangThuTienUtil.EvaluateValuesForViewBangThuTienRow(row, prevMonthRowDictionary != null && prevMonthRowDictionary.ContainsKey(row.HocSinhId) ? prevMonthRowDictionary[row.HocSinhId] : null, bTTKTDataTable, phieuThuDataTable, false);
                    row.AcceptChanges();
                }
            }

            this.viewBangThuTienRowBindingSource.DataSource = table;
            this.DataTable = table;
        }

        private void evaluatePrevMonthViewBangThuTienTable(DateTime ngayTinh)
        {
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable prevMonthBangThuTienTable = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(ngayTinh, null);
            List<int> prevMonthBangThuTienIds = new List<int>(prevMonthBangThuTienTable.Rows.Count);

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in prevMonthBangThuTienTable)
            {
                prevMonthBangThuTienIds.Add(row.BangThuTienId);
            }

            if (!ListUtil.IsEmpty(prevMonthBangThuTienIds))
            {
                QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable prevMonthBTTKTDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(String.Join(",", prevMonthBangThuTienIds));
                QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable prevMonthPhieuThuDataTable = phieuThuTableAdapter.GetDataByHocSinhIdAndNgayTinh(-1, ngayTinh);
                prevMonthRowDictionary = new Dictionary<int, Dao.QLMamNonDs.ViewBangThuTienRow>();

                foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in prevMonthBangThuTienTable)
                {
                    BangThuTienUtil.EvaluateValuesForViewBangThuTienRow(row, null, prevMonthBTTKTDataTable, prevMonthPhieuThuDataTable, true);
                    prevMonthRowDictionary.Add(row.HocSinhId, row);
                }
            }
        }

        private void recalculateBangThuTienKhoanThuList(QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow)
        {
            int khoiId = StaticDataUtil.GetKhoiIdByLopId(lopKhoiTableAdapter, viewBangThuTienRow.LopId).Value;
            int[] khoanThuIds = new int[] { BangThuTienConstant.KhoanThuIdBanTru, BangThuTienConstant.KhoanThuIdHocPhi, BangThuTienConstant.KhoanThuIdPhuPhi, BangThuTienConstant.KhoanThuIdTienAnSua, BangThuTienConstant.KhoanThuIdAnSang, BangThuTienConstant.KhoanThuIdAnToi };
            QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamDataTable khoanThuHangNamTable = khoanThuHangNamTableAdapter.GetKhoanThuHangNamByParams(String.Join(",", khoanThuIds), khoiId, viewBangThuTienRow.NgayTinh);

            foreach (QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamRow row in khoanThuHangNamTable)
            {
                long soTien = BangThuTienUtil.CalculateSoTienPhi(khoiId, viewBangThuTienRow.SXThangTruoc, row.SoTien, row.KhoanThuId);
                switch (row.KhoanThuId)
                {
                    case BangThuTienConstant.KhoanThuIdTienAnSua:
                        viewBangThuTienRow.TienAnSua = soTien;
                        break;
                    case BangThuTienConstant.KhoanThuIdPhuPhi:
                        viewBangThuTienRow.PhuPhi = soTien;
                        break;
                    case BangThuTienConstant.KhoanThuIdBanTru:
                        viewBangThuTienRow.BanTru = soTien;
                        break;
                    case BangThuTienConstant.KhoanThuIdHocPhi:
                        viewBangThuTienRow.HocPhi = soTien;
                        break;
                    default:
                        break;
                }
            }
        }

        private void fillReportBangKeTongHopThuTien(RptBangKeTongHopThuTienHS rpt)
        {
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = evaluateViewBangThuTienRowsForReport();
            List<BangKeThuTienItem> rowsToDisplay = new List<BangKeThuTienItem>();
            Dictionary<int, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> hocSinhIdsToViewBangThuTienRows = new Dictionary<int, QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow>();

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow in rows)
            {
                hocSinhIdsToViewBangThuTienRows.Add(viewBangThuTienRow.HocSinhId, viewBangThuTienRow);
            }

            QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable = phieuThuTableAdapter.GetDataByHocSinhIdsAndThangNam(StringUtil.Join(new List<int>(hocSinhIdsToViewBangThuTienRows.Keys), ","), this.GetNgayTinh().Year, this.GetNgayTinh().Month);
            int stt = 1;

            foreach (QLMamNon.Dao.QLMamNonDs.PhieuThuRow phieuThuRow in phieuThuDataTable)
            {
                QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow viewBangThuTienRow = hocSinhIdsToViewBangThuTienRows[phieuThuRow.HocSinhId];
                BangKeThuTienItem bangKeThuTienItem = new BangKeThuTienItem()
                {
                    STT = stt++,
                    HocSinhId = viewBangThuTienRow.HocSinhId,
                    HoTen = viewBangThuTienRow.HoTen,
                    Lop = viewBangThuTienRow.Lop,
                    NgayNop = phieuThuRow.Ngay,
                    SoBienLai = phieuThuRow.MaPhieu,
                    PhuPhi = viewBangThuTienRow.PhuPhi,
                    BanTru = viewBangThuTienRow.BanTru,
                    HocPhi = viewBangThuTienRow.HocPhi,
                    AnChinh = viewBangThuTienRow.TienAnSua,
                    AnSang = viewBangThuTienRow.SoTienAnSangConLai,
                    AnToi = viewBangThuTienRow.SoTienAnToiConLai,
                    NangKhieu = viewBangThuTienRow.SoTienNangKhieu,
                    DoDung = viewBangThuTienRow.SoTienDoDung,
                    DieuHoa = viewBangThuTienRow.SoTienDieuHoa,
                    TruyThu = viewBangThuTienRow.SoTienTruyThu,
                    PhaiThu = viewBangThuTienRow.ThanhTien,
                    DaThu = phieuThuRow.SoTien,
                    ConNo = viewBangThuTienRow.ThanhTien - phieuThuRow.SoTien
                };

                if (!ListUtil.IsEmpty(rowsToDisplay))
                {
                    BangKeThuTienItem prevVangKeThuTienItem = rowsToDisplay[rowsToDisplay.Count - 1];

                    if (prevVangKeThuTienItem.HocSinhId == bangKeThuTienItem.HocSinhId)
                    {
                        bangKeThuTienItem.TruyThu = prevVangKeThuTienItem.ConNo;
                        bangKeThuTienItem.PhaiThu = prevVangKeThuTienItem.ConNo;
                        bangKeThuTienItem.ConNo = bangKeThuTienItem.PhaiThu - bangKeThuTienItem.DaThu;
                    }
                }

                rowsToDisplay.Add(bangKeThuTienItem);
            }

            rpt.viewBangThuTienRowbindingSource.DataSource = rowsToDisplay;
            rpt.Ngay.Value = this.GetNgayTinh();
        }

        private List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> evaluateViewBangThuTienRowsForReport()
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
            return rows;
        }

        private void fillRptSoThuTienTrang1(RptSoThuTienTrang1 rpt)
        {
            List<QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow> rows = evaluateViewBangThuTienRowsForReport();
            rpt.viewBangThuTienRowbindingSource.DataSource = rows;
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