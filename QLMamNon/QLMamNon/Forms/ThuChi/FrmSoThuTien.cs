using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ACG.Core.WinForm.Util;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using QLMamNon.Components.Command;
using QLMamNon.Components.Command.QLMNDao;
using QLMamNon.Components.Data.Static;
using QLMamNon.Constant;
using QLMamNon.Facade;
using QLMamNon.Properties;
using QLMamNon.Service.Data;
using QLThuChi;
using ViewBangThuTienDataTable = QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable;
using ViewBangThuTienRow = QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow;

namespace QLMamNon.Forms.ThuChi
{
    public partial class FrmSoThuTien : CRUDForm
    {
        #region Properties

        private QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhDataTable;
        private QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable;
        private Dictionary<int, ViewBangThuTienRow> prevMonthRowDictionary;
        private QLMamNon.Dao.QLMamNonDs.PhieuThuDataTable phieuThuDataTable;
        private DateTime ngayTinh;
        private int lop;

        #endregion

        #region Events

        public FrmSoThuTien()
            : base()
        {
            InitializeComponent();

            this.GridViewColumnSequenceName = null;
            this.TablePrimaryKey = "BangThuTienId";
            this.DanhMuc = DanhMucConstant.SoThuTien;
            this.FormKey = AppForms.FormSoThuTien;

            this.loadLopData();
            this.loadHocSinhData();
            this.InitForm(null, null, null, this.btnLuu, this.btnHuyBo, this.gvMain, this.viewBangThuTienTableAdapter.Adapter, this.viewBangThuTienRowBindingSource.DataSource as ViewBangThuTienDataTable);
        }

        private void FrmSoThuTien_Load(object sender, EventArgs e)
        {
            this.lopRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.LopHoc);
            this.namHocBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.NamHoc);
            this.cmbNam.Text = DateTime.Now.Year.ToString();
            this.cmbThang.Text = DateTime.Now.Month.ToString();
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
                ViewBangThuTienFieldName.SoTienDoDung,
                ViewBangThuTienFieldName.TienAnVaSua,
                ViewBangThuTienFieldName.PhuPhi,
                ViewBangThuTienFieldName.BanTru,
                ViewBangThuTienFieldName.HocPhi
            };

            if (fieldsToEvaluate.Contains(e.Column.FieldName) && e.RowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (e.Value != DBNull.Value)
                {
                    DataRowView rowView = gv.GetRow(e.RowHandle) as DataRowView;
                    ViewBangThuTienRow row = rowView.Row as ViewBangThuTienRow;
                    BangThuTienUtil.EvaluateValuesForViewBangThuTienRow(row,
                        prevMonthRowDictionary != null && prevMonthRowDictionary.ContainsKey(row.HocSinhId) ? prevMonthRowDictionary[row.HocSinhId] : null,
                        bTTKTDataTable, phieuThuDataTable, false, false, false);

                    if (ViewBangThuTienFieldName.SXThangTruoc.Equals(e.Column.FieldName))
                    {
                        BangThuTienUtil.RecalculateBangThuTienKhoanThuList(lopKhoiTableAdapter, khoanThuHangNamTableAdapter, row);
                    }
                }
            }
        }

        private void gvMain_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "HoTen")
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (this.isValidNgayTinhAndLop())
            {
                this.persistNgayTinhAndLop();
                this.loadViewBangThuTiens(ngayTinh, lop);
            }
        }

        private void persistNgayTinhAndLop()
        {
            this.ngayTinh = this.GetNgayTinh();
            this.lop = (int)this.cmbLop.EditValue;
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

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            if (this.isValidNgayTinhAndLop() && !this.isDataTableEmpty())
            {
                RptSoThuTienTrang1 rpt = new RptSoThuTienTrang1();
                this.fillRptSoThuTienTrang1(rpt);
                FormMainFacade.ShowReport(rpt);
            }
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            if (this.isValidNgayTinhAndLop() && !this.isDataTableEmpty())
            {
                RptSoThuTienTrang2 rpt = new RptSoThuTienTrang2();
                this.fillRptSoThuTienTrang2(rpt);
                FormMainFacade.ShowReport(rpt);
            }
        }

        private void btnPrintGiayBaoNopTien_Click(object sender, EventArgs e)
        {
            if (this.isValidNgayTinhAndLop() && !this.isDataTableEmpty())
            {
                RptGiayBaoNopTien rpt = new RptGiayBaoNopTien();
                this.fillRptGiayBaoNopTien(rpt);
                FormMainFacade.ShowReport(rpt);
            }
        }

        protected override void onSaving()
        {
            ViewBangThuTienDataTable table = this.DataTable as ViewBangThuTienDataTable;
            List<int> bangThuTienIds = new List<int>();

            foreach (ViewBangThuTienRow viewBangThuTienRow in table)
            {
                viewBangThuTienRow.SoTienSXThangTruoc = BangThuTienUtil.SXToSoTienSX(viewBangThuTienRow.SXThangTruoc, Settings.Default.TienAnChinh);
                viewBangThuTienRow.SoTienAnSangThangTruoc = BangThuTienUtil.SXAnSangToSoTienAnSang(viewBangThuTienRow.AnSangThangTruoc, Settings.Default.TienAnSang);
                viewBangThuTienRow.SoTienAnToiThangTruoc = BangThuTienUtil.SXAnToiToSoTienAnToi(viewBangThuTienRow.AnToiThangTruoc, Settings.Default.TienAnToi);

                if (this.isNeedToUpdateBangThuTienKhoanThu(viewBangThuTienRow))
                {
                    bangThuTienIds.Add(viewBangThuTienRow.BangThuTienId);
                }
            }

            if (!ListUtil.IsEmpty(bangThuTienIds))
            {
                QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bangThuTienKhoanThuDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(StringUtil.Join(bangThuTienIds, ","));

                foreach (QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow bangThuTienKhoanThuRow in bangThuTienKhoanThuDataTable)
                {
                    ViewBangThuTienRow[] viewBangThuTienRows = (ViewBangThuTienRow[])table.Select(String.Format("BangThuTienId={0}", bangThuTienKhoanThuRow.BangThuTienId));
                    ViewBangThuTienRow viewBangThuTienRow = viewBangThuTienRows[0];
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
                        case BangThuTienConstant.KhoanThuIdAnSang:
                            bangThuTienKhoanThuRow.SoTien = viewBangThuTienRow.SoTienAnSangThangNay;
                            break;
                        case BangThuTienConstant.KhoanThuIdAnToi:
                            bangThuTienKhoanThuRow.SoTien = viewBangThuTienRow.SoTienAnToiThangNay;
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

            foreach (ViewBangThuTienRow viewBangThuTienRow in table)
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

        private bool isDataTableEmpty()
        {
            if (this.DataTable == null || this.DataTable.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách sổ thu tiền trống", "Danh sách trống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        private bool isNeedToUpdateBangThuTienKhoanThu(ViewBangThuTienRow viewBangThuTienRow)
        {
            List<String> fieldsToCheck = new List<string>() { ViewBangThuTienFieldName.SXThangTruoc,
                ViewBangThuTienFieldName.TienAnVaSua,
                ViewBangThuTienFieldName.PhuPhi,
                ViewBangThuTienFieldName.BanTru,
                ViewBangThuTienFieldName.HocPhi,
                ViewBangThuTienFieldName.SoTienAnSangThangNay,
                ViewBangThuTienFieldName.SoTienAnToiThangNay
            };

            foreach (String field in fieldsToCheck)
            {
                object original = viewBangThuTienRow[field, DataRowVersion.Original];
                object current = viewBangThuTienRow[field, DataRowVersion.Current];
                bool isChanged = !ObjectUtil.equals(original, current);

                if (isChanged)
                {
                    return true;
                }
            }

            return false;
        }

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

        private void loadViewBangThuTiens(DateTime ngayTinh, int lop)
        {
            if (this.isNeedToGenerateSoThuTiens(ngayTinh, lop, false))
            {
                this.showFormGenerateSoThuTiens(true);
                return;
            }

            ViewBangThuTienDataTable table = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(ngayTinh, lop);
            List<int> bangThuTienIds = new List<int>(table.Rows.Count);

            foreach (ViewBangThuTienRow row in table)
            {
                bangThuTienIds.Add(row.BangThuTienId);
            }

            if (!ListUtil.IsEmpty(bangThuTienIds))
            {
                bTTKTDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(String.Join(",", bangThuTienIds));
                phieuThuDataTable = phieuThuTableAdapter.GetDataByHocSinhIdAndNgayTinh(-1, ngayTinh);

                SoThuTienService soThuTienService = new SoThuTienService();
                prevMonthRowDictionary = soThuTienService.EvaluatePrevMonthViewBangThuTienTable(ngayTinh.AddMonths(-1), lop);

                foreach (ViewBangThuTienRow row in table)
                {
                    row.HoTen = StaticDataUtil.GetHocSinhFullNameByHocSinhId(hocSinhDataTable, row.HocSinhId);
                    BangThuTienUtil.EvaluateValuesForViewBangThuTienRow(row,
                        prevMonthRowDictionary != null && prevMonthRowDictionary.ContainsKey(row.HocSinhId) ? prevMonthRowDictionary[row.HocSinhId] : null,
                        bTTKTDataTable, phieuThuDataTable, false, false, true);
                    row.AcceptChanges();
                }
            }

            this.viewBangThuTienRowBindingSource.DataSource = table;
            this.DataTable = table;
        }

        #endregion
    }
}