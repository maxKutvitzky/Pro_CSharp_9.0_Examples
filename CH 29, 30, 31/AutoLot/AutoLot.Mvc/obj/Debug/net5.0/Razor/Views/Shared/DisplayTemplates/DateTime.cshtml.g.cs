#pragma checksum "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\Shared\DisplayTemplates\DateTime.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e24298405f228bb7e8a7b2ff7dc905040400cb61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_DisplayTemplates_DateTime), @"mvc.1.0.view", @"/Views/Shared/DisplayTemplates/DateTime.cshtml")]
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
#line 1 "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\_ViewImports.cshtml"
using AutoLot.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\_ViewImports.cshtml"
using AutoLot.Mvc.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\_ViewImports.cshtml"
using AutoLot.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e24298405f228bb7e8a7b2ff7dc905040400cb61", @"/Views/Shared/DisplayTemplates/DateTime.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cdcf4250e50fe4187055d35dad8aa6ffcd4328b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_DisplayTemplates_DateTime : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DateTime?>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\Shared\DisplayTemplates\DateTime.cshtml"
 if (Model == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            WriteLiteral("Unknown\r\n");
#nullable restore
#line 5 "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\Shared\DisplayTemplates\DateTime.cshtml"
}
else
{
    if (ViewData.ModelMetadata.IsNullableValueType)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
#nullable restore
#line 10 "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\Shared\DisplayTemplates\DateTime.cshtml"
      Write(Model.Value.ToString("d"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\Shared\DisplayTemplates\DateTime.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
#nullable restore
#line 14 "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\Shared\DisplayTemplates\DateTime.cshtml"
      Write(((DateTime)Model).ToString("d"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 15 "D:\UNIVER\#\Pro C# 9.0\CH 29, 30, 31\AutoLot\AutoLot.Mvc\Views\Shared\DisplayTemplates\DateTime.cshtml"
    }
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DateTime?> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591