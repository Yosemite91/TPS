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
                                                               End Sub)

#Region "CrearReunion"
        <Route("crear", Name:="crearReunion")>
        <HttpPost>
        Public Async Function CrearReunion(<FromBody> model As List(Of ReunionModel)) As Task(Of IHttpActionResult)

            Dim db As New EmprendedorasDbContext()
            Dim reunionModel As ReunionModel
            Dim reunion As Reunion = Nothing
            Dim asistencia As AsistenciaReunion = Nothing
            Dim usuario As Usuario = Nothing
            Dim mapper As AutoMapper.IMapper

            Try
                reunion = db.Reuniones.Create()
                With reunion
                    .Descripcion = "descripcion de reunion"
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



    End Class
End Namespace