Imports System.Web.Mvc

Namespace Controllers
    Public Class UsuariosController
        Inherits Controller

        'Crear Usuario
        Function CrearUsuario() As ActionResult
            ViewData("Title") = "Crear Usuarios"
            Return View()
        End Function


    End Class
End Namespace