#pragma checksum "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "236ddaf4c5c933fb3c716c44334da972e2222238"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Edit), @"mvc.1.0.view", @"/Views/Home/Edit.cshtml")]
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
#nullable restore
#line 1 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\_ViewImports.cshtml"
using AssemblyCardsSystem.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\_ViewImports.cshtml"
using AssemblyCardsSystem.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
using Microsoft.AspNetCore.Builder;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"236ddaf4c5c933fb3c716c44334da972e2222238", @"/Views/Home/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7d82d5fcd343d961fdfec40713b636499670caf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CardsResource>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SaveEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Edit Digital Assembly Card</h2>\r\n");
#nullable restore
#line 8 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
 if (@Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "236ddaf4c5c933fb3c716c44334da972e22222385681", async() => {
                WriteLiteral("\r\n        <fieldset>\r\n            <legend>Add Digital Assembly Card</legend>\r\n            <div>\r\n                <label>Sort:</label>\r\n                <input type=\"text\" name=\"sort\"");
                BeginWriteAttribute("value", " value=\"", 354, "\"", 386, 1);
#nullable restore
#line 15 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
WriteAttributeValue("", 362, Model.AssemblyCard.Sort, 362, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
            </div>
            <div>
                <label>Numer sekwencji:</label>
            </div>
            <div>
                <label>Kod kreskowy:</label>
            </div>
            <div>
                <label>KNNR:</label>
                <input type=""text"" name=""KNNR""");
                BeginWriteAttribute("value", " value=\"", 688, "\"", 720, 1);
#nullable restore
#line 25 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
WriteAttributeValue("", 696, Model.AssemblyCard.KNNR, 696, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n            <div>\r\n                <label>Employee number:</label>\r\n                <input type=\"text\" name=\"EmployeeID\"");
                BeginWriteAttribute("value", " value=\"", 866, "\"", 904, 1);
#nullable restore
#line 29 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
WriteAttributeValue("", 874, Model.AssemblyCard.EmployeeID, 874, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n            <div>\r\n                <label>Employee first name:</label>\r\n                <input type=\"text\" name=\"EmployeeFN\"");
                BeginWriteAttribute("value", " value=\"", 1054, "\"", 1092, 1);
#nullable restore
#line 33 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
WriteAttributeValue("", 1062, Model.AssemblyCard.EmployeeFN, 1062, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n            <div>\r\n                <label>Employee last name:</label>\r\n                <input type=\"text\" name=\"EmployeeLN\"");
                BeginWriteAttribute("value", " value=\"", 1241, "\"", 1279, 1);
#nullable restore
#line 37 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
WriteAttributeValue("", 1249, Model.AssemblyCard.EmployeeLN, 1249, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n            <div>\r\n                <label>&nbsp;</label>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "236ddaf4c5c933fb3c716c44334da972e22222389257", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
                                                                                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n        </fieldset>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\rabar\OneDrive\Documents\studia\semestr 6\KSR\plikiLabDocker\AssemblyCardsSystem\AssemblyCardsSystem.Web\Views\Home\Edit.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CardsResource> Html { get; private set; }
    }
}
#pragma warning restore 1591
