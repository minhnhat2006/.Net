namespace QLMamNon.Forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.bbtnHocSinhThongTin = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnHocSinhKiemTraTrung = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnHocSinhThongTinHocTap = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnHocSinhTuExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnHocSinhXepLop = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnHocSinhThongTinCanDo = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnHocSinhSoLieuWHO = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnHocSinhBaoCaoSucKhoe = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnHocSinhThongKe = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.rpDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpHocSinh = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgHocSinh = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgHocSinhCanDo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgHocSinhBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpGiaoVien = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpDinhDuong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpThuChi = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbtnHocSinhThongTin,
            this.bbtnHocSinhKiemTraTrung,
            this.bbtnHocSinhThongTinHocTap,
            this.bbtnHocSinhTuExcel,
            this.bbtnHocSinhXepLop,
            this.bbtnHocSinhThongTinCanDo,
            this.bbtnHocSinhSoLieuWHO,
            this.bbtnHocSinhBaoCaoSucKhoe,
            this.bbtnHocSinhThongKe});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpDanhMuc,
            this.rpHocSinh,
            this.rpGiaoVien,
            this.rpDinhDuong,
            this.rpThuChi,
            this.rpBaoCao});
            this.ribbon.Size = new System.Drawing.Size(990, 150);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // bbtnHocSinhThongTin
            // 
            this.bbtnHocSinhThongTin.Caption = "Thông tin Học sinh";
            this.bbtnHocSinhThongTin.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhThongTin.Id = 5;
            this.bbtnHocSinhThongTin.LargeImageIndex = 3;
            this.bbtnHocSinhThongTin.Name = "bbtnHocSinhThongTin";
            // 
            // bbtnHocSinhKiemTraTrung
            // 
            this.bbtnHocSinhKiemTraTrung.Caption = "Kiểm tra Học sinh trùng";
            this.bbtnHocSinhKiemTraTrung.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhKiemTraTrung.Id = 6;
            this.bbtnHocSinhKiemTraTrung.LargeImageIndex = 4;
            this.bbtnHocSinhKiemTraTrung.Name = "bbtnHocSinhKiemTraTrung";
            // 
            // bbtnHocSinhThongTinHocTap
            // 
            this.bbtnHocSinhThongTinHocTap.Caption = "Nhập thông tin học tập";
            this.bbtnHocSinhThongTinHocTap.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhThongTinHocTap.Id = 7;
            this.bbtnHocSinhThongTinHocTap.LargeImageIndex = 7;
            this.bbtnHocSinhThongTinHocTap.Name = "bbtnHocSinhThongTinHocTap";
            // 
            // bbtnHocSinhTuExcel
            // 
            this.bbtnHocSinhTuExcel.Caption = "Thêm Học sinh từ file Excel";
            this.bbtnHocSinhTuExcel.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhTuExcel.Id = 8;
            this.bbtnHocSinhTuExcel.LargeImageIndex = 2;
            this.bbtnHocSinhTuExcel.Name = "bbtnHocSinhTuExcel";
            // 
            // bbtnHocSinhXepLop
            // 
            this.bbtnHocSinhXepLop.Caption = "Lên lớp - Xếp lớp";
            this.bbtnHocSinhXepLop.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhXepLop.Id = 9;
            this.bbtnHocSinhXepLop.LargeImageIndex = 5;
            this.bbtnHocSinhXepLop.Name = "bbtnHocSinhXepLop";
            // 
            // bbtnHocSinhThongTinCanDo
            // 
            this.bbtnHocSinhThongTinCanDo.Caption = "Nhập thông tin cân đo";
            this.bbtnHocSinhThongTinCanDo.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhThongTinCanDo.Id = 10;
            this.bbtnHocSinhThongTinCanDo.LargeImageIndex = 1;
            this.bbtnHocSinhThongTinCanDo.Name = "bbtnHocSinhThongTinCanDo";
            // 
            // bbtnHocSinhSoLieuWHO
            // 
            this.bbtnHocSinhSoLieuWHO.Caption = "Bảng số liệu WHO";
            this.bbtnHocSinhSoLieuWHO.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhSoLieuWHO.Id = 11;
            this.bbtnHocSinhSoLieuWHO.LargeImageIndex = 0;
            this.bbtnHocSinhSoLieuWHO.Name = "bbtnHocSinhSoLieuWHO";
            // 
            // bbtnHocSinhBaoCaoSucKhoe
            // 
            this.bbtnHocSinhBaoCaoSucKhoe.Caption = "Báo cáo sức khỏe";
            this.bbtnHocSinhBaoCaoSucKhoe.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhBaoCaoSucKhoe.Id = 12;
            this.bbtnHocSinhBaoCaoSucKhoe.LargeImageIndex = 8;
            this.bbtnHocSinhBaoCaoSucKhoe.Name = "bbtnHocSinhBaoCaoSucKhoe";
            // 
            // bbtnHocSinhThongKe
            // 
            this.bbtnHocSinhThongKe.Caption = "Danh sách thống kê";
            this.bbtnHocSinhThongKe.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhThongKe.Id = 13;
            this.bbtnHocSinhThongKe.LargeImageIndex = 9;
            this.bbtnHocSinhThongKe.Name = "bbtnHocSinhThongKe";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "bangsolieu.jpg");
            this.imageCollection1.Images.SetKeyName(1, "cando.jpg");
            this.imageCollection1.Images.SetKeyName(2, "excel.jpg");
            this.imageCollection1.Images.SetKeyName(3, "hocsinh.jpg");
            this.imageCollection1.Images.SetKeyName(4, "kiemtratrung.jpg");
            this.imageCollection1.Images.SetKeyName(5, "lenlopxeplop.jpg");
            this.imageCollection1.Images.SetKeyName(6, "login.png");
            this.imageCollection1.Images.SetKeyName(7, "nhapthongtinhoctap.jpg");
            this.imageCollection1.Images.SetKeyName(8, "suckhoe.jpg");
            this.imageCollection1.Images.SetKeyName(9, "thongke.jpg");
            // 
            // rpDanhMuc
            // 
            this.rpDanhMuc.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpDanhMuc.Appearance.Options.UseFont = true;
            this.rpDanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rpDanhMuc.Name = "rpDanhMuc";
            this.rpDanhMuc.Text = "Danh mục - Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // rpHocSinh
            // 
            this.rpHocSinh.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpHocSinh.Appearance.Options.UseFont = true;
            this.rpHocSinh.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgHocSinh,
            this.rpgHocSinhCanDo,
            this.rpgHocSinhBaoCao});
            this.rpHocSinh.Name = "rpHocSinh";
            this.rpHocSinh.Text = "Học sinh";
            // 
            // rpgHocSinh
            // 
            this.rpgHocSinh.ItemLinks.Add(this.bbtnHocSinhThongTin);
            this.rpgHocSinh.ItemLinks.Add(this.bbtnHocSinhKiemTraTrung);
            this.rpgHocSinh.ItemLinks.Add(this.bbtnHocSinhThongTinHocTap);
            this.rpgHocSinh.ItemLinks.Add(this.bbtnHocSinhTuExcel);
            this.rpgHocSinh.ItemLinks.Add(this.bbtnHocSinhXepLop);
            this.rpgHocSinh.Name = "rpgHocSinh";
            this.rpgHocSinh.Text = "Học sinh";
            // 
            // rpgHocSinhCanDo
            // 
            this.rpgHocSinhCanDo.ItemLinks.Add(this.bbtnHocSinhThongTinCanDo);
            this.rpgHocSinhCanDo.ItemLinks.Add(this.bbtnHocSinhSoLieuWHO);
            this.rpgHocSinhCanDo.Name = "rpgHocSinhCanDo";
            this.rpgHocSinhCanDo.Text = "Cân đo";
            // 
            // rpgHocSinhBaoCao
            // 
            this.rpgHocSinhBaoCao.ItemLinks.Add(this.bbtnHocSinhBaoCaoSucKhoe);
            this.rpgHocSinhBaoCao.ItemLinks.Add(this.bbtnHocSinhThongKe);
            this.rpgHocSinhBaoCao.Name = "rpgHocSinhBaoCao";
            this.rpgHocSinhBaoCao.Text = "Báo cáo";
            // 
            // rpGiaoVien
            // 
            this.rpGiaoVien.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpGiaoVien.Appearance.Options.UseFont = true;
            this.rpGiaoVien.Name = "rpGiaoVien";
            this.rpGiaoVien.Text = "Cán bộ - Giáo viên";
            // 
            // rpDinhDuong
            // 
            this.rpDinhDuong.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpDinhDuong.Appearance.Options.UseFont = true;
            this.rpDinhDuong.Name = "rpDinhDuong";
            this.rpDinhDuong.Text = "Khảu phần dinh dưỡng";
            // 
            // rpThuChi
            // 
            this.rpThuChi.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpThuChi.Appearance.Options.UseFont = true;
            this.rpThuChi.Name = "rpThuChi";
            this.rpThuChi.Text = "Quản lý thu chi";
            // 
            // rpBaoCao
            // 
            this.rpBaoCao.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpBaoCao.Appearance.Options.UseFont = true;
            this.rpBaoCao.Name = "rpBaoCao";
            this.rpBaoCao.Text = "Báo cáo thống kê phòng giáo dục";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 718);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(990, 31);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.AppearancePage.Header.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xtraTabbedMdiManager1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabbedMdiManager1.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next)
                        | DevExpress.XtraTab.TabButtons.Close)
                        | DevExpress.XtraTab.TabButtons.Default)));
            this.xtraTabbedMdiManager1.Images = this.imageCollection1;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // FrmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 749);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Quản lý Mầm non";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpDanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpHocSinh;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpGiaoVien;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpDinhDuong;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpThuChi;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpBaoCao;
        private DevExpress.XtraBars.BarButtonItem bbtnHocSinhThongTin;
        private DevExpress.XtraBars.BarButtonItem bbtnHocSinhKiemTraTrung;
        private DevExpress.XtraBars.BarButtonItem bbtnHocSinhThongTinHocTap;
        private DevExpress.XtraBars.BarButtonItem bbtnHocSinhTuExcel;
        private DevExpress.XtraBars.BarButtonItem bbtnHocSinhXepLop;
        private DevExpress.XtraBars.BarButtonItem bbtnHocSinhThongTinCanDo;
        private DevExpress.XtraBars.BarButtonItem bbtnHocSinhSoLieuWHO;
        private DevExpress.XtraBars.BarButtonItem bbtnHocSinhBaoCaoSucKhoe;
        private DevExpress.XtraBars.BarButtonItem bbtnHocSinhThongKe;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgHocSinh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgHocSinhCanDo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgHocSinhBaoCao;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
    }
}