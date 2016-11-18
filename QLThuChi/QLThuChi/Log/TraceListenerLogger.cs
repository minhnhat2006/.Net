using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace QLThuChi.Log
{
    public class TraceListenerLogger
    {
        public static void Error(string message)
        {
            WriteEntry(message, "error");
        }

        public static void Error(Exception ex)
        {
            WriteEntry(string.Format("{0}\n{1}", ex.Message, ex.StackTrace), "error");
        }

        public static void Warning(string message)
        {
            WriteEntry(message, "warning");
        }

        public static void Info(string message)
        {
            WriteEntry(message, "info");
        }

        private static void WriteEntry(string message, string type)
        {
            Trace.WriteLine(
                    string.Format("{0} {1} : {2}",
                                  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                  type,
                                  message));
        }
    }
}
