@Code
    ViewData("Title") = "Emprendedoras"
End Code

@*Header*@
<header id="top" class="header">
    <div class="text-vertical-center">
        <div class="long-title"><h2><strong>
            Asociación de <br />Emprendedoras
        </strong></h2></div>
        <h4>Esfuerzo &amp; Compromiso</h4>
        <br>
        <a href="#about" class="btn btn-dark btn-lg">Conocer más</a>        
    </div>
</header>

@*Motivados por un cambio*@
<section id="about" class="about">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h2>Motivados por un cambio</h2>                
            </div>            
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@*Nuestros Emprendedores*@
<!-- The circle icons use Font Awesome's stacked icon classes. For more information, visit http://fontawesome.io/examples/ -->
<section id="services" class="services bg-primary">
    <div class="container">
        <div class="row text-center">
            <div class="col-lg-10 col-lg-offset-1">
                <h2>Nuestros Emprendedores</h2>
                <hr class="small">
                @* SLIDER DE IMAGENES DEVEXTREME *@
                <div id="dxSlider" style="align-items:center">
                    <div id="gallery" data-bind="dxGallery: galleryOptions"></div>
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.col-lg-10 -->            
            <div class="btn btn-lg btn-light" style="margin-top:15px">
                @Html.ActionLink("Ver todos los Emprendedores", "ListaUsuarios", "Usuarios")
            </div>
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@*Motivados por un cambio*@
<section id="about" class="about">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">                
            </div>
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@*Callout*@
<aside class="callout">
    <div class="text-vertical-center">
        <h2>Trabajo Enfocado</h2>
    </div>
</aside>

@*Noticias*@
<section id="portfolio" class="portfolio">
    <div class="container">
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1 text-center">
                <h2>Noticias</h2>
                <br class="small">                                
                <div class="row">
                    @* dxList *@
                    <div id="list" class="list-container">
                        <div data-bind="dxList: listOptions">
                            <div data-options="dxTemplate: {name: 'item'}">
                                <div class="product" style="display: block">
                                    <h4 data-bind="text: $data.titulo"></h4>
                                    <img id="imgList" data-bind="attr: {src: $data.foto}"/>
                                    <br />
                                    @*<div data-bind="text: $data.descripcion"></div>*@
                                </div>
                            </div>
                        </div>
                    </div>
                    @* dxList *@              
                </div>
                <!-- /.row (nested) -->
                <div class="btn btn-lg btn-light">
                    @Html.ActionLink("Ver más noticias", "ListaPublicacionNoticias", "PublicacionNoticias")
                </div>
            </div>
            <!-- /.col-lg-10 -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@*Acerca de nosotros*@
<aside id="acercaDe" class="call-to-action bg-primary">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h3>Acerca de Nosotros</h3>
                <div id="aboutUs" style="font-size: 16px">
                    La Asociación Gremial de Mujeres Emprendedoras Arica, lleva más de cinco años apoyando a la mujer microempresaria, posicionándose como una organización líder en la ciudad.
                    <p id="revelar" style="font-size: 16px; display: none; margin-top: 0">
                        Hemos trabajado de manera independiente, a través de seminarios, charlas, ferias, escuelas, conferencias, promoviendo la inclusión en todo ámbito.
                        Actualmente realizamos un convenio con el banco estado, dándole flexibilidad en sus créditos.
                        Trabajamos transversalmente con los servicios públicos de la ciudad, dándole un enfoque de compromiso ciudadano.
                        <p id="mision" class="btn btn-dark btn-lg" style="display:none">Misión</p>
                        <p id="vision" class="btn btn-dark btn-lg" style="display:none">Visión</p>
                    </p>                    
                </div>

                <div style="display:">
                    <div id="mision2" style="display:none; margin-left:auto; margin-right:auto">
                        <p><h3>Misión:</h3>Impulsar en nuestra organización a mujeres emprendedoras para que sean capaces de innovar, ser creativas, desarrollándose en lo social ofreciendo sus productos y servicios, para contribuir a su transformación en mujeres capaces de tomar decisiones para mejorar su nivel socioeconómico y el de sus familias </p>
                    </div>

                    <div id="vision2" style="display:none; margin-left:auto; margin-right:auto">
                        <p><h3>Visión:</h3>Convertirse en una organización reconocida para el desarrollo de la mujer emprendedora en lo social con las expectativas de la competitividad en todo ámbito, impulsando procesos de empoderamiento, para poder tener presencia internacional</p>
                    </div>
                </div>

                <p id="conocerMas" class="btn btn-lg btn-light">Conocer más</p>
            </div>
        </div>
    </div>
</aside>

@*Footer solo para Index*@
<footer>
    <div id="contact" class="container">
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1 text-center">
                <h4>
                    <strong>Contacto</strong>
                </h4>
                <p>
                    3481 Melrose Place
                    <br>Beverly Hills, CA 90210
                </p>
                <ul class="list-unstyled">
                    <li><i class="fa fa-phone fa-fw"></i> (123) 456-7890</li>
                    <li>
                        <i class="fa fa-envelope-o fa-fw"></i> <a href="mailto:name@example.com">name@example.com</a>
                    </li>
                </ul>
                <ul class="list-inline">
                    <li>
                        <a href="#"><i class="fa fa-facebook fa-fw fa-3x"></i></a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-twitter fa-fw fa-3x"></i></a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</footer>

@Section Scripts
    <script src="~/Scripts/app/Index/IndexViewModel.js"></script>
    <script>
    $(document).ready(function () {
        $("#conocerMas").click(function () {
            $("#revelar").toggle(500);
            $("#mision").toggle(500);
            $("#vision").toggle(500);
            $("#mision2").hide(500);
            $("#vision2").hide(500);
        });

        $("#mision").click(function () {            
            $("#mision2").toggle(500);            
        });
        $("#vision").click(function () {
            $("#vision2").toggle(500);
        });
    });    
    ko.applyBindings(new Index.IndexViewModel());
    </script>
End Section
