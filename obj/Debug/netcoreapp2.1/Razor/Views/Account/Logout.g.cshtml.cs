#pragma checksum "/Users/halim/Desktop/ha/webStore1/Views/Account/Logout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52972a1be552db71da2778ee2f98f570662fcd33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Logout), @"mvc.1.0.razor-page", @"/Views/Account/Logout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Views/Account/Logout.cshtml", typeof(AspNetCore.Views_Account_Logout), null)]
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
#line 1 "/Users/halim/Desktop/ha/webStore1/Views/_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#line 2 "/Users/halim/Desktop/ha/webStore1/Views/_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
#line 1 "/Users/halim/Desktop/ha/webStore1/Views/Account/_ViewImports.cshtml"
using WebApp1.Areas.Identity.Pages.Account;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52972a1be552db71da2778ee2f98f570662fcd33", @"/Views/Account/Logout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87bbdfa9d416decbea554eec34698177e01680d6", @"/Views/Account/_ViewImports.cshtml")]
    public class Views_Account_Logout : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/Users/halim/Desktop/ha/webStore1/Views/Account/Logout.cshtml"
  
    ViewData["Title"] = "Log out";

#line default
#line hidden
            BeginContext(65, 18, true);
            WriteLiteral("\n<header>\n    <h1>");
            EndContext();
            BeginContext(84, 17, false);
#line 8 "/Users/halim/Desktop/ha/webStore1/Views/Account/Logout.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(101, 79, true);
            WriteLiteral("</h1>\n    <p>You have successfully logged out of the application.</p>\n</header>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LogoutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogoutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogoutModel>)PageContext?.ViewData;
        public LogoutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
