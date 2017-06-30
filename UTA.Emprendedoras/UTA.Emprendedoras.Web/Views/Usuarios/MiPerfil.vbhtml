﻿@Code
    ViewData("Title") = "MiPerfil"
End Code
<div data-bind="dxPopup: popUpCambiarPass"></div>
<div id="cuerpoLista">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>

    <div id="botonesDetalle">
        <div id="volver" data-bind="dxButton: goBack"> </div>
    </div>

    <div id="modificar-button" data-bind="dxButton: applyButtonOptionsModificar"> </div>
    <div id="usuario-form" data-bind="dxForm: form"></div>

    <div id="usuario-form-contrasena" data-bind="dxForm: formContrasena"></div>
    <div id="modificar-button" data-bind="dxButton: applyButtonOptionsModificarContrasena"> </div>
</div>

@Section Scripts
    <script src="~/Scripts/app/Usuarios/MiPerfilViewModel.js"></script>
    <script>
        ko.applyBindings(new Usuarios.MiPerfilViewModel());
    </script>
End Section
