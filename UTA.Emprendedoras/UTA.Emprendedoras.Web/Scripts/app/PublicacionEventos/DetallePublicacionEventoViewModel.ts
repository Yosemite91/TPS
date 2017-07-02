﻿/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IPublicacionEventoModel.d.ts' />

namespace PublicacionEventos {
    export class DetallePublicacionEventoViewModel {
        public evento: KnockoutObservable<IPublicacionEventoModel> = ko.observable<IPublicacionEventoModel>({
            id: null, titulo: null, descripcion: null, fechaPublicacion: null, foto: null
        });
        //Buttons
        public botonEditar = {
            text: 'Modificar',
            type: 'default',
            icon: 'edit',
            onClick: function (e: any) {
                var id = this.evento().id;
                window.location.assign(App.appRoot + 'PublicacionEventos/EditarPublicacionEvento?id=' + id);
            }
        };

        //Formulario
        public form: DevExpress.ui.dxFormOptions = {
            formData: this.evento,
            readOnly: true,
            colCount: 'auto',
            colCountByScreen: {
                lg: 2,
                md: 2,
                sm: 1,
                xs: 1
            },
            items: [
                <DevExpress.ui.dxFormGroupItem>{
                    itemType: 'group',
                    caption: 'Información Evento',
                    items: ['titulo', 'descripcion'
                        //,
                        //<DevExpress.ui.dxFormSimpleItem>{
                        //    dataField: 'fechaPublicacion',
                        //    editorType: 'dxDateBox',
                        //    editorOptions: {
                        //        displayFormat: 'MM/dd/yyyy',
                        //        width: 'auto'
                        //    }
                        //}
                    ]
                }]
        };

        public loading: KnockoutObservable<boolean> = ko.observable(false);
        constructor() {
            const id: string = window.location.search.replace('?id=', '');

            this.loading(true);
            $.getJSON(App.apiRoot + 'publicacion-eventos/get/' + id).then((result: IPublicacionEventoModel): void => {
                this.evento(result);
                $('#evento-form').dxForm('instance').repaint();
                this.loading(false);
            });

        }
    }
}