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
                var listaUsuariosDTO = this.usuarios();

                var info = JSON.stringify(listaUsuariosDTO);
                $.ajax({
                    url: App.apiRoot + 'reuniones/crear',
                    cache: false,
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: info,
                    dataType: 'json'
                }).then(
                    function (data) {
                        DevExpress.ui.notify('REUNION CREADA', 'success', 3000);
                        window.location.assign(App.appRoot + 'Reuniones/ListaReuniones');
                    },
                    function (xhr, textStatus, err) {
                        alert(err);
                    }
                    );
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
            editing: {
                mode: "cell", allowUpdating : true
            },
            columns: [
                { dataField: 'nombre', allowEditing:false},
                { dataField: 'apellido', allowEditing: false},
                { dataField: 'run', allowEditing: false},
                { dataField: 'esAsistente', caption: '¿Asistio?', allowEditing:true}
            ]
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