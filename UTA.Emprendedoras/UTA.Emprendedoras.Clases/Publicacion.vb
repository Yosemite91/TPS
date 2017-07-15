Public Class Publicacion

    Public Property ID As Integer
    Public Property Titulo As String
    Public Property Descripcion As String
    Public Property Foto As Byte()
    Public Property FechaPublicacion As Date
    Public Property Creador As Usuario
    Public Property PublicacionTipo As TipoPublicacion
    Public Property FechaRealizacion As Date
    Public Property EsActivo As Boolean
End Class
