Public Class AsistenciaReunion

    Public Property ID As Integer
    Public Property QuienAsisteID As Integer
    Public Overridable Property QuienAsiste As Usuario
    Public Property QueReunionID As Integer
    Public Overridable Property QueReunion As Reunion
    Public Property EsAsistente As Boolean
End Class
