Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class addesasistente
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Usuario", "EsAsistente", Function(c) c.Boolean(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Usuario", "EsAsistente")
        End Sub
    End Class
End Namespace
