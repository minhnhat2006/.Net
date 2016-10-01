using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace QLThuChi.Form
{
    public partial class FrmCTTMNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public const string MaNhanVienTatCa = "Tất cả";

        public bool IsAdmin { get; set; }

        public int UserId { get; set; }

        public FrmCTTMNhanVien()
        {
            InitializeComponent();
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

        private void FrmCTTMNhanVien_Load(object sender, EventArgs e)
        {
            if (this.IsAdmin)
            {
                // TODO: This line of code loads data into the 'thuChi.user' table. You can move, or remove it, as needed.
                this.userTableAdapter.Fill(this.thuChi.user);
                QLThuChi.Dao.ThuChi.userRow row = this.thuChi.user.NewuserRow();
                row.FullName = MaNhanVienTatCa;
                row.Code = MaNhanVienTatCa;
                row.Password = "";
                row.IsAdmin = false;
                this.thuChi.user.Rows.InsertAt(row, 0);
                this.txtMaNhanVien.Text = MaNhanVienTatCa;
            }
            else
            {
                this.userTableAdapter.getUserByUserId(this.thuChi.user, this.UserId);
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            bool isValidatePass = this.ValidateInputs();

            if (!isValidatePass)
            {
                return;
            }

            this.Hide();
            FrmHome home = this.Owner as FrmHome;
            RptCTTMNhanVien rpt = new RptCTTMNhanVien();
            this.fillReportUser(rpt);
            home.ucReport1.printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();
            home.xtraTabControl1.SelectedTabPageIndex = 4;
            home.xtraTabControl1.TabPages[4].Text = "Xem trước Chứng từ tiền mặt theo Mã Nhân Viên";
        }

        private bool ValidateInputs()
        {
            bool isMaNhanVien = Validate_EmptyStringRule(this.txtMaNhanVien);
            bool isTuNgay = Validate_EmptyStringRule(this.txtTuNgay);
            bool isDenNgay = Validate_EmptyStringRule(this.txtDenNgay);

            bool isValidatePass = isMaNhanVien && isTuNgay && isDenNgay;
            return isValidatePass;
        }

        private void fillReportUser(RptCTTMNhanVien rpt)
        {
            rpt.UserCode.Value = this.txtMaNhanVien.Text == MaNhanVienTatCa ? null : this.txtMaNhanVien.Text;
            rpt.FromDate.Value = txtTuNgay.DateTime;
            rpt.ToDate.Value = txtDenNgay.DateTime;

            rpt.lblMaNhanVien.Text = this.txtMaNhanVien.Text;
            rpt.lblTuNgay.Text = string.Format("{0:d}", txtTuNgay.DateTime);
            rpt.lblDenNgay.Text = string.Format("{0:d}", txtDenNgay.DateTime);
        }
    }
}