using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using MySql.Data.MySqlClient;
using QLThuChi.Form;
using System.Threading;

namespace QLThuChi
{
    public partial class FrmHome : DevExpress.XtraEditors.XtraForm
    {
        public string LoginFullName { get; set; }

        public string LoginUserCode { get; set; }

        public int UserId { get; set; }

        public bool IsAdmin { get; set; }

        #region Util

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

        #endregion

        #region Tab

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    this.rpgCTTM.Visible = true;
                    this.rpgTienTCS.Visible = false;
                    this.rpgUser.Visible = false;
                    this.rpgSetting.Visible = false;
                    this.txtCTTMNgay.Focus();
                    break;
                case 1:
                    this.rpgCTTM.Visible = false;
                    this.rpgTienTCS.Visible = true;
                    this.rpgUser.Visible = false;
                    this.rpgSetting.Visible = false;
                    this.txtUserFullname.Focus();
                    break;
                case 2:
                    this.rpgCTTM.Visible = false;
                    this.rpgTienTCS.Visible = false;
                    this.rpgUser.Visible = true;
                    this.rpgSetting.Visible = false;
                    break;
                case 3:
                    this.rpgCTTM.Visible = false;
                    this.rpgTienTCS.Visible = false;
                    this.rpgUser.Visible = false;
                    this.rpgSetting.Visible = true;
                    break;
                case 4:
                    this.rpgCTTM.Visible = false;
                    this.rpgTienTCS.Visible = false;
                    this.rpgUser.Visible = false;
                    this.rpgSetting.Visible = false;
                    break;
            }
        }

        private bool isCTTMTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 0;
        }

        private bool isTienTCSTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 1;
        }

        private bool isUserTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 2;
        }

        private bool isSettingTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 3;
        }

        #endregion

        #region FrmHome

        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thuChi.tientcs' table. You can move, or remove it, as needed.
            this.tientcsTableAdapter.Fill(this.thuChi.tientcs);
            // TODO: This line of code loads data into the 'thuChi.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.thuChi.user);
            // TODO: This line of code loads data into the 'thuChi.chungtutienmat' table. You can move, or remove it, as needed.
            this.chungtutienmatTableAdapter.FillByUserId(this.thuChi.chungtutienmat, this.UserId);
            // TODO: This line of code loads data into the 'thuChi.setting' table. You can move, or remove it, as needed.
            this.settingTableAdapter.Fill(this.thuChi.setting);

            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarCheckItem item = ribbonControl1.Items.CreateCheckItem(skin.SkinName, false);
                item.Tag = skin.SkinName;
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(OnPaintStyleClick);
                iPaintStyle.ItemLinks.Add(item);
            }

            this.chungtutienmatTableAdapter.Adapter.RowUpdated += new MySqlRowUpdatedEventHandler(onCTTMRowUpdated);
            this.userTableAdapter.Adapter.RowUpdated += new MySqlRowUpdatedEventHandler(onUserRowUpdated);

            this.LoadSetting();
            this.txtCTTMHoTen.Text = this.LoginFullName;
            this.txtCTTMNgay.Focus();
            this.IsProcessChangingCurrentCTTMRow = true;
            this.IsProcessChangingCurrentUserRow = true;

            this.AdjustWindowByLoginUser();
        }

        private void AdjustWindowByLoginUser()
        {
            if (!this.IsAdmin)
            {
                this.xtraTabPage2.PageVisible = false;
                this.xtraTabPage3.PageVisible = false;
                this.xtraTabPage5.PageVisible = false;
                this.layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                this.xtraTabPage2.PageVisible = true;
                this.xtraTabPage3.PageVisible = true;
                this.xtraTabPage5.PageVisible = true;
                this.layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void FrmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.thuChi.RejectChanges();
            Application.Exit();
        }

        void OnPaintStyleClick(object sender, ItemClickEventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Tag.ToString());
        }

        private void iPaintStyle_Popup(object sender, System.EventArgs e)
        {
            foreach (BarItemLink link in iPaintStyle.ItemLinks)
                ((BarCheckItem)link.Item).Checked = link.Item.Caption == defaultLookAndFeel1.LookAndFeel.ActiveSkinName;
        }

        #endregion

        #region Toolbar

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region TienTCS

        private void iTienTCSLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            LuuTienTCS(sender, e);
        }

        private void iTienTCSHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.HuyTienTCS();
        }

        private void iTienTCSThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ThemTienTCS();
        }

        private void iTienTCSXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.XoaTienTCS(sender, e);
        }

        private void iTienTCSTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isTienTCSTab())
            {
                this.gvTienTCS.OptionsView.ShowAutoFilterRow = !this.gvTienTCS.OptionsView.ShowAutoFilterRow;
            }
        }

        #endregion

        #region User

        private void iUserLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            LuuUser(sender, e);
        }

        private void userBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (!this.IsCurrentUserAddingNew)
            {
                this.txtUserPassword.Text = "";
            }
        }

        #endregion

        #region CTTM

        private void cttmBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            this.txtCTTMNgay.Focus();
        }

        private void onCTTMRowUpdated(object sender, MySqlRowUpdatedEventArgs e)
        {
            // Conditionally execute this code block on inserts only. 
            if (e.StatementType == StatementType.Insert)
            {
                MySqlCommand cmdNewID = new MySqlCommand("SELECT @@IDENTITY", this.chungtutienmatTableAdapter.Connection);
                // Retrieve the Autonumber and store it in the CategoryID column.
                e.Row["ChungTuTienMatId"] = cmdNewID.ExecuteScalar();
                e.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        private void iCTTMThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ThemCTTM();
        }

        private void iCTTMHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.HuyCTTM();
        }

        private void iCTTMTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.isCTTMTab())
            {
                this.gvCTTM.OptionsView.ShowAutoFilterRow = !this.gvCTTM.OptionsView.ShowAutoFilterRow;
            }
        }

        private void iCTTMXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.XoaCTTM(sender, e);
        }

        private void iCTTMCapNhat_ItemClick(object sender, ItemClickEventArgs e)
        {
            CapNhatCTTM(sender, e);
        }

        private void thuChiBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (this.isCTTMTab() && this.IsProcessChangingCurrentCTTMRow && this.chungtutienmatBindingSource.Current != null && !(this.chungtutienmatBindingSource.Current as DataRowView).IsNew)
            {
                this.HuyCTTM();
            }
        }

        private void btnCTTMNhanVien_Click(object sender, EventArgs e)
        {
            if (this.IsCurrentCTTMAddingNew)
            {
                this.iCTTMCapNhat_ItemClick(sender, null);
            }

            if (!this.IsCTTMValidatingError && this.chungtutienmatBindingSource.Current != null)
            {
                FrmCTTMNhanVien cttmNhanVien = new FrmCTTMNhanVien();
                cttmNhanVien.IsAdmin = this.IsAdmin;
                cttmNhanVien.UserId = this.UserId;
                cttmNhanVien.ShowDialog(this);
            }
        }

        private void btnCTTMCuoiNgay_Click(object sender, EventArgs e)
        {
            if (this.IsCurrentCTTMAddingNew)
            {
                this.iCTTMCapNhat_ItemClick(sender, null);
            }

            if (!this.IsCTTMValidatingError && this.chungtutienmatBindingSource.Current != null)
            {
                FrmCTTMTheoNgay cttmTheoNgay = new FrmCTTMTheoNgay();
                cttmTheoNgay.ShowDialog(this);
            }
        }

        private void gvCTTM_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Caption == "Số thứ tự")
            {
                if (e.RowHandle >= 0)
                {
                    e.DisplayText = (e.RowHandle + 1).ToString();
                }
                else
                {
                    e.DisplayText = "";
                }
            }
        }

        #endregion

        #region Setting

        private void iSettingLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.LuuSetting(sender, e);
        }

        #endregion
    }
}