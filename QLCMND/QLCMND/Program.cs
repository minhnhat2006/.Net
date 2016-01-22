﻿using System;
using System.Windows.Forms;
using System.Threading;

namespace QLCMND
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
            Application.Run(new FrmHome());
        }
    }
}
