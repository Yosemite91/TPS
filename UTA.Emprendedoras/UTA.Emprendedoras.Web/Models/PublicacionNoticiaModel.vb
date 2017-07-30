Imports System.ComponentModel.DataAnnotations

Namespace Models
    Public Class PublicacionNoticiaModel
        Public Property ID As Integer
        Public Property Titulo As String
        Public Property Descripcion As String
        Public Property Foto As String
        Public Property FechaPublicacion As Date
        Public Property FotoByte As Byte()
    End Class
End Namespace

