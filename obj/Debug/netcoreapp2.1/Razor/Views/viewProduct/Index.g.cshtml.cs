#pragma checksum "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96ec715b8d2e326083185064056f26e7bec30049"
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
#line 1 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#line 2 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96ec715b8d2e326083185064056f26e7bec30049", @"/Views/viewProduct/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_viewProduct_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/view_product.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
  
    ViewProductModel viewProductModel = (ViewProductModel) ViewData["ProductModel"];
    List<ViewProductAttributes> attributes = (List<ViewProductAttributes>) ViewData["ProductAttributeModel"];
    string imagePath = "/images/products/" + viewProductModel.Image;

#line default
#line hidden
            BeginContext(269, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a98326fcd43546779744d89c9c4f6d1a", async() => {
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
            BeginContext(322, 64, true);
            WriteLiteral("\n<div class=\"pageBackground\">\n    <div id=\"category\">Categorie: ");
            EndContext();
            BeginContext(387, 25, false);
#line 8 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                             Write(viewProductModel.Category);

#line default
#line hidden
            EndContext();
            BeginContext(412, 92, true);
            WriteLiteral("</div>\n    <div class=\"row\" id=\"productHeader\">\n        <div class=\"col-6\">\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 504, "\"", 520, 1);
#line 11 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
WriteAttributeValue("", 510, imagePath, 510, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(521, 133, true);
            WriteLiteral(" height=\"300\" width=\"400\" class=\"productImage\"></img>\n        </div>\n        <div class=\"col-6\" id=\"productContent\">\n            <h2>");
            EndContext();
            BeginContext(655, 21, false);
#line 14 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
           Write(viewProductModel.Name);

#line default
#line hidden
            EndContext();
            BeginContext(676, 157, true);
            WriteLiteral("</h2>\n            <div class=\"description\">\n                <div class=\"descriptionTitle\">BESCHRIJVING</div>\n                <div class=\"descriptionContent\">");
            EndContext();
            BeginContext(834, 28, false);
#line 17 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                                           Write(viewProductModel.Description);

#line default
#line hidden
            EndContext();
            BeginContext(862, 54, true);
            WriteLiteral("</div>\n            </div>\n            <div id=\"price\">");
            EndContext();
            BeginContext(917, 22, false);
#line 19 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                       Write(viewProductModel.Price);

#line default
#line hidden
            EndContext();
            BeginContext(939, 19, true);
            WriteLiteral("</div>\n            ");
            EndContext();
            BeginContext(958, 793, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ea6a74b6c854fca90627ff911849a36", async() => {
                BeginContext(977, 47, true);
                WriteLiteral("\n                <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 1024, "\'", 1052, 1);
#line 21 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
WriteAttributeValue("", 1032, viewProductModel.Id, 1032, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1053, 39, true);
                WriteLiteral("/>\n                <input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("formaction", " formaction=\"", 1092, "\"", 1131, 1);
#line 22 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
WriteAttributeValue("", 1105, Url.Action("buy", "Cart"), 1105, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1132, 50, true);
                WriteLiteral(" class=\"CartBtn\" value=\"Zet in Winkelwagen\">     \n");
                EndContext();
#line 23 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                 if (ViewBag.alreadyInFav)
                {

#line default
#line hidden
                BeginContext(1243, 57, true);
                WriteLiteral("                    <input type=\"hidden\" name=\"returnUrl\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1300, "\"", 1372, 1);
#line 25 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
WriteAttributeValue("", 1308, Url.Action("Index","ViewProduct", new {id=viewProductModel.Id}), 1308, 64, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1373, 43, true);
                WriteLiteral("/>\n                    <input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("formaction", " formaction=\"", 1416, "\"", 1470, 1);
#line 26 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
WriteAttributeValue("", 1429, Url.Action("RemoveProduct", "Favorites"), 1429, 41, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1471, 52, true);
                WriteLiteral(" class=\"CartBtn\" value=\"Verwijder uit Favorieten\"> \n");
                EndContext();
#line 27 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                }
                else
                {

#line default
#line hidden
                BeginContext(1580, 40, true);
                WriteLiteral("                    <input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("formaction", " formaction=\"", 1620, "\"", 1671, 1);
#line 30 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
WriteAttributeValue("", 1633, Url.Action("AddProduct", "Favorites"), 1633, 38, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1672, 42, true);
                WriteLiteral(" class=\"CartBtn\" value=\"Zet in Favoriet\">\n");
                EndContext();
#line 31 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                }

#line default
#line hidden
                BeginContext(1732, 12, true);
                WriteLiteral("            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1751, 36, true);
            WriteLiteral("\n        </div>\n    </div>\n    <hr>\n");
            EndContext();
#line 36 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
     if (attributes.Count > 0)
    {

#line default
#line hidden
            BeginContext(1824, 207, true);
            WriteLiteral("        <h3>Product eigenschappen</h3>\n        <div id=\"tableContainer\">\n            <table id=\"table\">\n                <tr>\n                    <th></th>\n                    <th></th>\n                </tr>\n");
            EndContext();
#line 45 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                 foreach (ViewProductAttributes item in attributes)
                {

#line default
#line hidden
            BeginContext(2117, 53, true);
            WriteLiteral("                    <tr>\n                        <td>");
            EndContext();
            BeginContext(2171, 18, false);
#line 48 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                       Write(item.AttributeName);

#line default
#line hidden
            EndContext();
            BeginContext(2189, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(2224, 19, false);
#line 49 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                       Write(item.AttributeValue);

#line default
#line hidden
            EndContext();
            BeginContext(2243, 32, true);
            WriteLiteral("</td>\n                    </tr>\n");
            EndContext();
#line 51 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2293, 36, true);
            WriteLiteral("            </table>\n        </div>\n");
            EndContext();
#line 54 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(2350, 84, true);
            WriteLiteral("        <h3 id=\"no-attributes-warning\">Geen product eigenschappen beschikbaar!</h3>\n");
            EndContext();
#line 58 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/viewProduct/Index.cshtml"
    }

#line default
#line hidden
            BeginContext(2440, 7, true);
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
