/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IReunionModel.d.ts' />

namespace Reuniones {
    export class ListaReunionesViewModel {
        public reuniones: KnockoutObservable<any> = ko.observable<any>({
            id: null, descripcion: null, fecha: null
        });

        //Buttons
        public botonAgregar = {
            text: 'Crear',
            type: 'success',
            icon: 'plus',
            onClick: function (e: any) {
                window.location.assign(App.appRoot + 'Reuniones/CrearReunion');
            }
        };

        public goBack = {
            icon: 'back',
            type: 'normal',
            onClick: (e: any): void => {
                window.history.back();
            }
        };

        //DataGrid
        public grid: DevExpress.ui.dxDataGridOptions = {
            dataSource: this.reuniones,
            onRowClick: (e: DevExpress.ui.dxDataGridRow) => {
                const data: IReunionModel = <IReunionModel>e.data;
                let url: string = App.appRoot + 'Reuniones/DetalleReunion';
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
                <DevExpress.ui.dxFormSimpleItem>{
                    dataField: 'fecha',
                    dataType: 'date',
                    format: 'dd/MM/yyyy'
                },'descripcion'
            ]
        };

        public loading: KnockoutObservable<boolean> = ko.observable(false);
        constructor() {
            this.loading(true);
            //Cargar Reuniones
            $.getJSON(App.apiRoot + 'reuniones/get-reuniones/').then((result: IReunionModel[]): void => {
                this.reuniones(result);
                this.loading(false);
            });
        }
    }
}