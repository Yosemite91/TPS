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
        'Detalle Usuario
        Function DetalleUsuario() As ActionResult
            ViewData("Title") = "Detalle Usuario"
            Return View()
        End Function
        'Mi Perfil
        Function MiPerfil() As ActionResult
            ViewData("Title") = "Mi Perfil"
            Return View()
        End Function
        'Lista Usurios
        Function ListaUsuarios() As ActionResult
            ViewData("Title") = "Lista Usuarios"
            Return View()
        End Function

    End Class
End Namespace