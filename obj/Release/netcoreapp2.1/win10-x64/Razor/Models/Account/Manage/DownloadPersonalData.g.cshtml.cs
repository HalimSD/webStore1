#pragma checksum "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\DownloadPersonalData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "972786752012d821cd4e01698e0d17c5950046de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Models_Account_Manage_DownloadPersonalData), @"mvc.1.0.razor-page", @"/Models/Account/Manage/DownloadPersonalData.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Models/Account/Manage/DownloadPersonalData.cshtml", typeof(AspNetCore.Models_Account_Manage_DownloadPersonalData), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"972786752012d821cd4e01698e0d17c5950046de", @"/Models/Account/Manage/DownloadPersonalData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87bbdfa9d416decbea554eec34698177e01680d6", @"/Models/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"527b6c26c6e3adca82441b7d38b9f48ceb841834", @"/Models/Account/Manage/_ViewImports.cshtml")]
    public class Models_Account_Manage_DownloadPersonalData : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\DownloadPersonalData.cshtml"
  
    ViewData["Title"] = "Download Your Data";
    ViewData["ActivePage"] = ManageNavPages.DownloadPersonalData;

#line default
#line hidden
            BeginContext(162, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(169, 17, false);
#line 8 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\DownloadPersonalData.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(186, 9, true);
            WriteLiteral("</h4>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(213, 52, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DownloadPersonalDataModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DownloadPersonalDataModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DownloadPersonalDataModel>)PageContext?.ViewData;
        public DownloadPersonalDataModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
