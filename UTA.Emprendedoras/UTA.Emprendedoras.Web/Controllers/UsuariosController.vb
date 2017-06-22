Imports System.Web.Mvc

Namespace Controllers
    Public Class UsuariosController
        Inherits Controller

        'Crear Usuario
        Function CrearUsuario() As ActionResult
            ViewData("Title") = "Crear Usuario"
            Return View()
        End Function
        'Editar Usuario
        Function EditarUsuario() As ActionResult
            ViewData("Title") = "Editar Usuario"
            Return View()
        End Function
    End Class
End Namespace