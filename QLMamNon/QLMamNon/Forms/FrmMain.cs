using System;
using DevExpress.XtraBars;
using QLMamNon.Components.ModuleMediator.Channel;
using QLMamNon.Forms.HocSinh;
using QLMamNon.Workflow.Forms;
using QLMamNon.Facade;
using QLMamNon.Forms.Resource;
using QLMamNon.Components.Data.Static;

namespace QLMamNon.Forms
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Public Methods

        public void SetManHinhCaption(string caption)
        {
            this.bsiManHinh.Caption = caption;
        }

        public void SetTrangThaiCaption(string caption)
        {
            this.bsiTrangThai.Caption = caption;
        }

        #endregion

        #region Events

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            IChannelManager formChannelManager = new FormChannelManager();
            formChannelManager.InitSubscribers(this);

            IFormWorkFlow formWorkFlow = new FrmMainFlow();
            formWorkFlow.InitWorkFlow(this);

            FormMainFacade.InitFormMain(this);

            this.initStaticData();
        }

        private void initStaticData()
        {
            StaticDataFacade.Add(DataKeys.TinhThanhPho, new TinhThanhPhoData(thanhPhoTableAdapter));
            StaticDataFacade.Add(DataKeys.PhuongXa, new PhuongXaData(phuongXaTableAdapter));
            StaticDataFacade.Add(DataKeys.QuanHuyen, new QuanHuyenData(quanHuyenTableAdapter));
            StaticDataFacade.Add(DataKeys.TruongHoc, new TruongData(truongTableAdapter));
            StaticDataFacade.Add(DataKeys.NamHoc, new NamHocData());
            StaticDataFacade.Add(DataKeys.KhoiHoc, new KhoiData(khoiTableAdapter));
            StaticDataFacade.Add(DataKeys.LopHoc, new LopData(lopTableAdapter));
            StaticDataFacade.Add(DataKeys.KhoanThu, new KhoanThuData(khoanThuTableAdapter));
        }

        private void bbtnHocSinhThongTin_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormThongTinHocSinh);
        }

        private void bbtnHocSinhXepLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormXepLop);
        }

        private void bbiTruongHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormDanhMucTruongHoc);
        }

        private void bbiKhoiHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormDanhMucKhoiHoc);
        }

        private void bbiLopHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormDanhMucLopHoc);
        }

        private void bbiTinhThanhPho_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormDanhMucTinhThanhPho);
        }

        private void bbiQuanHuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormDanhMucQuanHuyen);
        }

        private void bbiPhuongXa_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormDanhMucPhuongXa);
        }

        private void bbiTaoPhieuThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuThu);
        }

        private void bbiTaoPhieuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowDialog(AppForms.FormTaoPhieuChi);
        }

        private void bbiPhanLoaiChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormDanhMucPhanLoaiChi);
        }

        private void bbiDSPhieuThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormPhieuThu);
        }

        private void bbiDSPhieuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormPhieuChi);
        }

        private void bbiSoThuTienHS_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormSoThuTien);
        }

        private void bbiKhoanThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormDanhMucKhoanThu);
        }

        private void bbiKhoanThuHangNam_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormMainFacade.ShowForm(AppForms.FormDanhMucKhoanThuHangNam);
        }

        #endregion
    }
}