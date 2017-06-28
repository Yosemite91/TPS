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
    End Class
End Namespace