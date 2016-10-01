using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace QLThuChi
{
    public partial class FrmHome
    {
        #region CTTM;

        private bool IsCurrentCTTMAddingNew
        {
            get
            {
                if (this.chungtutienmatBindingSource.Current != null)
                {
                    QLThuChi.Dao.ThuChi.chungtutienmatRow row = (this.chungtutienmatBindingSource.Current as DataRowView).Row as QLThuChi.Dao.ThuChi.chungtutienmatRow;
                    return row.RowState == DataRowState.Detached;
                }

                return false;
            }
        }

        private bool IsProcessChangingCurrentCTTMRow { get; set; }

        private bool IsCTTMValidatingError { get; set; }

        private bool ValidateCTTMFields()
        {
            bool isCTTMNgay = Validate_EmptyStringRule(this.txtCTTMNgay);
            bool isCTTMNo = Validate_EmptyStringRule(this.txtCTTMNo);
            bool isCTTMCo = Validate_EmptyStringRule(this.txtCTTMCo);
            this.IsCTTMValidatingError = !(isCTTMNgay && isCTTMNo && isCTTMCo);
            return this.IsCTTMValidatingError;
        }

        private void ThemCTTM()
        {
            if (this.isCTTMTab() && !this.IsCurrentCTTMAddingNew)
            {
                this.chungtutienmatBindingSource.AddNew();
                this.iCTTMXoa.Enabled = false;
                this.gcCTTM.Enabled = false;

                this.txtCTTMCo.Value = 0;
                this.txtCTTMNo.Value = 0;
            }
        }

        private void CapNhatCTTM()
        {
            QLThuChi.Dao.ThuChi.chungtutienmatRow row = (QLThuChi.Dao.ThuChi.chungtutienmatRow)((DataRowView)this.chungtutienmatBindingSource.Current).Row;
            row.UserId = this.UserId;

            this.chungtutienmatBindingSource.EndEdit();
            this.thuChi.chungtutienmat.GetChanges();
            this.chungtutienmatTableAdapter.Update(this.thuChi.chungtutienmat);
            this.thuChi.chungtutienmat.AcceptChanges();
        }

        private void CapNhatCTTM(object sender, ItemClickEventArgs e)
        {
            if (this.isCTTMTab() && this.chungtutienmatBindingSource.Current != null)
            {
                this.ValidateCTTMFields();

                if (!this.IsCTTMValidatingError)
                {
                    this.CapNhatCTTM();
                }
            }
            else if (this.chungtutienmatBindingSource.Current == null)
            {
                var confirmResult = MessageBox.Show("Không có CTTM nào trong danh sách hiện tại. Bạn có tạo một CTTM mới không ?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    this.iCTTMThem_ItemClick(sender, e);
                }
            }
        }

        private void HuyCTTM()
        {
            if (this.isCTTMTab())
            {
                if (this.IsCurrentCTTMAddingNew)
                {
                    this.IsProcessChangingCurrentCTTMRow = false;
                    this.chungtutienmatBindingSource.RemoveCurrent();
                    this.IsProcessChangingCurrentCTTMRow = true;
                }

                this.thuChi.chungtutienmat.RejectChanges();
                this.thuChi.chungtutienmat.AcceptChanges();

                this.dxErrorProvider1.ClearErrors();
                this.IsCTTMValidatingError = false;
                this.iCTTMXoa.Enabled = true;
                this.gcCTTM.Enabled = true;
            }
        }

        private void XoaCTTM(object sender, ItemClickEventArgs e)
        {
            if (this.chungtutienmatBindingSource.Current == null)
            {
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa CTTM này không ?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (this.IsCurrentCTTMAddingNew)
                {
                    this.iCTTMHuy_ItemClick(sender, e);
                }
                else
                {
                    this.IsProcessChangingCurrentCTTMRow = false;
                    this.chungtutienmatBindingSource.RemoveCurrent();
                    this.chungtutienmatBindingSource.EndEdit();
                    this.thuChi.chungtutienmat.GetChanges();
                    this.chungtutienmatTableAdapter.Update(this.thuChi.chungtutienmat);
                    this.thuChi.chungtutienmat.AcceptChanges();
                    this.IsProcessChangingCurrentCTTMRow = true;
                }
            }
        }

        #endregion
    }
}
