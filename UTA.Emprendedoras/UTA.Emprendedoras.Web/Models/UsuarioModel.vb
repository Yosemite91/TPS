Imports System.ComponentModel.DataAnnotations

Namespace Models

    Public Class UsuarioModel
        Public Property ID As Integer
        Public Property Nombre As String
        Public Property Apellido As String
        Public Property Run As String
        Public Property Contrasena As String
        Public Property Telefono As String
        Public Property FechaNacimiento As Date?
        Public Property EsActivo As Boolean
        Public Property EsAdministrador As Boolean
        Public Property EsAdminPublicacion As Boolean
        Public Property SitioWebUrl As String
        Public Property Categoria As String
        Public Property Foto As Byte()
        Public Property EsAsistente As Boolean
    End Class

End Namespace