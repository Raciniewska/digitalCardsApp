#pragma checksum "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e828ac457749417f6fe71c003de58b8d500d296"
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
#line 1 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\_ViewImports.cshtml"
using AssemblyCardsSystem.Web;

#line default
#line hidden
#line 2 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\_ViewImports.cshtml"
using AssemblyCardsSystem.Web.Models;

#line default
#line hidden
#line 1 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
using Microsoft.AspNetCore.Builder;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e828ac457749417f6fe71c003de58b8d500d296", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7d82d5fcd343d961fdfec40713b636499670caf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CardsResource>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Filter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(65, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
   ViewData["Title"] = "Search";
    var createdCards = (List<string>) @ViewData["createdCards"];

#line default
#line hidden
            BeginContext(170, 25, true);
            WriteLiteral("\r\n    <h2>Search</h2>\r\n\r\n");
            EndContext();
            BeginContext(195, 298, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e828ac457749417f6fe71c003de58b8d500d2965210", async() => {
                BeginContext(243, 243, true);
                WriteLiteral("\r\n    <p>\r\n        KNNR: <input type=\"text\" name=\"SearchKNNR\">\r\n        Employee Lastname: <input type=\"text\" name=\"SearchEL\">\r\n        Sort No.: <input type=\"text\" name=\"SearchSort\">\r\n        <input type=\"submit\" value=\"filter\" />\r\n    </p>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
            BeginContext(493, 85, true);
            WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n\r\n            <!--<ul>-->\r\n");
            EndContext();
#line 22 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
             if (Model != null)
            {
            

#line default
#line hidden
#line 24 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
             foreach (var resource in @Model)
            {

#line default
#line hidden
            BeginContext(688, 34, true);
            WriteLiteral("            <hr>\r\n            <p> ");
            EndContext();
            BeginContext(723, 26, false);
#line 27 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
           Write(resource.AssemblyCard.KNNR);

#line default
#line hidden
            EndContext();
            BeginContext(749, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(753, 26, false);
#line 27 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
                                         Write(resource.AssemblyCard.Sort);

#line default
#line hidden
            EndContext();
            BeginContext(779, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(783, 32, false);
#line 27 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
                                                                       Write(resource.AssemblyCard.EmployeeLN);

#line default
#line hidden
            EndContext();
            BeginContext(815, 39, true);
            WriteLiteral("</p>\r\n            <p><a>EDIT</a>   |   ");
            EndContext();
            BeginContext(854, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e828ac457749417f6fe71c003de58b8d500d2969388", async() => {
                BeginContext(926, 6, true);
                WriteLiteral("DELETE");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 28 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
                                                                                WriteLiteral(resource.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(936, 49, true);
            WriteLiteral("   |   <a>SEND AS EMAIL</a></p>\r\n            <br>");
            EndContext();
#line 29 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
                }

#line default
#line hidden
#line 29 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Search.cshtml"
                 }

#line default
#line hidden
            BeginContext(989, 54, true);
            WriteLiteral("            <!--</ul>-->\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CardsResource>> Html { get; private set; }
    }
}
#pragma warning restore 1591