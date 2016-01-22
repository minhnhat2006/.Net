using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QLCMND
{
    public partial class FrmHome
    {
        #region PhieuThu

        private bool IsPTAddingNew { get; set; }

        private bool IsCurrentPTAddingNew
        {
            get
            {
                if (this.phieuthuBindingSource.Current != null)
                {
                    QLCMND.CMND.phieuthuRow row = (this.phieuthuBindingSource.Current as DataRowView).Row as QLCMND.CMND.phieuthuRow;
                    return row.phieuthuid < 0;
                }

                return false;
            }
        }

        private bool IsProcessChangingCurrentPTRow { get; set; }

        private void OnPTRowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            // Conditionally execute this code block on inserts only. 
            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", this.phieuthuTableAdapter.Connection);
                // Retrieve the Autonumber and store it in the CategoryID column.
                e.Row["phieuthuid"] = (int)cmdNewID.ExecuteScalar();
                e.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        private void txtPTSoTien_TextChanged(object sender, EventArgs e)
        {
            txtPTTienChu.Text = VNCurrency.ToString(txtPTSoTien.Value);
        }

        private void phieuthuBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            this.lblPTNgayLap.Text = string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            this.txtPTHoTen.Focus();
        }

        private void iPTTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuThuTab())
            {
                this.gridView2.OptionsView.ShowAutoFilterRow = !this.gridView2.OptionsView.ShowAutoFilterRow;
            }
        }

        private void phieuthuBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (this.isPhieuThuTab() && this.IsProcessChangingCurrentPTRow && this.phieuthuBindingSource.Current != null && !(this.phieuthuBindingSource.Current as DataRowView).IsNew)
            {
                QLCMND.CMND.phieuthuRow row = (QLCMND.CMND.phieuthuRow)((DataRowView)this.phieuthuBindingSource.Current).Row;

                if (!row.IsngaylapNull())
                {
                    this.lblPTNgayLap.Text = string.Format("Ngày {0} tháng {1} năm {2}", row.ngaylap.Day, row.ngaylap.Month, row.ngaylap.Year);
                }

                this.HuyPT();
            }
        }

        private void iPTThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuThuTab() && !this.IsPTAddingNew)
            {
                string lydo = this.txtPTLyDo.Text;
                this.phieuthuBindingSource.AddNew();
                this.txtPTLyDo.Text = lydo;
                this.IsPTAddingNew = true;
            }
        }

        private void HuyPT()
        {
            if (this.isPhieuThuTab())
            {
                if (this.IsCurrentPTAddingNew)
                {
                    this.IsProcessChangingCurrentPTRow = false;
                    this.phieuthuBindingSource.RemoveCurrent();
                    this.IsProcessChangingCurrentPTRow = true;
                }

                this.cMND.phieuthu.RejectChanges();
                this.cMND.phieuthu.AcceptChanges();

                this.dxErrorProvider1.ClearErrors();
                this.IsPTAddingNew = false;
            }
        }

        private void iPTHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.HuyPT();
        }

        private bool ValidatePhieuThuFields()
        {
            bool isNguoiNop = Validate_EmptyStringRule(txtPTHoTen);
            bool isSoTien = Validate_EmptyStringRule(txtPTSoTien);
            return isNguoiNop && isSoTien;
        }

        private void iPTLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuThuTab() && this.phieuthuBindingSource.Current != null)
            {
                if (this.ValidatePhieuThuFields())
                {
                    this.txtPTHoTen.Focus();
                    QLCMND.CMND.phieuthuRow row = (QLCMND.CMND.phieuthuRow)((DataRowView)this.phieuthuBindingSource.Current).Row;

                    if (row.IscreateddateNull())
                    {
                        row.createddate = DateTime.Now;
                        row.ngaylap = DateTime.Now;
                    }

                    this.IsPTAddingNew = false;
                    this.phieuthuBindingSource.EndEdit();
                    this.cMND.phieuthu.GetChanges();
                    this.phieuthuTableAdapter.Update(this.cMND.phieuthu);
                    this.cMND.phieuthu.AcceptChanges();
                }
            }
            else if (this.phieuthuBindingSource.Current == null)
            {
                var confirmResult = MessageBox.Show("Không có Phiếu thu nào trong danh sách hiện tại. Bạn có tạo một Phiếu thu mới không ??", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    this.iPTThem_ItemClick(sender, e);
                }
            }
        }

        private void iPTXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.phieuthuBindingSource.Current == null)
            {
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa Phiếu thu này không ??", "Confirm Delete!!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (this.IsPTAddingNew)
                {
                    this.iPTHuy_ItemClick(sender, e);
                }
                else
                {
                    this.IsProcessChangingCurrentPTRow = false;
                    this.phieuthuBindingSource.RemoveCurrent();
                    this.phieuthuBindingSource.EndEdit();
                    this.cMND.phieuthu.GetChanges();
                    this.phieuthuTableAdapter.Update(this.cMND.phieuthu);
                    this.cMND.phieuthu.AcceptChanges();
                    this.IsPTAddingNew = false;
                    this.IsProcessChangingCurrentPTRow = true;
                }
            }
        }

        private void fillReportPhieuThu(RptPhieuThu rpt)
        {
            QLCMND.CMND.phieuthuRow row = (QLCMND.CMND.phieuthuRow)((DataRowView)this.phieuthuBindingSource.Current).Row;
            rpt.lblHoTen.Text = row.hoten.ToUpper();

            if (!row.IsdiachiNull())
            {
                rpt.lblDiaChi.Text = row.diachi;
            }
            else
            {
                rpt.lblDiaChi.Text = "";
            }

            if (!row.IslydoNull())
            {
                rpt.lblLyDo.Text = row.lydo;
            }
            else
            {
                rpt.lblLyDo.Text = "";
            }

            if (!row.IschungtugocNull())
            {
                rpt.lblChungTuGoc.Text = row.chungtugoc;
            }
            else
            {
                rpt.lblChungTuGoc.Text = "";
            }

            if (!row.IskemtheoNull())
            {
                rpt.lblKemTheo.Text = row.kemtheo;
            }
            else
            {
                rpt.lblKemTheo.Text = "";
            }

            rpt.lblSoTien.Text = string.Format("{0:n0}, đồng", row.sotien);
            rpt.lblSoTienChu.Text = "                                    " + VNCurrency.ToString((double)row.sotien);

            if (!row.IsngaylapNull())
            {
                rpt.lblNgayLap.Text = string.Format("Ngày {0} tháng {1} năm {2}", row.ngaylap.Day, row.ngaylap.Month, row.ngaylap.Year);
            }
            else
            {
                rpt.lblNgayLap.Text = "";
            }

            if (!row.IscotkNull())
            {
                rpt.lblCoTK.Text = row.cotk;
            }
            else
            {
                rpt.lblCoTK.Text = "";
            }
        }

        private void iPTXemTruoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuThuTab() && this.phieuthuBindingSource.Current != null)
            {
                if (this.ValidatePhieuThuFields())
                {
                    RptPhieuThu rpt = new RptPhieuThu();
                    this.fillReportPhieuThu(rpt);
                    this.ucReport1.printControl1.PrintingSystem = rpt.PrintingSystem;
                    rpt.CreateDocument();
                    this.xtraTabControl1.SelectedTabPageIndex = 3;
                    this.xtraTabControl1.TabPages[3].Text = "Xem trước Phiếu thu";
                }
            }
        }

        private void iPTIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuThuTab() && this.phieuthuBindingSource.Current != null)
            {
                if (this.ValidatePhieuThuFields())
                {
                    RptPhieuThu rpt = new RptPhieuThu();
                    this.fillReportPhieuThu(rpt);
                    this.ucReport1.printControl1.PrintingSystem = rpt.PrintingSystem;
                    try
                    {
                        rpt.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion
    }
}
