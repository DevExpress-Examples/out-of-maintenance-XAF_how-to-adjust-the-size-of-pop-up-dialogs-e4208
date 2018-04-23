using System;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Templates;
using PopupSizeExample.Module.BusinessObjects;

namespace PopupSizeExample.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
#if EASYTEST
			DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register();
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            PopupSizeExampleWindowsFormsApplication winApplication = new PopupSizeExampleWindowsFormsApplication();
            winApplication.CustomizeTemplate += new EventHandler<CustomizeTemplateEventArgs>(winApplication_CustomizeTemplate);
            // Refer to the http://documentation.devexpress.com/#Xaf/CustomDocument2680 help article for more details on how to provide a custom splash form.
            //winApplication.SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen("YourSplashImage.png");
#if EASYTEST
			if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
				winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
			}
#endif
            if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            try {
                winApplication.Setup();
                winApplication.Start();
            }
            catch(Exception e) {
                winApplication.HandleException(e);
            }
        }
        static void winApplication_CustomizeTemplate(object sender, CustomizeTemplateEventArgs args) {
            XafApplication app = (XafApplication)sender;
            if(args.Context == TemplateContext.PopupWindow && args.Template is ISupportViewChanged) {
                ((ISupportViewChanged)args.Template).ViewChanged += (s, e) => { // This event is handled just for demo purposes to make the template size dependent on the current View object.
                    Form templateForm = ((Form)args.Template);
                    templateForm.HandleCreated += (s1, e1) => { // In WinForms handle this event to customize the form when it is initialized.
                        if((e.View != null) && (e.View.CurrentObject is PopupInfoDemoObject) && (app.MainWindow.View !=null) && (app.MainWindow.View.CurrentObject is PopupDemoObject)) {
                            templateForm.Size = ((PopupDemoObject)app.MainWindow.View.CurrentObject).GetPopupSize();
                        }
                    };
                };
            }
        }
    }
}
