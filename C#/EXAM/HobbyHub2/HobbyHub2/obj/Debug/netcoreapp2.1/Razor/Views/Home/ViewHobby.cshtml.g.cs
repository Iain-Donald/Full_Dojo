#pragma checksum "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3bd484513992dca713aee8f65839f55079780036"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewHobby), @"mvc.1.0.view", @"/Views/Home/ViewHobby.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ViewHobby.cshtml", typeof(AspNetCore.Views_Home_ViewHobby))]
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
#line 1 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\_ViewImports.cshtml"
using BeltExam3HobbyHub;

#line default
#line hidden
#line 2 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\_ViewImports.cshtml"
using BeltExam3HobbyHub.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bd484513992dca713aee8f65839f55079780036", @"/Views/Home/ViewHobby.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88a3cb8b867e0e1f5ab4d3ce7159d29a65c586fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewHobby : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Hobby>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(14, 61, true);
            WriteLiteral("<h1 class=\"split\">Hobby Hub</h1>\r\n<h4 class=\"split\">Welcome, ");
            EndContext();
            BeginContext(76, 12, false);
#line 3 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml"
                      Write(ViewBag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(88, 135, true);
            WriteLiteral("</h1>\r\n<a href=\"/logout\" class=\"split\"><button>Logout</button></a>\r\n<a href=\"/home\" class=\"split\"><button>Home</button></a>\r\n<hr>\r\n<h1>");
            EndContext();
            BeginContext(224, 10, false);
#line 7 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml"
Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(234, 24, true);
            WriteLiteral("</h1>\r\n<h4>Description: ");
            EndContext();
            BeginContext(259, 17, false);
#line 8 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml"
            Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(276, 36, true);
            WriteLiteral("</h4>\r\n<br>\r\n<h4>Enthusiasts:</h4>\r\n");
            EndContext();
#line 11 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml"
  
    bool alreadyJoined = false;

    foreach (var u in @Model.UsersJoined.OrderByDescending(b => b.User.CreatedAt).ToList())
    {
        if (@u.User.UserId == @ViewBag.loggedInId)
        {
            alreadyJoined = true;
        }

#line default
#line hidden
            BeginContext(560, 12, true);
            WriteLiteral("        <h5>");
            EndContext();
            BeginContext(573, 16, false);
#line 20 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml"
       Write(u.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(589, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(591, 15, false);
#line 20 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml"
                         Write(u.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(606, 7, true);
            WriteLiteral("</h5>\r\n");
            EndContext();
#line 21 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml"
    }
    if (!alreadyJoined)
    {

#line default
#line hidden
            BeginContext(652, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 662, "\"", 688, 2);
#line 24 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml"
WriteAttributeValue("", 669, Model.HobbyId, 669, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 683, "/join", 683, 5, true);
            EndWriteAttribute();
            BeginContext(689, 44, true);
            WriteLiteral("><button>Become an Enthusiast</button></a>\r\n");
            EndContext();
#line 25 "C:\Users\iaind\OneDrive\Documents\DOJO\C#\EXAM\HobbyHub2\HobbyHub2\Views\Home\ViewHobby.cshtml"
    }

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hobby> Html { get; private set; }
    }
}
#pragma warning restore 1591
