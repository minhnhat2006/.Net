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

namespace QLMamNon.Forms.HocSinh
{
    public partial class FrmSoThuTien : CRUDForm
    {
        #region Properties

        private QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhDataTable;

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
            this.khoiRowBindingSource.DataSource = StaticDataFacade.Get(DataKeys.KhoiHoc);
            this.namHocBindingSource.DataSource = StaticDataFacade.Get(DataKeys.NamHoc);
        }

        private void gvMain_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "HocSinhId" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object hocSinhId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "HocSinhId");
                if (hocSinhId != DBNull.Value)
                {
                    e.DisplayText = StaticDataUtil.getHocSinhFullNameByHocSinhId(hocSinhDataTable, (int)hocSinhId);
                }
            }
            if (e.Column.FieldName == "SoTienSXThangTruoc" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object sxThangTruoc = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "SXThangTruoc");
                if (sxThangTruoc != DBNull.Value)
                {
                    e.DisplayText = (this.sxToSoTienSX((int)sxThangTruoc)).ToString();
                }
            }
            if (e.Column.FieldName == "SoTienAnSangThangTruoc" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object anSangThangTruoc = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "AnSangThangTruoc");
                if (anSangThangTruoc != DBNull.Value)
                {
                    e.DisplayText = (this.SXAnSangToSoTienAnSang((int)anSangThangTruoc)).ToString();
                }
            }
            if (e.Column.FieldName == "SoTienAnSangConLai" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object bangThuTienId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "BangThuTienId");
                QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow[] bangThuTienRows = this.DataTable.Select(String.Format("BangThuTienId={0}", bangThuTienId)) as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow[];
                if (bangThuTienRows != null && bangThuTienRows.Length > 0)
                {
                    QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienRow = bangThuTienRows[0];
                    bangThuTienRow.SoTienAnSangConLai = bangThuTienRow.SoTienAnSangThangNay - bangThuTienRow.SoTienAnSangThangTruoc;
                }
            }
            if (e.Column.FieldName == "SoTienAnToiConLai" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object bangThuTienId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "BangThuTienId");
                QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow[] bangThuTienRows = this.DataTable.Select(String.Format("BangThuTienId={0}", bangThuTienId)) as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow[];
                if (bangThuTienRows != null && bangThuTienRows.Length > 0)
                {
                    QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienRow = bangThuTienRows[0];
                    bangThuTienRow.SoTienAnToiConLai = bangThuTienRow.SoTienAnToiThangNay - bangThuTienRow.SoTienAnToiThangTruoc;
                }
            }
            if (e.Column.FieldName == "ThanhTien" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                object bangThuTienId = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "BangThuTienId");
                QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow[] bangThuTienRows = this.DataTable.Select(String.Format("BangThuTienId={0}", bangThuTienId)) as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow[];
                if (bangThuTienRows != null && bangThuTienRows.Length > 0)
                {
                    QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow bangThuTienRow = bangThuTienRows[0];
                    e.DisplayText = (bangThuTienRow.TienAnSua + bangThuTienRow.PhuPhi + bangThuTienRow.BanTru + bangThuTienRow.HocPhi +
                        bangThuTienRow.SoTienSXThangTruoc + bangThuTienRow.SoTienAnSangConLai + bangThuTienRow.SoTienAnToiConLai +
                        bangThuTienRow.SoTienNangKhieu + bangThuTienRow.SoTienTruyThu).ToString();
                }
            }
        }

        private void gvMain_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.RowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (e.Value != DBNull.Value)
                {

                }
            }
        }

        private void cmbKhoi_EditValueChanged(object sender, EventArgs e)
        {
            QLMamNon.Dao.QLMamNonDs.LopDataTable table = StaticDataFacade.Get(DataKeys.LopHoc) as QLMamNon.Dao.QLMamNonDs.LopDataTable;
            if (cmbKhoiHoc.EditValue != DBNull.Value && cmbKhoiHoc.EditValue != null)
            {
                this.lopRowBindingSource.DataSource = table.Select(String.Format("KhoiId={0}", cmbKhoiHoc.EditValue));
            }
            else
            {
                this.lopRowBindingSource.DataSource = null;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();
            if (ControlUtil.IsEditValueNull(this.cmbLopHoc))
            {
                return;
            }

            if (!ControlUtil.IsEditValueNull(this.cmbNam) && !ControlUtil.IsEditValueNull(this.cmbThang))
            {
                Int32 nam = (Int32)cmbNam.EditValue;
                int thang = IntUtil.stringToInt((string)cmbThang.EditValue).Value;
                int ngay = 1;
                this.loadViewBangThuTienData((int)this.cmbLopHoc.EditValue, new DateTime(nam, thang, ngay));
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            dialog.FileName = "SoThuTien.xlsx";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.gvMain.ExportToXlsx(dialog.FileName, new XlsxExportOptions(TextExportMode.Text));
            }
        }

        protected override void onSaving()
        {
            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable table = this.DataTable as QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable;
            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in table)
            {
                row.SoTienSXThangTruoc = this.sxToSoTienSX(row.SXThangTruoc);
                row.SoTienAnSangThangTruoc = this.SXAnSangToSoTienAnSang(row.AnSangThangTruoc);
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

        private void loadViewBangThuTienData(int lopId, DateTime ngayTinh)
        {
            long genHistoryCount = (long)bangThuTienGenHistoryTableAdapter.countBangThuTienGenHistoryByLopAndNgayTinh(lopId, ngayTinh);

            if (genHistoryCount == 0)
            {
                this.generateSoThuTienByLopAndThangNam(lopId, ngayTinh, this.bangThuTienTableAdapter);
                this.bangThuTienGenHistoryTableAdapter.Insert(ngayTinh, lopId, DateTime.Now);
            }

            QLMamNon.Dao.QLMamNonDs.ViewBangThuTienDataTable table = viewBangThuTienTableAdapter.GetViewBangThuTienByNgayTinhAndLop(ngayTinh, lopId);

            List<int> bangThuTienIds = new List<int>(table.Rows.Count);
            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in table)
            {
                bangThuTienIds.Add(row.BangThuTienId);
            }

            QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuDataTable bTTKTDataTable = bangThuTienKhoanThuTableAdapter.GetBangThuTienKhoanThuByBangThuTienIds(String.Join(",", bangThuTienIds));

            foreach (QLMamNon.Dao.QLMamNonDs.ViewBangThuTienRow row in table)
            {
                row.TienAnSua = 0;
                row.PhuPhi = 0;
                row.BanTru = 0;
                row.HocPhi = 0;
                row.KhoanThuChinh = 0;

                QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow[] bangThuTienKhoanThuRows = bTTKTDataTable.Select(String.Format("BangThuTienId={0}", row.BangThuTienId)) as QLMamNon.Dao.QLMamNonDs.BangThuTienKhoanThuRow[];

                if (bangThuTienKhoanThuRows == null || bangThuTienKhoanThuRows.Length == 0)
                {
                    continue;
                }

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
                        default:
                            break;
                    }
                }

                row.KhoanThuChinh = row.TienAnSua + row.PhuPhi + row.BanTru + row.HocPhi;
            }

            this.viewBangThuTienRowBindingSource.DataSource = table;
            this.DataTable = table;
        }

        private void generateSoThuTienByLopAndThangNam(int lopId, DateTime ngayTinh, BangThuTienTableAdapter bangThuTienTableAdapter)
        {
            QLMamNon.Dao.QLMamNonDs.HocSinhDataTable hocSinhTable = hocSinhTableAdapter.GetHocSinhByLopAndNgay(lopId, ngayTinh);
            int stt = 1;
            foreach (QLMamNon.Dao.QLMamNonDs.HocSinhRow hocSinh in hocSinhTable)
            {
                this.generateSoThuTienByHocSinhAndLopAndNgayTinh(hocSinh.HocSinhId, lopId, ngayTinh, stt);
                stt++;
            }
        }

        private void generateSoThuTienByHocSinhAndLopAndNgayTinh(int hocSinhId, int lopId, DateTime ngayTinh, int stt)
        {
            int sXThangTruoc = 0;
            long soTienSXThangTruoc = this.sxToSoTienSX(sXThangTruoc);
            int anSangThangTruoc = 0;
            long soTienAnSangThangTruoc = this.SXAnSangToSoTienAnSang(anSangThangTruoc);
            long soTienAnSangThangNay = 0;
            long soTienAnToiThangTruoc = 0;
            long soTienAnToiThangNay = 0;
            long soTienNangKhieu = 0;
            long soTienTruyThu = 0;
            String ghiChu = "";
            bangThuTienTableAdapter.Insert(hocSinhId, lopId, sXThangTruoc, soTienSXThangTruoc, anSangThangTruoc, soTienAnSangThangTruoc, soTienAnSangThangNay, soTienAnToiThangTruoc, soTienAnToiThangNay, soTienNangKhieu, soTienTruyThu, ngayTinh, stt, 0, DateTime.Now, ghiChu);
            int bangThuTienId = (int)bangThuTienTableAdapter.Adapter.InsertCommand.LastInsertedId;
            int khoiId = StaticDataUtil.GetKhoiIdByLopId(lopKhoiTableAdapter, lopId).Value;
            this.generateBangThuTienKhoanThu(bangThuTienId, khoiId, ngayTinh);
        }

        private void generateBangThuTienKhoanThu(int bangThuTienId, int khoiId, DateTime ngayTinh)
        {
            int[] khoanThuIds = new int[] { BangThuTienConstant.KhoanThuIdBanTru, BangThuTienConstant.KhoanThuIdHocPhi, BangThuTienConstant.KhoanThuIdPhuPhi, BangThuTienConstant.KhoanThuIdTienAnSua };
            QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamDataTable khoanThuHangNamTable = khoanThuHangNamTableAdapter.GetKhoanThuHangNamByParams(String.Join(",", khoanThuIds), khoiId, ngayTinh);

            foreach (QLMamNon.Dao.QLMamNonDs.KhoanThuHangNamRow row in khoanThuHangNamTable)
            {
                bangThuTienKhoanThuTableAdapter.Insert(row.KhoanThuId, bangThuTienId, row.SoTien);
            }
        }

        private long sxToSoTienSX(int sx)
        {
            return sx * 20000;
        }

        private long SXAnSangToSoTienAnSang(int sx)
        {
            return sx * 6000;
        }

        #endregion
    }
}