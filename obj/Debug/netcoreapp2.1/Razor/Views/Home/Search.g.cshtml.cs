#pragma checksum "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14be6fe742834c1cb9972e91eace9ce16e6199c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Search.cshtml", typeof(AspNetCore.Views_Home_Search))]
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
#line 1 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
using WebApp1.products;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14be6fe742834c1cb9972e91eace9ce16e6199c4", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApp1.products.Productwaarde>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/mainpage.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Zet in winkelwagen"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "buy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
  
    int currentColumn = 0;
    List<Productwaarde> col2Items = new List<Productwaarde>();
    List<Productwaarde> col3Items = new List<Productwaarde>();
 

#line default
#line hidden
            BeginContext(241, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(243, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fa190900f9654520bcc0bddd9acd51cf", async() => {
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
            BeginContext(292, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 11 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
  
    //var hi= (ViewData["productsoorten"]);
    var productst = Context.Session.Get<String>("productsoort");

#line default
#line hidden
            BeginContext(414, 265, true);
            WriteLiteral(@"

<div class=""row"">
    
    <div class=""col-8"">
        <div class=""container"" id=""productsArea"">
            <h2>Boten</h2>
            <h4>Producten</h4>
            <div class=""row"" id=""products"">
                <div class=""col-sm"">
               
");
            EndContext();
#line 26 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                     foreach (var item in Model)
                    {
                        if (currentColumn == 0)
                        {

#line default
#line hidden
            BeginContext(828, 163, true);
            WriteLiteral("                            <div class=\"card\" style=\"width: 20rem;\">\r\n                                <div class=\"card-body\">\r\n                                    ");
            EndContext();
            BeginContext(991, 884, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c84c0ad0ecc4ab4bfdec86848a39f7b", async() => {
                BeginContext(1055, 131, true);
                WriteLiteral("\r\n                                        <div id=\"container\" class=\"form-group\">\r\n                                            <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1186, "\"", 1227, 1);
#line 34 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
WriteAttributeValue("", 1192, "/images/products/" + item.Image, 1192, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1228, 94, true);
                WriteLiteral(" id=\"productImage\"><img/>\r\n                                            <h5 class=\"card-title\">");
                EndContext();
                BeginContext(1323, 10, false);
#line 35 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                                                              Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1333, 74, true);
                WriteLiteral("</h5>\r\n                                            <p class=\"card-text\">€ ");
                EndContext();
                BeginContext(1408, 10, false);
#line 36 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                                                              Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(1418, 80, true);
                WriteLiteral("</p>\r\n                                            <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 1498, "\'", 1514, 1);
#line 37 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
WriteAttributeValue("", 1506, item.Id, 1506, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1515, 155, true);
                WriteLiteral("/>\r\n                                            <input type=\"submit\" class=\"btn btn-primary\" value=\"Details\">\r\n                                            ");
                EndContext();
                BeginContext(1670, 112, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cf0c901bba5948c3a721dae8d64f7814", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1782, 86, true);
                WriteLiteral("\r\n                                        </div>\r\n                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 32 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
AddHtmlAttributeValue("", 1005, Url.Action("Index", "ViewProduct"), 1005, 35, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1875, 78, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 44 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
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
            BeginContext(2645, 80, true);
            WriteLiteral("                \r\n                </div>\r\n                <div class=\"col-sm\">\r\n");
            EndContext();
#line 64 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                     foreach (Productwaarde item in col2Items)
                    {

#line default
#line hidden
            BeginContext(2812, 151, true);
            WriteLiteral("                        <div class=\"card\" style=\"width: 20rem;\">\r\n                            <div class=\"card-body\">\r\n                                ");
            EndContext();
            BeginContext(2963, 848, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8735117e1cb240cc933e49c94944e2db", async() => {
                BeginContext(3027, 123, true);
                WriteLiteral("\r\n                                    <div id=\"container\" class=\"form-group\">\r\n                                        <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 3150, "\"", 3191, 1);
#line 70 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
WriteAttributeValue("", 3156, "/images/products/" + item.Image, 3156, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3192, 90, true);
                WriteLiteral(" id=\"productImage\"><img/>\r\n                                        <h5 class=\"card-title\">");
                EndContext();
                BeginContext(3283, 10, false);
#line 71 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                                                          Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(3293, 70, true);
                WriteLiteral("</h5>\r\n                                        <p class=\"card-text\">€ ");
                EndContext();
                BeginContext(3364, 10, false);
#line 72 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                                                          Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(3374, 76, true);
                WriteLiteral("</p>\r\n                                        <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 3450, "\'", 3466, 1);
#line 73 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
WriteAttributeValue("", 3458, item.Id, 3458, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3467, 147, true);
                WriteLiteral("/>\r\n                                        <input type=\"submit\" class=\"btn btn-primary\" value=\"Details\">\r\n                                        ");
                EndContext();
                BeginContext(3614, 112, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "451c00cb00484970ba43c5d651bf6aae", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3726, 78, true);
                WriteLiteral("\r\n                                    </div>\r\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 68 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
AddHtmlAttributeValue("", 2977, Url.Action("Index", "ViewProduct"), 2977, 35, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3811, 70, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 80 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                    }

#line default
#line hidden
            BeginContext(3904, 62, true);
            WriteLiteral("                </div>\r\n                <div class=\"col-sm\">\r\n");
            EndContext();
#line 83 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                     foreach (Productwaarde item in col3Items)
                    {

#line default
#line hidden
            BeginContext(4053, 151, true);
            WriteLiteral("                        <div class=\"card\" style=\"width: 20rem;\">\r\n                            <div class=\"card-body\">\r\n                                ");
            EndContext();
            BeginContext(4204, 850, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79381dd553114636bb9cacb1206fe54c", async() => {
                BeginContext(4268, 123, true);
                WriteLiteral("\r\n                                    <div id=\"container\" class=\"form-group\">\r\n                                        <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 4391, "\"", 4432, 1);
#line 89 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
WriteAttributeValue("", 4397, "/images/products/" + item.Image, 4397, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4433, 90, true);
                WriteLiteral(" id=\"productImage\"><img/>\r\n                                        <h5 class=\"card-title\">");
                EndContext();
                BeginContext(4524, 10, false);
#line 90 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                                                          Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(4534, 70, true);
                WriteLiteral("</h5>\r\n                                        <p class=\"card-text\">€ ");
                EndContext();
                BeginContext(4605, 10, false);
#line 91 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                                                          Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(4615, 76, true);
                WriteLiteral("</p>\r\n                                        <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 4691, "\'", 4707, 1);
#line 92 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
WriteAttributeValue("", 4699, item.Id, 4699, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4708, 147, true);
                WriteLiteral("/>\r\n                                        <input type=\"submit\" class=\"btn btn-primary\" value=\"Details\">\r\n                                        ");
                EndContext();
                BeginContext(4855, 112, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b4450d3106424ec9a44526d112607f61", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4967, 80, true);
                WriteLiteral("\r\n\r\n                                    </div>\r\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 87 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
AddHtmlAttributeValue("", 4218, Url.Action("Index", "ViewProduct"), 4218, 35, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5054, 70, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 100 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Search.cshtml"
                    }

#line default
#line hidden
            BeginContext(5147, 80, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
