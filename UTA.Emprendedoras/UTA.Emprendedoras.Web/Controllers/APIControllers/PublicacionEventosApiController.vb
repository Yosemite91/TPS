Imports System.Data.Entity
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports UTA.Emprendedoras.Data
Imports UTA.Emprendedoras.Clases
Imports AutoMapper.QueryableExtensions
Imports UTA.Emprendedoras.Web.Models

Namespace Controllers.APIControllers
    <RoutePrefix("api/publicacion-eventos")>
    Public Class PublicacionEventosApiController
        Inherits ApiController
        Dim mapperConfig As New AutoMapper.MapperConfiguration(Sub(config)
                                                                   config.CreateMap(Of PublicacionEventoModel, Publicacion)()
                                                                   config.CreateMap(Of Publicacion, PublicacionEventoModel)()
                                                               End Sub)

#Region "CrearEvento"
        <Route("crear", Name:="crearEvento")>
        <HttpPost>
        Public Async Function CrearEvento(<FromBody> model As PublicacionEventoModel) As Task(Of IHttpActionResult)

            Dim db As New EmprendedorasDbContext()
            Dim evento As Publicacion = Nothing
            Dim mapper As AutoMapper.IMapper

            Try

                evento = db.Publicaciones.Create()
                mapper = mapperConfig.CreateMapper()
                mapper.Map(model, evento)

                With evento
                    'fechaPublicacion = Now
                    .PublicacionTipo = TipoPublicacion.Evento
                End With

                db.Publicaciones.Add(evento)
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para crear evento. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("crearEvento", New With {.ID = evento.ID}, "Usuario creado exitosamente")
        End Function
#End Region

#Region "Get Evento"
        <Route("get/{id:int}", Name:="getEvento")>
        <HttpGet>
        Public Async Function GetEvento(id As Integer) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim result As PublicacionEventoModel = New PublicacionEventoModel
            Dim mapper As AutoMapper.IMapper
            Try
                Dim evento As Publicacion = Await db.Publicaciones.Where(Function(u) u.ID = id).SingleOrDefaultAsync()
                mapper = mapperConfig.CreateMapper()
                mapper.Map(evento, result)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para retornar evento. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try

            If result IsNot Nothing Then Return Me.Ok(result)
            Return Me.Content(HttpStatusCode.NotFound, "Información no encontrada")

        End Function
#End Region

#Region "Editar Evento"
        <Route("editar", Name:="editarEvento")>
        <HttpPut>
        Public Async Function EditarEvento(<FromBody> model As PublicacionEventoModel) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim evento As New Publicacion
            Try

                evento = db.Publicaciones.Find(model.ID)
                With evento
                    .Titulo = model.Titulo
                    .Descripcion = model.Descripcion
                End With
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para guardar cambios. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("editarEvento", New With {.ID = evento.ID}, "Evento  Modificado exitosamente")
        End Function
#End Region

    End Class
End Namespace