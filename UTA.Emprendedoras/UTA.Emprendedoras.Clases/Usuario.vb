﻿Public Class Usuario

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
    Public Overridable Property PublicacionesCreadas As IList(Of Publicacion)
    Public Property Email As String

    Public Property EsAsistente As Boolean
End Class
