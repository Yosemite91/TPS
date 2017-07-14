Imports System.Data.Entity
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports UTA.Emprendedoras.Data
Imports UTA.Emprendedoras.Clases
Imports AutoMapper.QueryableExtensions
Imports UTA.Emprendedoras.Web.Models
Imports System.Collections.Generic

Namespace Controllers.APIControllers
    <RoutePrefix("api/reuniones")>
    Public Class ReunionesController
        Inherits ApiController

        Dim mapperConfig As New AutoMapper.MapperConfiguration(Sub(config)
                                                                   config.CreateMap(Of ReunionModel, Reunion)()
                                                                   config.CreateMap(Of Reunion, ReunionModel)()
                                                                   config.CreateMap(Of AsistenciaReunion, ReunionModel)()
                                                               End Sub)

#Region "CrearReunion"
        <Route("crear", Name:="crearReunion")>
        <HttpPost>
        Public Async Function CrearReunion(<FromBody> model As List(Of ReunionModel), descripcion As String) As Task(Of IHttpActionResult)

            Dim db As New EmprendedorasDbContext()
            Dim reunionModel As ReunionModel
            Dim reunion As Reunion = Nothing
            Dim asistencia As AsistenciaReunion = Nothing
            Dim usuario As Usuario = Nothing
            Dim mapper As AutoMapper.IMapper

            Try
                reunion = db.Reuniones.Create()
                With reunion
                    .Descripcion = descripcion
                    .Fecha = Now
                End With
                db.Reuniones.Add(reunion)
                Await db.SaveChangesAsync()



                For Each reunionModel In model
                    asistencia = db.AsistenciaReuniones.Create()
                    usuario = db.Usuarios.Find(reunionModel.ID)
                    With asistencia
                        .QueReunionID = reunion.ID
                        .QuienAsisteID = usuario.ID
                        .EsAsistente = reunionModel.EsAsistente
                    End With
                    db.AsistenciaReuniones.Add(asistencia)
                Next
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para crear la reunion. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("crearReunion", New With {.ID = reunion.ID}, "Reunion creada exitosamente")
        End Function
#End Region

#Region "getAsistencia"
        <Route("get/{id:int}", Name:="getAsistencia")>
        <HttpGet>
        Public Async Function GetAsistencia(id As Integer) As Task(Of IHttpActionResult)
            Dim reunion As List(Of ReunionModel) = Nothing
            Dim db As New EmprendedorasDbContext()

            Try
                reunion = Await db.AsistenciaReuniones _
                           .Where(Function(u) u.QueReunionID = id) _
                           .Select(Function(u) New ReunionModel With {
                                                              .ID = u.QueReunionID,
                                                              .IdUsuario = u.QuienAsisteID,
                                                              .IdAsistencia = u.ID,
                                                              .Nombre = u.QuienAsiste.Nombre,
                                                              .Apellido = u.QuienAsiste.Apellido,
                                                              .Run = u.QuienAsiste.Run,
                                                              .EsAsistente = u.EsAsistente,
                                                              .Descripcion = u.QueReunion.Descripcion
                                                            }) _
                           .ToListAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para retornar reunion. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.Ok(reunion)
            Return Me.Content(HttpStatusCode.NotFound, "Información no encontrada")
        End Function
#End Region

#Region "EditarAsistencia"
        <Route("editar", Name:="editarReunion")>
        <HttpPut>
        Public Async Function EditarReunion(<FromBody> model As List(Of ReunionModel), descripcion As String) As Task(Of IHttpActionResult)

            Dim db As New EmprendedorasDbContext()
            Dim reunionModel As ReunionModel
            Dim reunion As Reunion = Nothing
            Dim asistencia As AsistenciaReunion = Nothing
            Dim usuario As Usuario = Nothing
            Dim mapper As AutoMapper.IMapper

            Try

                reunion = db.Reuniones.Find(model(1).ID)
                With reunion
                    .Descripcion = descripcion
                End With
                Await db.SaveChangesAsync()

                For Each reunionModel In model
                    asistencia = db.AsistenciaReuniones.Find(reunionModel.IdAsistencia)
                    With asistencia
                        .QueReunionID = reunionModel.ID
                        .QuienAsisteID = reunionModel.IdUsuario
                        .EsAsistente = reunionModel.EsAsistente
                    End With
                    Await db.SaveChangesAsync()
                Next
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para crear la reunion. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("crearReunion", New With {.ID = reunion.ID}, "Reunion creada exitosamente")
        End Function
#End Region

#Region "Lista reuniones"
        <Route("get-reuniones/", Name:="getReuniones")>
        <HttpGet>
        Public Async Function GetReuniones() As Task(Of IHttpActionResult)
            Dim reunion As List(Of ReunionModel) = Nothing
            Dim db As New EmprendedorasDbContext()

            Try
                reunion = Await db.Reuniones _
                           .Select(Function(u) New ReunionModel With {
                                                              .ID = u.ID,
                                                               .Fecha = u.Fecha,
                                                              .Descripcion = u.Descripcion
                                                            }) _
                           .ToListAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para retornar reunion. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.Ok(reunion)
            Return Me.Content(HttpStatusCode.NotFound, "Información no encontrada")
        End Function
#End Region
    End Class
End Namespace