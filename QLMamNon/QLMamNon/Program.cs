using System;
using System.Threading;
using System.Windows.Forms;
using QLMamNon.Forms;
using System.Drawing;

namespace QLMamNon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN");
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Times New Roman", 12);
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = new Font("Times New Roman", 12);
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultPrintFont = new Font("Times New Roman", 12);
            Application.Run(new FrmMain());
        }
    }
}
