#pragma checksum "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f52a38750041a77631a7edb8a8cfc9391aa6a461"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Staffs_Details), @"mvc.1.0.view", @"/Views/Staffs/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Staffs/Details.cshtml", typeof(AspNetCore.Views_Staffs_Details))]
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
#line 1 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\_ViewImports.cshtml"
using FlowAuth;

#line default
#line hidden
#line 2 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\_ViewImports.cshtml"
using FlowAuth.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f52a38750041a77631a7edb8a8cfc9391aa6a461", @"/Views/Staffs/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89129962b79090d0f1ae5f5d5048e447eef01cf2", @"/Views/_ViewImports.cshtml")]
    public class Views_Staffs_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FlowAuth.Models.Staff>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(75, 119, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Staff</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(195, 43, false);
#line 14 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StaffID));

#line default
#line hidden
            EndContext();
            BeginContext(238, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(282, 39, false);
#line 17 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.StaffID));

#line default
#line hidden
            EndContext();
            BeginContext(321, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(365, 46, false);
#line 20 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_type));

#line default
#line hidden
            EndContext();
            BeginContext(411, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(455, 42, false);
#line 23 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_type));

#line default
#line hidden
            EndContext();
            BeginContext(497, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(541, 50, false);
#line 26 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_fullName));

#line default
#line hidden
            EndContext();
            BeginContext(591, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(635, 46, false);
#line 29 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_fullName));

#line default
#line hidden
            EndContext();
            BeginContext(681, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(725, 50, false);
#line 32 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_position));

#line default
#line hidden
            EndContext();
            BeginContext(775, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(819, 46, false);
#line 35 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_position));

#line default
#line hidden
            EndContext();
            BeginContext(865, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(909, 52, false);
#line 38 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_emp_nature));

#line default
#line hidden
            EndContext();
            BeginContext(961, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1005, 48, false);
#line 41 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_emp_nature));

#line default
#line hidden
            EndContext();
            BeginContext(1053, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1097, 50, false);
#line 44 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_res_addr));

#line default
#line hidden
            EndContext();
            BeginContext(1147, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1191, 46, false);
#line 47 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_res_addr));

#line default
#line hidden
            EndContext();
            BeginContext(1237, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1281, 51, false);
#line 50 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_cellphone));

#line default
#line hidden
            EndContext();
            BeginContext(1332, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1376, 47, false);
#line 53 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_cellphone));

#line default
#line hidden
            EndContext();
            BeginContext(1423, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1467, 47, false);
#line 56 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_email));

#line default
#line hidden
            EndContext();
            BeginContext(1514, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1558, 43, false);
#line 59 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_email));

#line default
#line hidden
            EndContext();
            BeginContext(1601, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1645, 45, false);
#line 62 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_DOB));

#line default
#line hidden
            EndContext();
            BeginContext(1690, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1734, 41, false);
#line 65 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_DOB));

#line default
#line hidden
            EndContext();
            BeginContext(1775, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1819, 49, false);
#line 68 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_country));

#line default
#line hidden
            EndContext();
            BeginContext(1868, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1912, 45, false);
#line 71 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_country));

#line default
#line hidden
            EndContext();
            BeginContext(1957, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2001, 47, false);
#line 74 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_idNum));

#line default
#line hidden
            EndContext();
            BeginContext(2048, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2092, 43, false);
#line 77 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_idNum));

#line default
#line hidden
            EndContext();
            BeginContext(2135, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2179, 50, false);
#line 80 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_passport));

#line default
#line hidden
            EndContext();
            BeginContext(2229, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2273, 46, false);
#line 83 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_passport));

#line default
#line hidden
            EndContext();
            BeginContext(2319, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2363, 51, false);
#line 86 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_incomeTax));

#line default
#line hidden
            EndContext();
            BeginContext(2414, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2458, 47, false);
#line 89 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_incomeTax));

#line default
#line hidden
            EndContext();
            BeginContext(2505, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2549, 52, false);
#line 92 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_medicalAid));

#line default
#line hidden
            EndContext();
            BeginContext(2601, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2645, 48, false);
#line 95 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_medicalAid));

#line default
#line hidden
            EndContext();
            BeginContext(2693, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2737, 54, false);
#line 98 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_medicalAidNo));

#line default
#line hidden
            EndContext();
            BeginContext(2791, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2835, 50, false);
#line 101 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_medicalAidNo));

#line default
#line hidden
            EndContext();
            BeginContext(2885, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2929, 54, false);
#line 104 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_nextKin_name));

#line default
#line hidden
            EndContext();
            BeginContext(2983, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3027, 50, false);
#line 107 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_nextKin_name));

#line default
#line hidden
            EndContext();
            BeginContext(3077, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3121, 59, false);
#line 110 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_nextKin_cellphone));

#line default
#line hidden
            EndContext();
            BeginContext(3180, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3224, 55, false);
#line 113 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_nextKin_cellphone));

#line default
#line hidden
            EndContext();
            BeginContext(3279, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3323, 46, false);
#line 116 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_rate));

#line default
#line hidden
            EndContext();
            BeginContext(3369, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3413, 42, false);
#line 119 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_rate));

#line default
#line hidden
            EndContext();
            BeginContext(3455, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3499, 51, false);
#line 122 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_leaveDays));

#line default
#line hidden
            EndContext();
            BeginContext(3550, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3594, 47, false);
#line 125 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_leaveDays));

#line default
#line hidden
            EndContext();
            BeginContext(3641, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3685, 49, false);
#line 128 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Staff_lastDay));

#line default
#line hidden
            EndContext();
            BeginContext(3734, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3778, 45, false);
#line 131 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
       Write(Html.DisplayFor(model => model.Staff_lastDay));

#line default
#line hidden
            EndContext();
            BeginContext(3823, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(3870, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f53e2a29479f4b349ad811b5751fb8f8", async() => {
                BeginContext(3921, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 136 "C:\Users\stsplanet\source\repos\Project day\FlowAuth\FlowAuth\Views\Staffs\Details.cshtml"
                           WriteLiteral(Model.StaffID);

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
            BeginContext(3929, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(3937, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e3010e8dad240b296439641d8e6922c", async() => {
                BeginContext(3959, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3975, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FlowAuth.Models.Staff> Html { get; private set; }
    }
}
#pragma warning restore 1591
