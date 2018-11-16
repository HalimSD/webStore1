#pragma checksum "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/SetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "290b6cd8010ffdddbe2b5bfb489c93a67bcef7ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Models_Account_Manage_SetPassword), @"mvc.1.0.razor-page", @"/Models/Account/Manage/SetPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Models/Account/Manage/SetPassword.cshtml", typeof(AspNetCore.Models_Account_Manage_SetPassword), null)]
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
#line 1 "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/_ViewImports.cshtml"
using WebApp1.Areas.Identity.Pages.Account;

#line default
#line hidden
#line 1 "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/_ViewImports.cshtml"
using WebApp1.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"290b6cd8010ffdddbe2b5bfb489c93a67bcef7ee", @"/Models/Account/Manage/SetPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87bbdfa9d416decbea554eec34698177e01680d6", @"/Models/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"527b6c26c6e3adca82441b7d38b9f48ceb841834", @"/Models/Account/Manage/_ViewImports.cshtml")]
    public class Models_Account_Manage_SetPassword : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/SetPassword.cshtml"
  
    ViewData["Title"] = "Set password";
    ViewData["ActivePage"] = ManageNavPages.ChangePassword;

#line default
#line hidden
            BeginContext(141, 30, true);
            WriteLiteral("\r\n<h4>Set your password</h4>\r\n");
            EndContext();
            BeginContext(172, 51, false);
#line 9 "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/SetPassword.cshtml"
Write(Html.Partial("_StatusMessage", Model.StatusMessage));

#line default
#line hidden
            EndContext();
            BeginContext(223, 1039, true);
            WriteLiteral(@"
<p class=""text-info"">
    You do not have a local username/password for this site. Add a local
    account so you can log in without an external login.
</p>
<div class=""row"">
    <div class=""col-md-6"">
        <form id=""set-password-form"" method=""post"">
            <div asp-validation-summary=""All"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Input.NewPassword""></label>
                <input asp-for=""Input.NewPassword"" class=""form-control"" />
                <span asp-validation-for=""Input.NewPassword"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Input.ConfirmPassword""></label>
                <input asp-for=""Input.ConfirmPassword"" class=""form-control"" />
                <span asp-validation-for=""Input.ConfirmPassword"" class=""text-danger""></span>
            </div>
            <button type=""submit"" class=""btn btn-default"">Set password</button>
        </form>
    </d");
            WriteLiteral("iv>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1280, 52, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SetPasswordModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SetPasswordModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SetPasswordModel>)PageContext?.ViewData;
        public SetPasswordModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
