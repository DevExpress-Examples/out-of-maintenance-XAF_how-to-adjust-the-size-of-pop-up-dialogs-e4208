using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using PopupSizeExample.Module.BusinessObjects;

namespace PopupSizeExample.Module.DatabaseUpdate {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            for (byte i = 0; i <= 10; i++) {
                var width = i * 40 + 400;
                var height = i * 20 + 200;
                PopupDemoObject obj = ObjectSpace.FindObject<PopupDemoObject>(
                    CriteriaOperator.Parse(
                    string.Format("Width = '{0}' and Height = '{1}'", width, height)));
                if (obj == null) {
                    obj = ObjectSpace.CreateObject<PopupDemoObject>();
                    obj.Width = width;
                    obj.Height = height;
                }
            }
        }
    }
}
