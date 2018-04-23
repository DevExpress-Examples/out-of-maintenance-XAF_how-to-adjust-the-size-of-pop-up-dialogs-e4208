Imports DevExpress.Xpo
Imports System.Drawing
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports System.ComponentModel

Namespace PopupSizeExample.Module.BusinessObjects
    Public Interface IFormSizeProvider
        Function GetFormSize() As Size
    End Interface
    <DefaultClassOptions> _
    Public Class DemoObject
        Inherits BaseObject
        Implements IFormSizeProvider

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
        Public Function GetFormSize() As Size Implements IFormSizeProvider.GetFormSize
            Return New Size(Width, Height)
        End Function
        <Size(-1)> _
        Public ReadOnly Property Info() As String
            Get
                Return "The form must be sized according to the Width and Height properties when this object is displayed in a standalone form, e.g. in WinForms with UIType=MultipleWindowSDI"
            End Get
        End Property
    End Class
    <DomainComponent> _
    Public Class PopupInfoDemoObject
        Implements IFormSizeProvider

        Public Sub New(ByVal parent As DemoObject)
            Me.Parent = parent
        End Sub
        <FieldSize(-1)> _
        Public ReadOnly Property Info() As String
            Get
                Return "In both WinForms and ASP.NET, the form must be sized according to the Width and Height properties of the parent object"
            End Get
        End Property
        Private privateParent As DemoObject
        <Browsable(False)> _
        Public Property Parent() As DemoObject
            Get
                Return privateParent
            End Get
            Private Set(ByVal value As DemoObject)
                privateParent = value
            End Set
        End Property
        Public Function GetFormSize() As Size Implements IFormSizeProvider.GetFormSize
            Return If(Parent IsNot Nothing, Parent.GetFormSize(), Size.Empty)
        End Function
    End Class
    Public Class ShowPopupViewController
        Inherits ObjectViewController(Of ObjectView, DemoObject)

        Public Sub New()
            AddHandler CType(New PopupWindowShowAction(Me, "ShowPopup", PredefinedCategory.View), PopupWindowShowAction).CustomizePopupWindowParams, Sub(s, e)
                Dim objectSpace As IObjectSpace = e.Application.CreateObjectSpace(GetType(PopupInfoDemoObject))
                Dim detailView As DetailView = e.Application.CreateDetailView(objectSpace, New PopupInfoDemoObject(ViewCurrentObject))
                detailView.ViewEditMode = ViewEditMode.Edit
                e.View = detailView
            End Sub
        End Sub
    End Class
End Namespace
