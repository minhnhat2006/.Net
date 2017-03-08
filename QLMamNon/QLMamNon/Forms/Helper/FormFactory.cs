using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using DevExpress.XtraEditors;
using QLMamNon.Forms.HocSinh;
using QLMamNon.Constant;
using QLMamNon.Forms.DanhMuc;
using QLMamNon.Forms.ThuChi;

namespace QLMamNon.Forms.Resource
{
    public class FormFactory
    {
        private Dictionary<string, string> formToTypes = new Dictionary<string, string>();

        private Dictionary<string, Form> forms = new Dictionary<string, Form>();

        public FormFactory()
        {
            formToTypes.Add(AppForms.FormThongTinHocSinh, typeof(FrmThongTinHocSinh).FullName);
            formToTypes.Add(AppForms.FormXepLop, typeof(FrmXepLop).FullName);
            formToTypes.Add(AppForms.FormDanhMucTruongHoc, typeof(FrmTruongHoc).FullName);
            formToTypes.Add(AppForms.FormDanhMucKhoiHoc, typeof(FrmKhoiHoc).FullName);
            formToTypes.Add(AppForms.FormDanhMucLopHoc, typeof(FrmLopHoc).FullName);
            formToTypes.Add(AppForms.FormDanhMucTinhThanhPho, typeof(FrmTinhThanhPho).FullName);
            formToTypes.Add(AppForms.FormDanhMucQuanHuyen, typeof(FrmQuanHuyen).FullName);
            formToTypes.Add(AppForms.FormDanhMucPhuongXa, typeof(FrmPhuongXa).FullName);
            formToTypes.Add(AppForms.FormDanhMucPhanLoaiChi, typeof(FrmPhanLoaiChi).FullName);
            formToTypes.Add(AppForms.FormDanhMucKhoanThu, typeof(FrmKhoanThu).FullName);
            formToTypes.Add(AppForms.FormDanhMucKhoanThuHangNam, typeof(FrmKhoanThuHangNam).FullName);
            formToTypes.Add(AppForms.FormPhieuThu, typeof(FrmPhieuThu).FullName);
            formToTypes.Add(AppForms.FormTaoPhieuChi, typeof(FrmTaoPhieuChi).FullName);
            formToTypes.Add(AppForms.FormPhieuChi, typeof(FrmPhieuChi).FullName);
            formToTypes.Add(AppForms.FormTaoPhieuThu, typeof(FrmTaoPhieuThu).FullName);
            formToTypes.Add(AppForms.FormSoThuTien, typeof(FrmSoThuTien).FullName);
        }

        public Form GetForm(string key)
        {
            bool isFormCreated = forms.ContainsKey(key);

            if (isFormCreated && forms[key].IsDisposed)
            {
                forms.Remove(key);
                isFormCreated = false;
            }

            if (!isFormCreated)
            {
                string type = formToTypes[key];
                Form frm = Activator.CreateInstance(Type.GetType(type)) as Form;
                forms.Add(key, frm);
            }

            return forms[key];
        }

        public string GetFormCaption(string key)
        {
            Form form = this.GetForm(key);

            if (form != null)
            {
                return form.Text;
            }

            return CommonConstant.EMPTY;
        }

        public void RemoveForm(string key)
        {
            if (forms.ContainsKey(key))
            {
                forms.Remove(key);
            }
        }
    }
}
