#pragma checksum "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\DeletePersonalData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48db9beee5aba8f5fef4d887ed55dd5e4940549d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Models_Account_Manage_DeletePersonalData), @"mvc.1.0.razor-page", @"/Models/Account/Manage/DeletePersonalData.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Models/Account/Manage/DeletePersonalData.cshtml", typeof(AspNetCore.Models_Account_Manage_DeletePersonalData), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48db9beee5aba8f5fef4d887ed55dd5e4940549d", @"/Models/Account/Manage/DeletePersonalData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87bbdfa9d416decbea554eec34698177e01680d6", @"/Models/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"527b6c26c6e3adca82441b7d38b9f48ceb841834", @"/Models/Account/Manage/_ViewImports.cshtml")]
    public class Models_Account_Manage_DeletePersonalData : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\DeletePersonalData.cshtml"
  
    ViewData["Title"] = "Delete Personal Data";
    ViewData["ActivePage"] = ManageNavPages.DeletePersonalData;

#line default
#line hidden
            BeginContext(160, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(167, 17, false);
#line 8 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\DeletePersonalData.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(184, 402, true);
            WriteLiteral(@"</h4>

<div class=""alert alert-warning"" role=""alert"">
    <p>
        <span class=""glyphicon glyphicon-warning-sign""></span>
        <strong>Deleting this data will permanently remove your account, and this cannot be recovered.</strong>
    </p>
</div>

<div>
    <form id=""delete-user"" method=""post"" class=""form-group"">
        <div asp-validation-summary=""All"" class=""text-danger""></div>
");
            EndContext();
#line 20 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\DeletePersonalData.cshtml"
         if (Model.RequirePassword)
        {

#line default
#line hidden
            BeginContext(634, 256, true);
            WriteLiteral(@"        <div class=""form-group"">
            <label asp-for=""Input.Password""></label>
            <input asp-for=""Input.Password"" class=""form-control"" />
            <span asp-validation-for=""Input.Password"" class=""text-danger""></span>
        </div>
");
            EndContext();
#line 27 "C:\Users\Okan Emeni\RiderProjects\webStore1\Models\Account\Manage\DeletePersonalData.cshtml"
        }

#line default
#line hidden
            BeginContext(901, 119, true);
            WriteLiteral("        <button class=\"btn btn-danger\" type=\"submit\">Delete data and close my account</button>\r\n    </form>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1038, 48, true);
                WriteLiteral("\r\n<partial name=\"_ValidationScriptsPartial\" />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DeletePersonalDataModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DeletePersonalDataModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DeletePersonalDataModel>)PageContext?.ViewData;
        public DeletePersonalDataModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
