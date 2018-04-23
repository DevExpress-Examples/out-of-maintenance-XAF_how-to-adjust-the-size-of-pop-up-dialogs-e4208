Imports System
Imports System.Collections.Generic
Imports System.Web.UI
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Web.Templates
Imports DevExpress.ExpressApp.Web.Controls
Imports PopupSizeExample.Module.Web.Controllers

Partial Public Class [Default]
    Inherits BaseXafPage
    Implements IPopupWindowControlHolder

    Private ReadOnly Property IPopupWindowControlHolder_PopupWindowControl() As XafPopupWindowControl Implements IPopupWindowControlHolder.PopupWindowControl
        Get
            Return PopupWindowControl
        End Get
    End Property

    Protected Overrides Function CreateContextActionsMenu() As ContextActionsMenu
        Return New ContextActionsMenu(Me, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports")
    End Function

    Public Overrides ReadOnly Property InnerContentPlaceHolder() As Control
        Get
            Return Content
        End Get
    End Property
End Class