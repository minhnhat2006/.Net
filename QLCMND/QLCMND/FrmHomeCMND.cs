using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.OleDb;

namespace QLCMND
{
    public partial class FrmHome
    {
        #region CMND;

        private bool IsCMNDAddingNew { get; set; }

        private bool IsCurrentCMNDAddingNew
        {
            get
            {
                if (this.cMNDBindingSource.Current != null)
                {
                    QLCMND.CMND.CMNDRow row = (this.cMNDBindingSource.Current as DataRowView).Row as QLCMND.CMND.CMNDRow;
                    return row.uid < 0;
                }

                return false;
            }
        }

        private bool IsProcessChangingCurrentCMNDRow { get; set; }

        private bool IsCMNDValidatingError { get; set; }

        private bool ValidateCMNDFields()
        {
            bool isSoCMND = Validate_EmptyStringRule(this.txtSoCMND);
            bool isCMNDHoTen = Validate_EmptyStringRule(this.txtHoTen);
            bool isCMDNgayCap = Validate_EmptyStringRule(this.txtNgayCap);
            bool isCMNDNoiCap = Validate_EmptyStringRule(this.txtNoiCap);
            this.IsCMNDValidatingError = !(isSoCMND && isCMNDHoTen && isCMDNgayCap && isCMNDNoiCap);
            return this.IsCMNDValidatingError;
        }

        private void OnCMNDRowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            // Conditionally execute this code block on inserts only. 
            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", this.cMNDTableAdapter.Connection);
                // Retrieve the Autonumber and store it in the CategoryID column.
                e.Row["uid"] = (int)cmdNewID.ExecuteScalar();
                e.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        private void cMNDBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            this.txtSoCMND.Focus();
        }

        private void ThemCMND()
        {
            this.cMNDBindingSource.AddNew();
            this.IsCMNDAddingNew = true;
        }

        private void iCMNDThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isCMNDTab() && !this.IsCMNDAddingNew)
            {
                this.ThemCMND();
            }
        }

        private void CapNhatCMND()
        {
            QLCMND.CMND.CMNDRow row = (QLCMND.CMND.CMNDRow)((DataRowView)this.cMNDBindingSource.Current).Row;

            row.lastupdate = DateTime.Now;

            if (string.IsNullOrEmpty(row.diachi))
            {
                row.diachi = row.hkthuongtru;
            }

            this.IsCMNDAddingNew = false;
            this.cMNDBindingSource.EndEdit();
            this.cMND._CMND.GetChanges();
            this.cMNDTableAdapter.Update(this.cMND._CMND);
            this.cMND._CMND.AcceptChanges();
        }

        private void iCMNDCapNhat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isCMNDTab() && this.cMNDBindingSource.Current != null)
            {
                this.txtSoCMND.Focus();
                this.ValidateCMNDFields();

                if (!this.IsCMNDValidatingError)
                {
                    this.CapNhatCMND();
                }
            }
            else if (this.cMNDBindingSource.Current == null)
            {
                var confirmResult = MessageBox.Show("Không có CMND nào trong danh sách hiện tại. Bạn có tạo một CMND mới không ??", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    this.iCMNDThem_ItemClick(sender, e);
                }
            }
        }

        private void cMNDBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (this.isCMNDTab() && this.IsProcessChangingCurrentCMNDRow && this.cMNDBindingSource.Current != null && !(this.cMNDBindingSource.Current as DataRowView).IsNew)
            {
                this.HuyCMND();
            }
        }

        private void HuyCMND()
        {
            if (this.isCMNDTab())
            {
                if (this.IsCurrentCMNDAddingNew)
                {
                    this.IsProcessChangingCurrentCMNDRow = false;
                    this.cMNDBindingSource.RemoveCurrent();
                    this.IsProcessChangingCurrentCMNDRow = true;
                }

                this.cMND._CMND.RejectChanges();
                this.cMND._CMND.AcceptChanges();

                this.dxErrorProvider1.ClearErrors();
                this.IsCMNDValidatingError = false;
                this.IsCMNDAddingNew = false;
            }
        }

        private void iCMNDHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.HuyCMND();
        }

        private void iCMNDTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isCMNDTab())
            {
                this.gridView1.OptionsView.ShowAutoFilterRow = !this.gridView1.OptionsView.ShowAutoFilterRow;
            }
        }

        private void iCMNDXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.cMNDBindingSource.Current == null)
            {
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa CMND này không ??", "Confirm Delete!!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (this.IsCMNDAddingNew)
                {
                    this.iCMNDHuy_ItemClick(sender, e);
                }
                else
                {
                    this.IsProcessChangingCurrentCMNDRow = false;
                    this.cMNDBindingSource.RemoveCurrent();
                    this.cMNDBindingSource.EndEdit();
                    this.cMND._CMND.GetChanges();
                    this.cMNDTableAdapter.Update(this.cMND._CMND);
                    this.cMND._CMND.AcceptChanges();
                    this.IsCMNDAddingNew = false;
                    this.IsProcessChangingCurrentCMNDRow = true;
                }
            }
        }

        private void iCMNDPhieuThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.IsCMNDAddingNew)
            {
                this.iCMNDCapNhat_ItemClick(sender, e);
            }

            if (!this.IsCMNDValidatingError && this.cMNDBindingSource.Current != null)
            {
                this.xtraTabControl1.SelectedTabPageIndex = 1;
                QLCMND.CMND.CMNDRow row = (QLCMND.CMND.CMNDRow)((DataRowView)this.cMNDBindingSource.Current).Row;

                this.iPTThem_ItemClick(sender, e);
                this.txtPTHoTen.Text = row.hoten;

                if (row.IsdiachiNull())
                {
                    this.txtPTDiaChi.Text = "";
                }
                else
                {
                    this.txtPTDiaChi.Text = row.diachi;
                }

                this.txtPTSoTien.Focus();
            }
        }

        private void iCMNDPhieuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.IsCMNDAddingNew)
            {
                this.iCMNDCapNhat_ItemClick(sender, e);
            }

            if (!this.IsCMNDValidatingError && this.cMNDBindingSource.Current != null)
            {
                this.xtraTabControl1.SelectedTabPageIndex = 2;
                QLCMND.CMND.CMNDRow row = (QLCMND.CMND.CMNDRow)((DataRowView)this.cMNDBindingSource.Current).Row;

                this.iPCThem_ItemClick(sender, e);
                this.txtCMND.Text = row.cmndid;
                this.txtPCSoTien.Focus();
            }
        }

        #endregion
    }
}
