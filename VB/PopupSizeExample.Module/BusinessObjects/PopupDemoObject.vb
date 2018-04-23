Imports System
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports System.Drawing

Namespace PopupSizeExample.Module.BusinessObjects
	<DefaultClassOptions>
	Public Class PopupDemoObject
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private width_Renamed As Integer
		Public Property Width() As Integer
			Get
				Return width_Renamed
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Width", width_Renamed, value)
			End Set
		End Property
'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private height_Renamed As Integer
		Public Property Height() As Integer
			Get
				Return height_Renamed
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Height", height_Renamed, value)
			End Set
		End Property
		<Action(Caption := "Show Popup", SelectionDependencyType := MethodActionSelectionDependencyType.RequireSingleObject)>
		Public Sub ShowPopup(ByVal obj As PopupInfoDemoObject)
		End Sub
		Public Function GetPopupSize() As Size
			Return New Size(Width, Height)
		End Function
	End Class
	<DomainComponent>
	Public Class PopupInfoDemoObject
		Public Property Info() As String
	End Class
End Namespace
