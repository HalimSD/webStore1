#pragma checksum "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a501d9983923061e89a29ebc6de8b1c3acbc627"
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
#line 1 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#line 2 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a501d9983923061e89a29ebc6de8b1c3acbc627", @"/Views/viewProduct/Index.cshtml")]
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
#line 1 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
  
    ViewProductModel viewProductModel = (ViewProductModel) ViewData["ProductModel"];
    List<ViewProductAttributes> attributes = (List<ViewProductAttributes>) ViewData["ProductAttributeModel"];

#line default
#line hidden
            BeginContext(200, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a5c36c9a153640f0a7463569bf3f72e0", async() => {
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
            BeginContext(253, 117, true);
            WriteLiteral("\n<div class=\"pageBackground\">  \n    <div class=\"row\" id=\"productHeader\">\n        <div class=\"col-6\">\n            <h2>");
            EndContext();
            BeginContext(371, 21, false);
#line 9 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
           Write(viewProductModel.Name);

#line default
#line hidden
            EndContext();
            BeginContext(392, 18, true);
            WriteLiteral("</h2>\n            ");
            EndContext();
            BeginContext(410, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "85f28fc6934e4a5e8c24a3b3314cfed2", async() => {
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
            BeginContext(485, 85, true);
            WriteLiteral("</img>\n        </div>\n        <div class=\"col-6\">\n            <div id=\"price\">Prijs: ");
            EndContext();
            BeginContext(571, 22, false);
#line 13 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
                              Write(viewProductModel.Price);

#line default
#line hidden
            EndContext();
            BeginContext(593, 49, true);
            WriteLiteral("</div>\n            <div id=\"category\">Categorie: ");
            EndContext();
            BeginContext(643, 25, false);
#line 14 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
                                     Write(viewProductModel.Category);

#line default
#line hidden
            EndContext();
            BeginContext(668, 120, true);
            WriteLiteral("</div>\n            <button type=\"submit\" class=\"CartBtn\">Zet in Winkelwagen</button>\n        </div>\n    </div>\n    <hr>\n");
            EndContext();
#line 19 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
     if (attributes.Count > 0)
    {

#line default
#line hidden
            BeginContext(825, 207, true);
            WriteLiteral("        <h3>Product eigenschappen</h3>\n        <div id=\"tableContainer\">\n            <table id=\"table\">\n                <tr>\n                    <th></th>\n                    <th></th>\n                </tr>\n");
            EndContext();
#line 28 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
                 foreach (ViewProductAttributes item in attributes)
                {

#line default
#line hidden
            BeginContext(1118, 53, true);
            WriteLiteral("                    <tr>\n                        <td>");
            EndContext();
            BeginContext(1172, 18, false);
#line 31 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
                       Write(item.AttributeName);

#line default
#line hidden
            EndContext();
            BeginContext(1190, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1225, 19, false);
#line 32 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
                       Write(item.AttributeValue);

#line default
#line hidden
            EndContext();
            BeginContext(1244, 32, true);
            WriteLiteral("</td>\n                    </tr>\n");
            EndContext();
#line 34 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1294, 36, true);
            WriteLiteral("            </table>\n        </div>\n");
            EndContext();
#line 37 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1351, 57, true);
            WriteLiteral("        <h3>Geen product eigenschappen beschikbaar!</h3>\n");
            EndContext();
#line 41 "/Users/sergentokcan/Documents/GitHub/webStore1/Views/viewProduct/Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1414, 7, true);
            WriteLiteral("\n</div>");
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
