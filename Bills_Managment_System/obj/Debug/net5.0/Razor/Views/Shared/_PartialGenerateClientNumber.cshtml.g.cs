#pragma checksum "C:\Users\Maged\Desktop\Bills_Managment_System\Bills_Managment_System\Views\Shared\_PartialGenerateClientNumber.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aecccb62131c272d9669d8cd441ab91b7068f002"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PartialGenerateClientNumber), @"mvc.1.0.view", @"/Views/Shared/_PartialGenerateClientNumber.cshtml")]
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
#line 1 "C:\Users\Maged\Desktop\Bills_Managment_System\Bills_Managment_System\Views\_ViewImports.cshtml"
using Bills_Managment_System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Maged\Desktop\Bills_Managment_System\Bills_Managment_System\Views\_ViewImports.cshtml"
using Bills_Managment_System.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aecccb62131c272d9669d8cd441ab91b7068f002", @"/Views/Shared/_PartialGenerateClientNumber.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"925298af047f74f08d5810c4126eb5313fa81e1b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PartialGenerateClientNumber : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<label class=\"col-md-3 label-control\" >Number : </label>\r\n<div class=\"col-md-9\">\r\n    <input");
            BeginWriteAttribute("value", " value=\"", 98, "\"", 121, 1);
#nullable restore
#line 6 "C:\Users\Maged\Desktop\Bills_Managment_System\Bills_Managment_System\Views\Shared\_PartialGenerateClientNumber.cshtml"
WriteAttributeValue("", 106, ViewBag.number, 106, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" for=\"Number\" readonly id=\"Number\" name=\"Number\" type=\"text\"  class=\"form-control\">\r\n    <span  class=\"text-danger\"></span>\r\n                                                            \r\n</div>");
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
