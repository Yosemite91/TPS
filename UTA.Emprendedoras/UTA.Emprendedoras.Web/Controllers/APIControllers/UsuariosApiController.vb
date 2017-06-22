Imports System.Data.Entity
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports UTA.Emprendedoras.Data
Imports UTA.Emprendedoras.Clases
Imports AutoMapper.QueryableExtensions
Imports UTA.Emprendedoras.Web.Models

Namespace Controllers.APIControllers
    <RoutePrefix("api/usuarios")>
    Public Class UsuariosApiController
        Inherits ApiController


        Dim mapperConfig As New AutoMapper.MapperConfiguration(Sub(config)
                                                                   config.CreateMap(Of UsuarioCreateModel, Usuario)()
                                                               End Sub)


#Region "CrearUsuario"
        <Route("crear", Name:="crearUsuario")>
        <HttpPost>
        Public Async Function CrearUsuario(<FromBody> model As UsuarioCreateModel) As Task(Of IHttpActionResult)

            Dim db As New EmprendedorasDbContext()
            Dim usuario As Usuario = Nothing
            Dim mapper As AutoMapper.IMapper

            Try
                If Await db.Usuarios.AnyAsync(Function(u) u.Run = model.Run) Then
                    Return Me.Content(HttpStatusCode.BadRequest, $"Ya existe un usuario con el run {model.Run}")
                End If
                usuario = db.Usuarios.Create()
                mapper = mapperConfig.CreateMapper()
                mapper.Map(model, usuario)
                usuario.Contrasena = My.Settings.PasswordDefault
                db.Usuarios.Add(usuario)
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para crear usuario. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("crearUsuario", New With {.Run = usuario.Run}, "Usuario creado exitosamente")
        End Function
#End Region



    End Class
End Namespace