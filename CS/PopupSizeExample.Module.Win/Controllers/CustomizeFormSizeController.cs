using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Templates;
using PopupSizeExample.Module.BusinessObjects;

namespace PopupSizeExample.Module.Win.Controllers {
    public class CustomizeFormSizeController : WindowController {
        protected override void OnActivated() {
            base.OnActivated();
            //Subscribe to this or the XafApplication.CustomizeTemplate event from a Controller or other places to access the target window template.
            Window.TemplateChanged += Window_TemplateChanged;
        }
        private void Window_TemplateChanged(object sender, EventArgs e) {
            if(Window.Template is System.Windows.Forms.Form && Window.Template is ISupportStoreSettings) {
                //Handle this or the Form.HandleCreated/Load events for applying customizations AFTER the default XAF template settings were applied.
                ((ISupportStoreSettings)Window.Template).SettingsReloaded += OnFormReadyForCustomizations;
            }
        }
        private void OnFormReadyForCustomizations(object sender, EventArgs e) {
            if(YourCustomBusinessCondition(Window.View)) {
                //Here we are resizing the form based on the View object properties. You can also adjust other Form settings as well.
                ((System.Windows.Forms.Form)sender).Size = ((IFormSizeProvider)Window.View.CurrentObject).GetFormSize();
            }
        }
        private bool YourCustomBusinessCondition(View view) {
            return view != null && view.CurrentObject is IFormSizeProvider;
        }
        protected override void OnDeactivated() {
            Window.TemplateChanged -= Window_TemplateChanged;
            base.OnDeactivated();
        }
    }
}
