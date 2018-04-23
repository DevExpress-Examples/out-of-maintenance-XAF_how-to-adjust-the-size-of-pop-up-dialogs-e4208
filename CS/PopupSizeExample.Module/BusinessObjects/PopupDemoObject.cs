using System;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.Drawing;

namespace PopupSizeExample.Module.BusinessObjects {
    [DefaultClassOptions]
    public class PopupDemoObject : BaseObject {
        public PopupDemoObject(Session session) : base(session) { }
        private int width;
        public int Width {
            get { return width; }
            set { SetPropertyValue("Width", ref width, value); }
        }
        private int height;
        public int Height {
            get { return height; }
            set { SetPropertyValue("Height", ref height, value); }
        }
        [Action(Caption = "Show Popup", SelectionDependencyType =
            MethodActionSelectionDependencyType.RequireSingleObject)]
        public void ShowPopup(PopupInfoDemoObject obj) { }
        public Size GetPopupSize() { return new Size(Width, Height); }
    }
    [DomainComponent]
    public class PopupInfoDemoObject {
        public string Info { get; set; }
    }
}
