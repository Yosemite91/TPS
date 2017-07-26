Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.AsistenciaReunion",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .QuienAsisteID = c.Int(nullable := False),
                        .QueReunionID = c.Int(nullable := False),
                        .EsAsistente = c.Boolean(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Reunion", Function(t) t.QueReunionID) _
                .ForeignKey("dbo.Usuario", Function(t) t.QuienAsisteID) _
                .Index(Function(t) t.QuienAsisteID) _
                .Index(Function(t) t.QueReunionID)
            
            CreateTable(
                "dbo.Reunion",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Titulo = c.String(),
                        .Descripcion = c.String(),
                        .Fecha = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Usuario",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(),
                        .Apellido = c.String(),
                        .Run = c.String(),
                        .Contrasena = c.String(),
                        .Telefono = c.String(),
                        .FechaNacimiento = c.DateTime(),
                        .EsActivo = c.Boolean(nullable := False),
                        .EsAdministrador = c.Boolean(nullable := False),
                        .EsAdminPublicacion = c.Boolean(nullable := False),
                        .SitioWebUrl = c.String(),
                        .Categoria = c.String(),
                        .Foto = c.Binary(),
                        .Email = c.String(),
                        .EsAsistente = c.Boolean(nullable := False),
                        .Reunion_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Reunion", Function(t) t.Reunion_ID) _
                .Index(Function(t) t.Reunion_ID)
            
            CreateTable(
                "dbo.Publicacion",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Titulo = c.String(),
                        .Descripcion = c.String(),
                        .Foto = c.Binary(),
                        .FechaPublicacion = c.DateTime(nullable := False),
                        .PublicacionTipo = c.Int(nullable := False),
                        .FechaRealizacion = c.DateTime(nullable := False),
                        .EsActivo = c.Boolean(nullable := False),
                        .Creador_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Usuario", Function(t) t.Creador_ID) _
                .Index(Function(t) t.Creador_ID)
            
            CreateTable(
                "dbo.Token",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Run = c.String(),
                        .TokenActual = c.String(),
                        .Fecha = c.DateTime(nullable := False),
                        .UsuarioID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.AsistenciaReunion", "QuienAsisteID", "dbo.Usuario")
            DropForeignKey("dbo.AsistenciaReunion", "QueReunionID", "dbo.Reunion")
            DropForeignKey("dbo.Usuario", "Reunion_ID", "dbo.Reunion")
            DropForeignKey("dbo.Publicacion", "Creador_ID", "dbo.Usuario")
            DropIndex("dbo.Publicacion", New String() { "Creador_ID" })
            DropIndex("dbo.Usuario", New String() { "Reunion_ID" })
            DropIndex("dbo.AsistenciaReunion", New String() { "QueReunionID" })
            DropIndex("dbo.AsistenciaReunion", New String() { "QuienAsisteID" })
            DropTable("dbo.Token")
            DropTable("dbo.Publicacion")
            DropTable("dbo.Usuario")
            DropTable("dbo.Reunion")
            DropTable("dbo.AsistenciaReunion")
        End Sub
    End Class
End Namespace
