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
                                                                   config.CreateMap(Of UsuarioModel, Usuario)()
                                                                   config.CreateMap(Of Usuario, UsuarioModel)()
                                                               End Sub)


#Region "CrearUsuario"
        <Route("crear", Name:="crearUsuario")>
        <HttpPost>
        Public Async Function CrearUsuario(<FromBody> model As UsuarioModel) As Task(Of IHttpActionResult)

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

#Region "GetUsuario"
        <Route("get/{run:regex(^[1-9][0-9]{0,7}-[0-9kK]$)}", Name:="getUsuario")>
        <HttpGet>
        Public Async Function GetUsuario(run As String) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim result As UsuarioModel = New UsuarioModel
            Dim mapper As AutoMapper.IMapper
            Try

                Dim user As Usuario = Await db.Usuarios.Where(Function(u) u.Run = run).SingleOrDefaultAsync()
                mapper = mapperConfig.CreateMapper()
                mapper.Map(user, result)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para retornar usuario. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try

            If result IsNot Nothing Then Return Me.Ok(result)
            Return Me.Content(HttpStatusCode.NotFound, "Información no encontrada")

        End Function
#End Region

#Region "EditarUsuario"
        <Route("editar", Name:="editarUsuario")>
        <HttpPut>
        Public Async Function EditarUsuario(<FromBody> model As UsuarioModel) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim usuario As New Usuario
            Try
                Dim ID As Integer? = Await db.Usuarios _
                        .Where(Function(u) u.Run = model.Run) _
                        .Select(Function(u) u.ID) _
                        .FirstOrDefaultAsync()
                If String.IsNullOrEmpty(ID) Then
                    Return Me.Content(HttpStatusCode.BadRequest, String.Format("No existe el usuario asociado a este run. error"))
                End If

                usuario = db.Usuarios.Find(ID)
                With usuario
                    .Nombre = model.Nombre
                    .Apellido = model.Apellido
                    .Run = model.Run
                    .Telefono = model.Telefono
                    .FechaNacimiento = model.FechaNacimiento
                    .EsActivo = model.EsActivo
                    .EsAdministrador = model.EsAdministrador
                    .EsAdminPublicacion = model.EsAdminPublicacion
                    .SitioWebUrl = model.SitioWebUrl
                    .Categoria = model.Categoria
                End With
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para guardar cambios. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("editarUsuario", New With {.Run = usuario.Run}, "Usuario Modificado exitosamente")
        End Function
#End Region

#Region "Bloquear Usuario"
        <Route("bloquear", Name:="bloquearUsuario")>
        <HttpPut>
        Public Async Function BloquearUsuario(<FromBody> model As UsuarioModel) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim usuario As New Usuario
            Try
                Dim ID As Integer? = Await db.Usuarios _
                        .Where(Function(u) u.Run = model.Run) _
                        .Select(Function(u) u.ID) _
                        .FirstOrDefaultAsync()
                If String.IsNullOrEmpty(ID) Then
                    Return Me.Content(HttpStatusCode.BadRequest, String.Format("No existe el usuario asociado a este run. error"))
                End If

                usuario = db.Usuarios.Find(ID)
                With usuario
                    .EsActivo = False
                End With
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para guardar cambios. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("bloquearUsuario", New With {.Run = usuario.Run}, "Usuario Modificado exitosamente")
        End Function
#End Region

#Region "Desbloquear Usuario"
        <Route("desbloquear", Name:="desbloquearUsuario")>
        <HttpPut>
        Public Async Function DesbloquearUsuario(<FromBody> model As UsuarioModel) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim usuario As New Usuario
            Try
                Dim ID As Integer? = Await db.Usuarios _
                        .Where(Function(u) u.Run = model.Run) _
                        .Select(Function(u) u.ID) _
                        .FirstOrDefaultAsync()
                If String.IsNullOrEmpty(ID) Then
                    Return Me.Content(HttpStatusCode.BadRequest, String.Format("No existe el usuario asociado a este run. error"))
                End If

                usuario = db.Usuarios.Find(ID)
                With usuario
                    .EsActivo = True
                End With
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para guardar cambios. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("desbloquearUsuario", New With {.Run = usuario.Run}, "Usuario Modificado exitosamente")
        End Function
#End Region

#Region "Cambiar Contraseña"
        <Route("cambiar-contrasena", Name:="cambiarContrasena")>
        <HttpPut>
        Public Async Function CambiarContrasena(<FromBody> model As UsuarioModel) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim usuario As New Usuario
            Try
                Dim ID As Integer? = Await db.Usuarios _
                        .Where(Function(u) u.Run = model.Run) _
                        .Select(Function(u) u.ID) _
                        .FirstOrDefaultAsync()
                If String.IsNullOrEmpty(ID) Then
                    Return Me.Content(HttpStatusCode.BadRequest, String.Format("No existe el usuario asociado a este run. error"))
                End If
                usuario = db.Usuarios.Find(ID)
                With usuario
                    .Contrasena = model.Contrasena
                End With
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para actualizar contraseña. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("cambiarContrasena", New With {.Run = usuario.Run}, "Usuario Modificado exitosamente")
        End Function
#End Region

#Region "Restablacer Contraseña"
        <Route("restablecer-contrasena", Name:="restablecerContrasena")>
        <HttpPut>
        Public Async Function RestablecerContrasena(<FromBody> model As UsuarioModel) As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim usuario As New Usuario
            Try
                Dim ID As Integer? = Await db.Usuarios _
                        .Where(Function(u) u.Run = model.Run) _
                        .Select(Function(u) u.ID) _
                        .FirstOrDefaultAsync()
                If String.IsNullOrEmpty(ID) Then
                    Return Me.Content(HttpStatusCode.BadRequest, String.Format("No existe el usuario asociado a este run. error"))
                End If
                usuario = db.Usuarios.Find(ID)
                With usuario
                    .Contrasena = My.Settings.PasswordDefault
                End With
                Await db.SaveChangesAsync()
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para restablecer contraseña. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
            Return Me.CreatedAtRoute("restablecerContrasena", New With {.Run = usuario.Run}, "Contrseña restablecida")
        End Function
#End Region

#Region "Get Usuarios"
        <Route("get-usuarios", Name:="getUsuarios")>
        <HttpGet>
        Public Async Function GetUsuarios() As Task(Of IHttpActionResult)
            Dim db As New EmprendedorasDbContext()
            Dim usuarios As List(Of UsuarioModel) = Nothing

            Try
                usuarios = Await db.Usuarios.ProjectTo(Of UsuarioModel)(mapperConfig).ToListAsync()
                Return Me.Ok(usuarios)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para retornar usuarios. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
        End Function
#End Region

    End Class
End Namespace