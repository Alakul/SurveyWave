#pragma checksum "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9783201ce57c6c3048b240f6052992dd6547b468"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Templates__Pagination), @"mvc.1.0.view", @"/Views/Shared/Templates/_Pagination.cshtml")]
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
#nullable restore
#line 1 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml"
using X.PagedList.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9783201ce57c6c3048b240f6052992dd6547b468", @"/Views/Shared/Templates/_Pagination.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ad8f9b2ac1be452f4567cdca51b7ef10888c46", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Templates__Pagination : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml"
  
    string controllerName = @Model.Item2;
    string actionName = @Model.Item3;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-count text-center mt-3\">\r\n    Strona ");
#nullable restore
#line 13 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml"
       Write(Model.Item1.PageCount < Model.Item1.PageNumber ? 0 : Model.Item1.PageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" z ");
#nullable restore
#line 13 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml"
                                                                                       Write(Model.Item1.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div class=\"me-auto mt-2 d-flex justify-content-center\">\r\n    ");
#nullable restore
#line 16 "C:\Users\alicj\source\repos\ASP.NET Core MVC - SurveyWave\SurveyWave\Views\Shared\Templates\_Pagination.cshtml"
Write(Html.PagedListPager((IPagedList)@Model.Item1, page => 
    Url.Action(@actionName, @controllerName, new { page, id = ViewData["Id"] }), 
    new PagedListRenderOptions {
        LiElementClasses = new string[] { "page-item" },
        PageClasses = new string[] { "page-link" },
    }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
