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
        #region PhieuChi

        private bool IsPCAddingNew { get; set; }

        private bool IsCurrentPCAddingNew
        {
            get
            {
                if (this.phieuchiBindingSource.Current != null)
                {
                    QLCMND.CMND.phieuchiRow row = (this.phieuchiBindingSource.Current as DataRowView).Row as QLCMND.CMND.phieuchiRow;
                    return row.phieuchiid < 0;
                }

                return false;
            }
        }

        private bool IsProcessChangingCurrentPCRow { get; set; }

        private void OnPCRowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            // Conditionally execute this code block on inserts only. 
            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", this.phieuchiTableAdapter.Connection);
                // Retrieve the Autonumber and store it in the CategoryID column.
                e.Row["phieuchiid"] = (int)cmdNewID.ExecuteScalar();
                e.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        private void txtPCSoTien_TextChanged(object sender, EventArgs e)
        {
            txtPCTienChu.Text = VNCurrency.ToString(txtPCSoTien.Value);
        }

        private void phieuchiBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            this.lblPCNgayLap.Text = string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            this.txtCMND.Focus();

        }

        private void txtCMND_EditValueChanged(object sender, EventArgs e)
        {
            if (this.cMNDBindingSource1.Current != null && this.txtCMND.IsEditorActive)
            {
                QLCMND.CMND.CMNDRow row = (QLCMND.CMND.CMNDRow)((DataRowView)this.txtCMND.Properties.GetDataSourceRowByKeyValue(this.txtCMND.EditValue)).Row;
                this.txtPCNguoiNhan.Text = row.hoten;
                this.txtPCNgayCap.DateTime = row.ngaycap;
                this.txtPCNoiCap.Text = row.noicap;
                this.txtPCDiaChi.Text = row.diachi;
            }
        }

        private void iPCTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuChiTab())
            {
                this.gridView3.OptionsView.ShowAutoFilterRow = !this.gridView3.OptionsView.ShowAutoFilterRow;
            }
        }

        private void HuyPC()
        {
            if (this.isPhieuChiTab())
            {
                if (this.IsCurrentPCAddingNew)
                {
                    this.IsProcessChangingCurrentPCRow = false;
                    this.phieuchiBindingSource.RemoveCurrent();
                    this.IsProcessChangingCurrentPCRow = true;
                }

                this.cMND.phieuchi.RejectChanges();
                this.cMND.phieuchi.AcceptChanges();

                this.dxErrorProvider1.ClearErrors();
                this.IsPCAddingNew = false;
            }
        }

        private void iPCHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.HuyPC();
        }

        private void phieuchiBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (this.isPhieuChiTab() && this.IsProcessChangingCurrentPCRow && this.phieuchiBindingSource.Current != null && !(this.phieuchiBindingSource.Current as DataRowView).IsNew)
            {
                QLCMND.CMND.phieuchiRow row = (QLCMND.CMND.phieuchiRow)((DataRowView)this.phieuchiBindingSource.Current).Row;

                if (!row.IsngaylapNull())
                {
                    this.lblPCNgayLap.Text = string.Format("Ngày {0} tháng {1} năm {2}", row.ngaylap.Day, row.ngaylap.Month, row.ngaylap.Year);
                }

                this.HuyPC();
            }
        }

        private void iPCThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuChiTab() && !this.IsPCAddingNew)
            {
                string lydo = this.txtPCLyDo.Text;
                this.phieuchiBindingSource.AddNew();
                this.txtPCLyDo.Text = lydo;
                this.IsPCAddingNew = true;
            }
        }

        private bool ValidatePhieuChiFields()
        {
            bool isNguoiNhan = Validate_EmptyStringRule(txtPCNguoiNhan);
            bool isSoCMND = Validate_EmptyStringRule(txtCMND);
            bool isSoTien = Validate_EmptyStringRule(txtPCSoTien);
            return isNguoiNhan && isSoCMND && isSoTien;
        }

        private void iPCLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuChiTab() && this.phieuchiBindingSource.Current != null)
            {
                if (this.ValidatePhieuChiFields())
                {
                    QLCMND.CMND.phieuchiRow row = (QLCMND.CMND.phieuchiRow)((DataRowView)this.phieuchiBindingSource.Current).Row;

                    if (row.IscreateddateNull())
                    {
                        row.createddate = DateTime.Now;
                        row.ngaylap = DateTime.Now;
                    }

                    this.IsPCAddingNew = false;
                    this.phieuchiBindingSource.EndEdit();
                    this.cMND.phieuchi.GetChanges();
                    this.phieuchiTableAdapter.Update(this.cMND.phieuchi);
                    this.cMND.phieuchi.AcceptChanges();

                    // Luu thong tin CMND
                    int currentPos = this.cMNDBindingSource.Position;
                    int position = this.cMNDBindingSource.Find("cmndid", row.cmnd);

                    if (position >= 0)
                    {
                        this.cMNDBindingSource.Position = position;
                        this.iCMNDHuy_ItemClick(sender, e);

                        QLCMND.CMND.CMNDRow cmndRow = ((this.cMNDBindingSource.Current as DataRowView).Row as QLCMND.CMND.CMNDRow);
                        cmndRow.ngaycap = this.txtPCNgayCap.DateTime;
                        cmndRow.noicap = this.txtPCNoiCap.Text;
                        cmndRow.diachi = this.txtPCDiaChi.Text;

                        this.cMNDBindingSource.EndEdit();
                        this.cMND._CMND.GetChanges();
                        this.cMNDTableAdapter.Update(this.cMND._CMND);
                        this.cMND._CMND.AcceptChanges();
                    }
                    else
                    {
                        this.iCMNDHuy_ItemClick(sender, e);
                        this.ThemCMND();

                        QLCMND.CMND.CMNDRow cmndRow = ((this.cMNDBindingSource.Current as DataRowView).Row as QLCMND.CMND.CMNDRow);
                        cmndRow.ngaycap = this.txtPCNgayCap.DateTime;
                        cmndRow.noicap = this.txtPCNoiCap.Text;
                        cmndRow.hkthuongtru = this.txtPCDiaChi.Text;

                        this.CapNhatCMND();
                    }

                    this.cMNDBindingSource.Position = currentPos;
                }
            }
            else if (this.phieuchiBindingSource.Current == null)
            {
                var confirmResult = MessageBox.Show("Không có Phiếu chi nào trong danh sách hiện tại. Bạn có tạo một Phiếu chi mới không ??", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    this.iPCThem_ItemClick(sender, e);
                }
            }
        }

        private void iPCXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.phieuchiBindingSource.Current == null)
            {
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa Phiếu chi này không ??", "Confirm Delete!!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (this.IsPCAddingNew)
                {
                    this.iPCHuy_ItemClick(sender, e);
                }
                else
                {
                    this.IsProcessChangingCurrentPCRow = false;
                    this.phieuchiBindingSource.RemoveCurrent();
                    this.phieuchiBindingSource.EndEdit();
                    this.cMND.phieuchi.GetChanges();
                    this.phieuchiTableAdapter.Update(this.cMND.phieuchi);
                    this.cMND.phieuchi.AcceptChanges();
                    this.IsPCAddingNew = false;
                    this.IsProcessChangingCurrentPCRow = true;
                }
            }
        }

        private void fillReportPhieuChi(RptPhieuChi rpt)
        {
            QLCMND.CMND.phieuchiRow row = (QLCMND.CMND.phieuchiRow)((DataRowView)this.phieuchiBindingSource.Current).Row;
            rpt.lblHoTen.Text = row.hoten.ToUpper();
            rpt.lblCMND.Text = row.cmnd;

            if (!row.IscapngayNull())
            {
                rpt.lblCapNgay.Text = string.Format("{0:d}", row.capngay);
            }
            else
            {
                rpt.lblCapNgay.Text = "";
            }

            if (!row.IsnoicapNull())
            {
                rpt.lblNoiCap.Text = row.noicap;
            }
            else
            {
                rpt.lblNoiCap.Text = "";
            }


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
            rpt.lblSoTienChu.Text = "                                      " + VNCurrency.ToString((double)row.sotien);

            if (!row.IsngaylapNull())
            {
                rpt.lblNgayLap.Text = string.Format("Ngày {0} tháng {1} năm {2}", row.ngaylap.Day, row.ngaylap.Month, row.ngaylap.Year);
            }
            else
            {
                rpt.lblNgayLap.Text = "";
            }

            if (!row.IsnotkNull())
            {
                rpt.lblNoTK.Text = row.notk;
            }
            else
            {
                rpt.lblNoTK.Text = "";
            }
        }

        private void iPCXemTruoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuChiTab() && this.phieuchiBindingSource.Current != null)
            {
                if (this.ValidatePhieuChiFields())
                {
                    RptPhieuChi rpt = new RptPhieuChi();
                    this.fillReportPhieuChi(rpt);
                    this.ucReport1.printControl1.PrintingSystem = rpt.PrintingSystem;
                    rpt.CreateDocument();
                    this.xtraTabControl1.SelectedTabPageIndex = 3;
                    this.xtraTabControl1.TabPages[3].Text = "Xem trước Phiếu chi";
                }
            }
        }

        private void iPCIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isPhieuChiTab() && this.phieuchiBindingSource.Current != null)
            {
                if (this.ValidatePhieuChiFields())
                {
                    RptPhieuChi rpt = new RptPhieuChi();
                    this.fillReportPhieuChi(rpt);
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
