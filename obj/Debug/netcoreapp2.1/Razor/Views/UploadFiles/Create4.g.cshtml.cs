#pragma checksum "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe07d8ce581f9e12e1b7b61fccf438f7de405425"
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
#line 1 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#line 2 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
#line 2 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe07d8ce581f9e12e1b7b61fccf438f7de405425", @"/Views/UploadFiles/Create4.cshtml")]
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
#line 3 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
  
    Layout = "";
 

#line default
#line hidden
            BeginContext(107, 751, true);
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
            BeginWriteAttribute("href", " href=\"", 858, "\"", 896, 1);
#line 19 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
WriteAttributeValue("", 865, Url.Action("Mainpage", "Home"), 865, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(897, 116, true);
            WriteLiteral(">Home <span class=\"sr-only\">(current)</span></a>\n      </li>\n      <li class=\"nav-item\">\n        <a class=\"nav-link\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1013, "\"", 1051, 1);
#line 22 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
WriteAttributeValue("", 1020, Url.Action("Login", "Account"), 1020, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1052, 346, true);
            WriteLiteral(@">Login</a>
      </li>
      <li class=""nav-item dropdown"">
        <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
          Admin
        </a>
        <div class=""dropdown-menu"" aria-labelledby=""navbarDropdown"">
          <a class=""dropdown-item""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1398, "\"", 1438, 1);
#line 29 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
WriteAttributeValue("", 1405, Url.Action("Create", "Products"), 1405, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1439, 62, true);
            WriteLiteral(">Maak product soort aan</a>\n          <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1501, "\"", 1542, 1);
#line 30 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
WriteAttributeValue("", 1508, Url.Action("Create2", "Products"), 1508, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1543, 103, true);
            WriteLiteral(">Voeg product toe</a>\n          <div class=\"dropdown-divider\"></div>\n          <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1646, "\"", 1687, 1);
#line 32 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
WriteAttributeValue("", 1653, Url.Action("Statistics", "Chart"), 1653, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1688, 163, true);
            WriteLiteral(">Site Statistieken</a>\n        </div>\n      </li>\n      <li class=\"nav-item\">\n        <a class=\"nav-link disabled\" href=\"#\">Disabled</a>\n      </li>\n    </ul>\n    ");
            EndContext();
            BeginContext(1851, 238, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb12507708aa40d5b3ec38b041a00c3d", async() => {
                BeginContext(1890, 192, true);
                WriteLiteral("\n      <input class=\"form-control mr-sm-2\" type=\"search\" placeholder=\"Search\" aria-label=\"Search\">\n      <button class=\"btn btn-outline-success my-2 my-sm-0\" type=\"submit\">Search</button>\n    ");
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
            BeginContext(2089, 25, true);
            WriteLiteral("\n  </div>\n</nav>  \n<br>\n\n");
            EndContext();
#line 47 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
  
    //var hi= (ViewData["productsoorten"]);
    var productst = Context.Session.Get<String>("productsoort");

#line default
#line hidden
            BeginContext(2228, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 52 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
  var i = 1;

#line default
#line hidden
            BeginContext(2244, 20, true);
            WriteLiteral("\n<div class=\"row\" >\n");
            EndContext();
#line 56 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
 foreach (var item in Model)
        {
                if ((i%2)!=0){ 
                    

#line default
#line hidden
            BeginContext(2356, 189, true);
            WriteLiteral("                        <div class=\"col\">\n                        <div class=\"card\" style=\"width: 25rem;\">\n                            <div class=\"card-body\">\n                              ");
            EndContext();
            BeginContext(2545, 504, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0dc9eb0d86e2424289ca59bab9c38a94", async() => {
                BeginContext(2573, 129, true);
                WriteLiteral("\n                                <div id=\"container\" class=\"form-group\">\n                                <h5 class=\"card-title\" >");
                EndContext();
                BeginContext(2703, 10, false);
#line 65 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
                                                   Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(2713, 62, true);
                WriteLiteral("</h5>\n                                <p class=\"card-text\" >$ ");
                EndContext();
                BeginContext(2776, 10, false);
#line 66 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
                                                   Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(2786, 69, true);
                WriteLiteral("</p>\n                                <input type=\"hidden\" name = \"hi\"");
                EndContext();
                BeginWriteAttribute("value", " value =  \'", 2855, "\'", 2877, 1);
#line 67 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
WriteAttributeValue("", 2866, item.Title, 2866, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2878, 164, true);
                WriteLiteral(" />\n                                <input type=\"submit\" class=\"btn btn-primary\" value=\"Buy\"  >\n                                </div>\n                             ");
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
            BeginContext(3049, 107, true);
            WriteLiteral("             \n                            </div>\n                        </div>\n                    </div>\n");
            EndContext();
#line 74 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
                
                }
                else{

#line default
#line hidden
            BeginContext(3213, 186, true);
            WriteLiteral("                    <div class=\"col\">\n                        <div class=\"card\" style=\"width: 25rem;\">\n                            <div class=\"card-body\">\n                               ");
            EndContext();
            BeginContext(3399, 504, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b82f352f1e25464fbfed0906443fb7f1", async() => {
                BeginContext(3427, 129, true);
                WriteLiteral("\n                                <div id=\"container\" class=\"form-group\">\n                                <h5 class=\"card-title\" >");
                EndContext();
                BeginContext(3557, 10, false);
#line 82 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
                                                   Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(3567, 62, true);
                WriteLiteral("</h5>\n                                <p class=\"card-text\" >$ ");
                EndContext();
                BeginContext(3630, 10, false);
#line 83 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
                                                   Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(3640, 69, true);
                WriteLiteral("</p>\n                                <input type=\"hidden\" name = \"hi\"");
                EndContext();
                BeginWriteAttribute("value", " value =  \'", 3709, "\'", 3731, 1);
#line 84 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
WriteAttributeValue("", 3720, item.Title, 3720, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3732, 164, true);
                WriteLiteral(" />\n                                <input type=\"submit\" class=\"btn btn-primary\" value=\"Buy\"  >\n                                </div>\n                             ");
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
            BeginContext(3903, 167, true);
            WriteLiteral(" \n                            </div>\n                        </div>\n                    </div>\n                     <div class=\"w-100\"></div>\n                    <br>\n");
            EndContext();
#line 93 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
                }
            i++;
        }

#line default
#line hidden
            BeginContext(4115, 52, true);
            WriteLiteral("</div>\n\n<script type=\'text/javascript\'>\nvar names = ");
            EndContext();
            BeginContext(4168, 52, false);
#line 99 "/Users/halim/hr/2de/echtlast/untitledfolder/untitledfolder/webStore1/Views/UploadFiles/Create4.cshtml"
       Write(Html.Raw(Json.Serialize(ViewData["productsoorten"])));

#line default
#line hidden
            EndContext();
            BeginContext(4220, 1020, true);
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
    <div class=""col-md-4"">
        ");
            EndContext();
            BeginContext(5240, 389, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86f5a9166765494e9d6c5f9101ea53c3", async() => {
                BeginContext(5267, 355, true);
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
            BeginContext(5629, 30, true);
            WriteLiteral("\n    </div>\n</div>\n\n<div>\n    ");
            EndContext();
            BeginContext(5659, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d575720f068f42caa32348f1599b52a2", async() => {
                BeginContext(5681, 12, true);
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
            BeginContext(5697, 7, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApp1.products.Productwaarde>> Html { get; private set; }
    }
}
#pragma warning restore 1591
