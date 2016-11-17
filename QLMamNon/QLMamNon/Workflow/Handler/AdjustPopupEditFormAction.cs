using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using QLMamNon.Facade;
using QLMamNon.Forms.HocSinh;
using DevExpress.XtraGrid.Views.BandedGrid;


namespace QLMamNon.Workflow.Handler
{
    public class AdjustPopupEditFormAction : ACG.Core.WinForm.Mediator.Action
    {
        #region Properties

        protected Dictionary<string, string> EDIT_FORM_BUTTON_CAPTION_MAP = new Dictionary<string, string>
            {
                {"Update", "Lưu"},
                {"Cancel", "Hủy"}
            };

        protected Dictionary<string, string> EDIT_FORM_BUTTON_CAPTION_TO_IMAGE_MAP = new Dictionary<string, string>
            {
                {"Update", "btnLuu.Image"},
                {"Cancel", "btnHuyBo.Image"}
            };

        #endregion

        public void gvMain_ShowingPopupEditForm(object sender, DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThongTinHocSinh));

            foreach (Control control in e.EditForm.Controls)
            {
                if (control is EditFormContainer)
                {
                    foreach (Control nestedControl in control.Controls)
                    {
                        if (nestedControl is PanelControl)
                        {
                            foreach (Control button in nestedControl.Controls)
                                if (button is SimpleButton)
                                {
                                    SimpleButton simpleButton = button as SimpleButton;

                                    if (!EDIT_FORM_BUTTON_CAPTION_TO_IMAGE_MAP.ContainsKey(simpleButton.Text))
                                    {
                                        return;
                                    }

                                    simpleButton.Image = ((System.Drawing.Image)(resources.GetObject(EDIT_FORM_BUTTON_CAPTION_TO_IMAGE_MAP[simpleButton.Text])));
                                    simpleButton.Text = EDIT_FORM_BUTTON_CAPTION_MAP[simpleButton.Text];

                                    ActivityTrackerFacade.InitActivityTracker(e.EditForm);
                                }
                        }
                    }
                }
            }
        }

        public override void Receive(object from, object message)
        {
            BandedGridView gv = message as BandedGridView;
            gv.ShowingPopupEditForm += new DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventHandler(this.gvMain_ShowingPopupEditForm);
        }
    }
}
