#pragma checksum "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "772dee68012a79470d325ec542f3dbb77c561332"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BoOl.Pages.Orders.Pages_Orders_Details), @"mvc.1.0.razor-page", @"/Pages/Orders/Details.cshtml")]
namespace BoOl.Pages.Orders
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"772dee68012a79470d325ec542f3dbb77c561332", @"/Pages/Orders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"995521a2689695e2fc01ba93b66ce32eae21bfbf", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Orders_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary mt-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/CustomServices/Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Ви дійсно хочете видалити дане замовлення?\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/CustomServices/Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
  
    ViewData["Title"] = "Order";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-4 col-md-3"">
        <div class=""card border border-secondary text-center"">
            <div class=""card-header"">
                Кількість послуг:
            </div>
            <p class=""font-weight-bold"" style=""font-size:xx-large"">");
#nullable restore
#line 14 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                              Write(Model.CountOfServices);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-8 col-md-9\">\r\n");
#nullable restore
#line 18 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
         if (!User.IsInRole("Administrator"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-grid gap-2 d-flex justify-content-end\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "772dee68012a79470d325ec542f3dbb77c5613327061", async() => {
                WriteLiteral("<i class=\"fas fa-plus\"> Додати послугу</i>");
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
#line 21 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                                      WriteLiteral(Model.Order.Id);

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
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 23 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-12 col-md-6 mt-1\">\r\n        <div class=\"card border-dark\">\r\n            <div class=\"card-header\">\r\n                <strong>Інформація по замовленню №");
#nullable restore
#line 31 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                             Write(Html.DisplayFor(model => model.Order.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong>
            </div>
            <div class=""card-body"">
                <dl class=""row"">
                    <dt class=""col-4"">
                        Клієнт:
                    </dt>
                    <dd class=""col-8"">
                        ");
#nullable restore
#line 39 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Order.Product.Customer.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 39 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                                    Write(Html.DisplayFor(model => model.Order.Product.Customer.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 39 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                                                                                                      Write(Html.DisplayFor(model => model.Order.Product.Customer.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-4\">\r\n                        Техніка:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 45 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Order.Product.Model.Manufacturer));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 45 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                                     Write(Html.DisplayFor(model => model.Order.Product.Model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 45 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                                                                                               Write(Html.DisplayFor(model => model.Order.Product.SerialNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-4\">\r\n                        Оплачено:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 52 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Order.Payment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-4\">\r\n                        Статус:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 59 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Order.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-4\">\r\n                        Знижка:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 66 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Order.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-4\">\r\n                        Дата прийому:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 73 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Order.DateOfAdmission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-4\">\r\n                        Дата видачі:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 80 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Order.DateOfIssue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-4\">\r\n                        Працівник:\r\n                    </dt>\r\n                    <dd class=\"col-8\">\r\n                        ");
#nullable restore
#line 87 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Order.Worker.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 87 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                          Write(Html.DisplayFor(model => model.Order.Worker.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 87 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                                                                                  Write(Html.DisplayFor(model => model.Order.Worker.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n            <div class=\"card-footer d-grid gap-2 d-flex justify-content-end\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "772dee68012a79470d325ec542f3dbb77c56133216206", async() => {
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
#line 92 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                         WriteLiteral(Model.Order.Id);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "772dee68012a79470d325ec542f3dbb77c56133218510", async() => {
                WriteLiteral("<i class=\"far fa-trash-alt\"> Видалити</i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                                                   WriteLiteral(Model.Order.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
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
    <div class=""col-12 col-md-6 mt-1"">
        <div class=""card border-dark"">
            <div class=""card-header"">
                <strong>Послуги</strong>
            </div>
            <div class=""card-body"">
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>
                                Послуга
                            </th>
                            <th>
                                Працівник
                            </th>
                            <th>
                                Дата виконання
                            </th>
                            <th>
                                Зроблено
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 122 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                         foreach (var item in Model.Order.CustomServices)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 126 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Service.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 129 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Worker.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 129 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                                   Write(Html.DisplayFor(modelItem => item.Worker.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 129 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                                                                                                                                        Write(Html.DisplayFor(modelItem => item.Worker.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 132 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ExecutionDate.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 135 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                               Write(Html.DisplayFor(modelItem => item.IsDone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "772dee68012a79470d325ec542f3dbb77c56133224691", async() => {
                WriteLiteral("<i class=\"fas fa-info\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 138 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
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
#line 141 "D:\University\TermPaper\BoOl\BoOl\Pages\Orders\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BoOl.Pages.Orders.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BoOl.Pages.Orders.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BoOl.Pages.Orders.DetailsModel>)PageContext?.ViewData;
        public BoOl.Pages.Orders.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
