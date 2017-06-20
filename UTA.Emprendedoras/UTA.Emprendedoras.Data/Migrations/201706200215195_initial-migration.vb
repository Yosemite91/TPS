Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class initialmigration
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.AsistenciaReunion",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .QueReunion_ID = c.Int(),
                        .QuienAsiste_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Reunion", Function(t) t.QueReunion_ID) _
                .ForeignKey("dbo.Usuario", Function(t) t.QuienAsiste_ID) _
                .Index(Function(t) t.QueReunion_ID) _
                .Index(Function(t) t.QuienAsiste_ID)
            
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
                        .Foto = c.String(),
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
                        .Foto = c.String(),
                        .FechaPublicacion = c.String(),
                        .PublicacionTipo = c.Int(nullable := False),
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
            DropForeignKey("dbo.AsistenciaReunion", "QuienAsiste_ID", "dbo.Usuario")
            DropForeignKey("dbo.AsistenciaReunion", "QueReunion_ID", "dbo.Reunion")
            DropForeignKey("dbo.Usuario", "Reunion_ID", "dbo.Reunion")
            DropForeignKey("dbo.Publicacion", "Creador_ID", "dbo.Usuario")
            DropIndex("dbo.Publicacion", New String() { "Creador_ID" })
            DropIndex("dbo.Usuario", New String() { "Reunion_ID" })
            DropIndex("dbo.AsistenciaReunion", New String() { "QuienAsiste_ID" })
            DropIndex("dbo.AsistenciaReunion", New String() { "QueReunion_ID" })
            DropTable("dbo.Token")
            DropTable("dbo.Publicacion")
            DropTable("dbo.Usuario")
            DropTable("dbo.Reunion")
            DropTable("dbo.AsistenciaReunion")
        End Sub
    End Class
End Namespace
