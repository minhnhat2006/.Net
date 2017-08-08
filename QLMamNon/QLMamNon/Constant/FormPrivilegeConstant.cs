using System.Collections.Generic;

namespace QLMamNon.Constant
{
    public static class FormPrivilegeConstant
    {
        public const int XemDanhSachPhieuChi = 1;
        public const int XemDanhSachPhieuThu = 2;
        public const int XemSoQuyTienMat = 3;
        public const int XemBaoCaoThuChi = 4;

        public static Dictionary<string, int> FormKeyToPrivilegeId = new Dictionary<string, int>()
        {
            {AppForms.FormPhieuChi, XemDanhSachPhieuChi},
            {AppForms.FormPhieuThu, XemDanhSachPhieuThu},
            {AppForms.FormSoQuyTienMat, XemSoQuyTienMat},
            {AppForms.FormBangKeThuHocPhi, XemSoQuyTienMat},
            {AppForms.FormBaoCaoTinhHinhThuChi, XemBaoCaoThuChi},
            {AppForms.FormUser, XemBaoCaoThuChi}
        };
    }
}
