#pragma checksum "C:\Users\avram\RiderProjects\WebApplication\WebApplication\Views\Round\CreateRound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7965e4b5a754851638189d104b1bde400c1ed508"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Round_CreateRound), @"mvc.1.0.view", @"/Views/Round/CreateRound.cshtml")]
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
#line 1 "C:\Users\avram\RiderProjects\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\avram\RiderProjects\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7965e4b5a754851638189d104b1bde400c1ed508", @"/Views/Round/CreateRound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa0ef8da47a84ffb33e8bc853509aa4fa5703a26", @"/Views/_ViewImports.cshtml")]
    public class Views_Round_CreateRound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("teacherTable"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\avram\RiderProjects\WebApplication\WebApplication\Views\Round\CreateRound.cshtml"
  
    ViewData["Title"] = "Current pending items";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1>Create Rubric</h1>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7965e4b5a754851638189d104b1bde400c1ed5084383", async() => {
                WriteLiteral(@"
    <div class=""input-group mb-3"">
        <div class=""input-group-prepend"">
            <span class=""input-group-text"" id=""basic-addon1"">Deadline: </span>
        </div>
        <input type=""date"" name=""roundDeadline"" class=""form-control"" placeholder=""Deadline"" aria-label=""Deadline"" aria-describedby=""basic-addon1"">
        <div class=""input-group-prepend ml-3"">
            <span class=""input-group-text"" id=""basic-addon1"">Module: </span>
        </div>
        <select class=""form-control"" name=""moduleName"">
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7965e4b5a754851638189d104b1bde400c1ed5085204", async() => {
                    WriteLiteral("Romanian");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7965e4b5a754851638189d104b1bde400c1ed5086232", async() => {
                    WriteLiteral("Maths");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7965e4b5a754851638189d104b1bde400c1ed5087257", async() => {
                    WriteLiteral("Network and Security");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        </select>
    </div>
    <div class=""row mt-4"">
        <div class=""col"">
            <table class=""table table-bordered"">
                <input type=""hidden"" name=""tableLength"" value=""5""/>
                <input type=""hidden"" name=""tableWidth"" value=""3""/>

                <thead>
                <tr class=""table-success"">
                    <th scope=""col""></th>
                    <th scope=""col"">1</th>
                    <th scope=""col"">2</th>
                    <th scope=""col"">3</th>
                    <th scope=""col"">4</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <th scope=""row"" class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row1col1""></textarea>
                        </div>
                    </th>
                    <td class");
                WriteLiteral(@"=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row1col2""></textarea>
                        </div>
                    </td>
                    <td class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row1col3""></textarea>
                        </div>
                    </td>
                    <td class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" name=""row1col4"" rows=""3""></textarea>
                        </div>
                    </td>
                    <td class=""rubric-item"">
                        <!--Material text");
                WriteLiteral(@"area-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3""  name=""row1col5"" ></textarea>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th scope=""row"" class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row2col1""></textarea>
                        </div>
                    </th>
                    <td class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row2col2""></textarea>
                        </div>
                    </td>
                    <td class=""rubric-item"">
                        <!--Material tex");
                WriteLiteral(@"tarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row2col3""></textarea>
                        </div>
                    </td>
                    <td class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row2col4"" ></textarea>
                        </div>
                    </td>
                    <td class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" name=""row2col5""></textarea>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th scope=""row"" class=""rubric-item"">
                        <!--Material textarea-->
                WriteLiteral(@"
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row3col1""></textarea>
                            <input type=""hidden"" name=""thirdRowCol1""/>
                        </div>
                    </th>
                    <td class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row3col2""></textarea>
                        </div>
                    </td>
                    <td class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row3col3""></textarea>
                        </div>
                    </td>
                    <td class=""rubric-item"">
                        <!--Materia");
                WriteLiteral(@"l textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row3col4""></textarea>
                        </div>
                    </td>
                    <td class=""rubric-item"">
                        <!--Material textarea-->
                        <div class=""md-form"">
                            <textarea id=""form7"" class=""md-textarea form-control"" rows=""3"" name=""row3col5""></textarea>
                        </div>
                    </td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
    <button type=""submit"" class=""btn btn-primary float-right mr-3"" id=""createRubric"">Create</button>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 8 "C:\Users\avram\RiderProjects\WebApplication\WebApplication\Views\Round\CreateRound.cshtml"
AddHtmlAttributeValue("", 213, Url.Action("SubmitRound", "Round"), 213, 35, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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