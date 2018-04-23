using System;
using System.Collections.Generic;
using System.Web.UI;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Web.Controls;
using DevExpress.ExpressApp.Web;
using PopupSizeExample.Module.BusinessObjects;
using System.Drawing;

public partial class Default : BaseXafPage {
    protected override ContextActionsMenu CreateContextActionsMenu() {
        return new ContextActionsMenu(this, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports");
    }
    public override Control InnerContentPlaceHolder {
        get {
            return Content;
        }
    }
    protected void PopupWindowControl_CustomizePopupWindowSize(object sender, CustomizePopupWindowSizeEventArgs e) {
        PopupWindow window;
        try { window = e.FindPopupWindow(WebApplication.Instance); }
        catch(ArgumentException) { return; }
        if(window != null && window.View != null) {
            PopupInfoDemoObject currentObjectInPopup = window.View.CurrentObject as PopupInfoDemoObject;
            PopupDemoObject currentParentObject = View.CurrentObject as PopupDemoObject;
            if((currentParentObject != null) && (currentObjectInPopup != null)) {
                e.Size = currentParentObject.GetPopupSize();
                e.Handled = true;
            }
        }
    }
}