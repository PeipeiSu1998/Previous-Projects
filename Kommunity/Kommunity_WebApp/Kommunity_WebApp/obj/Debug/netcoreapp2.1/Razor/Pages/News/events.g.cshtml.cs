#pragma checksum "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\News\events.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67d5d76a0f08f639f81c6f0153900a75b18efef0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Kommunity_WebApp.Pages.News.Pages_News_events), @"mvc.1.0.razor-page", @"/Pages/News/events.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/News/events.cshtml", typeof(Kommunity_WebApp.Pages.News.Pages_News_events), null)]
namespace Kommunity_WebApp.Pages.News
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\_ViewImports.cshtml"
using Kommunity_WebApp;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67d5d76a0f08f639f81c6f0153900a75b18efef0", @"/Pages/News/events.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b254aff7ccfe927781fdef2444f7a13f7718cf1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_News_events : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\News\events.cshtml"
  
    ViewData["Title"] = "events";

#line default
#line hidden
            BeginContext(97, 220, true);
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <!-- Blog Entries Column -->\r\n        <div class=\"col-md-12\">\r\n            <br />\r\n            <br />\r\n            <h1>Events</h1>\r\n            <!-- Blog Post -->\r\n");
            EndContext();
#line 14 "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\News\events.cshtml"
             foreach (var item in Model.events)
            {

#line default
#line hidden
            BeginContext(381, 236, true);
            WriteLiteral("                <div class=\"card mb-4\">\r\n                    <img class=\"card-img-top\" src=\"http://placehold.it/750x300\" alt=\"Card image cap\">\r\n                    <div class=\"card-body\">\r\n                        <h2 class=\"card-title\">");
            EndContext();
            BeginContext(618, 9, false);
#line 19 "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\News\events.cshtml"
                                          Write(item.type);

#line default
#line hidden
            EndContext();
            BeginContext(627, 54, true);
            WriteLiteral("</h2>\r\n                        <h4 class=\"card-title\">");
            EndContext();
            BeginContext(682, 9, false);
#line 20 "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\News\events.cshtml"
                                          Write(item.city);

#line default
#line hidden
            EndContext();
            BeginContext(691, 52, true);
            WriteLiteral("</h4>\r\n                        <p class=\"card-text\">");
            EndContext();
            BeginContext(744, 12, false);
#line 21 "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\News\events.cshtml"
                                        Write(item.content);

#line default
#line hidden
            EndContext();
            BeginContext(756, 158, true);
            WriteLiteral("</p> <a href=\"#\" class=\"btn btn-primary\">Read More &rarr;</a>\r\n                    </div>\r\n                    <div class=\"card-footer text-muted\"> Posted on ");
            EndContext();
            BeginContext(915, 9, false);
#line 23 "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\News\events.cshtml"
                                                              Write(item.city);

#line default
#line hidden
            EndContext();
            BeginContext(924, 16, true);
            WriteLiteral(" by <a href=\"#\">");
            EndContext();
            BeginContext(941, 17, false);
#line 23 "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\News\events.cshtml"
                                                                                        Write(item.creator.name);

#line default
#line hidden
            EndContext();
            BeginContext(958, 37, true);
            WriteLiteral("</a> </div>\r\n                </div>\r\n");
            EndContext();
#line 25 "D:\Third Semester\SEP\SEP3_KommunitySystem\System\Kommunity_WebApp\Kommunity_WebApp\Pages\News\events.cshtml"
            }

#line default
#line hidden
            BeginContext(1010, 359, true);
            WriteLiteral(@"           
            <!-- Pagination -->
            <ul class=""pagination justify-content-center mb-4"">
                <li class=""page-item""> <a class=""page-link"" href=""#"">&larr; Older</a> </li>
                <li class=""page-item disabled""> <a class=""page-link"" href=""#"">Newer &rarr;</a> </li>
            </ul>
        </div>
    </div>
</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Kommunity_WebApp.Pages.News.eventsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Kommunity_WebApp.Pages.News.eventsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Kommunity_WebApp.Pages.News.eventsModel>)PageContext?.ViewData;
        public Kommunity_WebApp.Pages.News.eventsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
