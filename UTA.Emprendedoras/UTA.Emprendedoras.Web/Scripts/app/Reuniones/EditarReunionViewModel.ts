/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IReunionModel.d.ts' />

namespace Reuniones {
    export class EditarReunionViewModel {
        public asistencia: KnockoutObservable<any> = ko.observable<any>({
            id: null, idUsuario:null, idAsistencia:null, nombre: null, apellido: null, run: null, esAsistente: false, descripcion: null
        });

        public descripcionDX: KnockoutObservable<string> = ko.observable<string>();
        //Pop up
        private popUpModificarAsistencia = ko.observable(false);

        public popUpModificar = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Modificar Asistencia?',
            showTitle: true,
            showCloseButton: true,
            title: 'Alerta',
            visible: this.popUpModificarAsistencia,
            dragEnabled: false,
            closeOnOutsideClick: false,
            toolbarItems: [{
                toolbar: 'bottom',
                widget: 'button',
                options: { text: 'OK' },
                onClick: (e: any): void => {
                    this.loading(true);
                    var listaUsuariosDTO = this.asistencia();
                    var info = JSON.stringify(listaUsuariosDTO);
                    $.ajax({
                        url: App.apiRoot + 'reuniones/editar?descripcion=' + this.asistencia().descripcion,
                        cache: false,
                        type: 'PUT',
                        contentType: 'application/json; charset=utf-8',
                        data: info,
                        dataType: 'json'
                    }).then(
                        function (data) {
                            DevExpress.ui.notify('Asistencia Modificado', 'success', 3000);
                            window.location.assign(App.appRoot + 'Reuniones/ListaReuniones');
                        },
                        function (xhr, textStatus, err) {
                            this.loading(false);
                            alert(err);
                        });
                }
            }]
        };

        //Buttons
        public botonGuardar = {
            text: 'Guardar',
            type: 'success',
            icon: 'floppy',
            onClick: function (e: any) {
                this.popUpModificarAsistencia(true);
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
        public dxDescripcion = {
            value: this.descripcionDX,
            width: 'auto',
            editorOptions: {
                mode: 'text'
            },
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.asistencia().descripcion = e.value;
            }
        }

        public grid: DevExpress.ui.dxDataGridOptions = {
            dataSource: this.asistencia,
            showRowLines: true,
            rowAlternationEnabled: true,
            showBorders: true,
            columnHidingEnabled: false,
            paging: {
                pageSize: 9
            },
            editing: {
                mode: "cell", allowUpdating: true
            },
            columns: [
                { dataField: 'nombre', allowEditing: false },
                { dataField: 'apellido', allowEditing: false },
                { dataField: 'run', allowEditing: false },
                { dataField: 'esAsistente', caption: '¿Asistio?', allowEditing: true }
            ]
        };

        public loading: KnockoutObservable<boolean> = ko.observable(false);
        constructor() {
            this.loading(true);
            const id: string = window.location.search.replace('?id=', '');
            //Cargar Reunion
            $.getJSON(App.apiRoot + 'reuniones/get/' + id).then((result: IReunionModel[]): void => {
                this.asistencia(result);
                this.descripcionDX(result[0].descripcion);
                this.loading(false);
            });
        }
    }
}