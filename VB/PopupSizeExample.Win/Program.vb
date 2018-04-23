Imports System
Imports System.Configuration
Imports System.Windows.Forms
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Templates
Imports PopupSizeExample.Module.BusinessObjects

Namespace PopupSizeExample.Win
	Friend NotInheritable Class Program

		Private Sub New()
		End Sub

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Shared Sub Main()
#If EASYTEST Then
			DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register()
#End If

			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
			Dim winApplication As New PopupSizeExampleWindowsFormsApplication()
			AddHandler winApplication.CustomizeTemplate, AddressOf winApplication_CustomizeTemplate
			' Refer to the http://documentation.devexpress.com/#Xaf/CustomDocument2680 help article for more details on how to provide a custom splash form.
			'winApplication.SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen("YourSplashImage.png");
#If EASYTEST Then
			If ConfigurationManager.ConnectionStrings("EasyTestConnectionString") IsNot Nothing Then
				winApplication.ConnectionString = ConfigurationManager.ConnectionStrings("EasyTestConnectionString").ConnectionString
			End If
#End If
			If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
				winApplication.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
			End If
			Try
				winApplication.Setup()
				winApplication.Start()
			Catch e As Exception
				winApplication.HandleException(e)
			End Try
		End Sub
		Private Shared Sub winApplication_CustomizeTemplate(ByVal sender As Object, ByVal args As CustomizeTemplateEventArgs)
			Dim app As XafApplication = DirectCast(sender, XafApplication)
			If args.Context = TemplateContext.PopupWindow AndAlso TypeOf args.Template Is ISupportViewChanged Then
                ' This event is handled just for demo purposes to make the template size dependent on the current View object.
				AddHandler DirectCast(args.Template, ISupportViewChanged).ViewChanged, Sub(s, e) 
					Dim templateForm As Form = (DirectCast(args.Template, Form))
                    ' In WinForms handle this event to customize the form when it is initialized.
					AddHandler templateForm.HandleCreated, Sub(s1, e1) 
						If (e.View IsNot Nothing) AndAlso (TypeOf e.View.CurrentObject Is PopupInfoDemoObject) AndAlso (app.MainWindow.View IsNot Nothing) AndAlso (TypeOf app.MainWindow.View.CurrentObject Is PopupDemoObject) Then
							templateForm.Size = DirectCast(app.MainWindow.View.CurrentObject, PopupDemoObject).GetPopupSize()
						End If
					End Sub
				End Sub
			End If
		End Sub
	End Class
End Namespace
