using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;

namespace DuToanNSNN
{
    public partial class FrmHome
    {
        #region Chung tu Du toan NSNN

        private void selMaDVQHNS_EditValueChanged(object sender, EventArgs e)
        {
            txtDonVi.Text = ((sender as LookUpEdit).GetSelectedDataRow() as System.Data.DataRowView)["tenquanhens"] as String;
        }

        private void gridView12_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                if (e.RowHandle >= 0)
                {
                    e.DisplayText = (e.RowHandle + 1).ToString();
                }
                else
                {
                    e.DisplayText = "";
                }
            }
        }

        private void gridView12_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.UpdateDatasource(grdChungTuDTNSNN, nsnnTableAdapter.Adapter, "NSNN");
            nsnnTableAdapter.Fill(dtNSNN.NSNN);
        }

        private void chungTuDTNSNNBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                this.DoUpdate(nsnnTableAdapter.Adapter, dtNSNN.NSNN);
            }
        }

        private void btnChiTietDTNSNN_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;

            DTNSNN.NSNNRow currentRow = ((chungTuDTNSNNBindingSource.Current as DataRowView).Row as DuToanNSNN.DTNSNN.NSNNRow);
            chkNgay32.Checked = currentRow.ladulieucuoinam;
            txtNgay32Year.Value = currentRow.ngayhachtoan.Year;
            currentRow.BeginEdit();

            chiTietDuToanNSNNBindingSource.Filter = "nsnnId = " + currentRow.uid;
        }

        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            RptBaoCao rpt = new RptBaoCao();

            this.xtraTabControl1.SelectedTabPageIndex = 10;

            this.fillReport(rpt);
            this.ucReport1.printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            using (RptBaoCao rpt = new RptBaoCao())
            {
                this.fillReport(rpt);
                this.ucReport1.printControl1.PrintingSystem = rpt.PrintingSystem;
                try
                {
                    rpt.Landscape = true;
                    rpt.Print();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void fillReport(RptBaoCao rpt)
        {
            rpt.MaCapNS = selMaCapNS.EditValue == DBNull.Value ? "" : (selMaCapNS.EditValue as string);
            rpt.MaChuong = selMaChuong.EditValue == DBNull.Value ? "" : (selMaChuong.EditValue as string);
            rpt.MaQHNS = selMaDVQHNS.EditValue == DBNull.Value ? "" : (selMaDVQHNS.EditValue as string);

            DateTime fromDate;
            DateTime toDate;
            int nam = (int)selNam.Value;
            string quy = selQuy.Text;

            if (quy == "1")
            {
                fromDate = new DateTime(nam, 1, 1);
                toDate = new DateTime(nam, 3, DateTime.DaysInMonth(nam, 3));
                rpt.lblQuyNam.Text = string.Format("Quý " + selQuy.Text + " / Năm " + nam.ToString());
            }
            else if (quy == "2")
            {
                fromDate = new DateTime(nam, 4, 1);
                toDate = new DateTime(nam, 6, DateTime.DaysInMonth(nam, 6));
                rpt.lblQuyNam.Text = string.Format("Quý " + selQuy.Text + " / Năm " + nam.ToString());
            }
            else if (quy == "3")
            {
                fromDate = new DateTime(nam, 7, 1);
                toDate = new DateTime(nam, 9, DateTime.DaysInMonth(nam, 9));
                rpt.lblQuyNam.Text = string.Format("Quý " + selQuy.Text + " / Năm " + nam.ToString());
            }
            else if (quy == "4")
            {
                fromDate = new DateTime(nam, 10, 1);
                toDate = new DateTime(nam, 12, DateTime.DaysInMonth(nam, 12));
                rpt.lblQuyNam.Text = string.Format("Quý " + selQuy.Text + " / Năm " + nam.ToString());
            }
            else
            {
                fromDate = new DateTime(nam, 1, 1);
                toDate = new DateTime(nam, 12, DateTime.DaysInMonth(nam, 12));
                rpt.lblQuyNam.Text = string.Format("Năm " + nam.ToString());
            }

            rpt.FromDate = fromDate;
            rpt.ToDate = toDate;

            rpt.lblDonVi.Text = selMaDVQHNS.GetColumnValue("tenquanheNS") as String;
            rpt.lblMaCapNS.Text = selMaCapNS.EditValue as string;
            rpt.lblMaChuong.Text = selMaChuong.EditValue as string;
            rpt.lblMaDVDHNS.Text = selMaDVQHNS.EditValue as string;
        }


        #endregion

        #region Xu ly Bang doi chieu

        private void tinhToanBangDoiChieuChoTaiKhoan(string maNguon, string maNganh, string maCTMT, string maCapNS, string maQHNS, string maChuong, string maTaiKhoan, string coquan, int nam, string quy)
        {
            DateTime fromDate;
            DateTime toDate;

            if (quy == "1")
            {
                fromDate = new DateTime(nam, 1, 1);
                toDate = new DateTime(nam, 3, DateTime.DaysInMonth(nam, 3));
            }
            else if (quy == "2")
            {
                fromDate = new DateTime(nam, 4, 1);
                toDate = new DateTime(nam, 6, DateTime.DaysInMonth(nam, 6));
            }
            else if (quy == "3")
            {
                fromDate = new DateTime(nam, 7, 1);
                toDate = new DateTime(nam, 9, DateTime.DaysInMonth(nam, 9));
            }
            else if (quy == "4")
            {
                fromDate = new DateTime(nam, 10, 1);
                toDate = new DateTime(nam, 12, DateTime.DaysInMonth(nam, 12));
            }
            else
            {
                fromDate = new DateTime(nam, 1, 1);
                toDate = new DateTime(nam, 12, DateTime.DaysInMonth(nam, 12));
            }

            // Xoa data cu cua tai khoan nay
            bangDoiChieuTableAdapter.DeleteForTK(fromDate, toDate, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);

            // Get all HachToan cua tai khoan
            DTNSNN.HachToanDataTable table = hachToanTableAdapter.GetDataForTinhToanTK(fromDate, toDate, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);

            long sumCot1 = 0;
            long sumCot2 = 0;
            long sumCot4 = 0;
            long sumCot5 = 0;
            long sumCot7 = 0;
            long sumCot9 = 0;
            long sumCot10 = 0;
            long sumCot11 = 0;

            // Save vao bang doi chieu
            foreach (DuToanNSNN.DTNSNN.HachToanRow item in table.Rows)
            {
                long soTienCo = item.sotienco;
                long soTienNo = item.sotienno;
                DateTime ngayHachToan = (DateTime)item[20];
                string loaiDuToan = (string)item[21];

                long col1 = 0;
                long col2 = 0;
                long col3 = 0;
                long col4 = 0;
                long col5 = 0;
                long col6 = 0;
                long col7 = 0;
                long col8 = 0;
                long col9 = 0;
                long col10 = 0;
                long col11 = 0;

                switch (loaiDuToan)
                {
                    case "00":
                        col6 = soTienCo;
                        col7 = soTienCo;
                        break;
                    case "01":
                        col2 = soTienNo;
                        col3 = soTienNo;
                        col4 = soTienNo;
                        break;
                    case "02":
                        col3 = soTienNo;
                        col4 = soTienNo;
                        break;
                    case "03":
                        col3 = soTienNo;
                        col4 = soTienNo;

                        if (maNguon == "28")
                        {
                            col10 = soTienNo;
                        }
                        break;
                    case "06":
                        col1 = soTienNo;
                        break;
                    case "08":
                        col3 = soTienNo;
                        col4 = soTienNo;
                        break;
                    case "11":
                        col8 = soTienNo;
                        col9 = soTienNo - soTienCo;
                        break;
                    default:
                        break;
                }

                col5 = col1 + col4;
                col11 = col5 - col7 - col9;

                bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayHachToan, coquan, false, col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, col11);

                //if (maNguon == "28" && loaiDuToan == "03")
                //{
                //    bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayHachToan, coquan, false, 0, 0, soTienNo, soTienNo, soTienNo, 0, 0, 0, 0, soTienNo, soTienNo);
                //}

                sumCot1 += col1;
                sumCot2 += col2;
                sumCot4 += col4;
                sumCot5 += col5;
                sumCot7 += col7;
                sumCot9 += col9;
                sumCot10 += col10;
                sumCot11 += col11;
            }

            // Save du lieu luy ke
            if (quy == "1")
            {
                DateTime ngayLuyKe2 = new DateTime(nam, 4, 1, 0, 0, 0, 0);
                DateTime ngayLuyKe3 = new DateTime(nam, 7, 1, 0, 0, 0, 0, 0);
                DateTime ngayLuyKe4 = new DateTime(nam, 10, 1, 0, 0, 0, 0, 0);

                // Xoa du lieu luy ke cu
                bangDoiChieuTableAdapter.DeleteDuLieuLuyKeTK(ngayLuyKe2, ngayLuyKe2, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);
                bangDoiChieuTableAdapter.DeleteDuLieuLuyKeTK(ngayLuyKe3, ngayLuyKe3, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);
                bangDoiChieuTableAdapter.DeleteDuLieuLuyKeTK(ngayLuyKe4, ngayLuyKe4, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);
                //Them du lieu luy ke
                bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayLuyKe2, coquan, true, sumCot1, sumCot2, 0, sumCot4, sumCot5, 0, sumCot7, 0, sumCot9, sumCot10, sumCot11);
                bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayLuyKe3, coquan, true, sumCot1, sumCot2, 0, sumCot4, sumCot5, 0, sumCot7, 0, sumCot9, sumCot10, sumCot11);
                bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayLuyKe4, coquan, true, sumCot1, sumCot2, 0, sumCot4, sumCot5, 0, sumCot7, 0, sumCot9, sumCot10, sumCot11);
            }
            else if (quy == "2")
            {
                DateTime ngayLuyKe3 = new DateTime(nam, 7, 1, 0, 0, 0, 0);
                DateTime ngayLuyKe4 = new DateTime(nam, 10, 1, 0, 0, 0, 0, 0);

                // Xoa du lieu luy ke cu
                bangDoiChieuTableAdapter.DeleteDuLieuLuyKeTK(ngayLuyKe3, ngayLuyKe3, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);
                bangDoiChieuTableAdapter.DeleteDuLieuLuyKeTK(ngayLuyKe4, ngayLuyKe4, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);

                //Them du lieu luy ke
                DTNSNN.BangDoiChieuDataTable tblLuyKe = bangDoiChieuTableAdapter.GetDataByLuyKe(fromDate, toDate, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);

                if (tblLuyKe.Rows.Count > 0)
                {
                    DTNSNN.BangDoiChieuRow row = tblLuyKe.Rows[0] as DTNSNN.BangDoiChieuRow;
                    bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayLuyKe3, coquan, true, sumCot1 + row.col1, sumCot2 + row.col2, 0, sumCot4 + row.col4, sumCot5 + row.col5, 0, sumCot7 + row.col7, 0, sumCot9 + row.col9, sumCot10 + row.col10, sumCot11 + row.col11);
                    bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayLuyKe4, coquan, true, sumCot1 + row.col1, sumCot2 + row.col2, 0, sumCot4 + row.col4, sumCot5 + row.col5, 0, sumCot7 + row.col7, 0, sumCot9 + row.col9, sumCot10 + row.col10, sumCot11 + row.col11);
                }
                else
                {
                    bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayLuyKe3, coquan, true, sumCot1, sumCot2, 0, sumCot4, sumCot5, 0, sumCot7, 0, sumCot9, sumCot10, sumCot11);
                    bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayLuyKe4, coquan, true, sumCot1, sumCot2, 0, sumCot4, sumCot5, 0, sumCot7, 0, sumCot9, sumCot10, sumCot11);
                }
            }
            else if (quy == "3")
            {
                DateTime ngayLuyKe4 = new DateTime(nam, 10, 1, 0, 0, 0, 0);

                // Xoa du lieu luy ke cu
                bangDoiChieuTableAdapter.DeleteDuLieuLuyKeTK(ngayLuyKe4, ngayLuyKe4, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);
                //Them du lieu luy ke
                DTNSNN.BangDoiChieuDataTable tblLuyKe = bangDoiChieuTableAdapter.GetDataByLuyKe(fromDate, toDate, maChuong, maQHNS, maCapNS, maNguon, maNganh, maCTMT, maTaiKhoan, coquan);

                if (tblLuyKe.Rows.Count > 0)
                {
                    DTNSNN.BangDoiChieuRow row = tblLuyKe.Rows[0] as DTNSNN.BangDoiChieuRow;
                    bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayLuyKe4, coquan, true, sumCot1 + row.col1, sumCot2 + row.col2, 0, sumCot4 + row.col4, sumCot5 + row.col5, 0, sumCot7 + row.col7, 0, sumCot9 + row.col9, sumCot10 + row.col10, sumCot11 + row.col11);
                }
                else
                {
                    bangDoiChieuTableAdapter.Insert(maChuong, maQHNS, maCapNS, maNganh, maNguon, maCTMT, maTaiKhoan, ngayLuyKe4, coquan, true, sumCot1, sumCot2, 0, sumCot4, sumCot5, 0, sumCot7, 0, sumCot9, sumCot10, sumCot11);
                }
            }
        }

        #endregion
    }
}
