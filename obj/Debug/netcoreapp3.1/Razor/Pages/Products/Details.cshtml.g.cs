#pragma checksum "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80ffa62eefae5ae6b79bcbd7019a64ba91c548ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BoOl.Pages.Products.Pages_Products_Details), @"mvc.1.0.razor-page", @"/Pages/Products/Details.cshtml")]
namespace BoOl.Pages.Products
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
#line 1 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\_ViewImports.cshtml"
using BoOl;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80ffa62eefae5ae6b79bcbd7019a64ba91c548ab", @"/Pages/Products/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"995521a2689695e2fc01ba93b66ce32eae21bfbf", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Products_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary mt-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Orders/Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Orders/Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
  
    ViewData["Title"] = @Html.DisplayFor(model => model.Product.SerialNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-4 col-md-3"">
        <div class=""card border border-secondary text-center"">
            <div class=""card-header"">
                Кількість замовлень:
            </div>
            <p class=""font-weight-bold"" style=""font-size:xx-large"">");
#nullable restore
#line 14 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                                                              Write(Model.CountOfOrders);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-8 col-md-9\">\r\n        <div class=\"d-grid gap-2 d-flex justify-content-end\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80ffa62eefae5ae6b79bcbd7019a64ba91c548ab6189", async() => {
                WriteLiteral("<i class=\"fas fa-plus\"> Додати замовлення</i>");
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
#line 19 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                                                                          WriteLiteral(Model.Product.CustomerId);

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
            WriteLiteral(@"
        </div>
    </div>
</div>
<br />
<div class=""row"">
    <div class=""col-12 col-md-4 mt-1"">
        <div class=""card border-dark"">
            <div class=""card-header"">
                <strong>Особиста інформація</strong>
            </div>
            <div class=""card-body"">
                <dl class=""row"">
                    <dt class=""col-6"">
                        Власник:
                    </dt>
                    <dd class=""col-6"">
                        ");
#nullable restore
#line 36 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Product.Customer.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 36 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                                                                              Write(Html.DisplayFor(model => model.Product.Customer.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 36 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                                                                                                                                          Write(Html.DisplayFor(model => model.Product.Customer.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-6\">\r\n                        Серійний номер:\r\n                    </dt>\r\n                    <dd class=\"col-6\">\r\n                        ");
#nullable restore
#line 43 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Product.SerialNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-6\">\r\n                        Модель:\r\n                    </dt>\r\n                    <dd class=\"col-6\">\r\n                        ");
#nullable restore
#line 50 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Product.Model.Manufacturer));

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 50 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                                                                                Write(Html.DisplayFor(model => model.Product.Model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-6\">\r\n                        Додаткова інформація:\r\n                    </dt>\r\n                    <dd class=\"col-6\">\r\n                        ");
#nullable restore
#line 57 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Product.AdditionalInf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n            <div class=\"card-footer d-grid gap-2 d-flex justify-content-end\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80ffa62eefae5ae6b79bcbd7019a64ba91c548ab11972", async() => {
                WriteLiteral("<i class=\"far fa-edit\"> Редагувати</i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                                                                         WriteLiteral(Model.Product.Id);

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
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80ffa62eefae5ae6b79bcbd7019a64ba91c548ab14288", async() => {
                WriteLiteral("<i class=\"far fa-trash-alt\"> Видалити</i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                                                                        WriteLiteral(Model.Product.Id);

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
            WriteLiteral(@"
            </div>
        </div>
    </div>

    <div class=""col-12 col-md-8 mt-1"">
        <div class=""card border-dark"">
            <div class=""card-header"">
                <strong>Замовлення</strong>
            </div>
            <div class=""card-body"">
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>
                                Статус
                            </th>
                            <th>
                                Оплачено
                            </th>
                            <th>
                                Сума
                            </th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 89 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                         foreach (var item in Model.Product.Orders)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 93 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 96 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Payment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    \r\n                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80ffa62eefae5ae6b79bcbd7019a64ba91c548ab18673", async() => {
                WriteLiteral("<i class=\"fas fa-info\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 102 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                                                                    WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 105 "D:\University\4thYear\TermPaper\BoOl\BoOl\Pages\Products\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BoOl.Pages.Products.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BoOl.Pages.Products.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BoOl.Pages.Products.DetailsModel>)PageContext?.ViewData;
        public BoOl.Pages.Products.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
