#pragma checksum "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\Activities\Views\Shared\_Chat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "daf6319524466b4fa3dadf2f6e64dc617da4d71d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Chat), @"mvc.1.0.view", @"/Views/Shared/_Chat.cshtml")]
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
#line 1 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\Activities\Views\_ViewImports.cshtml"
using Activities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vmartinez\source\repos\vmartinez1984\PI_Almacen\Activities\Views\_ViewImports.cshtml"
using Activities.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"daf6319524466b4fa3dadf2f6e64dc617da4d71d", @"/Views/Shared/_Chat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a6eea3e0c48c887bdcba9e9adb4cf8a181ace29", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Chat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""fixed-bottom mb-4 mr-3"">
    <div class=""row"">
        <div class=""col-md-4 offset col-xl-6 offset-sm-6"">
            <div class=""card"">
                <div class=""card-header"">
                    <button class=""btn btn-primary btn-sm"" type=""button"" data-toggle=""collapse"" data-target=""#collapseExample"" aria-expanded=""false"" aria-controls=""collapseExample"">
                        Chat
                    </button>
                </div>
                <div class=""collapse"" id=""collapseExample"">
                    <div class=""card-body"">

                        <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
                            <li class=""nav-item"" role=""presentation"">
                                <a class=""nav-link active"" id=""home-tab"" data-toggle=""tab"" href=""#home"" role=""tab"" aria-controls=""home"" aria-selected=""true"">Lista de usuarios</a>
                            </li>
                            <li class=""nav-item"" role=""presentation"">
                ");
            WriteLiteral(@"                <a class=""nav-link"" id=""profile-tab"" data-toggle=""tab"" href=""#profile"" role=""tab"" aria-controls=""profile"" aria-selected=""false"">
                                    <span id=""userNameDestiny"">Usuario</span>
                                </a>
                            </li>
                        </ul>
                        <div class=""tab-content"" id=""myTabContent"">
                            <div class=""tab-pane fade show active"" id=""home"" role=""tabpanel"" aria-labelledby=""home-tab"">
                                <div class=""card"">
                                <div class=""card-body"">
                                    <div id=""divListUusers""></div>
                                </div>
                                </div>
                            </div>

                            <div class=""tab-pane fade"" id=""profile"" role=""tabpanel"" aria-labelledby=""profile-tab"">
                                <div class=""row"">
                                    <div c");
            WriteLiteral(@"lass=""col"">
                                        <br />
                                        <div class=""card"">
                                            <div id=""divConversation"" class=""card-body"" style=""max-height:350px; overflow-y: auto""></div>
                                        </div>
                                    </div>
                                </div>
                                <div class=""row mt-1"">
                                    <div class=""col-md-8"">
                                        <input type=""text"" maxlength=""250"" class=""form-control"" id=""message"" onkeyup=""onkeyup_detectEnter(event);"" />
                                    </div>
                                    <div class=""col-md-4"">
                                        <input type=""hidden"" id=""userIdSource"" />
                                        <input type=""hidden"" id=""userIdDestiny"" />
                                        <button class=""btn btn-primary btn-block"" onclick=""onc");
            WriteLiteral(@"lick_sendMessage();"">Enviar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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