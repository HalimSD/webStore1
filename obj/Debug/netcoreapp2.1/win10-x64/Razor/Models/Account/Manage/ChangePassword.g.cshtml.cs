#pragma checksum "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\ChangePassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a92cc76fa05e5c47201bf2b92bab396d3d304d19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Models_Account_Manage_ChangePassword), @"mvc.1.0.razor-page", @"/Models/Account/Manage/ChangePassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Models/Account/Manage/ChangePassword.cshtml", typeof(AspNetCore.Models_Account_Manage_ChangePassword), null)]
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
#line 1 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\_ViewImports.cshtml"
using WebApp1.Areas.Identity.Pages.Account;

#line default
#line hidden
#line 1 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\_ViewImports.cshtml"
using WebApp1.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a92cc76fa05e5c47201bf2b92bab396d3d304d19", @"/Models/Account/Manage/ChangePassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87bbdfa9d416decbea554eec34698177e01680d6", @"/Models/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"527b6c26c6e3adca82441b7d38b9f48ceb841834", @"/Models/Account/Manage/_ViewImports.cshtml")]
    public class Models_Account_Manage_ChangePassword : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\ChangePassword.cshtml"
  
    ViewData["Title"] = "Change password";

#line default
#line hidden
            BeginContext(86, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(93, 17, false);
#line 7 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\ChangePassword.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(110, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
            BeginContext(118, 51, false);
#line 8 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\ChangePassword.cshtml"
Write(Html.Partial("_StatusMessage", Model.StatusMessage));

#line default
#line hidden
            EndContext();
            BeginContext(169, 1169, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-6"">
        <form id=""change-password-form"" method=""post"">
            <div asp-validation-summary=""All"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Input.OldPassword""></label>
                <input asp-for=""Input.OldPassword"" class=""form-control"" />
                <span asp-validation-for=""Input.OldPassword"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Input.NewPassword""></label>
                <input asp-for=""Input.NewPassword"" class=""form-control"" />
                <span asp-validation-for=""Input.NewPassword"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Input.ConfirmPassword""></label>
                <input asp-for=""Input.ConfirmPassword"" class=""form-control"" />
                <span asp-validation-for=""Input.ConfirmPassword"" class=""text-danger""></span>");
            WriteLiteral("\r\n            </div>\r\n            <button type=\"submit\" class=\"btn btn-default\">Update password</button>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1356, 52, true);
                WriteLiteral("\r\n    <partial name=\"_ValidationScriptsPartial\" />\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChangePasswordModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ChangePasswordModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ChangePasswordModel>)PageContext?.ViewData;
        public ChangePasswordModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
