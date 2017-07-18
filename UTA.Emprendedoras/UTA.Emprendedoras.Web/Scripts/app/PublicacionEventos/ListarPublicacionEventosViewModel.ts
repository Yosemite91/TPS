/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IPublicacionEventoModel.d.ts' />

namespace PublicacionEventos {
    export class ListarPublicacionEventosViewModel {
        public eventos: KnockoutObservable<any> = ko.observable<any>();

        //Buttons
        public applyButtonOptionsCrear = {
            text: 'Crear Evento',
            icon: 'plus',
            type: 'success',
            onClick: function (e: any) {
                let url: string = App.appRoot + 'PublicacionEventos/CrearPublicacionEvento';
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
            dataSource: this.eventos,
            onRowClick: (e: DevExpress.ui.dxDataGridRow) => {
                const data: IPublicacionEventoModel = <IPublicacionEventoModel>e.data;
                let url: string = App.appRoot + 'PublicacionEventos/DetallePublicacionEvento';
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
            $.getJSON(App.apiRoot + 'publicacion-eventos/get-eventos/').then((result: IPublicacionEventoModel[]): void => {
                this.eventos(result);
                this.loading(false);
            });
        }
    }
}