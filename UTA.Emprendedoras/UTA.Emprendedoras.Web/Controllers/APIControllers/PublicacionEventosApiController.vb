﻿Imports System.Data.Entity
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
                'mapper = mapperConfig.CreateMapper()
                'mapper.Map(model, evento)

                With evento
                    .Titulo = model.Titulo
                    .Descripcion = model.Descripcion
                    .Foto = Encoding.ASCII.GetBytes(model.Foto)
                    .FechaPublicacion = Now
                    .EsActivo = True
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
            Dim result As PublicacionEventoModel = Nothing
            Dim mapper As AutoMapper.IMapper
            Try
                Dim evento As Publicacion = Await db.Publicaciones.Where(Function(u) u.ID = id).SingleOrDefaultAsync()

                result = New PublicacionEventoModel With
                         {
                            .ID = evento.ID,
                            .Titulo = evento.Titulo,
                            .Descripcion = evento.Descripcion,
                            .FechaRealizacion = evento.FechaRealizacion,
                            .Foto = Encoding.Default.GetString(evento.Foto)
                         }
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
                    .Foto = Encoding.ASCII.GetBytes(model.Foto)
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

#Region "Get Eventos"
        <Route("get-eventos", Name:="getEventos")>
        <HttpGet>
        Public Async Function GetEventos() As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim eventos As List(Of PublicacionEventoModel) = Nothing
            Try
                eventos = Await db.Publicaciones.Where(Function(e) e.PublicacionTipo = TipoPublicacion.Evento AndAlso e.EsActivo) _
                .Select(Function(e) New PublicacionEventoModel With {
                                                            .ID = e.ID,
                                                            .Titulo = e.Titulo,
                                                            .Descripcion = e.Descripcion
                                                            }) _
                .ToListAsync()
                Return Me.Ok(eventos)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para retornar eventos. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
        End Function
#End Region

#Region "Eliminar Evento"
        <Route("eliminar", Name:="eliminarEvento")>
        <HttpPut>
        Public Async Function EliminarEvento(<FromBody> model As PublicacionEventoModel) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim evento As New Publicacion
            Try
                evento = db.Publicaciones.Find(model.ID)
                With evento
                    .EsActivo = False
                End With
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para deshabilitar el evento. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("eliminarEvento", New With {.ID = evento.ID}, "Evento deshabilitado")
        End Function
#End Region
    End Class
End Namespace