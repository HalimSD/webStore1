#pragma checksum "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "245d927c50191146bfc93f3d54bd297ab52b8610"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UploadFiles_Create4), @"mvc.1.0.view", @"/Views/UploadFiles/Create4.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UploadFiles/Create4.cshtml", typeof(AspNetCore.Views_UploadFiles_Create4))]
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
#line 2 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"245d927c50191146bfc93f3d54bd297ab52b8610", @"/Views/UploadFiles/Create4.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_UploadFiles_Create4 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApp1.products.Productwaarde>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline my-2 my-lg-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Mainpage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
  
    Layout = "";
 

#line default
#line hidden
            BeginContext(112, 764, true);
            WriteLiteral(@"<link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"" integrity=""sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO"" crossorigin=""anonymous"">



  <nav class=""navbar navbar-expand-lg navbar-light bg-light"">
  <a class=""navbar-brand"" href=""#"">Webshop</a>
  <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarSupportedContent"" aria-controls=""navbarSupportedContent"" aria-expanded=""false"" aria-label=""Toggle navigation"">
    <span class=""navbar-toggler-icon""></span>
  </button>

  <div class=""collapse navbar-collapse"" id=""navbarSupportedContent"">
    <ul class=""navbar-nav mr-auto"">
      <li class=""nav-item active"">
        <a class=""nav-link""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 876, "\"", 914, 1);
#line 19 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
WriteAttributeValue("", 883, Url.Action("Mainpage", "Home"), 883, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(915, 119, true);
            WriteLiteral(">Home <span class=\"sr-only\">(current)</span></a>\r\n      </li>\r\n      <li class=\"nav-item\">\r\n        <a class=\"nav-link\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1034, "\"", 1072, 1);
#line 22 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
WriteAttributeValue("", 1041, Url.Action("Login", "Account"), 1041, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1073, 353, true);
            WriteLiteral(@">Login</a>
      </li>
      <li class=""nav-item dropdown"">
        <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
          Admin
        </a>
        <div class=""dropdown-menu"" aria-labelledby=""navbarDropdown"">
          <a class=""dropdown-item""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1426, "\"", 1466, 1);
#line 29 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
WriteAttributeValue("", 1433, Url.Action("Create", "Products"), 1433, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1467, 63, true);
            WriteLiteral(">Maak product soort aan</a>\r\n          <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1530, "\"", 1571, 1);
#line 30 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
WriteAttributeValue("", 1537, Url.Action("Create2", "Products"), 1537, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1572, 105, true);
            WriteLiteral(">Voeg product toe</a>\r\n          <div class=\"dropdown-divider\"></div>\r\n          <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1677, "\"", 1718, 1);
#line 32 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
WriteAttributeValue("", 1684, Url.Action("Statistics", "Chart"), 1684, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1719, 170, true);
            WriteLiteral(">Site Statistieken</a>\r\n        </div>\r\n      </li>\r\n      <li class=\"nav-item\">\r\n        <a class=\"nav-link disabled\" href=\"#\">Disabled</a>\r\n      </li>\r\n    </ul>\r\n    ");
            EndContext();
            BeginContext(1889, 241, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f07123d891b24f358f49d7b6774de9b1", async() => {
                BeginContext(1928, 195, true);
                WriteLiteral("\r\n      <input class=\"form-control mr-sm-2\" type=\"search\" placeholder=\"Search\" aria-label=\"Search\">\r\n      <button class=\"btn btn-outline-success my-2 my-sm-0\" type=\"submit\">Search</button>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2130, 30, true);
            WriteLiteral("\r\n  </div>\r\n</nav>  \r\n<br>\r\n\r\n");
            EndContext();
#line 47 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
  
    //var hi= (ViewData["productsoorten"]);
    var productst = Context.Session.Get<String>("productsoort");

#line default
#line hidden
            BeginContext(2278, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 52 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
  var i = 1;

#line default
#line hidden
            BeginContext(2297, 22, true);
            WriteLiteral("\r\n<div class=\"row\" >\r\n");
            EndContext();
#line 56 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
 foreach (var item in Model)
        {
                if ((i%2)!=0){ 
                    

#line default
#line hidden
            BeginContext(2415, 192, true);
            WriteLiteral("                        <div class=\"col\">\r\n                        <div class=\"card\" style=\"width: 25rem;\">\r\n                            <div class=\"card-body\">\r\n                              ");
            EndContext();
            BeginContext(2607, 511, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "406c839bc5a34ded996e973841aa2a60", async() => {
                BeginContext(2635, 131, true);
                WriteLiteral("\r\n                                <div id=\"container\" class=\"form-group\">\r\n                                <h5 class=\"card-title\" >");
                EndContext();
                BeginContext(2767, 10, false);
#line 65 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
                                                   Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(2777, 63, true);
                WriteLiteral("</h5>\r\n                                <p class=\"card-text\" >$ ");
                EndContext();
                BeginContext(2841, 10, false);
#line 66 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
                                                   Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(2851, 70, true);
                WriteLiteral("</p>\r\n                                <input type=\"hidden\" name = \"hi\"");
                EndContext();
                BeginWriteAttribute("value", " value =  \'", 2921, "\'", 2943, 1);
#line 67 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
WriteAttributeValue("", 2932, item.Title, 2932, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2944, 167, true);
                WriteLiteral(" />\r\n                                <input type=\"submit\" class=\"btn btn-primary\" value=\"Buy\"  >\r\n                                </div>\r\n                             ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3118, 111, true);
            WriteLiteral("             \r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 74 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
                
                }
                else{

#line default
#line hidden
            BeginContext(3289, 189, true);
            WriteLiteral("                    <div class=\"col\">\r\n                        <div class=\"card\" style=\"width: 25rem;\">\r\n                            <div class=\"card-body\">\r\n                               ");
            EndContext();
            BeginContext(3478, 511, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e820da824e674ef598af080991fc27cb", async() => {
                BeginContext(3506, 131, true);
                WriteLiteral("\r\n                                <div id=\"container\" class=\"form-group\">\r\n                                <h5 class=\"card-title\" >");
                EndContext();
                BeginContext(3638, 10, false);
#line 82 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
                                                   Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(3648, 63, true);
                WriteLiteral("</h5>\r\n                                <p class=\"card-text\" >$ ");
                EndContext();
                BeginContext(3712, 10, false);
#line 83 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
                                                   Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(3722, 70, true);
                WriteLiteral("</p>\r\n                                <input type=\"hidden\" name = \"hi\"");
                EndContext();
                BeginWriteAttribute("value", " value =  \'", 3792, "\'", 3814, 1);
#line 84 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
WriteAttributeValue("", 3803, item.Title, 3803, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3815, 167, true);
                WriteLiteral(" />\r\n                                <input type=\"submit\" class=\"btn btn-primary\" value=\"Buy\"  >\r\n                                </div>\r\n                             ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3989, 173, true);
            WriteLiteral(" \r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                     <div class=\"w-100\"></div>\r\n                    <br>\r\n");
            EndContext();
#line 93 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
                }
            i++;
        }

#line default
#line hidden
            BeginContext(4210, 55, true);
            WriteLiteral("</div>\r\n\r\n<script type=\'text/javascript\'>\r\nvar names = ");
            EndContext();
            BeginContext(4266, 52, false);
#line 99 "C:\Users\Okan Emeni\RiderProjects\webStore1\Views\UploadFiles\Create4.cshtml"
       Write(Html.Raw(Json.Serialize(ViewData["productsoorten"])));

#line default
#line hidden
            EndContext();
            BeginContext(4318, 1048, true);
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

<div class=""row"">
    <div cla");
            WriteLiteral("ss=\"col-md-4\">\r\n        ");
            EndContext();
            BeginContext(5366, 397, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40fbe55b842f419a899a48c8201ab376", async() => {
                BeginContext(5393, 363, true);
                WriteLiteral(@"
            <div id=""container1"" class=""form-group"">
                 Select all<input type=""radio"" name=""hi"" value=""select all""><br>
            </div>
            <div id=""container"" class=""form-group""></div>
            <div class=""form-group"">
                <input type=""submit"" value=""Filter"" class=""btn btn-default"" />
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
            BeginContext(5763, 35, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(5798, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "623c56e5b4b142dd8e24bfd9ba433801", async() => {
                BeginContext(5820, 12, true);
                WriteLiteral("Back to List");
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
            BeginContext(5836, 8, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApp1.products.Productwaarde>> Html { get; private set; }
    }
}
#pragma warning restore 1591
