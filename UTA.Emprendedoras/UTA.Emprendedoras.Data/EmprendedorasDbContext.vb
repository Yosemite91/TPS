Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.Linq
Imports UTA.Emprendedoras.Clases

Public Class EmprendedorasDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Emprendedoras")
    End Sub

    Public Overridable Property Usuarios As DbSet(Of Usuario)
    Public Overridable Property Reuniones As DbSet(Of Reunion)
    Public Overridable Property AsistenciaReuniones As DbSet(Of AsistenciaReunion)
    Public Overridable Property Publicaciones As DbSet(Of Publicacion)
    Public Overridable Property Token As DbSet(Of Token)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        modelBuilder.Conventions.Remove(Of OneToManyCascadeDeleteConvention)()
        modelBuilder.Conventions.Remove(Of ManyToManyCascadeDeleteConvention)()
    End Sub

End Class
