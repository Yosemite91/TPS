declare namespace Index {

    interface IPublicacionNoticiaModel {
        id: number,
        titulo: string,
        descripcion: string,
        fechaPublicacion: string,
        foto: string
    }

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
        email: string
    }
}
