﻿<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - UTA Emprendedoras</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Asociación de Emprendedoras", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Inicio", "Index", "Home")</li>
                    <li>@Html.ActionLink("Acerca de", "About", "Home")</li>
                    <li>@Html.ActionLink("Contacto", "Contact", "Home")</li>
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p id="footerTexto">&copy; @DateTime.Now.Year - Asociación de Emprendedoras - Arica</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/knockout")
    @Scripts.Render("~/bundles/devextreme")
    @Scripts.Render("~/bundles/app")

    @* LOGIN *@
    <script>
        esAdminSistema = App.esAdminSistema;
        esAdminPublicacion = App.esAdminPublicacion;

        App.apiRoot = '@Url.Content("~/")api/';
        App.appRoot = '@Url.Content("~/")';
        var Token = localStorage.getItem(App.appPrefix + 'login.token');

        function Salir(){
            App.goToLogin();
        }
    </script>
    
    @RenderSection("scripts", required:=False)
</body>
</html>
