#pragma checksum "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afef14aeef0ecd4fea0fe34bc72f789b716230ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__Layout), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afef14aeef0ecd4fea0fe34bc72f789b716230ae", @"/Areas/Admin/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d587d1119c7c9b37fa9ab078bbcf9a12e73b654", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/defaultUser.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("userpicimg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PasswordChange", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"az\">\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afef14aeef0ecd4fea0fe34bc72f789b716230ae5831", async() => {
                WriteLiteral("\n    <meta charset=\"utf-8\">\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, user-scalable=no\">\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 244, "\"", 254, 0);
                EndWriteAttribute();
                WriteLiteral(">\n    <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 280, "\"", 290, 0);
                EndWriteAttribute();
                WriteLiteral(">\n    <title>Sonsuz Bilgi - Admin</title>\n   ");
#nullable restore
#line 10 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
Write(await Html.PartialAsync("_LayoutCssPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afef14aeef0ecd4fea0fe34bc72f789b716230ae7671", async() => {
                WriteLiteral("\n    <div id=\"wrapper\">\n");
                WriteLiteral("        ");
#nullable restore
#line 15 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
   Write(await Component.InvokeAsync("AdminMenu"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@" 
        <!-- /.navbar-static-side -->

        <div id=""page-wrapper"">
            <div class=""row"">
                <nav class=""navbar navbar-default navbar-static-top"" style=""margin-bottom: 0"">
                    <button class=""menubtn pull-left btn ""><i class=""glyphicon  glyphicon-th""></i></button>
                    <div class=""searchwarpper"">
                        <div class=""input-group searchglobal"">
                            <input type=""text"" class=""form-control"" placeholder=""Search for..."" autofocus>
                            <span class=""input-group-btn"">
                                <button class=""btn btn-default"" type=""button""><i class=""fa fa-search""></i></button>
                            </span>
                        </div>
                    </div>
                    <ul class=""nav navbar-top-links navbar-right"">
                        <li class=""dropdown"">
                            <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""javascript:void(0)""> <i class=""fa ");
                WriteLiteral(@"fa-envelope fa-fw""></i> </a>
                            <ul class=""dropdown-menu dropdown-messages"">
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div> <strong>John Smith</strong> <span class=""pull-right text-muted""> <em>Yesterday</em> </span> </div>
                                        <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eleifend...</div>
                                    </a>
                                </li>
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div> <strong>John Smith</strong> <span class=""pull-right text-muted""> <em>Yesterday</em> </span> </div>
                                        <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eleifend...</div>
                                    </a>
                                </li>
  ");
                WriteLiteral(@"                              <li>
                                    <a href=""javascript:void(0)"">
                                        <div> <strong>John Smith</strong> <span class=""pull-right text-muted""> <em>Yesterday</em> </span> </div>
                                        <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eleifend...</div>
                                    </a>
                                </li>
                                <li> <a class=""text-center"" href=""javascript:void(0)""> <strong>Read All Messages</strong> <i class=""fa fa-angle-right""></i> </a> </li>
                            </ul>
                            <!-- /.dropdown-messages -->
                        </li>
                        <!-- /.dropdown -->
                        <li class=""dropdown"">
                            <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""javascript:void(0)""> <i class=""fa fa-tasks fa-fw""></i> <span class=""count"">9+</span> </a>
              ");
                WriteLiteral(@"              <ul class=""dropdown-menu dropdown-tasks"">
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div>
                                            <p> <strong>Task 1</strong> <span class=""pull-right text-muted"">40% Complete</span> </p>
                                            <div class=""progress progress-striped active"">
                                                <div class=""progress-bar progress-bar-success"" role=""progressbar"" aria-valuenow=""40"" aria-valuemin=""0"" aria-valuemax=""100"" style=""width: 40%""> <span class=""sr-only"">40% Complete (success)</span> </div>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div>
                   ");
                WriteLiteral(@"                         <p> <strong>Task 2</strong> <span class=""pull-right text-muted"">20% Complete</span> </p>
                                            <div class=""progress progress-striped active"">
                                                <div class=""progress-bar progress-bar-info"" role=""progressbar"" aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"" style=""width: 20%""> <span class=""sr-only"">20% Complete</span> </div>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div>
                                            <p> <strong>Task 3</strong> <span class=""pull-right text-muted"">60% Complete</span> </p>
                                            <div class=""progress progress-striped active"">
                                ");
                WriteLiteral(@"                <div class=""progress-bar progress-bar-warning"" role=""progressbar"" aria-valuenow=""60"" aria-valuemin=""0"" aria-valuemax=""100"" style=""width: 60%""> <span class=""sr-only"">60% Complete (warning)</span> </div>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div>
                                            <p> <strong>Task 4</strong> <span class=""pull-right text-muted"">80% Complete</span> </p>
                                            <div class=""progress progress-striped active"">
                                                <div class=""progress-bar progress-bar-danger"" role=""progressbar"" aria-valuenow=""80"" aria-valuemin=""0"" aria-valuemax=""100"" style=""width: 80%""> <span class=""sr-only"">80% Complete (danger)</span> </div>
        ");
                WriteLiteral(@"                                    </div>
                                        </div>
                                    </a>
                                </li>
                                <li> <a class=""text-center"" href=""javascript:void(0)""> <strong>See All Tasks</strong> <i class=""fa fa-angle-right""></i> </a> </li>
                            </ul>
                            <!-- /.dropdown-tasks -->
                        </li>
                        <!-- /.dropdown -->
                        <li class=""dropdown"">
                            <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""javascript:void(0)""> <i class=""fa fa-bell fa-fw""></i> <span class=""count"">1</span> </a>
                            <ul class=""dropdown-menu dropdown-alerts"">
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div> <i class=""fa fa-comment fa-fw""></i> New Comment <span class=""pull-right text-muted small"">4 ");
                WriteLiteral(@"minutes ago</span> </div>
                                    </a>
                                </li>
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div> <i class=""fa fa-twitter fa-fw""></i> 3 New Followers <span class=""pull-right text-muted small"">12 minutes ago</span> </div>
                                    </a>
                                </li>
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div> <i class=""fa fa-envelope fa-fw""></i> Message Sent <span class=""pull-right text-muted small"">4 minutes ago</span> </div>
                                    </a>
                                </li>
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div> <i class=""fa fa-tasks fa-fw""></i> New Task <span class=""pull-right text");
                WriteLiteral(@"-muted small"">4 minutes ago</span> </div>
                                    </a>
                                </li>
                                <li>
                                    <a href=""javascript:void(0)"">
                                        <div> <i class=""fa fa-upload fa-fw""></i> Server Rebooted <span class=""pull-right text-muted small"">4 minutes ago</span> </div>
                                    </a>
                                </li>
                                <li> <a class=""text-center"" href=""javascript:void(0)""> <strong>See All Alerts</strong> <i class=""fa fa-angle-right""></i> </a> </li>
                            </ul>
                            <!-- /.dropdown-alerts -->
                        </li>
                        <!-- /.dropdown -->
");
#nullable restore
#line 138 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
                         if (User.Identity.IsAuthenticated)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <li class=""dropdown"">
                                <a class=""dropdown-toggle userdd"" data-toggle=""dropdown"" href=""javascript:void(0)"">
                                    <div class=""userprofile small "">
                                        <span class=""userpic""> ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "afef14aeef0ecd4fea0fe34bc72f789b716230ae18371", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" </span>\n                                        <div class=\"textcontainer\">\n                                            <h3 class=\"username\">");
#nullable restore
#line 145 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
                                                            Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h3>
                                            <p>Xoş gəldiniz</p>
                                        </div>
                                    </div>
                                    <i class=""caret""></i>
                                </a>

                                <ul class=""dropdown-menu dropdown-user"">
                                    <li> ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afef14aeef0ecd4fea0fe34bc72f789b716230ae20457", async() => {
                    WriteLiteral("<i class=\"fa fa-user fa-fw\"></i> Şəxsi məlumatlar");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" </li>\n                                    <li> ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afef14aeef0ecd4fea0fe34bc72f789b716230ae22189", async() => {
                    WriteLiteral("<i class=\"fa fa-gear fa-fw\"></i> Şifrəni dəyiş");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" </li>\n                                    <li> ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afef14aeef0ecd4fea0fe34bc72f789b716230ae23918", async() => {
                    WriteLiteral("<i class=\"fa fa-sign-out fa-fw\"></i> Çıxış");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" </li>\n                                </ul>\n\n\n                                <!-- /.dropdown-user -->\n                            </li>\r\n");
#nullable restore
#line 161 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        
                        <!-- /.dropdown -->
                    </ul>
                    <!-- /.navbar-top-links -->

                </nav>
            </div>
            <!--<div class=""row"">
            <div class=""col-md-12  header-wrapper"">
                <h1 class=""page-header"">Dashboard</h1>
                <p class=""page-subtitle"">This is amazing template for all type of admin interfaces.</p>
            </div>-->
            <!-- /.col-lg-12 -->
            <!--</div>-->
            <!-- /.row -->
            <!--<ol class=""breadcrumb"">
            <li><a href=""javascript:void(0)"">Admin9</a></li>
            <li class=""active"">Dashboard</li>
        </ol>-->
");
#nullable restore
#line 181 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
             if (TempData["SuccessMessage"] != null)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"alert alert-success mt-2\" role=\"alert\">\r\n                    ");
#nullable restore
#line 184 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
               Write(TempData["SuccessMessage"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 186 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            ");
#nullable restore
#line 188 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            <!-- /.row -->\n        </div>\n        <!-- /#page-wrapper -->\n\n    </div>\n    <!-- /#wrapper -->\n\n\n   ");
#nullable restore
#line 197 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
Write(await Html.PartialAsync("_LayoutJsPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \n   ");
#nullable restore
#line 198 "C:\Users\Tural\source\repos\SonsuzbilgiV2\SonsuzBilgiV2.Mvc\Areas\Admin\Views\Shared\_Layout.cshtml"
Write(await RenderSectionAsync("Scripts",false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>\n");
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
