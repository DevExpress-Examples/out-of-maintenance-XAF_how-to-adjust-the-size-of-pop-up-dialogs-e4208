Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Templates
Imports PopupSizeExample.Module.BusinessObjects

Namespace PopupSizeExample.Module.Win.Controllers
    Public Class CustomizeFormSizeController
        Inherits WindowController

        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            'Subscribe to this or the XafApplication.CustomizeTemplate event from a Controller or other places to access the target window template.
            AddHandler Window.TemplateChanged, AddressOf Window_TemplateChanged
        End Sub
        Private Sub Window_TemplateChanged(ByVal sender As Object, ByVal e As EventArgs)
            If TypeOf Window.Template Is System.Windows.Forms.Form AndAlso TypeOf Window.Template Is ISupportStoreSettings Then
                'Handle this or the Form.HandleCreated/Load events for applying customizations AFTER the default XAF template settings were applied.
                AddHandler DirectCast(Window.Template, ISupportStoreSettings).SettingsReloaded, AddressOf OnFormReadyForCustomizations
            End If
        End Sub
        Private Sub OnFormReadyForCustomizations(ByVal sender As Object, ByVal e As EventArgs)
            If YourCustomBusinessCondition(Window.View) Then
                'Here we are resizing the form based on the View object properties. You can also adjust other Form settings as well.
                DirectCast(sender, System.Windows.Forms.Form).Size = DirectCast(Window.View.CurrentObject, IFormSizeProvider).GetFormSize()
            End If
        End Sub
        Private Function YourCustomBusinessCondition(ByVal view As View) As Boolean
            Return view IsNot Nothing AndAlso TypeOf view.CurrentObject Is IFormSizeProvider
        End Function
        Protected Overrides Sub OnDeactivated()
            RemoveHandler Window.TemplateChanged, AddressOf Window_TemplateChanged
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace
