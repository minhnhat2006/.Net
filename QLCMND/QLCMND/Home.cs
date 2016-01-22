using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace QLCMND
{
    public partial class FrmHome : DevExpress.XtraEditors.XtraForm
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    this.txtCMND.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                    this.rpgCMND.Visible = true;
                    this.rpgPhieuChi.Visible = false;
                    this.rpgPhieuThu.Visible = false;
                    this.txtSoCMND.Focus();
                    break;
                case 1:
                    this.txtCMND.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                    this.rpgCMND.Visible = false;
                    this.rpgPhieuChi.Visible = false;
                    this.rpgPhieuThu.Visible = true;
                    this.txtPTHoTen.Focus();
                    break;
                case 2:
                    this.txtCMND.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                    this.rpgCMND.Visible = false;
                    this.rpgPhieuChi.Visible = true;
                    this.rpgPhieuThu.Visible = false;
                    this.txtCMND.Focus();
                    break;
                case 3:
                    this.rpgCMND.Visible = false;
                    this.rpgPhieuChi.Visible = false;
                    this.rpgPhieuThu.Visible = false;
                    break;
            }
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cMND.phieuchi' table. You can move, or remove it, as needed.
            this.phieuchiTableAdapter.Fill(this.cMND.phieuchi);
            // TODO: This line of code loads data into the 'cMND.phieuthu' table. You can move, or remove it, as needed.
            this.phieuthuTableAdapter.Fill(this.cMND.phieuthu);
            // TODO: This line of code loads data into the 'cMND._CMND' table. You can move, or remove it, as needed.
            this.cMNDTableAdapter.Fill(this.cMND._CMND);

            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarCheckItem item = ribbonControl1.Items.CreateCheckItem(skin.SkinName, false);
                item.Tag = skin.SkinName;
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(OnPaintStyleClick);
                iPaintStyle.ItemLinks.Add(item);
            }

            this.cMNDTableAdapter.Adapter.RowUpdated += new OleDbRowUpdatedEventHandler(OnCMNDRowUpdated);
            this.phieuchiTableAdapter.Adapter.RowUpdated += new OleDbRowUpdatedEventHandler(OnPCRowUpdated);
            this.phieuthuTableAdapter.Adapter.RowUpdated += new OleDbRowUpdatedEventHandler(OnPTRowUpdated);

            this.txtSoCMND.Focus();
            this.IsProcessChangingCurrentCMNDRow = true;
            this.IsProcessChangingCurrentPCRow = true;
            this.IsProcessChangingCurrentPTRow = true;
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

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void FrmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.cMND.RejectChanges();
        }

        #region Utils

        private bool isCMNDTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 0;
        }

        private bool isPhieuThuTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 1;
        }

        private bool isPhieuChiTab()
        {
            return this.xtraTabControl1.SelectedTabPageIndex == 2;
        }

        #endregion

    }
}