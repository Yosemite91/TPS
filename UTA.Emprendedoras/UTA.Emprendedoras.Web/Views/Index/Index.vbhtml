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

@*About*@
<section id="about" class="about">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h2>Stylish Portfolio is the perfect theme for your next project!</h2>
                <p class="lead">This theme features some wonderful photography courtesy of <a target="_blank" href="http://join.deathtothestockphoto.com/">Death to the Stock Photo</a>.</p>
            </div>
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@*Services*@
<!-- The circle icons use Font Awesome's stacked icon classes. For more information, visit http://fontawesome.io/examples/ -->
<section id="services" class="services bg-primary">
    <div class="container">
        <div class="row text-center">
            <div class="col-lg-10 col-lg-offset-1">
                <h2>Nuestros Servicios</h2>
                <hr class="small">
                <div class="row">
                    <div class="col-md-3 col-sm-6">
                        <div class="service-item">
                            <span class="fa-stack fa-4x">
                                <i class="fa fa-circle fa-stack-2x"></i>
                                <i class="fa fa-cloud fa-stack-1x text-primary"></i>
                            </span>
                            <h4>
                                <strong>Service Name</strong>
                            </h4>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                            <a href="#" class="btn btn-light">Learn More</a>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="service-item">
                            <span class="fa-stack fa-4x">
                                <i class="fa fa-circle fa-stack-2x"></i>
                                <i class="fa fa-compass fa-stack-1x text-primary"></i>
                            </span>
                            <h4>
                                <strong>Service Name</strong>
                            </h4>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                            <a href="#" class="btn btn-light">Learn More</a>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="service-item">
                            <span class="fa-stack fa-4x">
                                <i class="fa fa-circle fa-stack-2x"></i>
                                <i class="fa fa-flask fa-stack-1x text-primary"></i>
                            </span>
                            <h4>
                                <strong>Service Name</strong>
                            </h4>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                            <a href="#" class="btn btn-light">Learn More</a>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="service-item">
                            <span class="fa-stack fa-4x">
                                <i class="fa fa-circle fa-stack-2x"></i>
                                <i class="fa fa-shield fa-stack-1x text-primary"></i>
                            </span>
                            <h4>
                                <strong>Service Name</strong>
                            </h4>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                            <a href="#" class="btn btn-light">Learn More</a>
                        </div>
                    </div>
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.col-lg-10 -->
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

@*Portfolio*@
<section id="portfolio" class="portfolio">
    <div class="container">
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1 text-center">
                <h2>Nuestro Trabajo</h2>
                <hr class="small">
                <div class="row">
                    <div class="col-md-6">
                        <div class="portfolio-item">
                            <a href="#">
                                <img class="img-portfolio img-responsive" src="~/Content/img/portfolio-1.jpg">
                            </a>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="portfolio-item">
                            <a href="#">
                                <img class="img-portfolio img-responsive" src="~/Content/img/portfolio-2.jpg">
                            </a>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="portfolio-item">
                            <a href="#">
                                <img class="img-portfolio img-responsive" src="~/Content/img/portfolio-3.jpg">
                            </a>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="portfolio-item">
                            <a href="#">
                                <img class="img-portfolio img-responsive" src="~/Content/img/portfolio-4.jpg">
                            </a>
                        </div>
                    </div>
                </div>
                <!-- /.row (nested) -->
                <a href="#" class="btn btn-dark">View More Items</a>
            </div>
            <!-- /.col-lg-10 -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@*ABOUT US*@
<aside class="call-to-action bg-primary">
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
                </p>
                </div>
                <a id="conocerMas" class="btn btn-lg btn-light">Conocer más</a>
            </div>
        </div>
    </div>
</aside>

@*Footer Just For Index*@
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
        });
    });
    ko.applyBindings(new Index.IndexViewModel());
    </script>
End Section
