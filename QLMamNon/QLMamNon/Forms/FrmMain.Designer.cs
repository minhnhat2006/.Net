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
            this.bsiManHinh = new DevExpress.XtraBars.BarStaticItem();
            this.bsiTrangThai = new DevExpress.XtraBars.BarStaticItem();
            this.bbiTruongHoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKhoiHoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLopHoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTinhThanhPho = new DevExpress.XtraBars.BarButtonItem();
            this.bbiQuanHuyen = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPhuongXa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTaoPhieuThu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTaoPhieuChi = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDSPhieuThu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDSPhieuChi = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPhanLoaiChi = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.rpHocSinh = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgHocSinh = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgHocSinhCanDo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgHocSinhBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpGiaoVien = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpDinhDuong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpThuChi = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgPhieuThu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPhieuChi = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTruongHoc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgTinhThanhPho = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgThuChi = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.thanhPhoTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.ThanhPhoTableAdapter();
            this.quanHuyenTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.QuanHuyenTableAdapter();
            this.phuongXaTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.PhuongXaTableAdapter();
            this.truongTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.TruongTableAdapter();
            this.khoiTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.KhoiTableAdapter();
            this.lopTableAdapter = new QLMamNon.Dao.QLMamNonDsTableAdapters.LopTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            // 
            // 
            // 
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
            this.bbtnHocSinhThongKe,
            this.bsiManHinh,
            this.bsiTrangThai,
            this.bbiTruongHoc,
            this.bbiKhoiHoc,
            this.bbiLopHoc,
            this.bbiTinhThanhPho,
            this.bbiQuanHuyen,
            this.bbiPhuongXa,
            this.bbiTaoPhieuThu,
            this.bbiTaoPhieuChi,
            this.bbiDSPhieuThu,
            this.bbiDSPhieuChi,
            this.bbiPhanLoaiChi});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4);
            this.ribbon.MaxItemId = 16;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpHocSinh,
            this.rpGiaoVien,
            this.rpDinhDuong,
            this.rpThuChi,
            this.rpBaoCao,
            this.rpDanhMuc});
            this.ribbon.Size = new System.Drawing.Size(990, 150);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbtnHocSinhThongTin
            // 
            this.bbtnHocSinhThongTin.Caption = "Thông tin Học sinh";
            this.bbtnHocSinhThongTin.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbtnHocSinhThongTin.Id = 5;
            this.bbtnHocSinhThongTin.LargeImageIndex = 3;
            this.bbtnHocSinhThongTin.Name = "bbtnHocSinhThongTin";
            this.bbtnHocSinhThongTin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnHocSinhThongTin_ItemClick);
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
            this.bbtnHocSinhXepLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnHocSinhXepLop_ItemClick);
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
            // bsiManHinh
            // 
            this.bsiManHinh.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiManHinh.Glyph")));
            this.bsiManHinh.Id = 1;
            this.bsiManHinh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bsiManHinh.LargeGlyph")));
            this.bsiManHinh.Name = "bsiManHinh";
            this.bsiManHinh.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiTrangThai
            // 
            this.bsiTrangThai.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiTrangThai.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiTrangThai.Glyph")));
            this.bsiTrangThai.Id = 2;
            this.bsiTrangThai.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bsiTrangThai.LargeGlyph")));
            this.bsiTrangThai.Name = "bsiTrangThai";
            this.bsiTrangThai.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiTruongHoc
            // 
            this.bbiTruongHoc.Caption = "Trường học";
            this.bbiTruongHoc.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTruongHoc.Glyph")));
            this.bbiTruongHoc.Id = 3;
            this.bbiTruongHoc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTruongHoc.LargeGlyph")));
            this.bbiTruongHoc.Name = "bbiTruongHoc";
            this.bbiTruongHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTruongHoc_ItemClick);
            // 
            // bbiKhoiHoc
            // 
            this.bbiKhoiHoc.Caption = "Khối học";
            this.bbiKhoiHoc.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiKhoiHoc.Glyph")));
            this.bbiKhoiHoc.Id = 4;
            this.bbiKhoiHoc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiKhoiHoc.LargeGlyph")));
            this.bbiKhoiHoc.Name = "bbiKhoiHoc";
            this.bbiKhoiHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiKhoiHoc_ItemClick);
            // 
            // bbiLopHoc
            // 
            this.bbiLopHoc.Caption = "Lớp học";
            this.bbiLopHoc.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiLopHoc.Glyph")));
            this.bbiLopHoc.Id = 5;
            this.bbiLopHoc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiLopHoc.LargeGlyph")));
            this.bbiLopHoc.Name = "bbiLopHoc";
            this.bbiLopHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLopHoc_ItemClick);
            // 
            // bbiTinhThanhPho
            // 
            this.bbiTinhThanhPho.Caption = "Tình/Thành phố";
            this.bbiTinhThanhPho.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTinhThanhPho.Glyph")));
            this.bbiTinhThanhPho.Id = 7;
            this.bbiTinhThanhPho.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTinhThanhPho.LargeGlyph")));
            this.bbiTinhThanhPho.Name = "bbiTinhThanhPho";
            this.bbiTinhThanhPho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTinhThanhPho_ItemClick);
            // 
            // bbiQuanHuyen
            // 
            this.bbiQuanHuyen.Caption = "Quận/Huyện";
            this.bbiQuanHuyen.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiQuanHuyen.Glyph")));
            this.bbiQuanHuyen.Id = 8;
            this.bbiQuanHuyen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiQuanHuyen.LargeGlyph")));
            this.bbiQuanHuyen.Name = "bbiQuanHuyen";
            this.bbiQuanHuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiQuanHuyen_ItemClick);
            // 
            // bbiPhuongXa
            // 
            this.bbiPhuongXa.Caption = "Phường/Xã";
            this.bbiPhuongXa.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPhuongXa.Glyph")));
            this.bbiPhuongXa.Id = 9;
            this.bbiPhuongXa.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPhuongXa.LargeGlyph")));
            this.bbiPhuongXa.Name = "bbiPhuongXa";
            this.bbiPhuongXa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPhuongXa_ItemClick);
            // 
            // bbiTaoPhieuThu
            // 
            this.bbiTaoPhieuThu.Caption = "Tạo Phiếu Thu";
            this.bbiTaoPhieuThu.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiTaoPhieuThu.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTaoPhieuThu.Glyph")));
            this.bbiTaoPhieuThu.Id = 11;
            this.bbiTaoPhieuThu.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTaoPhieuThu.LargeGlyph")));
            this.bbiTaoPhieuThu.Name = "bbiTaoPhieuThu";
            this.bbiTaoPhieuThu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTaoPhieuThu_ItemClick);
            // 
            // bbiTaoPhieuChi
            // 
            this.bbiTaoPhieuChi.Caption = "Tạo Phiếu Chi";
            this.bbiTaoPhieuChi.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiTaoPhieuChi.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTaoPhieuChi.Glyph")));
            this.bbiTaoPhieuChi.Id = 12;
            this.bbiTaoPhieuChi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTaoPhieuChi.LargeGlyph")));
            this.bbiTaoPhieuChi.Name = "bbiTaoPhieuChi";
            // 
            // bbiDSPhieuThu
            // 
            this.bbiDSPhieuThu.Caption = "Danh sách Phiếu Thu";
            this.bbiDSPhieuThu.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiDSPhieuThu.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDSPhieuThu.Glyph")));
            this.bbiDSPhieuThu.Id = 13;
            this.bbiDSPhieuThu.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDSPhieuThu.LargeGlyph")));
            this.bbiDSPhieuThu.Name = "bbiDSPhieuThu";
            this.bbiDSPhieuThu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDSPhieuThu_ItemClick);
            // 
            // bbiDSPhieuChi
            // 
            this.bbiDSPhieuChi.Caption = "Danh sách Phiếu Chi";
            this.bbiDSPhieuChi.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiDSPhieuChi.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDSPhieuChi.Glyph")));
            this.bbiDSPhieuChi.Id = 14;
            this.bbiDSPhieuChi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDSPhieuChi.LargeGlyph")));
            this.bbiDSPhieuChi.Name = "bbiDSPhieuChi";
            // 
            // bbiPhanLoaiChi
            // 
            this.bbiPhanLoaiChi.Caption = "Phân Loại Chi";
            this.bbiPhanLoaiChi.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiPhanLoaiChi.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPhanLoaiChi.Glyph")));
            this.bbiPhanLoaiChi.Id = 15;
            this.bbiPhanLoaiChi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPhanLoaiChi.LargeGlyph")));
            this.bbiPhanLoaiChi.Name = "bbiPhanLoaiChi";
            this.bbiPhanLoaiChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPhanLoaiChi_ItemClick);
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
            // rpHocSinh
            // 
            this.rpHocSinh.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpHocSinh.Appearance.Options.UseFont = true;
            this.rpHocSinh.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgHocSinh,
            this.rpgHocSinhCanDo,
            this.rpgHocSinhBaoCao});
            this.rpHocSinh.Image = ((System.Drawing.Image)(resources.GetObject("rpHocSinh.Image")));
            this.rpHocSinh.Name = "rpHocSinh";
            this.rpHocSinh.Text = "Học sinh";
            // 
            // rpgHocSinh
            // 
            this.rpgHocSinh.Name = "rpgHocSinh";
            this.rpgHocSinh.Text = "Học sinh";
            // 
            // rpgHocSinhCanDo
            // 
            this.rpgHocSinhCanDo.Name = "rpgHocSinhCanDo";
            this.rpgHocSinhCanDo.Text = "Cân đo";
            // 
            // rpgHocSinhBaoCao
            // 
            this.rpgHocSinhBaoCao.Name = "rpgHocSinhBaoCao";
            this.rpgHocSinhBaoCao.Text = "Báo cáo";
            // 
            // rpGiaoVien
            // 
            this.rpGiaoVien.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpGiaoVien.Appearance.Options.UseFont = true;
            this.rpGiaoVien.Image = ((System.Drawing.Image)(resources.GetObject("rpGiaoVien.Image")));
            this.rpGiaoVien.Name = "rpGiaoVien";
            this.rpGiaoVien.Text = "Cán bộ - Giáo viên";
            // 
            // rpDinhDuong
            // 
            this.rpDinhDuong.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpDinhDuong.Appearance.Options.UseFont = true;
            this.rpDinhDuong.Image = ((System.Drawing.Image)(resources.GetObject("rpDinhDuong.Image")));
            this.rpDinhDuong.Name = "rpDinhDuong";
            this.rpDinhDuong.Text = "Khẩu phần dinh dưỡng";
            // 
            // rpThuChi
            // 
            this.rpThuChi.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpThuChi.Appearance.Options.UseFont = true;
            this.rpThuChi.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgPhieuThu,
            this.rpgPhieuChi});
            this.rpThuChi.Image = ((System.Drawing.Image)(resources.GetObject("rpThuChi.Image")));
            this.rpThuChi.Name = "rpThuChi";
            this.rpThuChi.Text = "Quản lý thu chi";
            // 
            // rpgPhieuThu
            // 
            this.rpgPhieuThu.Name = "rpgPhieuThu";
            this.rpgPhieuThu.Text = "Phiếu Thu";
            // 
            // rpgPhieuChi
            // 
            this.rpgPhieuChi.Name = "rpgPhieuChi";
            this.rpgPhieuChi.Text = "Phiếu Chi";
            // 
            // rpBaoCao
            // 
            this.rpBaoCao.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpBaoCao.Appearance.Options.UseFont = true;
            this.rpBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("rpBaoCao.Image")));
            this.rpBaoCao.Name = "rpBaoCao";
            this.rpBaoCao.Text = "Báo cáo thống kê phòng giáo dục";
            // 
            // rpDanhMuc
            // 
            this.rpDanhMuc.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rpDanhMuc.Appearance.Options.UseFont = true;
            this.rpDanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgTruongHoc,
            this.rpgTinhThanhPho,
            this.rpgThuChi});
            this.rpDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("rpDanhMuc.Image")));
            this.rpDanhMuc.Name = "rpDanhMuc";
            this.rpDanhMuc.Text = "Danh mục - Hệ thống";
            // 
            // rpgTruongHoc
            // 
            this.rpgTruongHoc.Name = "rpgTruongHoc";
            this.rpgTruongHoc.Text = "Quản lý Trường học";
            // 
            // rpgTinhThanhPho
            // 
            this.rpgTinhThanhPho.Name = "rpgTinhThanhPho";
            this.rpgTinhThanhPho.Text = "Quản lý Tỉnh/Thành phố";
            // 
            // rpgThuChi
            // 
            this.rpgThuChi.Name = "rpgThuChi";
            this.rpgThuChi.Text = "Quản lý Thu Chi";
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
            // thanhPhoTableAdapter
            // 
            this.thanhPhoTableAdapter.ClearBeforeFill = true;
            // 
            // quanHuyenTableAdapter
            // 
            this.quanHuyenTableAdapter.ClearBeforeFill = true;
            // 
            // phuongXaTableAdapter
            // 
            this.phuongXaTableAdapter.ClearBeforeFill = true;
            // 
            // truongTableAdapter
            // 
            this.truongTableAdapter.ClearBeforeFill = true;
            // 
            // khoiTableAdapter
            // 
            this.khoiTableAdapter.ClearBeforeFill = true;
            // 
            // lopTableAdapter
            // 
            this.lopTableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpDanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTruongHoc;
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
        private DevExpress.XtraBars.BarStaticItem bsiManHinh;
        private DevExpress.XtraBars.BarStaticItem bsiTrangThai;
        private Dao.QLMamNonDsTableAdapters.ThanhPhoTableAdapter thanhPhoTableAdapter;
        private Dao.QLMamNonDsTableAdapters.QuanHuyenTableAdapter quanHuyenTableAdapter;
        private Dao.QLMamNonDsTableAdapters.PhuongXaTableAdapter phuongXaTableAdapter;
        private Dao.QLMamNonDsTableAdapters.TruongTableAdapter truongTableAdapter;
        private Dao.QLMamNonDsTableAdapters.KhoiTableAdapter khoiTableAdapter;
        private Dao.QLMamNonDsTableAdapters.LopTableAdapter lopTableAdapter;
        private DevExpress.XtraBars.BarButtonItem bbiTruongHoc;
        private DevExpress.XtraBars.BarButtonItem bbiKhoiHoc;
        private DevExpress.XtraBars.BarButtonItem bbiLopHoc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTinhThanhPho;
        private DevExpress.XtraBars.BarButtonItem bbiTinhThanhPho;
        private DevExpress.XtraBars.BarButtonItem bbiQuanHuyen;
        private DevExpress.XtraBars.BarButtonItem bbiPhuongXa;
        private DevExpress.XtraBars.BarButtonItem bbiTaoPhieuThu;
        private DevExpress.XtraBars.BarButtonItem bbiTaoPhieuChi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPhieuThu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPhieuChi;
        private DevExpress.XtraBars.BarButtonItem bbiDSPhieuThu;
        private DevExpress.XtraBars.BarButtonItem bbiDSPhieuChi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgThuChi;
        private DevExpress.XtraBars.BarButtonItem bbiPhanLoaiChi;
    }
}