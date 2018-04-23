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
    <DefaultClassOptions>
    Public Class DemoObject
        Inherits BaseObject
        Implements IFormSizeProvider

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private _width As Integer
        Public Property Width() As Integer
            Get
                Return _width
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("Width", _width, value)
            End Set
        End Property
'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private _height As Integer
        Public Property Height() As Integer
            Get
                Return _height
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("Height", _height, value)
            End Set
        End Property
        Public Function GetFormSize() As Size Implements IFormSizeProvider.GetFormSize
            Return New Size(Width, Height)
        End Function
        <Size(-1)>
        Public ReadOnly Property Info() As String
            Get
                Return "The form must be sized according to the Width and Height properties when this object is displayed in a standalone form, e.g. in WinForms with UIType=MultipleWindowSDI"
            End Get
        End Property
    End Class
    <DomainComponent>
    Public Class PopupInfoDemoObject
        Implements IFormSizeProvider

        Public Sub New(ByVal parent As DemoObject)
            Me.Parent = parent
        End Sub
        <FieldSize(-1)>
        Public ReadOnly Property Info() As String
            Get
                Return "In both WinForms and ASP.NET, the form must be sized according to the Width and Height properties of the parent object"
            End Get
        End Property
        Private privateParent As DemoObject
        <Browsable(False)>
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
'INSTANT VB NOTE: The variable objectSpace was renamed since Visual Basic does not handle local variables named the same as class members well:
                Dim _objectSpace As IObjectSpace = e.Application.CreateObjectSpace(GetType(PopupInfoDemoObject))
                Dim detailView As DetailView = e.Application.CreateDetailView(_objectSpace, New PopupInfoDemoObject(ViewCurrentObject))
                detailView.ViewEditMode = ViewEditMode.Edit
                e.View = detailView
            End Sub
        End Sub
    End Class
End Namespace
