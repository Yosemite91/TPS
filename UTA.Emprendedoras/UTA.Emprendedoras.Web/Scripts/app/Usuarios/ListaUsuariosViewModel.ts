/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IUsuarioModel.d.ts' />

namespace Usuarios{
    export class ListaUsuariosViewModel {

        public usuarios: KnockoutObservable<any> = ko.observable<any>();

        //Buttons
        public applyButtonOptionsCrear = {
            text: 'Crear Usuario',
            icon: 'plus',
            type: 'success',
            onClick: function (e: any) {
                let url: string = App.appRoot + 'Usuarios/CrearUsuario';
                window.location.assign(url);
            }
        };

        //Formulario
        public grid: DevExpress.ui.dxDataGridOptions = {
            dataSource: this.usuarios,
            onRowClick: (e: DevExpress.ui.dxDataGridRow) => {
                const data: IUsuarioModel = <IUsuarioModel>e.data;
                let url: string = App.appRoot + 'Usuarios/DetalleUsuario';
                if (data.run != undefined) {
                    url = url + '?run=' + data.run;
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
                'nombre',
                'apellido',
                'telefono',
                { dataField: 'esActivo', caption: '¿Activo?' }
            ]
        };

        public loading: KnockoutObservable<boolean> = ko.observable(false);

        constructor() {
            this.loading(true);
            //Cargar Usuarios
            $.getJSON(App.apiRoot + 'usuarios/get-usuarios/').then((result: IUsuarioModel[]): void => {
                this.usuarios(result);
                this.loading(false);
            });
        }

    }
}