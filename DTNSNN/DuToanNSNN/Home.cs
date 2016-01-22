using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using System.Data.Common;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace DuToanNSNN
{
    public partial class FrmHome : DevExpress.XtraEditors.XtraForm
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nSNN.LoaiDuToan' table. You can move, or remove it, as needed.
            this.loaiDuToanTableAdapter.Fill(this.dtNSNN.LoaiDuToan);
            // TODO: This line of code loads data into the 'nSNN.MaTinhChatNguon' table. You can move, or remove it, as needed.
            this.maTinhChatNguonTableAdapter.Fill(this.dtNSNN.MaTinhChatNguon);
            // TODO: This line of code loads data into the 'nSNN.MaTinh' table. You can move, or remove it, as needed.
            this.maTinhTableAdapter.Fill(this.dtNSNN.MaTinh);
            // TODO: This line of code loads data into the 'nSNN.MaCTMT' table. You can move, or remove it, as needed.
            this.maCTMTTableAdapter.Fill(this.dtNSNN.MaCTMT);
            // TODO: This line of code loads data into the 'nSNN.MaNganhKT' table. You can move, or remove it, as needed.
            this.maNganhKTTableAdapter.Fill(this.dtNSNN.MaNganhKT);
            // TODO: This line of code loads data into the 'nSNN.MaChuong' table. You can move, or remove it, as needed.
            this.maChuongTableAdapter.Fill(this.dtNSNN.MaChuong);
            // TODO: This line of code loads data into the 'nSNN.MaQuanHeNS' table. You can move, or remove it, as needed.
            this.maQuanHeNSTableAdapter.Fill(this.dtNSNN.MaQuanHeNS);
            // TODO: This line of code loads data into the 'nSNN.MaCapNS' table. You can move, or remove it, as needed.
            this.maCapNSTableAdapter.Fill(this.dtNSNN.MaCapNS);
            // TODO: This line of code loads data into the 'nSNN.HachToan' table. You can move, or remove it, as needed.
            this.hachToanTableAdapter.Fill(this.dtNSNN.HachToan);
            // TODO: This line of code loads data into the 'nSNN.MaTaiKhoan' table. You can move, or remove it, as needed.
            this.maTaiKhoanTableAdapter.Fill(this.dtNSNN.MaTaiKhoan);
            // TODO: This line of code loads data into the 'nSNN._NSNN' table. You can move, or remove it, as needed.
            this.nsnnTableAdapter.Fill(this.dtNSNN.NSNN);

            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarCheckItem item = ribbonControl1.Items.CreateCheckItem(skin.SkinName, false);
                item.Tag = skin.SkinName;
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(OnPaintStyleClick);
                iPaintStyle.ItemLinks.Add(item);
            }

        }

        void OnPaintStyleClick(object sender, ItemClickEventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Tag.ToString());
        }

        private void iPaintStyle_Popup(object sender, System.EventArgs e)
        {
            foreach (BarItemLink link in iPaintStyle.ItemLinks)
                ((BarCheckItem)link.Item).Checked = link.Item.Caption == defaultLookAndFeel1.LookAndFeel.ActiveSkinName;
        }

        private bool Validate_EmptyStringRule(BaseEdit control)
        {
            if (control.Text == null || control.Text.Trim().Length == 0)
            {
                this.dxErrorProvider1.SetError(control, "Thông tin này không được bỏ trống", ErrorType.Critical);
                return false;
            }
            else
            {
                dxErrorProvider1.SetError(control, "");
                return true;
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void FrmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.dtNSNN.RejectChanges();
        }

        private void xtraTabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                menuMain.ShowPopup(Control.MousePosition);
            }
        }

        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {
            int year = (int)((Decimal)(sender as BarEditItem).EditValue);

            if (year == 0)
            {
                return;
            }

            // Update BangDoiChieu by year

            // Delete all BangDoiChieu records for year
            bangDoiChieuRptTableAdapter.DeleteBangDoiChieuByYear(year.ToString());

            // Generate BangDoiChieu records for every taikhoan quy1
            BangDoiChieuKBNN.HachToanDataTable tableTaiKhoanQuy1 = hachToanRptTableAdapter.GetDataByListTaiKhoanByDate(
                new DateTime(year, 1, 1, 0, 0, 0, 0), new DateTime(year, 3, DateTime.DaysInMonth(year, 3), 23, 59, 59, 999));
            foreach (DuToanNSNN.BangDoiChieuKBNN.HachToanRow item in tableTaiKhoanQuy1.Rows)
            {
                this.tinhToanBangDoiChieuChoTaiKhoan(item.cot11, item.cot8, item.cot9, item.cot4, item.cot5, item.cot7, item.cot2, item[20] as String, year, "1");
            }

            // Generate BangDoiChieu records for every taikhoan quy2
            BangDoiChieuKBNN.HachToanDataTable tableTaiKhoanQuy2 = hachToanRptTableAdapter.GetDataByListTaiKhoanByDate(
                new DateTime(year, 4, 1, 0, 0, 0, 0), new DateTime(year, 6, DateTime.DaysInMonth(year, 6), 23, 59, 59, 999));
            foreach (DuToanNSNN.BangDoiChieuKBNN.HachToanRow item in tableTaiKhoanQuy2.Rows)
            {
                this.tinhToanBangDoiChieuChoTaiKhoan(item.cot11, item.cot8, item.cot9, item.cot4, item.cot5, item.cot7, item.cot2, item[20] as String, year, "2");
            }

            // Generate BangDoiChieu records for every taikhoan quy3
            BangDoiChieuKBNN.HachToanDataTable tableTaiKhoanQuy3 = hachToanRptTableAdapter.GetDataByListTaiKhoanByDate(
                new DateTime(year, 7, 1, 0, 0, 0, 0), new DateTime(year, 9, DateTime.DaysInMonth(year, 9), 23, 59, 59, 999));
            foreach (DuToanNSNN.BangDoiChieuKBNN.HachToanRow item in tableTaiKhoanQuy3.Rows)
            {
                this.tinhToanBangDoiChieuChoTaiKhoan(item.cot11, item.cot8, item.cot9, item.cot4, item.cot5, item.cot7, item.cot2, item[20] as String, year, "3");
            }

            // Generate BangDoiChieu records for every taikhoan quy4
            BangDoiChieuKBNN.HachToanDataTable tableTaiKhoanQuy4 = hachToanRptTableAdapter.GetDataByListTaiKhoanByDate(
                new DateTime(year, 10, 1, 0, 0, 0, 0), new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59, 999));
            foreach (DuToanNSNN.BangDoiChieuKBNN.HachToanRow item in tableTaiKhoanQuy4.Rows)
            {
                this.tinhToanBangDoiChieuChoTaiKhoan(item.cot11, item.cot8, item.cot9, item.cot4, item.cot5, item.cot7, item.cot2, item[20] as String, year, "4");
            }

            (sender as BarEditItem).EditValue = (Decimal)0;
        }

        #region Utils

        private bool isNSNNTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 0;
        }

        private bool isPhieuThuTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 1;
        }

        private bool isPhieuChiTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 2;
        }

        public void UpdateDatasource(GridControl grid, OleDbDataAdapter dataAdapter, string table)
        {
            //Save the latest changes to the bound DataTable 
            ColumnView View = (ColumnView)grid.FocusedView;
            if (!(View.PostEditor() && View.UpdateCurrentRow())) return;

            //Update the database's Suppliers table to which oleDBDataAdapter1 is connected 
            DoUpdate(dataAdapter, dtNSNN.Tables[table]);
        }

        public void DoUpdate(OleDbDataAdapter dataAdapter, System.Data.DataTable dataTable)
        {
            try
            {
                dataAdapter.Update(dataTable);
                dataTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}