Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security
Imports PopupSizeExample.Module.BusinessObjects

Namespace PopupSizeExample.Module.DatabaseUpdate
	Public Class Updater
		Inherits ModuleUpdater

		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			For i As Byte = 0 To 10
				Dim width = i * 40 + 400
				Dim height = i * 20 + 200
				Dim obj As PopupDemoObject = ObjectSpace.FindObject(Of PopupDemoObject)(CriteriaOperator.Parse(String.Format("Width = '{0}' and Height = '{1}'", width, height)))
				If obj Is Nothing Then
					obj = ObjectSpace.CreateObject(Of PopupDemoObject)()
					obj.Width = width
					obj.Height = height
				End If
			Next i
		End Sub
	End Class
End Namespace
