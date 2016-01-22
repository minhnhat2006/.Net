using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace DuToanNSNN
{
    public partial class FrmHome
    {
        #region NSNN;

        private bool IsNSNNValidatingError { get; set; }

        private bool ValidateDuToanNSNNFields()
        {
            bool isNgayHachToan = Validate_EmptyStringRule(this.txtNgayHachToan);
            bool isLoaiDuToan = Validate_EmptyStringRule(this.selLoaiDuToan);
            bool isCoQuan = Validate_EmptyStringRule(this.selHachToanCoQuan);
            this.IsNSNNValidatingError = !(isNgayHachToan && isLoaiDuToan && isCoQuan);

            return this.IsNSNNValidatingError;
        }

        private void CapNhatDuToanNSNN()
        {
            ((chungTuDTNSNNBindingSource.Current as DataRowView).Row as DuToanNSNN.DTNSNN.NSNNRow).EndEdit();
            this.DoUpdate(nsnnTableAdapter.Adapter, dtNSNN.NSNN);

            this.UpdateDatasource(grdHachToan, hachToanTableAdapter.Adapter, "HachToan");
            hachToanTableAdapter.Fill(dtNSNN.HachToan);

            // Tinh quy
            DateTime ngayHachToan = txtNgayHachToan.DateTime;
            string quy = "0";

            switch (ngayHachToan.Month)
            {
                case 1:
                case 2:
                case 3:
                    quy = "1";
                    break;
                case 4:
                case 5:
                case 6:
                    quy = "2";
                    break;
                case 7:
                case 8:
                case 9:
                    quy = "3";
                    break;
                default:
                    quy = "4";
                    break;
            }

            foreach (DataRowView item in chiTietDuToanNSNNBindingSource.List)
            {
                DuToanNSNN.DTNSNN.HachToanRow row = item.Row as DuToanNSNN.DTNSNN.HachToanRow;
                this.tinhToanBangDoiChieuChoTaiKhoan(row.cot11, row.cot8, row.cot9, row.cot4, row.cot5, row.cot7, row.cot2, selHachToanCoQuan.Text, ngayHachToan.Year, quy);
            }
        }

        private void btnLuuHachToan_Click(object sender, EventArgs e)
        {
            if (this.chungTuDTNSNNBindingSource.Current != null)
            {
                this.ValidateDuToanNSNNFields();

                if (!this.IsNSNNValidatingError)
                {
                    btnLuuHachToan.Enabled = false;

                    DTNSNN.NSNNRow currentRow = ((chungTuDTNSNNBindingSource.Current as DataRowView).Row as DuToanNSNN.DTNSNN.NSNNRow);

                    if (currentRow != null)
                    {
                        if (chiTietDuToanNSNNBindingSource.Current != null)
                        {
                            DuToanNSNN.DTNSNN.HachToanRow hachToanRow = ((chiTietDuToanNSNNBindingSource.Current as DataRowView).Row as DuToanNSNN.DTNSNN.HachToanRow);
                            if (hachToanRow != null)
                            {
                                hachToanRow.nsnnId = currentRow.uid;
                            }
                        }

                        if (currentRow.ladulieucuoinam)
                        {
                            currentRow.ngayhachtoan = new DateTime((int)txtNgay32Year.Value, 12, 31);
                        }
                    }

                    this.CapNhatDuToanNSNN();

                    btnLuuHachToan.Enabled = true;
                }
            }
        }

        private void chiTietDuToanNSNNBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            this.lcThongTinHachToan.Enabled = chiTietDuToanNSNNBindingSource.Current != null;
        }

        private void chiTietDuToanNSNNBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                this.DoUpdate(hachToanTableAdapter.Adapter, dtNSNN.HachToan);
            }
        }

        private void chkNgay32_CheckedChanged(object sender, EventArgs e)
        {
            txtNgayHachToan.Properties.ReadOnly = (sender as CheckEdit).Checked;
            txtNgay32Year.Properties.ReadOnly = !(sender as CheckEdit).Checked;
        }

        private void cnavHachToan_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                DTNSNN.NSNNRow currentRow = ((chungTuDTNSNNBindingSource.Current as DataRowView).Row as DuToanNSNN.DTNSNN.NSNNRow);

                if (currentRow != null)
                {
                    if (chiTietDuToanNSNNBindingSource.Current != null)
                    {
                        DuToanNSNN.DTNSNN.HachToanRow hachToanRow = ((chiTietDuToanNSNNBindingSource.Current as DataRowView).Row as DuToanNSNN.DTNSNN.HachToanRow);
                        if (hachToanRow != null)
                        {
                            hachToanRow.nsnnId = currentRow.uid;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
