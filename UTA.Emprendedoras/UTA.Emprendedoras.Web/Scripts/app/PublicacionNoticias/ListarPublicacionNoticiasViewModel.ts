/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IPublicacionNoticiaModel.d.ts' />

namespace PublicacionNoticias {
    export class ListarPublicacionNoticiasViewModel {
        public noticias: KnockoutObservable<any> = ko.observable<any>();

        //Buttons
        public applyButtonOptionsCrear = {
            text: 'Crear Noticia',
            icon: 'plus',
            type: 'success',
            onClick: function (e: any) {
                let url: string = App.appRoot + 'PublicacionNoticias/CrearPublicacionNoticia';
                window.location.assign(url);
            }
        };

        public goBack = {
            icon: 'back',
            type: 'normal',
            onClick: (e: any): void => {
                window.history.back();
            }
        };

        //Formulario
        public grid: DevExpress.ui.dxDataGridOptions = {
            dataSource: this.noticias,
            onRowClick: (e: DevExpress.ui.dxDataGridRow) => {
                const data: IPublicacionNoticiaModel = <IPublicacionNoticiaModel>e.data;
                let url: string = App.appRoot + 'PublicacionNoticias/DetallePublicacionNoticia';
                if (data.id != undefined) {
                    url = url + '?id=' + data.id;
                }
                window.location.assign(url);
            },
            searchPanel: {
                visible: true,
                width: 240,
                placeholder: 'Buscar...'
            },
            showRowLines: true,
            rowAlternationEnabled: true,
            showBorders: true,
            columnHidingEnabled: false,
            paging: {
                pageSize: 9
            },
            columns: [
                'titulo',
                'descripcion'
            ]
        };

        public loading: KnockoutObservable<boolean> = ko.observable(false);

        constructor() {
            this.loading(true);
            //Cargar Eventos
            $.getJSON(App.apiRoot + 'publicacion-noticias/get-noticias/').then((result: IPublicacionNoticiaModel[]): void => {
                this.noticias(result);
                this.loading(false);
            });
        }
    }
}