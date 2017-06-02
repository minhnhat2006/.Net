using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using QLMamNon.Forms;
using QLMamNon.Forms.Resource;
using System.Collections.Generic;

namespace QLMamNon.Facade
{
    public static class FormMainFacade
    {
        private static IDictionary<string, string> formKeysToCaptions;

        private static FrmMain frmMain;

        private static FormFactory formFactory = new FormFactory();

        public static void InitFormMain(FrmMain formMain)
        {
            frmMain = formMain;
            formKeysToCaptions = new Dictionary<string, string>();
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

            if (formKeysToCaptions.ContainsKey(form))
            {
                string caption = formKeysToCaptions[form];
                SetStatusCaption(form, caption);
            }
        }

        public static void ShowDialog(string form)
        {
            Form frm = formFactory.GetForm(form);
            frm.ShowDialog();
            frm.Activate();
        }

        public static void ShowReport(XtraReport rpt)
        {
            ReportPrintTool printTool = new ReportPrintTool(rpt);
            printTool.ShowPreview();
        }

        public static void CloseForm(string form)
        {
            formFactory.RemoveForm(form);
        }

        public static void SetFormCaption(string formKey)
        {
            string caption = formFactory.GetFormCaption(formKey);
            frmMain.SetManHinhCaption(caption);
        }

        public static void SetStatusCaption(string formKey, string caption)
        {
            formKeysToCaptions.Remove(formKey);
            formKeysToCaptions.Add(formKey, caption);
            frmMain.SetTrangThaiCaption(caption);
        }
    }
}
