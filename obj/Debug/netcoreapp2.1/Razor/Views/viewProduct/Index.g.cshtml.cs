#pragma checksum "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19961e57fb6c6d8d859b4e67808b018bf60e1dd8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_viewProduct_Index), @"mvc.1.0.view", @"/Views/viewProduct/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/viewProduct/Index.cshtml", typeof(AspNetCore.Views_viewProduct_Index))]
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
#line 1 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#line 2 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19961e57fb6c6d8d859b4e67808b018bf60e1dd8", @"/Views/viewProduct/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_viewProduct_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/view_product.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/boat.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("300"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("400"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("productImage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
  
    ViewProductModel viewProductModel = (ViewProductModel) ViewData["ProductModel"];
    List<ViewProductAttributes> attributes = (List<ViewProductAttributes>) ViewData["ProductAttributeModel"];

#line default
#line hidden
            BeginContext(204, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c8e83b69f22b4a52bb4b5f8e5b8035e2", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(257, 121, true);
            WriteLiteral("\r\n<div class=\"pageBackground\">  \r\n    <div class=\"row\" id=\"productHeader\">\r\n        <div class=\"col-6\">\r\n            <h2>");
            EndContext();
            BeginContext(379, 21, false);
#line 9 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
           Write(viewProductModel.Name);

#line default
#line hidden
            EndContext();
            BeginContext(400, 19, true);
            WriteLiteral("</h2>\r\n            ");
            EndContext();
            BeginContext(419, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c865833e540f4cc79708e193af56ccf6", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(494, 88, true);
            WriteLiteral("</img>\r\n        </div>\r\n        <div class=\"col-6\">\r\n            <div id=\"price\">Prijs: ");
            EndContext();
            BeginContext(583, 22, false);
#line 13 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                              Write(viewProductModel.Price);

#line default
#line hidden
            EndContext();
            BeginContext(605, 50, true);
            WriteLiteral("</div>\r\n            <div id=\"category\">Categorie: ");
            EndContext();
            BeginContext(656, 25, false);
#line 14 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                                     Write(viewProductModel.Category);

#line default
#line hidden
            EndContext();
            BeginContext(681, 125, true);
            WriteLiteral("</div>\r\n            <button type=\"submit\" class=\"CartBtn\">Zet in Winkelwagen</button>\r\n        </div>\r\n    </div>\r\n    <hr>\r\n");
            EndContext();
#line 19 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
     if (attributes.Count > 0)
    {

#line default
#line hidden
            BeginContext(845, 214, true);
            WriteLiteral("        <h3>Product eigenschappen</h3>\r\n        <div id=\"tableContainer\">\r\n            <table id=\"table\">\r\n                <tr>\r\n                    <th></th>\r\n                    <th></th>\r\n                </tr>\r\n");
            EndContext();
#line 28 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                 foreach (ViewProductAttributes item in attributes)
                {

#line default
#line hidden
            BeginContext(1147, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1202, 18, false);
#line 31 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                       Write(item.AttributeName);

#line default
#line hidden
            EndContext();
            BeginContext(1220, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1256, 19, false);
#line 32 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                       Write(item.AttributeValue);

#line default
#line hidden
            EndContext();
            BeginContext(1275, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 34 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1328, 38, true);
            WriteLiteral("            </table>\r\n        </div>\r\n");
            EndContext();
#line 37 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1390, 58, true);
            WriteLiteral("        <h3>Geen product eigenschappen beschikbaar!</h3>\r\n");
            EndContext();
#line 41 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1455, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
