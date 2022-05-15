#pragma checksum "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01bd459658584e87262558bd8975dc5d1a246194"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UserInvoce), @"mvc.1.0.view", @"/Views/Home/UserInvoce.cshtml")]
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
#line 1 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\_ViewImports.cshtml"
using Pharmavite_Saja;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\_ViewImports.cshtml"
using Pharmavite_Saja.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01bd459658584e87262558bd8975dc5d1a246194", @"/Views/Home/UserInvoce.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f62db154377536d7a6041b1a58142620cf96a460", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UserInvoce : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Pharmavite_Saja.Models.FinReport>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("later"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml"
  
    ViewData["Title"] = "User Invoice";
    Layout = "~/Views/Shared/_web_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link href=""/css/invoice.css"" rel=""stylesheet"" />
<div class=""row"">
    <div class=""invoice-card"">
        <div class=""invoice-title"">
            <div id=""main-title"">
                <h4>INVOICE</h4>
                <span>#89 292</span>
            </div>
            
            <span id=""date""> ");
#nullable restore
#line 15 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml"
                        Write(DateTime.Today);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
        </div>

        <div class=""invoice-details"">
            <table class=""invoice-table"">
                <thead>
                    <tr>
                        <td>PRODUCT</td>
                        <td>UNIT</td>
                        <td>PRICE</td>
                    </tr>
                </thead>
");
#nullable restore
#line 27 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml"
                    double total = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tbody>\r\n");
#nullable restore
#line 29 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml"
                     foreach (var fin in Model)
                    {
                        total += (double) (fin.ProductOrderQty * fin.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("                         <tr class=\"row-data\">\r\n                            <td> ");
#nullable restore
#line 33 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml"
                            Write(fin.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td id=\"unit\"> ");
#nullable restore
#line 34 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml"
                                      Write(fin.ProductOrderQty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td> ");
#nullable restore
#line 35 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml"
                            Write(fin.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 37 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <tr class=\"calc-row\">\r\n                        <td colspan=\"2\">Total</td>\r\n                        <td>");
#nullable restore
#line 41 "C:\Users\sajam\Desktop\First Project\project\Pharmavite_Saja\Pharmavite_Saja\Views\Home\UserInvoce.cshtml"
                       Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n\r\n        <div class=\"invoice-footer\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01bd459658584e87262558bd8975dc5d1a2461948229", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n         </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Pharmavite_Saja.Models.FinReport>> Html { get; private set; }
    }
}
#pragma warning restore 1591
