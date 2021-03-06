#pragma checksum "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02ff4a6bca0464624d5b7eda74e33364b3a480ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Response_Details), @"mvc.1.0.view", @"/Views/Response/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02ff4a6bca0464624d5b7eda74e33364b3a480ca", @"/Views/Response/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ad8f9b2ac1be452f4567cdca51b7ef10888c46", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Response_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResponseViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
  
	ViewData["Title"] = "Wyniki ankiety";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <div class=\"d-flex justify-content-between\">\r\n        <div class=\"mb-3\">\r\n            <h3 name=\"surveyTitle\" type=\"text\">");
#nullable restore
#line 9 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                                          Write(Model.Survey.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <p>");
#nullable restore
#line 10 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
          Write(Model.Survey.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"text-right\">\r\n            <p>Data opublikowania: <strong>");
#nullable restore
#line 13 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                                      Write(Model.Survey.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n            <p>Status: \r\n");
#nullable restore
#line 15 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                 if (@Model.Survey.Status == "O"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <strong >Otwarta</strong>\r\n");
#nullable restore
#line 17 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                }
                else if (@Model.Survey.Status == "C"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <strong>Zamkni??ta</strong>\r\n");
#nullable restore
#line 20 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </p>\r\n        </div>\r\n    </div>\r\n    <div>\r\n        <hr class=\"mb-0\"/>\r\n        <p class=\"mb-3 mt-3\">Liczba odpowiedzi: <strong>");
#nullable restore
#line 26 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                                                   Write(Model.ResponsesInfo.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n        <hr/>\r\n    </div>\r\n\r\n");
#nullable restore
#line 30 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
     if (@Model.ResponsesInfo.Count != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4 class=\"mb-3 mt-4\">Wyniki</h4>\r\n        <div>\r\n");
#nullable restore
#line 34 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
             for (int i = 0; i < Model.Questions.Count(); i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <table class=\"table table-bordered table-striped table-sm mb-5\">\r\n                    <thead>\r\n                        <tr>\r\n                            <th scope=\"col\" colspan=\"3\"><h5 class=\"m-0\"><strong>");
#nullable restore
#line 39 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                                                                            Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral(". ");
#nullable restore
#line 39 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                                                                                   Write(Model.Questions[i].Text);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></h5></th>
                        </tr>
                        <tr>
                            <th>Nr</th>
                            <th>Tre????</th>
                            <th>Liczba odpowiedzi</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 48 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                         for (int j = 0; j < Model.Questions[i].Answers.Count(); j++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 51 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                                Write(j+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 52 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                               Write(Model.Questions[i].Answers[j].Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 53 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                               Write(Model.Responses.Where(x=>x.Response.AnswerId==@Model.Questions[i].Answers[j].Id).ToList().Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 55 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 58 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 60 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Response\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResponseViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
