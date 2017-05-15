namespace QLMamNon.Forms.HocSinh
{
    partial class FrmXepLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXepLop));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveRight = new DevExpress.XtraEditors.SimpleButton();
            this.gcChuyenDen = new DevExpress.XtraGrid.GridControl();
            this.hocSinhRowBindingSourceDen = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHocSinhId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoDem1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcChuyenDi = new DevExpress.XtraGrid.GridControl();
            this.hocSinhRowBindingSourceDi = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHocSinhId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoDem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateNgayVaoLop = new DevExpress.XtraEditors.DateEdit();
            this.cmbNamHocDi = new DevExpress.XtraEditors.LookUpEdit();
            this.namHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbLopHocDi = new DevExpress.XtraEditors.LookUpEdit();
            this.lopRowBindingSourceDi = new System.Windows.Forms.BindingSource(this.components);
            this.cmbLopHocDen = new DevExpress.XtraEditors.LookUpEdit();
            this.lopRowBindingSourceDen = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciLopHoc = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNamHoc = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLopHocDen = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.hocSinhTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.HocSinhTableAdapter();
            this.hocSinhLopTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.HocSinhLopTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChuyenDen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hocSinhRowBindingSourceDen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChuyenDi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hocSinhRowBindingSourceDi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayVaoLop.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayVaoLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNamHocDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.namHocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLopHocDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopRowBindingSourceDi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLopHocDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopRowBindingSourceDen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLopHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNamHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLopHocDen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.btnSave);
            this.lcMain.Controls.Add(this.btnMoveLeft);
            this.lcMain.Controls.Add(this.btnMoveRight);
            this.lcMain.Controls.Add(this.gcChuyenDen);
            this.lcMain.Controls.Add(this.gcChuyenDi);
            this.lcMain.Controls.Add(this.dateNgayVaoLop);
            this.lcMain.Controls.Add(this.cmbNamHocDi);
            this.lcMain.Controls.Add(this.cmbLopHocDi);
            this.lcMain.Controls.Add(this.cmbLopHocDen);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2476, 162, 392, 484);
            this.lcMain.OptionsFocus.EnableAutoTabOrder = false;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcMain.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(992, 573);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "Lên lớp - Xếp lớp";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(479, 539);
            this.btnSave.MaximumSize = new System.Drawing.Size(60, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 22);
            this.btnSave.StyleController = this.lcMain;
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Lưu";
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveLeft.Image")));
            this.btnMoveLeft.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMoveLeft.Location = new System.Drawing.Point(484, 232);
            this.btnMoveLeft.MaximumSize = new System.Drawing.Size(50, 30);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(50, 30);
            this.btnMoveLeft.StyleController = this.lcMain;
            this.btnMoveLeft.TabIndex = 16;
            this.btnMoveLeft.Text = " ";
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveRight.Image")));
            this.btnMoveRight.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMoveRight.Location = new System.Drawing.Point(484, 188);
            this.btnMoveRight.MaximumSize = new System.Drawing.Size(50, 30);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(50, 30);
            this.btnMoveRight.StyleController = this.lcMain;
            this.btnMoveRight.TabIndex = 15;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // gcChuyenDen
            // 
            this.gcChuyenDen.DataSource = this.hocSinhRowBindingSourceDen;
            this.gcChuyenDen.Location = new System.Drawing.Point(552, 60);
            this.gcChuyenDen.MainView = this.gridView2;
            this.gcChuyenDen.Name = "gcChuyenDen";
            this.gcChuyenDen.Size = new System.Drawing.Size(428, 501);
            this.gcChuyenDen.TabIndex = 14;
            this.gcChuyenDen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // hocSinhRowBindingSourceDen
            // 
            this.hocSinhRowBindingSourceDen.AllowNew = true;
            this.hocSinhRowBindingSourceDen.DataSource = typeof(QLMamNon.Dao.QLMamNonDs.HocSinhRow);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHocSinhId1,
            this.colSTT1,
            this.colHoDem1,
            this.colGioiTinh1,
            this.colNgaySinh1});
            this.gridView2.GridControl = this.gcChuyenDen;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colHocSinhId1
            // 
            this.colHocSinhId1.Caption = "ID";
            this.colHocSinhId1.FieldName = "HocSinhId";
            this.colHocSinhId1.Name = "colHocSinhId1";
            // 
            // colSTT1
            // 
            this.colSTT1.Caption = "STT";
            this.colSTT1.Name = "colSTT1";
            this.colSTT1.Visible = true;
            this.colSTT1.VisibleIndex = 0;
            this.colSTT1.Width = 40;
            // 
            // colHoDem1
            // 
            this.colHoDem1.Caption = "Họ tên";
            this.colHoDem1.FieldName = "HoTen";
            this.colHoDem1.Name = "colHoDem1";
            this.colHoDem1.Visible = true;
            this.colHoDem1.VisibleIndex = 1;
            this.colHoDem1.Width = 135;
            // 
            // colGioiTinh1
            // 
            this.colGioiTinh1.Caption = "Giới tính";
            this.colGioiTinh1.FieldName = "GioiTinh";
            this.colGioiTinh1.Name = "colGioiTinh1";
            this.colGioiTinh1.Visible = true;
            this.colGioiTinh1.VisibleIndex = 2;
            this.colGioiTinh1.Width = 90;
            // 
            // colNgaySinh1
            // 
            this.colNgaySinh1.Caption = "Ngày sinh";
            this.colNgaySinh1.FieldName = "NgaySinh";
            this.colNgaySinh1.Name = "colNgaySinh1";
            this.colNgaySinh1.Visible = true;
            this.colNgaySinh1.VisibleIndex = 3;
            this.colNgaySinh1.Width = 100;
            // 
            // gcChuyenDi
            // 
            this.gcChuyenDi.DataSource = this.hocSinhRowBindingSourceDi;
            this.gcChuyenDi.Location = new System.Drawing.Point(12, 60);
            this.gcChuyenDi.MainView = this.gridView1;
            this.gcChuyenDi.Name = "gcChuyenDi";
            this.gcChuyenDi.Size = new System.Drawing.Size(454, 501);
            this.gcChuyenDi.TabIndex = 13;
            this.gcChuyenDi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // hocSinhRowBindingSourceDi
            // 
            this.hocSinhRowBindingSourceDi.DataSource = typeof(QLMamNon.Dao.QLMamNonDs.HocSinhRow);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHocSinhId,
            this.colSTT,
            this.colHoDem,
            this.colGioiTinh,
            this.colNgaySinh});
            this.gridView1.GridControl = this.gcChuyenDi;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colHocSinhId
            // 
            this.colHocSinhId.Caption = "ID";
            this.colHocSinhId.FieldName = "HocSinhId";
            this.colHocSinhId.Name = "colHocSinhId";
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 40;
            // 
            // colHoDem
            // 
            this.colHoDem.Caption = "Họ tên";
            this.colHoDem.FieldName = "HoTen";
            this.colHoDem.Name = "colHoDem";
            this.colHoDem.Visible = true;
            this.colHoDem.VisibleIndex = 1;
            this.colHoDem.Width = 135;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Caption = "Giới tính";
            this.colGioiTinh.FieldName = "GioiTinh";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 2;
            this.colGioiTinh.Width = 90;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày sinh";
            this.colNgaySinh.FieldName = "NgaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 3;
            this.colNgaySinh.Width = 100;
            // 
            // dateNgayVaoLop
            // 
            this.dateNgayVaoLop.EditValue = null;
            this.dateNgayVaoLop.Location = new System.Drawing.Point(618, 36);
            this.dateNgayVaoLop.Name = "dateNgayVaoLop";
            this.dateNgayVaoLop.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateNgayVaoLop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayVaoLop.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayVaoLop.Size = new System.Drawing.Size(362, 20);
            this.dateNgayVaoLop.StyleController = this.lcMain;
            this.dateNgayVaoLop.TabIndex = 12;
            this.dateNgayVaoLop.EditValueChanged += new System.EventHandler(this.dateNgayVaoLop_EditValueChanged);
            // 
            // cmbNamHocDi
            // 
            this.cmbNamHocDi.Location = new System.Drawing.Point(78, 12);
            this.cmbNamHocDi.Name = "cmbNamHocDi";
            this.cmbNamHocDi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmbNamHocDi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNamHocDi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Năm")});
            this.cmbNamHocDi.Properties.DataSource = this.namHocBindingSource;
            this.cmbNamHocDi.Properties.DisplayMember = "Text";
            this.cmbNamHocDi.Properties.NullText = "";
            this.cmbNamHocDi.Properties.PopupSizeable = false;
            this.cmbNamHocDi.Properties.ShowHeader = false;
            this.cmbNamHocDi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbNamHocDi.Properties.ValueMember = "FromYear";
            this.cmbNamHocDi.Size = new System.Drawing.Size(388, 20);
            this.cmbNamHocDi.StyleController = this.lcMain;
            this.cmbNamHocDi.TabIndex = 4;
            this.cmbNamHocDi.EditValueChanged += new System.EventHandler(this.cmbNamHocDi_EditValueChanged);
            // 
            // namHocBindingSource
            // 
            this.namHocBindingSource.DataSource = typeof(QLMamNon.Entity.Form.NamHoc);
            // 
            // cmbLopHocDi
            // 
            this.cmbLopHocDi.Location = new System.Drawing.Point(78, 36);
            this.cmbLopHocDi.Name = "cmbLopHocDi";
            this.cmbLopHocDi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmbLopHocDi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLopHocDi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.cmbLopHocDi.Properties.DataSource = this.lopRowBindingSourceDi;
            this.cmbLopHocDi.Properties.DisplayMember = "Name";
            this.cmbLopHocDi.Properties.NullText = "";
            this.cmbLopHocDi.Properties.PopupSizeable = false;
            this.cmbLopHocDi.Properties.ShowHeader = false;
            this.cmbLopHocDi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbLopHocDi.Properties.ValueMember = "LopId";
            this.cmbLopHocDi.Size = new System.Drawing.Size(388, 20);
            this.cmbLopHocDi.StyleController = this.lcMain;
            this.cmbLopHocDi.TabIndex = 6;
            this.cmbLopHocDi.EditValueChanged += new System.EventHandler(this.cmbLopHocDi_EditValueChanged);
            // 
            // lopRowBindingSourceDi
            // 
            this.lopRowBindingSourceDi.DataSource = typeof(QLMamNon.Dao.QLMamNonDs.LopRow);
            // 
            // cmbLopHocDen
            // 
            this.cmbLopHocDen.Location = new System.Drawing.Point(618, 12);
            this.cmbLopHocDen.Name = "cmbLopHocDen";
            this.cmbLopHocDen.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmbLopHocDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLopHocDen.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.cmbLopHocDen.Properties.DataSource = this.lopRowBindingSourceDen;
            this.cmbLopHocDen.Properties.DisplayMember = "Name";
            this.cmbLopHocDen.Properties.NullText = "";
            this.cmbLopHocDen.Properties.PopupSizeable = false;
            this.cmbLopHocDen.Properties.ShowHeader = false;
            this.cmbLopHocDen.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbLopHocDen.Properties.ValueMember = "LopId";
            this.cmbLopHocDen.Size = new System.Drawing.Size(362, 20);
            this.cmbLopHocDen.StyleController = this.lcMain;
            this.cmbLopHocDen.TabIndex = 10;
            this.cmbLopHocDen.EditValueChanged += new System.EventHandler(this.cmbLopHocDen_EditValueChanged);
            // 
            // lopRowBindingSourceDen
            // 
            this.lopRowBindingSourceDen.DataSource = typeof(QLMamNon.Dao.QLMamNonDs.LopRow);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLopHoc,
            this.lciNamHoc,
            this.lciLopHocDen,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(992, 573);
            this.layoutControlGroup1.Text = "Lên lớp - Xếp lớp";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciLopHoc
            // 
            this.lciLopHoc.Control = this.cmbLopHocDi;
            this.lciLopHoc.Location = new System.Drawing.Point(0, 24);
            this.lciLopHoc.Name = "lciLopHoc";
            this.lciLopHoc.Size = new System.Drawing.Size(458, 24);
            this.lciLopHoc.Text = "Lớp học";
            this.lciLopHoc.TextSize = new System.Drawing.Size(63, 13);
            // 
            // lciNamHoc
            // 
            this.lciNamHoc.Control = this.cmbNamHocDi;
            this.lciNamHoc.Location = new System.Drawing.Point(0, 0);
            this.lciNamHoc.Name = "lciNamHoc";
            this.lciNamHoc.Size = new System.Drawing.Size(458, 24);
            this.lciNamHoc.Text = "Năm học";
            this.lciNamHoc.TextSize = new System.Drawing.Size(63, 13);
            // 
            // lciLopHocDen
            // 
            this.lciLopHocDen.Control = this.cmbLopHocDen;
            this.lciLopHocDen.Location = new System.Drawing.Point(540, 0);
            this.lciLopHocDen.Name = "lciLopHocDen";
            this.lciLopHocDen.Size = new System.Drawing.Size(432, 24);
            this.lciLopHocDen.Text = "Lớp học";
            this.lciLopHocDen.TextSize = new System.Drawing.Size(63, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dateNgayVaoLop;
            this.layoutControlItem1.Location = new System.Drawing.Point(540, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(432, 24);
            this.layoutControlItem1.Text = "Ngày vào lớp";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(63, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcChuyenDi;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(458, 505);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcChuyenDen;
            this.layoutControlItem3.Location = new System.Drawing.Point(540, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(432, 505);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnMoveRight;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.layoutControlItem4.FillControlToClientArea = false;
            this.layoutControlItem4.Location = new System.Drawing.Point(458, 48);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(46, 42);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(82, 170);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(458, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(82, 48);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnMoveLeft;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem5.FillControlToClientArea = false;
            this.layoutControlItem5.Location = new System.Drawing.Point(458, 218);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(46, 42);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(82, 46);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSave;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.layoutControlItem6.FillControlToClientArea = false;
            this.layoutControlItem6.Location = new System.Drawing.Point(458, 264);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(52, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(82, 289);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // hocSinhTableAdapter
            // 
            this.hocSinhTableAdapter.ClearBeforeFill = true;
            // 
            // hocSinhLopTableAdapter
            // 
            this.hocSinhLopTableAdapter.ClearBeforeFill = true;
            // 
            // FrmXepLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 573);
            this.Controls.Add(this.lcMain);
            this.Name = "FrmXepLop";
            this.Text = "Lên lớp - Xếp lớp";
            this.Load += new System.EventHandler(this.FrmXepLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcChuyenDen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hocSinhRowBindingSourceDen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChuyenDi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hocSinhRowBindingSourceDi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayVaoLop.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayVaoLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNamHocDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.namHocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLopHocDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopRowBindingSourceDi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLopHocDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopRowBindingSourceDen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLopHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNamHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLopHocDen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lciNamHoc;
        private DevExpress.XtraLayout.LayoutControlItem lciLopHoc;
        private DevExpress.XtraLayout.LayoutControlItem lciLopHocDen;
        private DevExpress.XtraEditors.DateEdit dateNgayVaoLop;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gcChuyenDi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gcChuyenDen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnMoveRight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource hocSinhRowBindingSourceDi;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colHoDem;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private System.Windows.Forms.BindingSource hocSinhRowBindingSourceDen;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT1;
        private DevExpress.XtraGrid.Columns.GridColumn colHoDem1;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh1;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh1;
        private Dao.QLMamNonDsTableAdapters.HocSinhTableAdapter hocSinhTableAdapter;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnMoveLeft;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn colHocSinhId;
        private DevExpress.XtraGrid.Columns.GridColumn colHocSinhId1;
        private DevExpress.XtraEditors.LookUpEdit cmbNamHocDi;
        private DevExpress.XtraEditors.LookUpEdit cmbLopHocDi;
        private DevExpress.XtraEditors.LookUpEdit cmbLopHocDen;
        private System.Windows.Forms.BindingSource namHocBindingSource;
        private System.Windows.Forms.BindingSource lopRowBindingSourceDi;
        private System.Windows.Forms.BindingSource lopRowBindingSourceDen;
        private Dao.QLMamNonDsTableAdapters.HocSinhLopTableAdapter hocSinhLopTableAdapter;
    }
}