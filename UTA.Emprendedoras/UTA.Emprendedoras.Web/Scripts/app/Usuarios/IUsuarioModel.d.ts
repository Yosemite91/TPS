declare namespace Usuarios {

    interface IUsuarioModel {
        id: number,
        nombre: string,
        apellido: string,
        run: string,
        contrasena: string,
        telefono: string,
        fechaNacimiento: Date, //null
        esActivo: boolean,
        esAdministrador: boolean,
        esAdminPublicacion: boolean,
        sitioWebUrl: string,
        categoria: string,
        foto: string,
        correo: string,

        email: string
    }
}
