using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using QLMamNon.Forms.HocSinh;

namespace QLMamNon.Forms
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmThongTinHocSinh frm = new FrmThongTinHocSinh();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}