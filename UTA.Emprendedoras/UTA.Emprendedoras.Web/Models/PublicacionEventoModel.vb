Imports System.ComponentModel.DataAnnotations

Namespace Models
    Public Class PublicacionEventoModel
        Public Property ID As Integer
        Public Property Titulo As String
        Public Property Descripcion As String
        Public Property Foto As String
        Public Property FechaPublicacion As Date
        Public Property FechaRealizacion As Date
        Public Property EsActivo As Boolean
    End Class
End Namespace

