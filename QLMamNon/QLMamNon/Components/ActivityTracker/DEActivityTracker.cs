using System;
using System.Windows.Forms;
using System.Collections;
using ACG.Core.WinForm.Util;
using DevExpress.XtraEditors;
using ACG.Core.WinForm.ActivityObserver;
using QLMamNon.Components.ActivityTracker.ControlHandler;

namespace QLMamNon.Components.ActivityTracker
{
    public class DEActivityTracker : BaseActivityTracker
    {
        protected virtual void initControlHandlers()
        {
            controlHandlers.Add(new TextEditHandler());
            controlHandlers.Add(new ComboBoxEditHandler());
            controlHandlers.Add(new DateEditHandler());
            controlHandlers.Add(new SimpleButtonHandler());
        }
    }
}
