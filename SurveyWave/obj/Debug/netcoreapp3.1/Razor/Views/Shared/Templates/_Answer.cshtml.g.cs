#pragma checksum "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Answer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23439088e499974b240e51e8c067f0d89b0e9538"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Templates__Answer), @"mvc.1.0.view", @"/Views/Shared/Templates/_Answer.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23439088e499974b240e51e8c067f0d89b0e9538", @"/Views/Shared/Templates/_Answer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ad8f9b2ac1be452f4567cdca51b7ef10888c46", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Templates__Answer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Answer>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div");
            BeginWriteAttribute("id", " id=\"", 19, "\"", 45, 2);
            WriteAttributeValue("", 24, "answer_", 24, 7, true);
#nullable restore
#line 2 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Answer.cshtml"
WriteAttributeValue("", 31, Model.Index, 31, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"answerRow mb-1 d-flex justify-content-between mt-2\">\r\n    <div class=\"d-flex\">\r\n        <input class=\"mr-3 inputGroup\"");
            BeginWriteAttribute("type", " type=\"", 172, "\"", 210, 1);
#nullable restore
#line 4 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Answer.cshtml"
WriteAttributeValue("", 179, Model.QuestionType.ToLower(), 179, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 211, "\"", 240, 1);
#nullable restore
#line 4 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Answer.cshtml"
WriteAttributeValue("", 219, Model.QuestionType, 219, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div>\r\n            <input class=\"answers form-control form-control-sm border-0\" type=\"text\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 343, "\"", 379, 2);
            WriteAttributeValue("", 357, "Opcja", 357, 5, true);
#nullable restore
#line 6 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Answer.cshtml"
WriteAttributeValue(" ", 362, Model.Index+1, 363, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 380, "\"", 449, 5);
            WriteAttributeValue("", 387, "Questions[", 387, 10, true);
#nullable restore
#line 6 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Answer.cshtml"
WriteAttributeValue("", 397, Model.QuestionIndex, 397, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 419, "].Answers[", 419, 10, true);
#nullable restore
#line 6 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Answer.cshtml"
WriteAttributeValue("", 429, Model.Index, 429, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 443, "].Text", 443, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <span class=\"answerSpan text-danger field-validation-valid\" data-valmsg-for=\"Questions[");
#nullable restore
#line 7 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Answer.cshtml"
                                                                                               Write(Model.QuestionIndex);

#line default
#line hidden
#nullable disable
            WriteLiteral("].Answers[");
#nullable restore
#line 7 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Answer.cshtml"
                                                                                                                               Write(Model.Index);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"].Text""></span>
        </div>     
    </div>
    <div class=""answerButtons form-check"">
        <button type=""button"" class=""answerUp btn btn-light btn-action""><i class=""answerIcon bi bi-arrow-up""></i></button>
        <a href=""#"" class=""deleteAnswer btn btn-light btn-action""><i class=""answerIcon bi bi-trash""></i></a>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Answer> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
