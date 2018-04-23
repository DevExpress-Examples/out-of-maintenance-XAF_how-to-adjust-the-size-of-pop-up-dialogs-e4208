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
		Private _width As Integer
		Public Property Width() As Integer
			Get
				Return _width
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Width", _width, value)
			End Set
		End Property
		Private _height As Integer
		Public Property Height() As Integer
			Get
				Return _height
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Height", _height, value)
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
