using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLMamNon.Forms;
using System.Windows.Forms;
using QLMamNon.Forms.Resource;

namespace QLMamNon.Facade
{
    public static class FormMainFacade
    {
        private static FrmMain frmMain;

        private static FormFactory formFactory = new FormFactory();

        public static void InitFormMain(FrmMain formMain)
        {
            frmMain = formMain;
        }

        public static Form GetForm(string form)
        {
            Form frm = formFactory.GetForm(form);
            return frm;
        }

        public static void ShowForm(string form)
        {
            Form frm = formFactory.GetForm(form);
            frm.MdiParent = frmMain;
            frm.Show();
            frm.Activate();
        }

        public static void ShowDialog(string form)
        {
            Form frm = formFactory.GetForm(form);
            frm.ShowDialog();
            frm.Activate();
        }

        public static void CloseForm(string form)
        {
            formFactory.RemoveForm(form);
        }

        public static void SetManHinhCaption(string formKey)
        {
            string caption = formFactory.GetFormCaption(formKey);
            frmMain.SetManHinhCaption(caption);
        }

        public static void SetTrangThaiCaption(string caption)
        {
            frmMain.SetTrangThaiCaption(caption);
        }
    }
}
