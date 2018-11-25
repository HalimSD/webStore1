#pragma checksum "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16d02ae15211131269576767d50f4adccea4c7ee"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16d02ae15211131269576767d50f4adccea4c7ee", @"/Views/viewProduct/Index.cshtml")]
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
#line 1 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
  
    ViewProductModel viewProductModel = (ViewProductModel) ViewData["ProductModel"];
    List<ViewProductAttributes> attributes = (List<ViewProductAttributes>) ViewData["ProductAttributeModel"];
    string imagePath = "/images/products/" + viewProductModel.Image;
    bool inStock = viewProductModel.Quantity > 0;

#line default
#line hidden
            BeginContext(325, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1bc551be301f42f492a7660a1a6b4890", async() => {
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
            BeginContext(378, 66, true);
            WriteLiteral("\r\n<div class=\"pageBackground\">\r\n    <div id=\"category\">Categorie: ");
            EndContext();
            BeginContext(445, 25, false);
#line 9 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                             Write(viewProductModel.Category);

#line default
#line hidden
            EndContext();
            BeginContext(470, 95, true);
            WriteLiteral("</div>\r\n    <div class=\"row\" id=\"productHeader\">\r\n        <div class=\"col-6\">\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 565, "\"", 581, 1);
#line 12 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
WriteAttributeValue("", 571, imagePath, 571, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(582, 136, true);
            WriteLiteral(" height=\"300\" width=\"400\" class=\"productImage\"></img>\r\n        </div>\r\n        <div class=\"col-6\" id=\"productContent\">\r\n            <h2>");
            EndContext();
            BeginContext(719, 21, false);
#line 15 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
           Write(viewProductModel.Name);

#line default
#line hidden
            EndContext();
            BeginContext(740, 160, true);
            WriteLiteral("</h2>\r\n            <div class=\"description\">\r\n                <div class=\"descriptionTitle\">BESCHRIJVING</div>\r\n                <div class=\"descriptionContent\">");
            EndContext();
            BeginContext(901, 28, false);
#line 18 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                                           Write(viewProductModel.Description);

#line default
#line hidden
            EndContext();
            BeginContext(929, 56, true);
            WriteLiteral("</div>\r\n            </div>\r\n            <div id=\"price\">");
            EndContext();
            BeginContext(986, 22, false);
#line 20 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                       Write(viewProductModel.Price);

#line default
#line hidden
            EndContext();
            BeginContext(1008, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 21 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
             if (inStock)
            {

#line default
#line hidden
            BeginContext(1058, 35, true);
            WriteLiteral("                <div id=\"quantity\">");
            EndContext();
            BeginContext(1095, 38, false);
#line 23 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                               Write("Voorraad: "+viewProductModel.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1134, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 24 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1190, 76, true);
            WriteLiteral("                <div id=\"outOfStock\">Geen voorraad meer beschikbaar!</div>\r\n");
            EndContext();
#line 28 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1281, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1293, 878, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e32385fe11c54c359005d82a0caf4cf9", async() => {
                BeginContext(1312, 48, true);
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 1360, "\'", 1388, 1);
#line 30 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
WriteAttributeValue("", 1368, viewProductModel.Id, 1368, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1389, 4, true);
                WriteLiteral("/>\r\n");
                EndContext();
#line 31 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                 if (inStock)
                {

#line default
#line hidden
                BeginContext(1443, 40, true);
                WriteLiteral("                    <input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("formaction", " formaction=\"", 1483, "\"", 1522, 1);
#line 33 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
WriteAttributeValue("", 1496, Url.Action("buy", "Cart"), 1496, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1523, 46, true);
                WriteLiteral(" class=\"CartBtn\" value=\"Zet in Winkelwagen\">\r\n");
                EndContext();
#line 34 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                }     

#line default
#line hidden
                BeginContext(1593, 16, true);
                WriteLiteral("                ");
                EndContext();
#line 35 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                 if (ViewBag.alreadyInFav)
                {

#line default
#line hidden
                BeginContext(1656, 57, true);
                WriteLiteral("                    <input type=\"hidden\" name=\"returnUrl\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1713, "\"", 1785, 1);
#line 37 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
WriteAttributeValue("", 1721, Url.Action("Index","ViewProduct", new {id=viewProductModel.Id}), 1721, 64, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1786, 44, true);
                WriteLiteral("/>\r\n                    <input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("formaction", " formaction=\"", 1830, "\"", 1884, 1);
#line 38 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
WriteAttributeValue("", 1843, Url.Action("RemoveProduct", "Favorites"), 1843, 41, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1885, 53, true);
                WriteLiteral(" class=\"CartBtn\" value=\"Verwijder uit Favorieten\"> \r\n");
                EndContext();
#line 39 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                }
                else
                {

#line default
#line hidden
                BeginContext(1998, 40, true);
                WriteLiteral("                    <input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("formaction", " formaction=\"", 2038, "\"", 2089, 1);
#line 42 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
WriteAttributeValue("", 2051, Url.Action("AddProduct", "Favorites"), 2051, 38, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2090, 43, true);
                WriteLiteral(" class=\"CartBtn\" value=\"Zet in Favoriet\">\r\n");
                EndContext();
#line 43 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                }

#line default
#line hidden
                BeginContext(2152, 12, true);
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
            BeginContext(2171, 40, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <hr>\r\n");
            EndContext();
#line 48 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
     if (attributes.Count > 0)
    {

#line default
#line hidden
            BeginContext(2250, 214, true);
            WriteLiteral("        <h3>Product eigenschappen</h3>\r\n        <div id=\"tableContainer\">\r\n            <table id=\"table\">\r\n                <tr>\r\n                    <th></th>\r\n                    <th></th>\r\n                </tr>\r\n");
            EndContext();
#line 57 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                 foreach (ViewProductAttributes item in attributes)
                {

#line default
#line hidden
            BeginContext(2552, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(2607, 18, false);
#line 60 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                       Write(item.AttributeName);

#line default
#line hidden
            EndContext();
            BeginContext(2625, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2661, 19, false);
#line 61 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                       Write(item.AttributeValue);

#line default
#line hidden
            EndContext();
            BeginContext(2680, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 63 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2733, 38, true);
            WriteLiteral("            </table>\r\n        </div>\r\n");
            EndContext();
#line 66 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(2795, 85, true);
            WriteLiteral("        <h3 id=\"no-attributes-warning\">Geen product eigenschappen beschikbaar!</h3>\r\n");
            EndContext();
#line 70 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\viewProduct\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(2887, 8, true);
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
