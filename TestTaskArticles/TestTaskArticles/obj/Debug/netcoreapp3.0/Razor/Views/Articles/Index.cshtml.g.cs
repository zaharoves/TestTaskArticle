#pragma checksum "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6f2262c2e6b390b128b6690ffab06ea3e3bc7f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Articles_Index), @"mvc.1.0.view", @"/Views/Articles/Index.cshtml")]
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
#line 1 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\_ViewImports.cshtml"
using TestTaskArticles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\_ViewImports.cshtml"
using TestTaskArticles.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6f2262c2e6b390b128b6690ffab06ea3e3bc7f1", @"/Views/Articles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d14c28ac9b05d87df4ab23715c0ead0874c0e2a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Articles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TestTaskArticles.Models.ArticlesModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Список статей</h1>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>№</th>\r\n            <th>Текст статьи</th>\r\n            <th>Детали</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 13 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
         foreach (var item in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 17 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 19 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
                 if (item.Text.Length <= 350)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 21 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>");
#nullable restore
#line 21 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
                                       ;
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
                 if (item.Text.Length > 350)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 25 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
                   Write(String.Format("{0}...", @item.Text.Substring(0, 349)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>");
#nullable restore
#line 25 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
                                                                                   ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>");
#nullable restore
#line 28 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
               Write(Html.ActionLink("Читать", "ArticleDetails", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 30 "C:\Users\eszah\source\repos\TestTaskArticles\TestTaskArticles\Views\Articles\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TestTaskArticles.Models.ArticlesModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
