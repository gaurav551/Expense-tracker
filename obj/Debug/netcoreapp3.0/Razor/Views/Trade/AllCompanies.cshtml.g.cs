#pragma checksum "C:\Users\Lenovo\Desktop\ExpenseTracker\Views\Trade\AllCompanies.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd29e8912ba9722aefd0c932089baf8e72ef8731"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trade_AllCompanies), @"mvc.1.0.view", @"/Views/Trade/AllCompanies.cshtml")]
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
#line 1 "C:\Users\Lenovo\Desktop\ExpenseTracker\Views\_ViewImports.cshtml"
using ExpenseTracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\Desktop\ExpenseTracker\Views\_ViewImports.cshtml"
using ExpenseTracker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd29e8912ba9722aefd0c932089baf8e72ef8731", @"/Views/Trade/AllCompanies.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7d2bc418d006ee1a17f8c977b1f7a33b7f0c16f", @"/Views/_ViewImports.cshtml")]
    public class Views_Trade_AllCompanies : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<table class=\"table table-hover table-dark\">\r\n  <thead>\r\n    <tr>\r\n       <th scope=\"col\">Id</th>\r\n     <th scope=\"col\">CompanyName</th>\r\n       <th scope=\"col\">Pan</th>\r\n        <th scope=\"col\">Manage</th>\r\n      \r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n");
#nullable restore
#line 12 "C:\Users\Lenovo\Desktop\ExpenseTracker\Views\Trade\AllCompanies.cshtml"
     foreach(var x in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n      \r\n      <td>");
#nullable restore
#line 16 "C:\Users\Lenovo\Desktop\ExpenseTracker\Views\Trade\AllCompanies.cshtml"
     Write(x.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 17 "C:\Users\Lenovo\Desktop\ExpenseTracker\Views\Trade\AllCompanies.cshtml"
     Write(x.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 18 "C:\Users\Lenovo\Desktop\ExpenseTracker\Views\Trade\AllCompanies.cshtml"
     Write(x.PanNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>  <a class=\" btn btn-danger delete\"\r\n      data-id=\"");
#nullable restore
#line 20 "C:\Users\Lenovo\Desktop\ExpenseTracker\Views\Trade\AllCompanies.cshtml"
          Write(x.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n      data-action=\"DeleteCompany\"\r\n      data-body-message=\"Deleting company will delete all the transaction associated with this company which may affect trade of other companies\"\r\n      data-controller=\"Trade\"> Delete </a>  </td>\r\n\r\n    </tr>\r\n");
#nullable restore
#line 26 "C:\Users\Lenovo\Desktop\ExpenseTracker\Views\Trade\AllCompanies.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("   \r\n  </tbody>\r\n</table>");
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
