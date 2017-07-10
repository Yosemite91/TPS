﻿@Code
    ViewData("Title") = "Login"
End Code

<div class="containerLogin">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>
    
    <div class="row">
        <div id="top"> <h3 style="color: white">Inicie Sesión</h3> </div>
        <div id="formularioLogin" data-bind="dxForm: form"></div>
    </div>
</div>

@Section Scripts
<script src="~/Scripts/app/Login/LoginViewModel.js"></script>
<script>
    ko.applyBindings(new Login.LoginViewModel());
</script>
End Section
