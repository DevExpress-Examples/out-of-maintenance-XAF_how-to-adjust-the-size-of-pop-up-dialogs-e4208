Imports System
Imports System.Collections.Generic
Imports System.Web.UI
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Web.Templates
Imports DevExpress.ExpressApp.Web.Controls
Imports DevExpress.ExpressApp.Web
Imports PopupSizeExample.Module.BusinessObjects
Imports System.Drawing

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
	Protected Sub PopupWindowControl_CustomizePopupWindowSize(ByVal sender As Object, ByVal e As CustomizePopupWindowSizeEventArgs)
		Dim window As PopupWindow
		Try
			window = e.FindPopupWindow(WebApplication.Instance)
		Catch e1 As ArgumentException
			Return
		End Try
		If window IsNot Nothing AndAlso window.View IsNot Nothing Then
			Dim currentObjectInPopup As PopupInfoDemoObject = TryCast(window.View.CurrentObject, PopupInfoDemoObject)
			Dim currentParentObject As PopupDemoObject = TryCast(View.CurrentObject, PopupDemoObject)
			If (currentParentObject IsNot Nothing) AndAlso (currentObjectInPopup IsNot Nothing) Then
				e.Size = currentParentObject.GetPopupSize()
				e.Handled = True
			End If
		End If
	End Sub
End Class