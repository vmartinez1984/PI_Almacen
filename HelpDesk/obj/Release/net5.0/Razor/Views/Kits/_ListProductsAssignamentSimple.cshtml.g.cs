#pragma checksum "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63da1081d8b7bffdf60c7c53aac95fef9e67e328"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kits__ListProductsAssignamentSimple), @"mvc.1.0.view", @"/Views/Kits/_ListProductsAssignamentSimple.cshtml")]
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
#line 1 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\_ViewImports.cshtml"
using HelpDesk;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\_ViewImports.cshtml"
using HelpDesk.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63da1081d8b7bffdf60c7c53aac95fef9e67e328", @"/Views/Kits/_ListProductsAssignamentSimple.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52c247f7295ac14acf1ea99fed5a7a4fde8a5af2", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Kits__ListProductsAssignamentSimple : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HelpDesk.Models.ProductAssignmentEntity>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 7 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 10 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
           Write(Html.DisplayNameFor(model => model.PersonId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
           Write(Html.DisplayNameFor(model => model.DateAssignment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
           Write(Html.DisplayNameFor(model => model.DateRegistration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 21 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 25 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
               Write(Html.DisplayFor(modelItem => item.Product.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 28 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
               Write(Html.DisplayFor(modelItem => item.Person.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 31 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateAssignment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateRegistration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 37 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\HelpDesk\Views\Kits\_ListProductsAssignamentSimple.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HelpDesk.Models.ProductAssignmentEntity>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
