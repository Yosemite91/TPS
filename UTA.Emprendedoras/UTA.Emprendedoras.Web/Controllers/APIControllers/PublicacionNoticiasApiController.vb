Imports System.Data.Entity
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports UTA.Emprendedoras.Data
Imports UTA.Emprendedoras.Clases
Imports AutoMapper.QueryableExtensions
Imports UTA.Emprendedoras.Web.Models

Namespace Controllers.APIControllers
    <RoutePrefix("api/publicacion-noticias")>
    Public Class PublicacionNoticiasApiController
        Inherits ApiController

        Dim mapperConfig As New AutoMapper.MapperConfiguration(Sub(config)
                                                                   config.CreateMap(Of PublicacionNoticiaModel, Publicacion)()
                                                                   config.CreateMap(Of Publicacion, PublicacionNoticiaModel)()
                                                               End Sub)

#Region "CrearNoticia"
        <Route("crear", Name:="crearNoticia")>
        <HttpPost>
        Public Async Function CrearEvento(<FromBody> model As PublicacionNoticiaModel) As Task(Of IHttpActionResult)

            Dim db As New EmprendedorasDbContext()
            Dim noticia As Publicacion = Nothing
            Dim mapper As AutoMapper.IMapper

            Try

                noticia = db.Publicaciones.Create()
                mapper = mapperConfig.CreateMapper()
                mapper.Map(model, noticia)

                With noticia
                    .FechaPublicacion = Now
                    .EsActivo = True
                    .PublicacionTipo = TipoPublicacion.Noticia
                End With

                db.Publicaciones.Add(noticia)
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para crear noticia. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("crearNoticia", New With {.ID = noticia.ID}, "Usuario creado exitosamente")
        End Function
#End Region

#Region "Get Noticia"
        <Route("get/{id:int}", Name:="getNoticia")>
        <HttpGet>
        Public Async Function GetNoticia(id As Integer) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim result As PublicacionNoticiaModel = New PublicacionNoticiaModel

            Try
                Dim noticia As Publicacion = Await db.Publicaciones.Where(Function(u) u.ID = id).SingleOrDefaultAsync()
                result = New PublicacionNoticiaModel With
                         {
                            .ID = noticia.ID,
                            .Titulo = noticia.Titulo,
                            .Descripcion = noticia.Descripcion
                         }
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para retornar noticia. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try

            If result IsNot Nothing Then Return Me.Ok(result)
            Return Me.Content(HttpStatusCode.NotFound, "Información no encontrada")

        End Function
#End Region

#Region "Editar Noticia"
        <Route("editar", Name:="editarNoticia")>
        <HttpPut>
        Public Async Function EditarEvento(<FromBody> model As PublicacionNoticiaModel) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim noticia As New Publicacion
            Try
                noticia = db.Publicaciones.Find(model.ID)
                With noticia
                    .Titulo = model.Titulo
                    .Descripcion = model.Descripcion
                End With
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para guardar cambios. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("editarNoticia", New With {.ID = noticia.ID}, "Noticia  Modificado exitosamente")
        End Function
#End Region

#Region "Get Noticias"
        <Route("get-noticias", Name:="getnoticias")>
        <HttpGet>
        Public Async Function GetNoticias() As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim noticias As List(Of PublicacionNoticiaModel) = Nothing
            Try
                noticias = Await db.Publicaciones.Where(Function(e) e.PublicacionTipo = TipoPublicacion.Noticia AndAlso e.EsActivo) _
                .Select(Function(e) New PublicacionNoticiaModel With {
                                                            .ID = e.ID,
                                                            .Titulo = e.Titulo,
                                                            .Descripcion = e.Descripcion
                                                            }) _
                .ToListAsync()
                Return Me.Ok(noticias)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para retornar noticias. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
        End Function
#End Region

#Region "Eliminar Noticia"
        <Route("eliminar", Name:="eliminarNoticia")>
        <HttpPut>
        Public Async Function EliminarNoticia(<FromBody> model As PublicacionNoticiaModel) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim noticia As New Publicacion
            Try
                noticia = db.Publicaciones.Find(model.ID)
                With noticia
                    .EsActivo = False
                End With
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para deshabilitar la noticia. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("eliminarNoticia", New With {.ID = noticia.ID}, "Noticia deshabilitado")
        End Function
#End Region

    End Class
End Namespace