/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../../typings/devextreme/devextreme.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="iusuariomodel.d.ts" />

namespace Index {

    export class IndexViewModel {

        public noticias: KnockoutObservable<any> = ko.observable<any>();
        public usuarios: KnockoutObservable<any> = ko.observable<any>();

        public galleryOptions: DevExpress.ui.dxGalleryOptions = {
            dataSource: this.usuarios,
            animationDuration: 500,
            animationEnabled: true,
            slideshowDelay: 4000,
            loop: true,
            showNavButtons: true,
            showIndicator: true,
            stretchImages: true,
            swipeEnabled: true,
            onItemClick: (e) => {
                //var datoItem = e.itemData;
                //window.location.assign(App.appRoot + 'PublicacionNoticias/DetallePublicacionNoticia?id=' + datoItem.id);
            }
        }
       
        public listOptions: DevExpress.ui.dxListOptions = {
            dataSource: this.noticias,
            height: "100%",
            indicateLoading: true,
            menuMode: "content",
            nextButtonText: "Más",
            noDataText: "Sin datos por mostrar",
            pageLoadingText: "Cargando...",
            refreshingText: "Recargando...",            
            onItemClick: (e) => {                
                var datoItem = e.itemData;
                window.location.assign(App.appRoot + 'PublicacionNoticias/DetallePublicacionNoticia?id=' + datoItem.id);
            }
        };
        
        constructor() {
            //Cargar Usuarios
            $.getJSON(App.apiRoot + 'publicacion-noticias/get-lista/').then((result: IPublicacionNoticiaModel[]): void => {
                this.noticias(result);                
            });

            $.getJSON(App.apiRoot + 'usuarios/get-fotos/').then((result: IUsuarioModel[]): void => {
                //this.usuarios(result);
                var tam: number = result.length;
                var arreglo = new Array(tam);
                
                for (var i = 0; i < tam; i++){
                    arreglo[i] = result[i].foto;
                }

                this.usuarios(arreglo);
            });
        }
    }   
}
