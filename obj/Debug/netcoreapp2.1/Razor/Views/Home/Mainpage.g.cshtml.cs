#pragma checksum "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21fc71cf213cf1dddc49cfbd38468cc033f8434f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Mainpage), @"mvc.1.0.view", @"/Views/Home/Mainpage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Mainpage.cshtml", typeof(AspNetCore.Views_Home_Mainpage))]
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
#line 1 "/Users/halim/hr/webStore1/Views/_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#line 2 "/Users/halim/hr/webStore1/Views/_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
#line 3 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
using WebApp1.products;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21fc71cf213cf1dddc49cfbd38468cc033f8434f", @"/Views/Home/Mainpage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Mainpage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApp1.products.Productwaarde>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/mainpage.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Mainpage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Buy"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "buy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\n\n");
            EndContext();
#line 5 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
  
    int currentColumn = 0;
    List<Productwaarde> col2Items = new List<Productwaarde>();
    List<Productwaarde> col3Items = new List<Productwaarde>();
 

#line default
#line hidden
            BeginContext(236, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(237, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f078b3f6cd6e4f1594e0aa082e266667", async() => {
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
            BeginContext(286, 2, true);
            WriteLiteral("\n\n");
            EndContext();
#line 13 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
  
    //var hi= (ViewData["productsoorten"]);
    var productst = Context.Session.Get<String>("productsoort");

#line default
#line hidden
            BeginContext(402, 145, true);
            WriteLiteral("\n\n<div class=\"row\">\n    <div class=\"col-2\">\n        <div id=\"categoryArea\">\n            <div class=\"categoryTitle\">Categorieën</div>\n            ");
            EndContext();
            BeginContext(547, 454, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b95277eefcf4fc28e8a6009b17d4f18", async() => {
                BeginContext(575, 419, true);
                WriteLiteral(@"
                <div id=""container1"" class=""form-group"">
                    Select all<input type=""radio"" name=""hi"" value=""select all""><br>
                </div>
                <div id=""container"" class=""form-group""></div>
                <div class=""form-group"">
                    <input type=""submit"" value=""Ga naar Categorie"" class=""btn btn-default"" id=""btnSelectCategory""/>
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1001, 35, true);
            WriteLiteral("\n            <div>\n                ");
            EndContext();
            BeginContext(1036, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce6dbb3fbc9f400a97ae98a7cedfbb2c", async() => {
                BeginContext(1058, 25, true);
                WriteLiteral("Terug naar alle producten");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1087, 259, true);
            WriteLiteral(@"
            </div>
        </div>
    </div>
    <div class=""col-8"">
        <div class=""container"" id=""productsArea"">
            <h2>Boten</h2>
            <h4>Producten</h4>
            <div class=""row"" id=""products"">
                <div class=""col-sm"">
");
            EndContext();
#line 43 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                     foreach (var item in Model)
                    {
                        if (currentColumn == 0)
                        {

#line default
#line hidden
            BeginContext(1491, 161, true);
            WriteLiteral("                            <div class=\"card\" style=\"width: 20rem;\">\n                                <div class=\"card-body\">\n                                    ");
            EndContext();
            BeginContext(1652, 860, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ba981c17a8a4685a357cbc45b263dbc", async() => {
                BeginContext(1716, 129, true);
                WriteLiteral("\n                                        <div id=\"container\" class=\"form-group\">\n                                            <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1845, "\"", 1886, 1);
#line 51 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
WriteAttributeValue("", 1851, "/images/products/" + item.Image, 1851, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1887, 93, true);
                WriteLiteral(" id=\"productImage\"><img/>\n                                            <h5 class=\"card-title\">");
                EndContext();
                BeginContext(1981, 10, false);
#line 52 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                                                              Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1991, 73, true);
                WriteLiteral("</h5>\n                                            <p class=\"card-text\">€ ");
                EndContext();
                BeginContext(2065, 10, false);
#line 53 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                                                              Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(2075, 79, true);
                WriteLiteral("</p>\n                                            <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 2154, "\'", 2170, 1);
#line 54 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
WriteAttributeValue("", 2162, item.Id, 2162, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2171, 153, true);
                WriteLiteral("/>\n                                            <input type=\"submit\" class=\"btn btn-primary\" value=\"Details\">\n                                            ");
                EndContext();
                BeginContext(2324, 97, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b77d0534a1ea4958bef84a0f6ff1a2cc", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2421, 84, true);
                WriteLiteral("\n                                        </div>\n                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 49 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
AddHtmlAttributeValue("", 1666, Url.Action("Index", "ViewProduct"), 1666, 35, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2512, 75, true);
            WriteLiteral("\n                                </div>\n                            </div>\n");
            EndContext();
#line 61 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                            currentColumn++;
                        }
                        else
                        {
                            switch (currentColumn)
                            {
                                case 1: 
                                    col2Items.Add(item);
                                    currentColumn++;
                                    break;
                                case 2: 
                                    col3Items.Add(item);
                                    currentColumn = 0;
                                    break;
                            }
                        }
                    }

#line default
#line hidden
            BeginContext(3262, 60, true);
            WriteLiteral("                </div>\n                <div class=\"col-sm\">\n");
            EndContext();
#line 80 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                     foreach (Productwaarde item in col2Items)
                    {

#line default
#line hidden
            BeginContext(3407, 149, true);
            WriteLiteral("                        <div class=\"card\" style=\"width: 20rem;\">\n                            <div class=\"card-body\">\n                                ");
            EndContext();
            BeginContext(3556, 824, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9888b111d840459f951dc656976a4a87", async() => {
                BeginContext(3620, 121, true);
                WriteLiteral("\n                                    <div id=\"container\" class=\"form-group\">\n                                        <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 3741, "\"", 3782, 1);
#line 86 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
WriteAttributeValue("", 3747, "/images/products/" + item.Image, 3747, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3783, 89, true);
                WriteLiteral(" id=\"productImage\"><img/>\n                                        <h5 class=\"card-title\">");
                EndContext();
                BeginContext(3873, 10, false);
#line 87 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                                                          Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(3883, 69, true);
                WriteLiteral("</h5>\n                                        <p class=\"card-text\">€ ");
                EndContext();
                BeginContext(3953, 10, false);
#line 88 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                                                          Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(3963, 75, true);
                WriteLiteral("</p>\n                                        <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 4038, "\'", 4054, 1);
#line 89 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
WriteAttributeValue("", 4046, item.Id, 4046, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4055, 145, true);
                WriteLiteral("/>\n                                        <input type=\"submit\" class=\"btn btn-primary\" value=\"Details\">\n                                        ");
                EndContext();
                BeginContext(4200, 97, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b3caf291dffd4a808955edd2558dabc4", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4297, 76, true);
                WriteLiteral("\n                                    </div>\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 84 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
AddHtmlAttributeValue("", 3570, Url.Action("Index", "ViewProduct"), 3570, 35, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4380, 67, true);
            WriteLiteral("\n                            </div>\n                        </div>\n");
            EndContext();
#line 96 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                    }

#line default
#line hidden
            BeginContext(4469, 60, true);
            WriteLiteral("                </div>\n                <div class=\"col-sm\">\n");
            EndContext();
#line 99 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                     foreach (Productwaarde item in col3Items)
                    {

#line default
#line hidden
            BeginContext(4614, 149, true);
            WriteLiteral("                        <div class=\"card\" style=\"width: 20rem;\">\n                            <div class=\"card-body\">\n                                ");
            EndContext();
            BeginContext(4763, 825, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "220b3668b79e4b7eb1a1fa5c53c0cdfc", async() => {
                BeginContext(4827, 121, true);
                WriteLiteral("\n                                    <div id=\"container\" class=\"form-group\">\n                                        <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 4948, "\"", 4989, 1);
#line 105 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
WriteAttributeValue("", 4954, "/images/products/" + item.Image, 4954, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4990, 89, true);
                WriteLiteral(" id=\"productImage\"><img/>\n                                        <h5 class=\"card-title\">");
                EndContext();
                BeginContext(5080, 10, false);
#line 106 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                                                          Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(5090, 69, true);
                WriteLiteral("</h5>\n                                        <p class=\"card-text\">€ ");
                EndContext();
                BeginContext(5160, 10, false);
#line 107 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                                                          Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(5170, 75, true);
                WriteLiteral("</p>\n                                        <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 5245, "\'", 5261, 1);
#line 108 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
WriteAttributeValue("", 5253, item.Id, 5253, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5262, 145, true);
                WriteLiteral("/>\n                                        <input type=\"submit\" class=\"btn btn-primary\" value=\"Details\">\n                                        ");
                EndContext();
                BeginContext(5407, 97, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e9ccb07cb6b04737936d1ee59e3cbc6e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5504, 77, true);
                WriteLiteral("\n\n                                    </div>\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 103 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
AddHtmlAttributeValue("", 4777, Url.Action("Index", "ViewProduct"), 4777, 35, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5588, 67, true);
            WriteLiteral("\n                            </div>\n                        </div>\n");
            EndContext();
#line 116 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
                    }

#line default
#line hidden
            BeginContext(5677, 119, true);
            WriteLiteral("                </div>\n            </div>\n        </div>\n    </div>\n</div>\n<script type=\'text/javascript\'>\nvar names = ");
            EndContext();
            BeginContext(5797, 52, false);
#line 123 "/Users/halim/hr/webStore1/Views/Home/Mainpage.cshtml"
       Write(Html.Raw(Json.Serialize(ViewData["productsoorten"])));

#line default
#line hidden
            EndContext();
            BeginContext(5849, 978, true);
            WriteLiteral(@";
    //var serializedUsers = JSON.parse(names);
        function addFields(){
		for (i = 0; i <  names.length; i++) { 
            var container = document.getElementById(""container1"");
            // Clear previous contents of the container
                //container.removeChild(container.lastChild);
                // Append a node with a random text
                var res = names[i].split(""= "");
                var end = res[1].split("" }"");
                container.appendChild(document.createTextNode(end[0]));
                
				
                // Create an <input> element, set its type and name attributes
                var radio = document.createElement(""input"");
				radio.type = ""radio"";
				radio.name = ""hi"";
				radio.value = end[0];
                container.appendChild(radio);
                // Append a line break 
                container.appendChild(document.createElement(""br""));
				}
			}
			window.onload = addFields;
</script>


         
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApp1.products.Productwaarde>> Html { get; private set; }
    }
}
#pragma warning restore 1591
