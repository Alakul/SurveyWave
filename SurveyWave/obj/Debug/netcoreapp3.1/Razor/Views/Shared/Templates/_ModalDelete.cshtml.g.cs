#pragma checksum "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_ModalDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f801535014b7e1a9f8d87e7a5c9f83e0e7965724"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Templates__ModalDelete), @"mvc.1.0.view", @"/Views/Shared/Templates/_ModalDelete.cshtml")]
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
#line 1 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\_ViewImports.cshtml"
using SurveyWave;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\_ViewImports.cshtml"
using SurveyWave.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f801535014b7e1a9f8d87e7a5c9f83e0e7965724", @"/Views/Shared/Templates/_ModalDelete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ad8f9b2ac1be452f4567cdca51b7ef10888c46", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Templates__ModalDelete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 23, "\"", 46, 2);
            WriteAttributeValue("", 28, "deleteModal_", 28, 12, true);
#nullable restore
#line 1 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_ModalDelete.cshtml"
WriteAttributeValue("", 40, Model, 40, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-labelledby=""deleteModalLabel"" aria-hidden=""true"">
  <div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <h5 class=""modal-title"" id=""deleteModalLabel"">Usuń element</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
          <span aria-hidden=""true"">&times;</span>
        </button>
      </div>
      <div class=""modal-body"">
        Czy na pewno usunąć element?
      </div>
      <div class=""modal-footer"">
        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Anuluj</button>
        <button type=""button"" class=""btn btn-primary"">Usuń</button>
      </div>
    </div>
  </div>
</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
