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
                var width = i * 40 + 600;
                var height = i * 20 + 400;
                DemoObject obj = ObjectSpace.FindObject<DemoObject>(
                    CriteriaOperator.Parse(
                    string.Format("Width = '{0}' and Height = '{1}'", width, height)));
                if (obj == null) {
                    obj = ObjectSpace.CreateObject<DemoObject>();
                    obj.Width = width;
                    obj.Height = height;
                }
            }
            ObjectSpace.CommitChanges();
        }
    }
}
