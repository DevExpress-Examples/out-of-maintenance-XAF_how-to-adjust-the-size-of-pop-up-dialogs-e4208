Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base

Namespace PopupSizeExample.Module.BusinessObjects
	<DefaultClassOptions> _
	Public Class PopupDemoObject
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private width_Renamed As Integer
		Public Property Width() As Integer
			Get
				Return width_Renamed
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Width", width_Renamed, value)
			End Set
		End Property
		Private height_Renamed As Integer
		Public Property Height() As Integer
			Get
				Return height_Renamed
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Height", height_Renamed, value)
			End Set
		End Property
		<Action(Caption:= "Show Popup", SelectionDependencyType := MethodActionSelectionDependencyType.RequireSingleObject)> _
		Public Sub ShowPopup(ByVal obj As PopupInfoDemoObject)
		End Sub
	End Class
	<NonPersistent> _
	Public Class PopupInfoDemoObject
		Private privateInfo As String
		Public Property Info() As String
			Get
				Return privateInfo
			End Get
			Set(ByVal value As String)
				privateInfo = value
			End Set
		End Property
	End Class
End Namespace
