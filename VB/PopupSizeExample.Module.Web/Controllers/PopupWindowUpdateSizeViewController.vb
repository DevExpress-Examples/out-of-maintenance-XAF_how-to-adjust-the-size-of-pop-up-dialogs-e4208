Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Web.Controls
Imports System.Drawing
Imports PopupSizeExample.Module.BusinessObjects

Namespace PopupSizeExample.Module.Web.Controllers
	Public Class PopupWindowUpdateSizeViewController
		Inherits ViewController
		Protected Overrides Sub OnViewControlsCreated()
			MyBase.OnViewControlsCreated()
			If WebWindow.CurrentRequestPage IsNot Nothing Then
				AddHandler WebWindow.CurrentRequestPage.Load, AddressOf CurrentRequestPage_Load
				AddHandler WebWindow.CurrentRequestPage.Unload, AddressOf CurrentRequestPage_Unload
			End If
		End Sub
		Private Sub CurrentRequestPage_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim holder As IPopupWindowControlHolder = TryCast(sender, IPopupWindowControlHolder)
			If holder IsNot Nothing AndAlso holder.PopupWindowControl IsNot Nothing Then
				AddHandler holder.PopupWindowControl.CustomizePopupWindowSize, AddressOf PopupWindowControl_CustomizePopupControlSize
			End If
		End Sub
		Private Sub CurrentRequestPage_Unload(ByVal sender As Object, ByVal e As EventArgs)
			Dim page As Page = CType(sender, Page)
			RemoveHandler page.Load, AddressOf CurrentRequestPage_Load
			RemoveHandler page.Unload, AddressOf CurrentRequestPage_Unload
			Dim holder As IPopupWindowControlHolder = TryCast(page, IPopupWindowControlHolder)
			If holder IsNot Nothing AndAlso holder.PopupWindowControl IsNot Nothing Then
				RemoveHandler holder.PopupWindowControl.CustomizePopupWindowSize, AddressOf PopupWindowControl_CustomizePopupControlSize
			End If
		End Sub
		Private Sub PopupWindowControl_CustomizePopupControlSize(ByVal sender As Object, ByVal e As CustomizePopupWindowSizeEventArgs)
			Dim window As PopupWindow
			Try
 			       window = e.FindPopupWindow(CType(Application, WebApplication))
    			Catch e1 As ArgumentException
                       			 Return
			End Try
			If window IsNot Nothing AndAlso window.View IsNot Nothing Then
				Dim currentObjectInPopup As PopupInfoDemoObject = TryCast(window.View.CurrentObject, PopupInfoDemoObject)
				Dim currentParentObject As PopupDemoObject = TryCast(View.CurrentObject, PopupDemoObject)
				If (currentParentObject IsNot Nothing) AndAlso (currentObjectInPopup IsNot Nothing) Then
					e.Size = New Size(currentParentObject.Width, currentParentObject.Height)
					currentObjectInPopup.Info = String.Format("This popup size is {0}x{1}", currentParentObject.Width, currentParentObject.Height)
					e.Handled = True
				End If
			End If
		End Sub
	End Class
	Public Interface IPopupWindowControlHolder
		ReadOnly Property PopupWindowControl() As XafPopupWindowControl
	End Interface
End Namespace
