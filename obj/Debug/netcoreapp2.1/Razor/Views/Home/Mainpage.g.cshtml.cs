#pragma checksum "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc96cca93504dea897c2e6b26b254bbb2ef3fcea"
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
#line 1 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#line 2 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
#line 3 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
using WebApp1.products;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc96cca93504dea897c2e6b26b254bbb2ef3fcea", @"/Views/Home/Mainpage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Mainpage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApp1.products.Productwaarde>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/mainpage.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Mainpage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 5 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
  
    int currentColumn = 0;
    List<Productwaarde> col2Items = new List<Productwaarde>();
    List<Productwaarde> col3Items = new List<Productwaarde>();
 

#line default
#line hidden
            BeginContext(245, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(247, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e9b893cb79604e5dbbe1cbee7aae45f3", async() => {
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
            BeginContext(296, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 13 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
  
    //var hi= (ViewData["productsoorten"]);
    var productst = Context.Session.Get<String>("productsoort");

#line default
#line hidden
            BeginContext(418, 151, true);
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-2\">\r\n        <div id=\"categoryArea\">\r\n            <div class=\"categoryTitle\">Categorieën</div>\r\n            ");
            EndContext();
            BeginContext(569, 462, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cec974d32abf4f338d901da0a837746c", async() => {
                BeginContext(597, 427, true);
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
            BeginContext(1031, 37, true);
            WriteLiteral("\r\n            <div>\r\n                ");
            EndContext();
            BeginContext(1068, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36cefeee0956409ba934901099c05d3d", async() => {
                BeginContext(1090, 25, true);
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
            BeginContext(1119, 269, true);
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
#line 43 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                     foreach (var item in Model)
                    {
                        if (currentColumn == 0)
                        {

#line default
#line hidden
            BeginContext(1537, 163, true);
            WriteLiteral("                            <div class=\"card\" style=\"width: 20rem;\">\r\n                                <div class=\"card-body\">\r\n                                    ");
            EndContext();
            BeginContext(1700, 726, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f994dd9463c347829fac154a69c04dd9", async() => {
                BeginContext(1764, 131, true);
                WriteLiteral("\r\n                                        <div id=\"container\" class=\"form-group\">\r\n                                            <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1895, "\"", 1936, 1);
#line 51 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
WriteAttributeValue("", 1901, "/images/products/" + item.Image, 1901, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1937, 94, true);
                WriteLiteral(" id=\"productImage\"><img/>\r\n                                            <h5 class=\"card-title\">");
                EndContext();
                BeginContext(2032, 10, false);
#line 52 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                                                              Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(2042, 74, true);
                WriteLiteral("</h5>\r\n                                            <p class=\"card-text\">€ ");
                EndContext();
                BeginContext(2117, 10, false);
#line 53 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                                                              Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(2127, 80, true);
                WriteLiteral("</p>\r\n                                            <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 2207, "\'", 2223, 1);
#line 54 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
WriteAttributeValue("", 2215, item.Id, 2215, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2224, 195, true);
                WriteLiteral("/>\r\n                                            <input type=\"submit\" class=\"btn btn-primary\" value=\"Details\">\r\n                                        </div>\r\n                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 49 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
AddHtmlAttributeValue("", 1714, Url.Action("Index", "ViewProduct"), 1714, 35, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2426, 78, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 60 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
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
            BeginContext(3196, 62, true);
            WriteLiteral("                </div>\r\n                <div class=\"col-sm\">\r\n");
            EndContext();
#line 79 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                     foreach (Productwaarde item in col2Items)
                    {

#line default
#line hidden
            BeginContext(3345, 151, true);
            WriteLiteral("                        <div class=\"card\" style=\"width: 20rem;\">\r\n                            <div class=\"card-body\">\r\n                                ");
            EndContext();
            BeginContext(3496, 694, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62be588291a34445a7c10087f24b9c21", async() => {
                BeginContext(3560, 123, true);
                WriteLiteral("\r\n                                    <div id=\"container\" class=\"form-group\">\r\n                                        <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 3683, "\"", 3724, 1);
#line 85 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
WriteAttributeValue("", 3689, "/images/products/" + item.Image, 3689, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3725, 90, true);
                WriteLiteral(" id=\"productImage\"><img/>\r\n                                        <h5 class=\"card-title\">");
                EndContext();
                BeginContext(3816, 10, false);
#line 86 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                                                          Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(3826, 70, true);
                WriteLiteral("</h5>\r\n                                        <p class=\"card-text\">€ ");
                EndContext();
                BeginContext(3897, 10, false);
#line 87 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                                                          Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(3907, 76, true);
                WriteLiteral("</p>\r\n                                        <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 3983, "\'", 3999, 1);
#line 88 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
WriteAttributeValue("", 3991, item.Id, 3991, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4000, 183, true);
                WriteLiteral("/>\r\n                                        <input type=\"submit\" class=\"btn btn-primary\" value=\"Details\">\r\n                                    </div>\r\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 83 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
AddHtmlAttributeValue("", 3510, Url.Action("Index", "ViewProduct"), 3510, 35, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4190, 70, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 94 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                    }

#line default
#line hidden
            BeginContext(4283, 62, true);
            WriteLiteral("                </div>\r\n                <div class=\"col-sm\">\r\n");
            EndContext();
#line 97 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                     foreach (Productwaarde item in col3Items)
                    {

#line default
#line hidden
            BeginContext(4432, 151, true);
            WriteLiteral("                        <div class=\"card\" style=\"width: 20rem;\">\r\n                            <div class=\"card-body\">\r\n                                ");
            EndContext();
            BeginContext(4583, 694, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e85bb72ef334113b50224e375849bd7", async() => {
                BeginContext(4647, 123, true);
                WriteLiteral("\r\n                                    <div id=\"container\" class=\"form-group\">\r\n                                        <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 4770, "\"", 4811, 1);
#line 103 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
WriteAttributeValue("", 4776, "/images/products/" + item.Image, 4776, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4812, 90, true);
                WriteLiteral(" id=\"productImage\"><img/>\r\n                                        <h5 class=\"card-title\">");
                EndContext();
                BeginContext(4903, 10, false);
#line 104 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                                                          Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(4913, 70, true);
                WriteLiteral("</h5>\r\n                                        <p class=\"card-text\">€ ");
                EndContext();
                BeginContext(4984, 10, false);
#line 105 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                                                          Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(4994, 76, true);
                WriteLiteral("</p>\r\n                                        <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 5070, "\'", 5086, 1);
#line 106 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
WriteAttributeValue("", 5078, item.Id, 5078, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5087, 183, true);
                WriteLiteral("/>\r\n                                        <input type=\"submit\" class=\"btn btn-primary\" value=\"Details\">\r\n                                    </div>\r\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 101 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
AddHtmlAttributeValue("", 4597, Url.Action("Index", "ViewProduct"), 4597, 35, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5277, 70, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 112 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
                    }

#line default
#line hidden
            BeginContext(5370, 125, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<script type=\'text/javascript\'>\r\nvar names = ");
            EndContext();
            BeginContext(5496, 52, false);
#line 119 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\Home\Mainpage.cshtml"
       Write(Html.Raw(Json.Serialize(ViewData["productsoorten"])));

#line default
#line hidden
            EndContext();
            BeginContext(5548, 1006, true);
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
