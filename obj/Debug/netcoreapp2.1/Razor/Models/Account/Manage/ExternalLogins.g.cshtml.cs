#pragma checksum "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01c233da89416e9a29b89bb775e7d02dc5f97bab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Models_Account_Manage_ExternalLogins), @"mvc.1.0.razor-page", @"/Models/Account/Manage/ExternalLogins.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Models/Account/Manage/ExternalLogins.cshtml", typeof(AspNetCore.Models_Account_Manage_ExternalLogins), null)]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/halim/hr/webStore1/Models/Account/_ViewImports.cshtml"
using WebApp1.Areas.Identity.Pages.Account;

#line default
#line hidden
#line 1 "/Users/halim/hr/webStore1/Models/Account/Manage/_ViewImports.cshtml"
using WebApp1.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01c233da89416e9a29b89bb775e7d02dc5f97bab", @"/Models/Account/Manage/ExternalLogins.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87bbdfa9d416decbea554eec34698177e01680d6", @"/Models/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"527b6c26c6e3adca82441b7d38b9f48ceb841834", @"/Models/Account/Manage/_ViewImports.cshtml")]
    public class Models_Account_Manage_ExternalLogins : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
  
    ViewData["Title"] = "Manage your external logins";

#line default
#line hidden
            BeginContext(98, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(101, 51, false);
#line 7 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
Write(Html.Partial("_StatusMessage", Model.StatusMessage));

#line default
#line hidden
            EndContext();
            BeginContext(152, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
 if (Model.CurrentLogins?.Count > 0)
{

#line default
#line hidden
            BeginContext(195, 76, true);
            WriteLiteral("    <h4>Registered Logins</h4>\r\n    <table class=\"table\">\r\n        <tbody>\r\n");
            EndContext();
#line 13 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
             foreach (var login in Model.CurrentLogins)
            {

#line default
#line hidden
            BeginContext(343, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(390, 19, false);
#line 16 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
                   Write(login.LoginProvider);

#line default
#line hidden
            EndContext();
            BeginContext(409, 33, true);
            WriteLiteral("</td>\r\n                    <td>\r\n");
            EndContext();
#line 18 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
                         if (Model.ShowRemoveButton)
                        {

#line default
#line hidden
            BeginContext(523, 168, true);
            WriteLiteral("                        <form id=\"remove-login\" asp-page-handler=\"RemoveLogin\" method=\"post\">\r\n                            <div>\r\n                                <input");
            EndContext();
            BeginWriteAttribute("asp-for", " asp-for=\"", 691, "\"", 721, 1);
#line 22 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
WriteAttributeValue("", 701, login.LoginProvider, 701, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(722, 78, true);
            WriteLiteral(" name=\"LoginProvider\" type=\"hidden\" />\r\n                                <input");
            EndContext();
            BeginWriteAttribute("asp-for", " asp-for=\"", 800, "\"", 828, 1);
#line 23 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
WriteAttributeValue("", 810, login.ProviderKey, 810, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(829, 115, true);
            WriteLiteral(" name=\"ProviderKey\" type=\"hidden\" />\r\n                                <button type=\"submit\" class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 944, "\"", 1008, 7);
            WriteAttributeValue("", 952, "Remove", 952, 6, true);
            WriteAttributeValue(" ", 958, "this", 959, 5, true);
#line 24 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
WriteAttributeValue(" ", 963, login.LoginProvider, 964, 20, false);

#line default
#line hidden
            WriteAttributeValue(" ", 984, "login", 985, 6, true);
            WriteAttributeValue(" ", 990, "from", 991, 5, true);
            WriteAttributeValue(" ", 995, "your", 996, 5, true);
            WriteAttributeValue(" ", 1000, "account", 1001, 8, true);
            EndWriteAttribute();
            BeginContext(1009, 87, true);
            WriteLiteral(">Remove</button>\r\n                            </div>\r\n                        </form>\r\n");
            EndContext();
#line 27 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1180, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(1206, 9, true);
            WriteLiteral(" &nbsp;\r\n");
            EndContext();
#line 31 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
                        }

#line default
#line hidden
            BeginContext(1242, 50, true);
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 34 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
            }

#line default
#line hidden
            BeginContext(1307, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 37 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
}

#line default
#line hidden
#line 38 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
 if (Model.OtherLogins?.Count > 0)
{

#line default
#line hidden
            BeginContext(1381, 210, true);
            WriteLiteral("    <h4>Add another service to log in.</h4>\r\n    <hr />\r\n    <form id=\"link-login-form\" asp-page-handler=\"LinkLogin\" method=\"post\" class=\"form-horizontal\">\r\n        <div id=\"socialLoginList\">\r\n            <p>\r\n");
            EndContext();
#line 45 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
                 foreach (var provider in Model.OtherLogins)
                {

#line default
#line hidden
            BeginContext(1672, 104, true);
            WriteLiteral("                    <button id=\"link-login-button\" type=\"submit\" class=\"btn btn-default\" name=\"provider\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1776, "\"", 1798, 1);
#line 47 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
WriteAttributeValue("", 1784, provider.Name, 1784, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 1799, "\"", 1854, 6);
            WriteAttributeValue("", 1807, "Log", 1807, 3, true);
            WriteAttributeValue(" ", 1810, "in", 1811, 3, true);
            WriteAttributeValue(" ", 1813, "using", 1814, 6, true);
            WriteAttributeValue(" ", 1819, "your", 1820, 5, true);
#line 47 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
WriteAttributeValue(" ", 1824, provider.DisplayName, 1825, 21, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1846, "account", 1847, 8, true);
            EndWriteAttribute();
            BeginContext(1855, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1857, 20, false);
#line 47 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
                                                                                                                                                                                   Write(provider.DisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(1877, 11, true);
            WriteLiteral("</button>\r\n");
            EndContext();
#line 48 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
                }

#line default
#line hidden
            BeginContext(1907, 47, true);
            WriteLiteral("            </p>\r\n        </div>\r\n    </form>\r\n");
            EndContext();
#line 52 "/Users/halim/hr/webStore1/Models/Account/Manage/ExternalLogins.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExternalLoginsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ExternalLoginsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ExternalLoginsModel>)PageContext?.ViewData;
        public ExternalLoginsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
