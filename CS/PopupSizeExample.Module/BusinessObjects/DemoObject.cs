using DevExpress.Xpo;
using System.Drawing;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using System.ComponentModel;

namespace PopupSizeExample.Module.BusinessObjects {
    public interface IFormSizeProvider {
        Size GetFormSize();
    }
    [DefaultClassOptions]
    public class DemoObject : BaseObject, IFormSizeProvider {
        public DemoObject(Session session) : base(session) { }
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
        public Size GetFormSize() { return new Size(Width, Height); }
        [Size(-1)]
        public string Info { get { return "The form must be sized according to the Width and Height properties when this object is displayed in a standalone form, e.g. in WinForms with UIType=MultipleWindowSDI"; } }
    }
    [DomainComponent]
    public class PopupInfoDemoObject : IFormSizeProvider {
        public PopupInfoDemoObject(DemoObject parent) {
            this.Parent = parent;
        }
        [FieldSize(-1)]
        public string Info { get { return "In both WinForms and ASP.NET, the form must be sized according to the Width and Height properties of the parent object"; } }
        [Browsable(false)]
        public DemoObject Parent { get; private set; }
        public Size GetFormSize() { return Parent != null ? Parent.GetFormSize() : Size.Empty; }
    }
    public class ShowPopupViewController : ObjectViewController<ObjectView, DemoObject> {
        public ShowPopupViewController() {
            new PopupWindowShowAction(this, "ShowPopup", PredefinedCategory.View).CustomizePopupWindowParams += (s, e) => {
                IObjectSpace objectSpace = e.Application.CreateObjectSpace(typeof(PopupInfoDemoObject));
                DetailView detailView = e.Application.CreateDetailView(objectSpace, new PopupInfoDemoObject(ViewCurrentObject));
                detailView.ViewEditMode = ViewEditMode.Edit;
                e.View = detailView;
            };
        }
    }
}
