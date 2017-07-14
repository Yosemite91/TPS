<!DOCTYPE html>
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
    <!-- Navigation -->
    <a id="menu-toggle" href="#" class="btn btn-dark btn-lg toggle">
        <i class="glyphicon glyphicon-menu-hamburger"></i>
    </a>
    <nav id="sidebar-wrapper">
        <ul class="sidebar-nav">
            <a id="menu-close" href="#" class="btn btn-light btn-lg pull-right toggle">
                <i class="glyphicon glyphicon-remove"> </i>
            </a>
            <li class="sidebar-brand">
                @Html.ActionLink("Inicio", "Index", "Index")
                @*<a href="#top" onclick=$("#menu-close").click();>Start Bootstrap</a>*@
            </li>
            @* TIENE SESIÓN *@
            <!-- ko if: Token !== null -->
            <li>
                @Html.ActionLink("Perfil", "MiPerfil", "Usuarios")
                @*<a href="#top" onclick=$("#menu-close").click();>Start Bootstrap</a>*@                
            </li>
            <!-- /ko -->
            @* ADMINISTRADOR O ADMIN-PUBLICACION *@
            <!-- ko if: esAdministrador === 'true' || esAdminPublicacion === 'true' -->
            <li>                
                @Html.ActionLink("Usuarios", "ListaUsuarios", "Usuarios")
                @*<a href="#top" onclick=$("#menu-close").click();>Home</a>*@                
            </li>
            <!-- /ko -->
            <li>
                @Html.ActionLink("Eventos", "ListaPublicacionEventos", "PublicacionEventos")
                @*<a href="#about" onclick=$("#menu-close").click();>About</a>*@
            </li>
            <li>
                @Html.ActionLink("Noticias", "ListaPublicacionNoticias", "PublicacionNoticias")
                @*<a href="#services" onclick=$("#menu-close").click();>Services</a>*@
            </li>            
            @* ADMINISTRADOR O ADMIN-PUBLICACION *@
            <!-- ko if: esAdministrador === 'true' || esAdminPublicacion === 'true' -->
            <li>
                @Html.ActionLink("Reuniones", "ListaReuniones", "Reuniones")
                @*<a href="#top" onclick=$("#menu-close").click();>Home</a>*@
            </li>
            <!-- /ko -->
            <!-- ko if: Token === null -->
            <li>
                @Html.ActionLink("Iniciar Sesión", "Login", "Login")
                @*<a href="#portfolio" onclick=$("#menu-close").click();>Portfolio</a>*@
            </li>
            <!-- /ko -->
            <!-- ko if: Token !== null -->
            <li>
                <a href="#" onClick="Salir();"> Cerrar Sesión</a>
                @*<a href="#contact" onclick=$("#menu-close").click();>Contact</a>*@
            </li>            
            <!-- /ko -->
        </ul>
    </nav>
    
    <div class="container body-content">
        @RenderBody()        
    </div>

    @*Footer*@
    <footer>
        <div class="container">
            <div class="row">
                <hr class="small">
                <p id="footerTexto">&copy; @DateTime.Now.Year - Arica, Chile</p>
            </div>
        </div>
        <a id="to-top" href="#top" class="btn btn-dark btn-lg">
            <i class="glyphicon glyphicon-chevron-up"></i>
        </a>
    </footer>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/knockout")
    @Scripts.Render("~/bundles/devextreme")
    @Scripts.Render("~/bundles/app")

    @* LOGIN *@
    <script>
        esAdministrador = App.esAdministrador;
        esAdminPublicacion = App.esAdminPublicacion;

        App.apiRoot = '@Url.Content("~/")api/';
        App.appRoot = '@Url.Content("~/")';
        var Token = localStorage.getItem(App.appPrefix + 'login.token');

        function Salir(){
            App.goToLogin();
        }

        // Closes the sidebar menu
        $("#menu-close").click(function (e) {
            e.preventDefault();
            $("#sidebar-wrapper").toggleClass("active");
        });
        //Opens the sidebar menu
        $("#menu-toggle").click(function (e) {
            e.preventDefault();
            $("#sidebar-wrapper").toggleClass("active");
        });
        // Scrolls to the selected menu item on the page
        $(function () {
            $('a[href*=#]:not([href=#],[data-toggle],[data-target],[data-slide])').click(function () {
                if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') || location.hostname == this.hostname) {
                    var target = $(this.hash);
                    target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                    if (target.length) {
                        $('html,body').animate({
                            scrollTop: target.offset().top
                        }, 1000);
                        return false;
                    }
                }
            });
        });
        //#to-top button appears after scrolling
        var fixed = false;
        $(document).scroll(function () {
            if ($(this).scrollTop() > 250) {
                if (!fixed) {
                    fixed = true;
                    // $('#to-top').css({position:'fixed', display:'block'});
                    $('#to-top').show("slow", function () {
                        $('#to-top').css({
                            position: 'fixed',
                            display: 'block'
                        });
                    });
                }
            } else {
                if (fixed) {
                    fixed = false;
                    $('#to-top').hide("slow", function () {
                        $('#to-top').css({
                            display: 'none'
                        });
                    });
                }
            }
        });
    </script>
    
    @RenderSection("scripts", required:=False)
</body>
</html>
