﻿namespace QLMamNon.Forms.ThuChi
{
    partial class FrmTaoPhieuThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaoPhieuThu));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.btnLuuTao = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtSoTien = new DevExpress.XtraEditors.CalcEdit();
            this.txtMaPhieu = new DevExpress.XtraEditors.TextEdit();
            this.dateNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblTaoPhieuThu = new System.Windows.Forms.Label();
            this.cmbHocSinh = new DevExpress.XtraEditors.LookUpEdit();
            this.hocSinhRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtConLai = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciLblTaoPhieuThu = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNgay = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTxtMaPhieu = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTxtSoTien = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTxtChiChu = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCmbHocSinh = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.hocSinhTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.HocSinhTableAdapter();
            this.phieuThuTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.PhieuThuTableAdapter();
            this.unknownColumnViewTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.UnknownColumnViewTableAdapter();
            this.viewBangThuTienTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.ViewBangThuTienTableAdapter();
            this.bangThuTienKhoanThuTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.BangThuTienKhoanThuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHocSinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hocSinhRowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConLai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblTaoPhieuThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtMaPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtChiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCmbHocSinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Appearance.Control.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lcMain.Appearance.Control.Options.UseFont = true;
            this.lcMain.Controls.Add(this.txtGhiChu);
            this.lcMain.Controls.Add(this.btnLuuTao);
            this.lcMain.Controls.Add(this.btnLuu);
            this.lcMain.Controls.Add(this.txtSoTien);
            this.lcMain.Controls.Add(this.txtMaPhieu);
            this.lcMain.Controls.Add(this.dateNgay);
            this.lcMain.Controls.Add(this.lblTaoPhieuThu);
            this.lcMain.Controls.Add(this.cmbHocSinh);
            this.lcMain.Controls.Add(this.txtConLai);
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
            this.lcMain.Size = new System.Drawing.Size(442, 293);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(180, 256);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(233, 36);
            this.txtGhiChu.StyleController = this.lcMain;
            this.txtGhiChu.TabIndex = 12;
            // 
            // btnLuuTao
            // 
            this.btnLuuTao.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuTao.Image")));
            this.btnLuuTao.Location = new System.Drawing.Point(164, 296);
            this.btnLuuTao.MaximumSize = new System.Drawing.Size(250, 0);
            this.btnLuuTao.Name = "btnLuuTao";
            this.btnLuuTao.Size = new System.Drawing.Size(249, 40);
            this.btnLuuTao.StyleController = this.lcMain;
            this.btnLuuTao.TabIndex = 10;
            this.btnLuuTao.Text = "Lưu và Tạo mới";
            this.btnLuuTao.Click += new System.EventHandler(this.btnLuuTao_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(33, 296);
            this.btnLuu.MaximumSize = new System.Drawing.Size(150, 0);
            this.btnLuu.MinimumSize = new System.Drawing.Size(100, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(127, 40);
            this.btnLuu.StyleController = this.lcMain;
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(180, 168);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoTien.Properties.DisplayFormat.FormatString = "c0";
            this.txtSoTien.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtSoTien.Properties.Mask.EditMask = "c0";
            this.txtSoTien.Size = new System.Drawing.Size(233, 40);
            this.txtSoTien.StyleController = this.lcMain;
            this.txtSoTien.TabIndex = 7;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule1.ErrorText = "Vui lòng nhập Số tiền";
            conditionValidationRule1.Value1 = ((long)(0));
            conditionValidationRule1.Value2 = "0";
            conditionValidationRule1.Values.Add("0");
            this.dxValidationProvider.SetValidationRule(this.txtSoTien, conditionValidationRule1);
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(180, 124);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(233, 40);
            this.txtMaPhieu.StyleController = this.lcMain;
            this.txtMaPhieu.TabIndex = 6;
            // 
            // dateNgay
            // 
            this.dateNgay.EditValue = null;
            this.dateNgay.Location = new System.Drawing.Point(180, 36);
            this.dateNgay.Name = "dateNgay";
            this.dateNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay.Size = new System.Drawing.Size(233, 40);
            this.dateNgay.StyleController = this.lcMain;
            this.dateNgay.TabIndex = 5;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Vui lòng chọn Ngày";
            this.dxValidationProvider.SetValidationRule(this.dateNgay, conditionValidationRule2);
            // 
            // lblTaoPhieuThu
            // 
            this.lblTaoPhieuThu.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.lblTaoPhieuThu.Location = new System.Drawing.Point(12, 12);
            this.lblTaoPhieuThu.Name = "lblTaoPhieuThu";
            this.lblTaoPhieuThu.Size = new System.Drawing.Size(401, 20);
            this.lblTaoPhieuThu.TabIndex = 4;
            this.lblTaoPhieuThu.Text = "TẠO/CẬP NHẬT PHIẾU THU";
            this.lblTaoPhieuThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbHocSinh
            // 
            this.cmbHocSinh.Location = new System.Drawing.Point(180, 80);
            this.cmbHocSinh.Name = "cmbHocSinh";
            this.cmbHocSinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbHocSinh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HoDem", "Họ đệm", 47, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Tên", 28, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NgaySinh", "Ngày sinh", 58, DevExpress.Utils.FormatType.DateTime, "M/d/yyyy", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbHocSinh.Properties.DataSource = this.hocSinhRowBindingSource;
            this.cmbHocSinh.Properties.DisplayMember = "HoTen";
            this.cmbHocSinh.Properties.NullText = "";
            this.cmbHocSinh.Properties.PopupSizeable = false;
            this.cmbHocSinh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbHocSinh.Properties.ValueMember = "HocSinhId";
            this.cmbHocSinh.Size = new System.Drawing.Size(233, 40);
            this.cmbHocSinh.StyleController = this.lcMain;
            this.cmbHocSinh.TabIndex = 11;
            // 
            // hocSinhRowBindingSource
            // 
            this.hocSinhRowBindingSource.DataSource = typeof(QLMamNon.Dao.QLMamNonDs.HocSinhRow);
            // 
            // txtConLai
            // 
            this.txtConLai.Location = new System.Drawing.Point(180, 212);
            this.txtConLai.Name = "txtConLai";
            this.txtConLai.Properties.ReadOnly = true;
            this.txtConLai.Size = new System.Drawing.Size(233, 40);
            this.txtConLai.StyleController = this.lcMain;
            this.txtConLai.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 20F);
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLblTaoPhieuThu,
            this.lciNgay,
            this.lciTxtMaPhieu,
            this.lciTxtSoTien,
            this.lciTxtChiChu,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lciCmbHocSinh,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(425, 348);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciLblTaoPhieuThu
            // 
            this.lciLblTaoPhieuThu.Control = this.lblTaoPhieuThu;
            this.lciLblTaoPhieuThu.Location = new System.Drawing.Point(0, 0);
            this.lciLblTaoPhieuThu.Name = "lciLblTaoPhieuThu";
            this.lciLblTaoPhieuThu.Size = new System.Drawing.Size(405, 24);
            this.lciLblTaoPhieuThu.TextSize = new System.Drawing.Size(0, 0);
            this.lciLblTaoPhieuThu.TextVisible = false;
            // 
            // lciNgay
            // 
            this.lciNgay.Control = this.dateNgay;
            this.lciNgay.Location = new System.Drawing.Point(0, 24);
            this.lciNgay.Name = "lciNgay";
            this.lciNgay.Size = new System.Drawing.Size(405, 44);
            this.lciNgay.Text = "Ngày thu:";
            this.lciNgay.TextSize = new System.Drawing.Size(165, 33);
            // 
            // lciTxtMaPhieu
            // 
            this.lciTxtMaPhieu.Control = this.txtMaPhieu;
            this.lciTxtMaPhieu.Location = new System.Drawing.Point(0, 112);
            this.lciTxtMaPhieu.Name = "lciTxtMaPhieu";
            this.lciTxtMaPhieu.Size = new System.Drawing.Size(405, 44);
            this.lciTxtMaPhieu.Text = "Số biên lai:";
            this.lciTxtMaPhieu.TextSize = new System.Drawing.Size(165, 33);
            // 
            // lciTxtSoTien
            // 
            this.lciTxtSoTien.Control = this.txtSoTien;
            this.lciTxtSoTien.Location = new System.Drawing.Point(0, 156);
            this.lciTxtSoTien.Name = "lciTxtSoTien";
            this.lciTxtSoTien.Size = new System.Drawing.Size(405, 44);
            this.lciTxtSoTien.Text = "Số tiền nộp:";
            this.lciTxtSoTien.TextSize = new System.Drawing.Size(165, 33);
            // 
            // lciTxtChiChu
            // 
            this.lciTxtChiChu.Control = this.txtConLai;
            this.lciTxtChiChu.Location = new System.Drawing.Point(0, 200);
            this.lciTxtChiChu.Name = "lciTxtChiChu";
            this.lciTxtChiChu.Size = new System.Drawing.Size(405, 44);
            this.lciTxtChiChu.Text = "Còn lại:";
            this.lciTxtChiChu.TextSize = new System.Drawing.Size(165, 33);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnLuu;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem1.Location = new System.Drawing.Point(21, 284);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(131, 44);
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
            this.layoutControlItem2.Location = new System.Drawing.Point(152, 284);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(253, 44);
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // lciCmbHocSinh
            // 
            this.lciCmbHocSinh.Control = this.cmbHocSinh;
            this.lciCmbHocSinh.Location = new System.Drawing.Point(0, 68);
            this.lciCmbHocSinh.Name = "lciCmbHocSinh";
            this.lciCmbHocSinh.Size = new System.Drawing.Size(405, 44);
            this.lciCmbHocSinh.Text = "Cho Học sinh:";
            this.lciCmbHocSinh.TextSize = new System.Drawing.Size(165, 33);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 284);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(21, 44);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtGhiChu;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 244);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(405, 40);
            this.layoutControlItem3.Text = "Ghi chú:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(165, 33);
            // 
            // dxValidationProvider
            // 
            this.dxValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // hocSinhTableAdapter
            // 
            this.hocSinhTableAdapter.ClearBeforeFill = true;
            // 
            // phieuThuTableAdapter
            // 
            this.phieuThuTableAdapter.ClearBeforeFill = true;
            // 
            // unknownColumnViewTableAdapter
            // 
            this.unknownColumnViewTableAdapter.ClearBeforeFill = true;
            // 
            // viewBangThuTienTableAdapter
            // 
            this.viewBangThuTienTableAdapter.ClearBeforeFill = true;
            // 
            // bangThuTienKhoanThuTableAdapter
            // 
            this.bangThuTienKhoanThuTableAdapter.ClearBeforeFill = true;
            // 
            // FrmTaoPhieuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 293);
            this.Controls.Add(this.lcMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTaoPhieuThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo/Cập nhật Phiếu thu";
            this.Activated += new System.EventHandler(this.FrmTaoPhieuThu_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTaoPhieuThu_FormClosed);
            this.Load += new System.EventHandler(this.FrmTaoPhieuThu_Load);
            this.Enter += new System.EventHandler(this.FrmTaoPhieuThu_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHocSinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hocSinhRowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConLai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblTaoPhieuThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtMaPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtChiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCmbHocSinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Label lblTaoPhieuThu;
        private DevExpress.XtraLayout.LayoutControlItem lciLblTaoPhieuThu;
        private DevExpress.XtraEditors.DateEdit dateNgay;
        private DevExpress.XtraLayout.LayoutControlItem lciNgay;
        private DevExpress.XtraEditors.TextEdit txtMaPhieu;
        private DevExpress.XtraLayout.LayoutControlItem lciTxtMaPhieu;
        private DevExpress.XtraEditors.CalcEdit txtSoTien;
        private DevExpress.XtraLayout.LayoutControlItem lciTxtSoTien;
        private DevExpress.XtraLayout.LayoutControlItem lciTxtChiChu;
        private DevExpress.XtraEditors.SimpleButton btnLuuTao;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem lciCmbHocSinh;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit cmbHocSinh;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private Dao.QLMamNonDsTableAdapters.HocSinhTableAdapter hocSinhTableAdapter;
        private System.Windows.Forms.BindingSource hocSinhRowBindingSource;
        private Dao.QLMamNonDsTableAdapters.PhieuThuTableAdapter phieuThuTableAdapter;
        private DevExpress.XtraEditors.TextEdit txtConLai;
        private DevExpress.XtraEditors.MemoEdit txtGhiChu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Dao.QLMamNonDsTableAdapters.UnknownColumnViewTableAdapter unknownColumnViewTableAdapter;
        private Dao.QLMamNonDsTableAdapters.ViewBangThuTienTableAdapter viewBangThuTienTableAdapter;
        private Dao.QLMamNonDsTableAdapters.BangThuTienKhoanThuTableAdapter bangThuTienKhoanThuTableAdapter;
    }
}