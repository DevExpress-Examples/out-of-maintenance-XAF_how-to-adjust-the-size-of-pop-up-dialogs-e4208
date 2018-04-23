Imports System
Imports System.Collections.Generic
Imports System.Web.UI
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Web.Templates
Imports DevExpress.ExpressApp.Web.Controls
Imports DevExpress.ExpressApp.Web
Imports PopupSizeExample.Module.BusinessObjects
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports DevExpress.ExpressApp

Partial Public Class [Default]
    Inherits BaseXafPage

    Protected Overrides Function CreateContextActionsMenu() As ContextActionsMenu
        Return New ContextActionsMenu(Me, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports")
    End Function
    Public Overrides ReadOnly Property InnerContentPlaceHolder() As Control
        Get
            Return Content
        End Get
    End Property

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        AddHandler XafPopupWindowControl.CustomizePopupWindowSize, AddressOf PopupWindowControl_CustomizePopupWindowSize
        MyBase.OnLoad(e)
    End Sub

    Protected Sub PopupWindowControl_CustomizePopupWindowSize(ByVal sender As Object, ByVal e As CustomizePopupWindowSizeEventArgs)
        If e.ShowViewSource.SourceView.ObjectTypeInfo.Name = "DemoObject" Then
            Dim currentObjectInPopup As PopupInfoDemoObject = TryCast(e.PopupFrame.View.CurrentObject, PopupInfoDemoObject)
            Dim currentParentObject As DemoObject = TryCast(View.CurrentObject, DemoObject)
            If (currentParentObject IsNot Nothing) AndAlso (currentObjectInPopup IsNot Nothing) Then
                e.Height = New Unit(currentParentObject.Height)
                e.Width = New Unit(currentParentObject.Width)
                e.Handled = True
            End If
        End If
    End Sub
End Class