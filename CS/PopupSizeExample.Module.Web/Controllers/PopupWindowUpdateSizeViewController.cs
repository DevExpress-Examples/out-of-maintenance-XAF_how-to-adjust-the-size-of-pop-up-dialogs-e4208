using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web.Controls;
using System.Drawing;
using PopupSizeExample.Module.BusinessObjects;

namespace PopupSizeExample.Module.Web.Controllers {
    public class PopupWindowUpdateSizeViewController : ViewController {
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            if (WebWindow.CurrentRequestPage != null) {
                WebWindow.CurrentRequestPage.Load += new EventHandler(CurrentRequestPage_Load);
                WebWindow.CurrentRequestPage.Unload += new EventHandler(CurrentRequestPage_Unload);
            }
        }
        private void CurrentRequestPage_Load(object sender, EventArgs e) {
            IPopupWindowControlHolder holder = sender as IPopupWindowControlHolder;
            if (holder != null && holder.PopupWindowControl != null) {
                holder.PopupWindowControl.CustomizePopupWindowSize += 
                    PopupWindowControl_CustomizePopupControlSize;
            }
        }
        private void CurrentRequestPage_Unload(object sender, EventArgs e) {
            Page page = (Page)sender;
            page.Load -= CurrentRequestPage_Load;
            page.Unload -= CurrentRequestPage_Unload;
            IPopupWindowControlHolder holder = page as IPopupWindowControlHolder;
            if (holder != null && holder.PopupWindowControl != null) {
                holder.PopupWindowControl.CustomizePopupWindowSize -= 
                    PopupWindowControl_CustomizePopupControlSize;
            }
        }
        private void PopupWindowControl_CustomizePopupControlSize(object sender, CustomizePopupWindowSizeEventArgs e) {
            PopupWindow window;
            try { window = e.FindPopupWindow((WebApplication)Application); }
            catch (ArgumentException) { return; }
            if(window != null && window.View != null) {
                PopupInfoDemoObject currentObjectInPopup = window.View.CurrentObject as PopupInfoDemoObject;
                PopupDemoObject currentParentObject = View.CurrentObject as PopupDemoObject;
                if ((currentParentObject != null) && (currentObjectInPopup != null)) {
                    e.Size = new Size(currentParentObject.Width, currentParentObject.Height);
                    currentObjectInPopup.Info = string.Format("This popup size is {0}x{1}",
                        currentParentObject.Width, currentParentObject.Height);
                    e.Handled = true;
                }
            }
        }
    }
    public interface IPopupWindowControlHolder {
        XafPopupWindowControl PopupWindowControl { get; }
    }
}
