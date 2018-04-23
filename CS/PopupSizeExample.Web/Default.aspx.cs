using System;
using System.Collections.Generic;
using System.Web.UI;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Web.Controls;
using PopupSizeExample.Module.Web.Controllers;

public partial class Default : BaseXafPage, IPopupWindowControlHolder {
    XafPopupWindowControl IPopupWindowControlHolder.PopupWindowControl {
        get { return PopupWindowControl; }
    }

    protected override ContextActionsMenu CreateContextActionsMenu() {
        return new ContextActionsMenu(this, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports");
    }
    
    public override Control InnerContentPlaceHolder {
        get {
            return Content;
        }
    }
}