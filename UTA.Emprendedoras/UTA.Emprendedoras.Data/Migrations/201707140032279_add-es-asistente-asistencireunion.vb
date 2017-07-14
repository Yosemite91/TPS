Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class addesasistenteasistencireunion
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.AsistenciaReunion", "EsAsistente", Function(c) c.Boolean(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.AsistenciaReunion", "EsAsistente")
        End Sub
    End Class
End Namespace
