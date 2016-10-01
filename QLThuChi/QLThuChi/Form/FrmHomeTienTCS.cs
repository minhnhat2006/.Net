using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace QLThuChi
{
    public partial class FrmHome
    {
        #region TienTCS

        private bool IsCurrentTienTCSAddingNew
        {
            get
            {
                if (this.tientcsBindingSource.Current != null)
                {
                    QLThuChi.Dao.ThuChi.tientcsRow row = (this.tientcsBindingSource.Current as DataRowView).Row as QLThuChi.Dao.ThuChi.tientcsRow;
                    return row.RowState == DataRowState.Detached;
                }

                return false;
            }
        }

        private bool IsProcessChangingCurrentTienTCSRow { get; set; }

        private void onTienTCSRowUpdated(object sender, MySqlRowUpdatedEventArgs e)
        {
            // Conditionally execute this code block on inserts only. 
            if (e.StatementType == StatementType.Insert)
            {
                MySqlCommand cmdNewID = new MySqlCommand("SELECT @@IDENTITY", this.tientcsTableAdapter.Connection);
                e.Row["TienTCSId"] = cmdNewID.ExecuteScalar();
                e.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        private void HuyTienTCS()
        {
            if (this.isTienTCSTab())
            {
                if (this.IsCurrentTienTCSAddingNew)
                {
                    this.IsProcessChangingCurrentTienTCSRow = false;
                    this.tientcsBindingSource.RemoveCurrent();
                    this.IsProcessChangingCurrentTienTCSRow = true;
                }

                this.thuChi.tientcs.RejectChanges();
                this.thuChi.tientcs.AcceptChanges();

                this.iTienTCSXoa.Enabled = true;
                this.gcTienTCS.Enabled = true;
                this.dxErrorProvider1.ClearErrors();
            }
        }

        private void ThemTienTCS()
        {
            if (this.isTienTCSTab() && !this.IsCurrentTienTCSAddingNew)
            {
                DataRowView rowView = (DataRowView)this.tientcsBindingSource.AddNew();
                QLThuChi.Dao.ThuChi.tientcsRow row = rowView.Row as QLThuChi.Dao.ThuChi.tientcsRow;
                row.Ngay = DateTime.Today;
                row.ThuPhat = 0;
                row.ThuTCS = 0;

                this.iTienTCSXoa.Enabled = false;
                this.gcTienTCS.Enabled = false;
            }
        }

        private bool ValidateTienTCSFields()
        {
            bool isNgay = Validate_EmptyStringRule(txtTienTCSNgay);
            bool isThuTCS = Validate_EmptyStringRule(txtTienTCSThu);
            return isNgay && isThuTCS;
        }

        private void XoaTienTCS(object sender, ItemClickEventArgs e)
        {
            if (this.tientcsBindingSource.Current == null)
            {
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa TCS này không ?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (this.IsCurrentTienTCSAddingNew)
                {
                    this.iTienTCSHuy_ItemClick(sender, e);
                }
                else
                {
                    this.IsProcessChangingCurrentTienTCSRow = false;
                    this.tientcsBindingSource.RemoveCurrent();
                    this.tientcsBindingSource.EndEdit();
                    this.thuChi.tientcs.GetChanges();
                    this.tientcsTableAdapter.Update(this.thuChi.tientcs);
                    this.thuChi.tientcs.AcceptChanges();
                    this.IsProcessChangingCurrentTienTCSRow = true;
                }
            }
        }

        private void LuuTienTCS(object sender, ItemClickEventArgs e)
        {
            if (this.isTienTCSTab() && this.tientcsBindingSource.Current != null)
            {
                if (this.ValidateTienTCSFields())
                {
                    QLThuChi.Dao.ThuChi.tientcsRow row = (QLThuChi.Dao.ThuChi.tientcsRow)((DataRowView)this.tientcsBindingSource.Current).Row;

                    this.tientcsBindingSource.EndEdit();
                    this.thuChi.tientcs.GetChanges();
                    this.tientcsTableAdapter.Update(this.thuChi.tientcs);
                    this.thuChi.tientcs.AcceptChanges();

                    this.iTienTCSXoa.Enabled = true;
                    this.gcTienTCS.Enabled = true;
                }
            }
            else if (this.tientcsBindingSource.Current == null)
            {
                var confirmResult = MessageBox.Show("Không có dữ liệu TCS nào trong danh sách hiện tại. Bạn có tạo một TCS mới không ?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    this.iTienTCSThem_ItemClick(sender, e);
                }
            }
        }

        #endregion
    }
}
