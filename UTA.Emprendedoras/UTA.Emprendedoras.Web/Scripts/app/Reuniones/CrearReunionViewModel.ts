/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IReunionModel.d.ts' />

namespace Reuniones {
    export class CrearReunionViewModel {
        public usuarios: KnockoutObservable<any> = ko.observable<any>({
            id: null, nombre: null, apellido: null, run: null, esAsistente: false
        });
              
        public applyButtonOptionsCrear = {
            text: 'Finalizar',
            icon: 'plus',
            type: 'success',
            onClick: function (e: any) {
                let that: any = this;
                //$.each(this.grid.getSelectedRowsData(), function () {
                //    alert('hola');
                //});
                that.grid.refresh();
            }
        };
        //Formulario
        public grid: DevExpress.ui.dxDataGridOptions = {
            dataSource: this.usuarios,
            showRowLines: true,
            rowAlternationEnabled: true,
            showBorders: true,
            columnHidingEnabled: false,
            paging: {
                pageSize: 9
            },
            selection: {
                mode: 'multiple'
            },
            columns: [
                'nombre',
                'apellido',
                'run'
                ,
                {
                    dataField: 'esAsistente', caption: '¿Asistio?'
                }
            ]
            //,
            //editing: {
            //    mode: "colmun"
            //},
            //selection: {
            //    mode: "multiple"
            //},
        };

        public loading: KnockoutObservable<boolean> = ko.observable(false);
        constructor() {
            this.loading(true);
            //Cargar Usuarios
            $.getJSON(App.apiRoot + 'usuarios/get-usuarios/').then((result: IReunionModel[]): void => {
                this.usuarios(result);
                this.loading(false);
            });
        }
    }
}