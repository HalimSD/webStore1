#pragma checksum "/Users/halim/hr/webStore1/Models/Account/LoginWithRecoveryCode.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e14bfb8bee76cf850fd2251a49bb3ccfdb5cd57d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Models_Account_LoginWithRecoveryCode), @"mvc.1.0.razor-page", @"/Models/Account/LoginWithRecoveryCode.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Models/Account/LoginWithRecoveryCode.cshtml", typeof(AspNetCore.Models_Account_LoginWithRecoveryCode), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e14bfb8bee76cf850fd2251a49bb3ccfdb5cd57d", @"/Models/Account/LoginWithRecoveryCode.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87bbdfa9d416decbea554eec34698177e01680d6", @"/Models/Account/_ViewImports.cshtml")]
    public class Models_Account_LoginWithRecoveryCode : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/Users/halim/hr/webStore1/Models/Account/LoginWithRecoveryCode.cshtml"
  
    ViewData["Title"] = "Recovery code verification";

#line default
#line hidden
            BeginContext(104, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(111, 17, false);
#line 7 "/Users/halim/hr/webStore1/Models/Account/LoginWithRecoveryCode.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(128, 781, true);
            WriteLiteral(@"</h2>
<hr />
<p>
    You have requested to log in with a recovery code. This login will not be remembered until you provide
    an authenticator app code at log in or disable 2FA and log in again.
</p>
<div class=""row"">
    <div class=""col-md-4"">
        <form method=""post"">
            <div asp-validation-summary=""All"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Input.RecoveryCode""></label>
                <input asp-for=""Input.RecoveryCode"" class=""form-control"" autocomplete=""off"" />
                <span asp-validation-for=""Input.RecoveryCode"" class=""text-danger""></span>
            </div>
            <button type=""submit"" class=""btn btn-default"">Log in</button>
        </form>
    </div>
</div>
 
");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(928, 52, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoginWithRecoveryCodeModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LoginWithRecoveryCodeModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LoginWithRecoveryCodeModel>)PageContext?.ViewData;
        public LoginWithRecoveryCodeModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
