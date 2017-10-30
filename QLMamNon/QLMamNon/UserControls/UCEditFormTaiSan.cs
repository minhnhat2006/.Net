using System;
using QLMamNon.Components.Data.Static;
using QLMamNon.Facade;
using ACG.Core.WinForm.Util;
using QLMamNon.Constant;

namespace QLMamNon.UserControls
{
    public partial class UCEditFormTaiSan : UCCRUDBase
    {
        public UCEditFormTaiSan()
        {
            InitializeComponent();
        }

        private void UCEditFormTaiSan_Load(object sender, EventArgs e)
        {
            this.phanLoaiChiRowBindingSource.DataSource = StaticDataFacade.Get(StaticDataKeys.PhanLoaiChi);
        }

        private void UCEditFormTaiSan_Enter(object sender, EventArgs e)
        {
        }

        private void recalculateThanhTien()
        {
            QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow row = this.GridView.GetFocusedDataRow() as QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow;

            if (row != null && !ControlUtil.IsEditValueNull(txtDonGia) && !ControlUtil.IsEditValueNull(txtSoLuong))
            {
                row.ThanhTien = Convert.ToInt64(txtDonGia.Value * txtSoLuong.Value);
            }
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            recalculateThanhTien();
        }

        private void txtDonGia_Leave(object sender, EventArgs e)
        {
            recalculateThanhTien();
        }

        private void cmbPhanLoaiChi_EditValueChanged(object sender, EventArgs e)
        {
            QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow row = this.GridView.GetFocusedDataRow() as QLMamNon.Dao.QLMamNonDs.ViewTaiSanRow;

            if (row != null && cmbPhanLoaiChi.IsEditorActive)
            {
                if (!ControlUtil.IsEditValueNull(cmbPhanLoaiChi))
                {
                    row.PhanLoaiTaiSan = cmbPhanLoaiChi.Text;
                }
                else
                {
                    row.PhanLoaiTaiSan = CommonConstant.EMPTY;
                }
            }
        }
    }
}
