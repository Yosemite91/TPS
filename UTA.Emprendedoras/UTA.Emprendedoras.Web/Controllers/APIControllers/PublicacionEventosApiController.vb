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
                mapper = mapperConfig.CreateMapper()
                mapper.Map(model, evento)

                With evento
                    .FechaPublicacion = Now
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

    End Class
End Namespace