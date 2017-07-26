/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IReunionModel.d.ts' />

namespace Reuniones {
    export class DetalleReunionViewModel {
        public asistencia: KnockoutObservable<any> = ko.observable<any>({
            id: null, idUsuario: null, idAsistencia: null, nombre: null, apellido: null, run: null, esAsistente: false, descripcion: null
        });

        public descripcionDX: KnockoutObservable<string> = ko.observable<string>();
          
        //Buttons
        public botonEditar = {
            text: 'Editar',
            type: 'default',
            icon: 'edit',
            onClick: function (e: any) {
                window.location.assign(App.appRoot + 'Reuniones/EditarReunion?id=' + this.asistencia().idAsistencia);
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
            readOnly: true,
            editorOptions: {
                mode: 'text'
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
                { dataField: 'esAsistente', caption: '¿Asistio?', allowEditing: false }
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
                this.asistencia().idAsistencia = id;
                this.loading(false);
            });
        }
    }
}