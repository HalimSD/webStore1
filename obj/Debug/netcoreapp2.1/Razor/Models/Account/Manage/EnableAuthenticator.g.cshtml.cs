#pragma checksum "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/EnableAuthenticator.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e98ca216e3f6d5b0d638d6b617a71b59d9c0cb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Models_Account_Manage_EnableAuthenticator), @"mvc.1.0.razor-page", @"/Models/Account/Manage/EnableAuthenticator.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Models/Account/Manage/EnableAuthenticator.cshtml", typeof(AspNetCore.Models_Account_Manage_EnableAuthenticator), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e98ca216e3f6d5b0d638d6b617a71b59d9c0cb8", @"/Models/Account/Manage/EnableAuthenticator.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87bbdfa9d416decbea554eec34698177e01680d6", @"/Models/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"527b6c26c6e3adca82441b7d38b9f48ceb841834", @"/Models/Account/Manage/_ViewImports.cshtml")]
    public class Models_Account_Manage_EnableAuthenticator : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/EnableAuthenticator.cshtml"
  
    ViewData["Title"] = "Configure authenticator app";
    ViewData["ActivePage"] = ManageNavPages.TwoFactorAuthentication;

#line default
#line hidden
            BeginContext(173, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(176, 51, false);
#line 8 "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/EnableAuthenticator.cshtml"
Write(Html.Partial("_StatusMessage", Model.StatusMessage));

#line default
#line hidden
            EndContext();
            BeginContext(227, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(234, 17, false);
#line 9 "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/EnableAuthenticator.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(251, 886, true);
            WriteLiteral(@"</h4>
<div>
    <p>To use an authenticator app go through the following steps:</p>
    <ol class=""list"">
        <li>
            <p>
                Download a two-factor authenticator app like Microsoft Authenticator for
                <a href=""https://go.microsoft.com/fwlink/?Linkid=825071"">Windows Phone</a>,
                <a href=""https://go.microsoft.com/fwlink/?Linkid=825072"">Android</a> and
                <a href=""https://go.microsoft.com/fwlink/?Linkid=825073"">iOS</a> or
                Google Authenticator for
                <a href=""https://play.google.com/store/apps/details?id=com.google.android.apps.authenticator2&amp;hl=en"">Android</a> and
                <a href=""https://itunes.apple.com/us/app/google-authenticator/id388497605?mt=8"">iOS</a>.
            </p>
        </li>
        <li>
            <p>Scan the QR Code or enter this key <kbd>");
            EndContext();
            BeginContext(1138, 15, false);
#line 25 "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/EnableAuthenticator.cshtml"
                                                  Write(Model.SharedKey);

#line default
#line hidden
            EndContext();
            BeginContext(1153, 335, true);
            WriteLiteral(@"</kbd> into your two factor authenticator app. Spaces and casing do not matter.</p>
            <div class=""alert alert-info"">To enable QR code generation please read our <a href=""https://go.microsoft.com/fwlink/?Linkid=852423"">documentation</a>.</div>
            <div id=""qrCode""></div>
            <div id=""qrCodeData"" data-url=""");
            EndContext();
            BeginContext(1489, 32, false);
#line 28 "/Users/halim/hr/2de/proj5/van/webStore1/Models/Account/Manage/EnableAuthenticator.cshtml"
                                      Write(Html.Raw(Model.AuthenticatorUri));

#line default
#line hidden
            EndContext();
            BeginContext(1521, 1067, true);
            WriteLiteral(@"""></div>
        </li>
        <li>
            <p>
                Once you have scanned the QR code or input the key above, your two factor authentication app will provide you
                with a unique code. Enter the code in the confirmation box below.
            </p>
            <div class=""row"">
                <div class=""col-md-6"">
                    <form method=""post"">
                        <div class=""form-group"">
                            <label asp-for=""Input.Code"" class=""control-label"">Verification Code</label>
                            <input asp-for=""Input.Code"" class=""form-control"" autocomplete=""off"" />
                            <span asp-validation-for=""Input.Code"" class=""text-danger""></span>
                        </div>
                        <button type=""submit"" class=""btn btn-default"">Verify</button>
                        <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
                    </form>
                </div>
            <");
            WriteLiteral("/div>\r\n        </li>\r\n    </ol>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2606, 52, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EnableAuthenticatorModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EnableAuthenticatorModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EnableAuthenticatorModel>)PageContext?.ViewData;
        public EnableAuthenticatorModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591