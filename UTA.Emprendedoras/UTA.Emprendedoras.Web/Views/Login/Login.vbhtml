@Code
    ViewData("Title") = "Inicio Sesión"
End Code

<div class="containerLogin">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>
        
    <div id="elVato">
        <div id="top2" class="long-title" style="color: white"><h3>Iniciar Sesión</h3></div>
        <div id="formularioLogin" data-bind="dxForm: form"></div>
    </div>
</div>

<div id="footerLogin">
    <div id="centrado">
        <h5>
            <strong>Asociación de Emprendedoras</strong>
        </h5>        
        <p id="footerTexto">&copy; @DateTime.Now.Year - Arica, Chile</p>
    </div>
</div>

@Section Scripts
<script src="~/Scripts/app/Login/LoginViewModel.js"></script>
<script>
    ko.applyBindings(new Login.LoginViewModel());
</script>
End Section
