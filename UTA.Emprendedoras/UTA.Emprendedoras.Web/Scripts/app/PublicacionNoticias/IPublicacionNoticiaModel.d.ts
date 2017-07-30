declare namespace PublicacionNoticias {
    interface IPublicacionNoticiaModel {
        id: number,
        titulo: string,
        descripcion: string,
        fechaPublicacion: Date,
        foto: string
    }
}