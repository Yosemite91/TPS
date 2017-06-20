Public Class Reunion

    Public Property ID As Integer
    Public Property Titulo As String
    Public Property Descripcion As String
    Public Property Fecha As Date
    Public Overridable Property ListaAsistencia As IList(Of Usuario)

End Class
