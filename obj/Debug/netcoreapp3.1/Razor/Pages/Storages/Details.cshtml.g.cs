#pragma checksum "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84929a4a910d3de64ddc9dc7f516aefc5a082e25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BoOl.Pages.Storages.Pages_Storages_Details), @"mvc.1.0.razor-page", @"/Pages/Storages/Details.cshtml")]
namespace BoOl.Pages.Storages
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
#line 1 "D:\University\TermPaper\BoOl\BoOl\Pages\_ViewImports.cshtml"
using BoOl;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84929a4a910d3de64ddc9dc7f516aefc5a082e25", @"/Pages/Storages/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"995521a2689695e2fc01ba93b66ce32eae21bfbf", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Storages_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Ви дійсно хочете видалити дане постачання?\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
  
    ViewData["Title"] = @Html.DisplayFor(model => model.Storage.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-3""></div>
    <div class=""col-12 col-md-6 mt-1"">
        <div class=""card border-dark"">
            <div class=""card-header"">
                <strong>Інформація про постачання</strong>
            </div>
            <div class=""card-body"">
                <dl class=""row"">
                    <dt class=""col-4"">
                        Назва:
                    </dt>
                    <dd class=""col-8"">
                        ");
#nullable restore
#line 21 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Storage.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-4\">\r\n                        Виробник:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 27 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Storage.Manufacturer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-4\">\r\n                        Модель:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 33 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Storage.Model.Manufacturer));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 33 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                                                                               Write(Html.DisplayFor(model => model.Storage.Model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-4\">\r\n                        Кількість:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 39 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Storage.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-4\">\r\n                        Закупівельна ціна:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 45 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Storage.PurchasePrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-4\">\r\n                        Оптова ціна:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 51 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Storage.WholesalePrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-4\">\r\n                        Роздрібна ціна:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 57 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Storage.RetailPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-4\">\r\n                        Співробітник:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 63 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Storage.Worker.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 63 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.Storage.Worker.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-4\">\r\n                        Дата прибуття:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 69 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Storage.DateOfArrival));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n            <div class=\"card-footer d-grid gap-2 d-flex justify-content-end\">\r\n");
#nullable restore
#line 74 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                 if ((User.IsInRole("Owner") || (User.IsInRole("Storekeeper"))))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84929a4a910d3de64ddc9dc7f516aefc5a082e2510794", async() => {
                WriteLiteral("<i class=\"far fa-edit\"> Редагувати</i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                                                                             WriteLiteral(Model.Storage.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84929a4a910d3de64ddc9dc7f516aefc5a082e2513110", async() => {
                WriteLiteral("<i class=\"far fa-trash-alt\"> Видалити</i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 77 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                                                                                                       WriteLiteral(Model.Storage.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 78 "D:\University\TermPaper\BoOl\BoOl\Pages\Storages\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-3\"></div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BoOl.Pages.Storages.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BoOl.Pages.Storages.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BoOl.Pages.Storages.DetailsModel>)PageContext?.ViewData;
        public BoOl.Pages.Storages.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
