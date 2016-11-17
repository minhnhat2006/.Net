using System;
using System.Windows.Forms;
using ACG.Core.WinForm.ActivityObserver;
using ACG.Core.WinForm.ActivityObserver.ControlHandler;
using ACG.Core.WinForm.Util;
using DevExpress.XtraEditors;

namespace QLMamNon.Components.ActivityTracker.ControlHandler
{
    public class SimpleButtonHandler : ButtonHandler
    {
        protected virtual bool isControlNeedTrack(Control c)
        {
            return (c is SimpleButton);
        }

        protected void onClick(object sender, EventArgs e)
        {
            Control c = sender as Control;
            string controlName = ControlUtil.GetFullNameOfControl(c);

            foreach (object item in ActivityObservers)
            {
                (item as IActivityObserver).fire(controlName, sender, ActivityType.ButtonClick);
            }
        }
    }
}
