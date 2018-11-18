#pragma checksum "/Users/sergentokcan/Documents/GitHub/webStore1/Models/Account/Manage/PersonalData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b298b07a8d03fd60a8e5c93abe46c80faffc31dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Models_Account_Manage_PersonalData), @"mvc.1.0.razor-page", @"/Models/Account/Manage/PersonalData.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Models/Account/Manage/PersonalData.cshtml", typeof(AspNetCore.Models_Account_Manage_PersonalData), null)]
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
#line 1 "/Users/sergentokcan/Documents/GitHub/webStore1/Models/Account/_ViewImports.cshtml"
using WebApp1.Areas.Identity.Pages.Account;

#line default
#line hidden
#line 1 "/Users/sergentokcan/Documents/GitHub/webStore1/Models/Account/Manage/_ViewImports.cshtml"
using WebApp1.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b298b07a8d03fd60a8e5c93abe46c80faffc31dd", @"/Models/Account/Manage/PersonalData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87bbdfa9d416decbea554eec34698177e01680d6", @"/Models/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"527b6c26c6e3adca82441b7d38b9f48ceb841834", @"/Models/Account/Manage/_ViewImports.cshtml")]
    public class Models_Account_Manage_PersonalData : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/Users/sergentokcan/Documents/GitHub/webStore1/Models/Account/Manage/PersonalData.cshtml"
  
    ViewData["Title"] = "Personal Data";
    ViewData["ActivePage"] = ManageNavPages.PersonalData;

#line default
#line hidden
            BeginContext(141, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(148, 17, false);
#line 8 "/Users/sergentokcan/Documents/GitHub/webStore1/Models/Account/Manage/PersonalData.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(165, 635, true);
            WriteLiteral(@"</h4>

<div class=""row"">
    <div class=""col-md-6"">
        <p>Your account contains personal data that you have given us. This page allows you to download or delete that data.</p>
        <p>
            <strong>Deleting this data will permanently remove your account, and this cannot be recovered.</strong>
        </p>
        <form asp-page=""DownloadPersonalData"" method=""post"" class=""form-group"">
            <button class=""btn btn-default"" type=""submit"">Download</button>
        </form>
        <p>
            <a asp-page=""DeletePersonalData"" class=""btn btn-default"">Delete</a>
        </p>
    </div>
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(818, 52, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PersonalDataModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PersonalDataModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PersonalDataModel>)PageContext?.ViewData;
        public PersonalDataModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
