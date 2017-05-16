namespace QLMamNon.Forms.ThuChi
{
    partial class FrmTaoPhieuChi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaoPhieuChi));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnLuuTao = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.txtSoTien = new DevExpress.XtraEditors.CalcEdit();
            this.txtMaPhieu = new DevExpress.XtraEditors.TextEdit();
            this.dateNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblTaoPhieuChi = new System.Windows.Forms.Label();
            this.cmbPhanLoaiChi = new DevExpress.XtraEditors.LookUpEdit();
            this.phanLoaiChiRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciLblTaoPhieuChi = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNgay = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTxtMaPhieu = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTxtSoTien = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTxtChiChu = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCmbHocSinh = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.phieuChiTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.PhieuChiTableAdapter();
            this.phanLoaiChiTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.PhanLoaiChiTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhanLoaiChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phanLoaiChiRowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblTaoPhieuChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtMaPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtChiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCmbHocSinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Appearance.Control.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lcMain.Appearance.Control.Options.UseFont = true;
            this.lcMain.Controls.Add(this.btnLuuTao);
            this.lcMain.Controls.Add(this.btnLuu);
            this.lcMain.Controls.Add(this.txtGhiChu);
            this.lcMain.Controls.Add(this.txtSoTien);
            this.lcMain.Controls.Add(this.txtMaPhieu);
            this.lcMain.Controls.Add(this.dateNgay);
            this.lcMain.Controls.Add(this.lblTaoPhieuChi);
            this.lcMain.Controls.Add(this.cmbPhanLoaiChi);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(547, 189, 250, 350);
            this.lcMain.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcMain.OptionsPrint.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lcMain.OptionsPrint.AppearanceItemCaption.Options.UseFont = true;
            this.lcMain.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(492, 353);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // btnLuuTao
            // 
            this.btnLuuTao.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuTao.Image")));
            this.btnLuuTao.Location = new System.Drawing.Point(250, 301);
            this.btnLuuTao.MaximumSize = new System.Drawing.Size(250, 0);
            this.btnLuuTao.Name = "btnLuuTao";
            this.btnLuuTao.Size = new System.Drawing.Size(230, 40);
            this.btnLuuTao.StyleController = this.lcMain;
            this.btnLuuTao.TabIndex = 10;
            this.btnLuuTao.Text = "Lưu và Tạo mới";
            this.btnLuuTao.Click += new System.EventHandler(this.btnLuuTao_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(146, 301);
            this.btnLuu.MaximumSize = new System.Drawing.Size(150, 0);
            this.btnLuu.MinimumSize = new System.Drawing.Size(100, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 40);
            this.btnLuu.StyleController = this.lcMain;
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(178, 234);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(302, 63);
            this.txtGhiChu.StyleController = this.lcMain;
            this.txtGhiChu.TabIndex = 8;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(178, 190);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoTien.Properties.DisplayFormat.FormatString = "c0";
            this.txtSoTien.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtSoTien.Properties.Mask.EditMask = "c0";
            this.txtSoTien.Size = new System.Drawing.Size(302, 40);
            this.txtSoTien.StyleController = this.lcMain;
            this.txtSoTien.TabIndex = 7;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule2.ErrorText = "Vui lòng nhập Số tiền";
            conditionValidationRule2.Value1 = ((long)(0));
            conditionValidationRule2.Value2 = "0";
            conditionValidationRule2.Values.Add("0");
            this.dxValidationProvider.SetValidationRule(this.txtSoTien, conditionValidationRule2);
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(178, 146);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(302, 40);
            this.txtMaPhieu.StyleController = this.lcMain;
            this.txtMaPhieu.TabIndex = 6;
            // 
            // dateNgay
            // 
            this.dateNgay.EditValue = null;
            this.dateNgay.Location = new System.Drawing.Point(178, 58);
            this.dateNgay.Name = "dateNgay";
            this.dateNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay.Size = new System.Drawing.Size(302, 40);
            this.dateNgay.StyleController = this.lcMain;
            this.dateNgay.TabIndex = 5;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Vui lòng chọn Ngày";
            this.dxValidationProvider.SetValidationRule(this.dateNgay, conditionValidationRule3);
            // 
            // lblTaoPhieuChi
            // 
            this.lblTaoPhieuChi.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.lblTaoPhieuChi.Location = new System.Drawing.Point(12, 12);
            this.lblTaoPhieuChi.Name = "lblTaoPhieuChi";
            this.lblTaoPhieuChi.Size = new System.Drawing.Size(468, 42);
            this.lblTaoPhieuChi.TabIndex = 4;
            this.lblTaoPhieuChi.Text = "TẠO/CẬP NHẬT PHIẾU CHI";
            this.lblTaoPhieuChi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPhanLoaiChi
            // 
            this.cmbPhanLoaiChi.Location = new System.Drawing.Point(178, 102);
            this.cmbPhanLoaiChi.Name = "cmbPhanLoaiChi";
            this.cmbPhanLoaiChi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPhanLoaiChi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DienGiai", "Diễn giải", 47, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaPhanLoai", "Mã", 28, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.cmbPhanLoaiChi.Properties.DataSource = this.phanLoaiChiRowBindingSource;
            this.cmbPhanLoaiChi.Properties.DisplayMember = "DienGiai";
            this.cmbPhanLoaiChi.Properties.NullText = "";
            this.cmbPhanLoaiChi.Properties.PopupSizeable = false;
            this.cmbPhanLoaiChi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbPhanLoaiChi.Properties.ValueMember = "PhanLoaiChiId";
            this.cmbPhanLoaiChi.Size = new System.Drawing.Size(302, 40);
            this.cmbPhanLoaiChi.StyleController = this.lcMain;
            this.cmbPhanLoaiChi.TabIndex = 11;
            // 
            // phanLoaiChiRowBindingSource
            // 
            this.phanLoaiChiRowBindingSource.DataSource = typeof(QLMamNon.Dao.QLMamNonDs.PhanLoaiChiRow);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 20F);
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLblTaoPhieuChi,
            this.lciNgay,
            this.lciTxtMaPhieu,
            this.lciTxtSoTien,
            this.lciTxtChiChu,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lciCmbHocSinh,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(492, 353);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciLblTaoPhieuChi
            // 
            this.lciLblTaoPhieuChi.Control = this.lblTaoPhieuChi;
            this.lciLblTaoPhieuChi.Location = new System.Drawing.Point(0, 0);
            this.lciLblTaoPhieuChi.Name = "lciLblTaoPhieuChi";
            this.lciLblTaoPhieuChi.Size = new System.Drawing.Size(472, 46);
            this.lciLblTaoPhieuChi.TextSize = new System.Drawing.Size(0, 0);
            this.lciLblTaoPhieuChi.TextVisible = false;
            // 
            // lciNgay
            // 
            this.lciNgay.Control = this.dateNgay;
            this.lciNgay.Location = new System.Drawing.Point(0, 46);
            this.lciNgay.Name = "lciNgay";
            this.lciNgay.Size = new System.Drawing.Size(472, 44);
            this.lciNgay.Text = "Ngày chi:";
            this.lciNgay.TextSize = new System.Drawing.Size(163, 33);
            // 
            // lciTxtMaPhieu
            // 
            this.lciTxtMaPhieu.Control = this.txtMaPhieu;
            this.lciTxtMaPhieu.Location = new System.Drawing.Point(0, 134);
            this.lciTxtMaPhieu.Name = "lciTxtMaPhieu";
            this.lciTxtMaPhieu.Size = new System.Drawing.Size(472, 44);
            this.lciTxtMaPhieu.Text = "Mã Phiếu chi:";
            this.lciTxtMaPhieu.TextSize = new System.Drawing.Size(163, 33);
            // 
            // lciTxtSoTien
            // 
            this.lciTxtSoTien.Control = this.txtSoTien;
            this.lciTxtSoTien.Location = new System.Drawing.Point(0, 178);
            this.lciTxtSoTien.Name = "lciTxtSoTien";
            this.lciTxtSoTien.Size = new System.Drawing.Size(472, 44);
            this.lciTxtSoTien.Text = "Số tiền:";
            this.lciTxtSoTien.TextSize = new System.Drawing.Size(163, 33);
            // 
            // lciTxtChiChu
            // 
            this.lciTxtChiChu.Control = this.txtGhiChu;
            this.lciTxtChiChu.Location = new System.Drawing.Point(0, 222);
            this.lciTxtChiChu.Name = "lciTxtChiChu";
            this.lciTxtChiChu.Size = new System.Drawing.Size(472, 67);
            this.lciTxtChiChu.Text = "Ghi chú:";
            this.lciTxtChiChu.TextSize = new System.Drawing.Size(163, 33);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnLuu;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem1.Location = new System.Drawing.Point(134, 289);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 44);
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnLuuTao;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem2.Location = new System.Drawing.Point(238, 289);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(234, 44);
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // lciCmbHocSinh
            // 
            this.lciCmbHocSinh.Control = this.cmbPhanLoaiChi;
            this.lciCmbHocSinh.Location = new System.Drawing.Point(0, 90);
            this.lciCmbHocSinh.Name = "lciCmbHocSinh";
            this.lciCmbHocSinh.Size = new System.Drawing.Size(472, 44);
            this.lciCmbHocSinh.Text = "Phân loại Chi:";
            this.lciCmbHocSinh.TextSize = new System.Drawing.Size(163, 33);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 289);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(134, 44);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxValidationProvider
            // 
            this.dxValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // phieuChiTableAdapter
            // 
            this.phieuChiTableAdapter.ClearBeforeFill = true;
            // 
            // phanLoaiChiTableAdapter
            // 
            this.phanLoaiChiTableAdapter.ClearBeforeFill = true;
            // 
            // FrmTaoPhieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 353);
            this.Controls.Add(this.lcMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTaoPhieuChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo/Cập nhật Phiếu chi";
            this.Activated += new System.EventHandler(this.FrmTaoPhieuChi_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTaoPhieuChi_FormClosed);
            this.Load += new System.EventHandler(this.FrmTaoPhieuChi_Load);
            this.Enter += new System.EventHandler(this.FrmTaoPhieuChi_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhanLoaiChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phanLoaiChiRowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblTaoPhieuChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtMaPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtChiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCmbHocSinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Label lblTaoPhieuChi;
        private DevExpress.XtraLayout.LayoutControlItem lciLblTaoPhieuChi;
        private DevExpress.XtraEditors.DateEdit dateNgay;
        private DevExpress.XtraLayout.LayoutControlItem lciNgay;
        private DevExpress.XtraEditors.TextEdit txtMaPhieu;
        private DevExpress.XtraLayout.LayoutControlItem lciTxtMaPhieu;
        private DevExpress.XtraEditors.CalcEdit txtSoTien;
        private DevExpress.XtraLayout.LayoutControlItem lciTxtSoTien;
        private DevExpress.XtraEditors.MemoEdit txtGhiChu;
        private DevExpress.XtraLayout.LayoutControlItem lciTxtChiChu;
        private DevExpress.XtraEditors.SimpleButton btnLuuTao;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem lciCmbHocSinh;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit cmbPhanLoaiChi;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private Dao.QLMamNonDsTableAdapters.PhieuChiTableAdapter phieuChiTableAdapter;
        private System.Windows.Forms.BindingSource phanLoaiChiRowBindingSource;
        private Dao.QLMamNonDsTableAdapters.PhanLoaiChiTableAdapter phanLoaiChiTableAdapter;
    }
}