<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128587694/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4208)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomizeFormSizeController.cs](./CS/PopupSizeExample.Module.Win/Controllers/CustomizeFormSizeController.cs) (VB: [CustomizeFormSizeController.vb](./VB/PopupSizeExample.Module.Win/Controllers/CustomizeFormSizeController.vb))
* [DemoObject.cs](./CS/PopupSizeExample.Module/BusinessObjects/DemoObject.cs) (VB: [DemoObject.vb](./VB/PopupSizeExample.Module/BusinessObjects/DemoObject.vb))
* [Default.aspx.cs](./CS/PopupSizeExample.Web/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/PopupSizeExample.Web/Default.aspx.vb))
<!-- default file list end -->
# How to: Adjust the size of pop up dialogs
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4208)**
<!-- run online end -->


<p><strong>ASP.NET</strong><br>A complete description for the  ASP.NET version is available in the <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3456"><u>How to: Adjust the Size of Pop up Dialogs displayed in ASP.NET Applications</u></a> topic.</p>
<p><br><strong>WinForms</strong><br>Check out the <em>PopupSizeExample.Module.Win\Controllers\CustomizeFormSizeController.xx</em> file and code comments in it. See also the following product documentation:<br>    <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112683.aspx">Concepts</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112623.aspx">Extend Functionality</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112621.aspx">Controllers</a> <br>    <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressApp.aspx">DevExpress.ExpressApp</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppFrametopic.aspx">Frame</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppFrame_TemplateChangedtopic.aspx">TemplateChanged</a> <br>    <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressApp.aspx">DevExpress.ExpressApp</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppXafApplicationtopic.aspx">XafApplication</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppXafApplication_CustomizeTemplatetopic.aspx">CustomizeTemplate</a> <br>    <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppTemplates.aspx">DevExpress.ExpressApp.Templates</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppTemplatesISupportStoreSettingstopic.aspx">ISupportStoreSettings</a> > <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppTemplatesISupportStoreSettings_SettingsReloadedtopic.aspx">SettingsReloaded</a></p>
<p>Take special note that certain form templates (e.g., <a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112609">LookupForm, PopupForm, LookupControlTemplate</a>)  may have a minimum form size set by default (using the MinimumSize  property) or may calculate their size dynamically based on the content. So, if your custom size is ignored using the aforementioned method, you may want to research the source code for each required form template and adjust your default form settings accordingly.</p>

<br/>


