/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IPublicacionEventoModel.d.ts' />

namespace PublicacionEventos {

    export class CrearPublicacionEventoViewModel {
        public evento: KnockoutObservable<IPublicacionEventoModel> = ko.observable<IPublicacionEventoModel>({
            id: null, titulo: null, descripcion: null, fechaPublicacion: null, foto: null
        });

        //PopUp
        private popUpCancelarCreacionUsuario = ko.observable(false);
        private popUpCrearEvento = ko.observable(false);

        // POP-UP CANCELAR
        public popUpCancelar = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Volver a la página anterior?',
            showTitle: true,
            showCloseButton: true,
            title: 'Alerta',
            visible: this.popUpCancelarCreacionUsuario,
            dragEnabled: false,
            closeOnOutsideClick: false,
            toolbarItems: [{
                toolbar: 'bottom',
                widget: 'button',
                options: { text: 'OK' },
                onClick: function (e: any) {
                    window.location.assign(App.appRoot + 'PublicacionEventos/ListaPublicacionEventos');
                }
            }
            ]
        };

        // POP-UP CREAR
        public popUpCrear = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Quiere crear este nuevo evento?',
            showTitle: true,
            showCloseButton: true,
            title: 'Alerta',
            visible: this.popUpCrearEvento,
            dragEnabled: false,
            closeOnOutsideClick: false,
            toolbarItems: [{
                toolbar: 'bottom',
                widget: 'dxButton',
                options: { text: 'OK' },
                onClick: (e: any): void => {
                    //Volcando información de formulario
                    var EventoDTO = {
                        titulo: this.evento().titulo,
                        descripcion: this.evento().descripcion
                    };

                    var info = JSON.stringify(EventoDTO);
                    $.ajax({
                        url: App.apiRoot + 'publicacion-eventos/crear',
                        cache: false,
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        data: info,
                        dataType: 'json'
                    }).then(
                        function (data) {
                            DevExpress.ui.notify('EVENTO CREADO', 'success', 3000);
                            window.location.assign(App.appRoot + 'PublicacionEventos/ListaPublicacionEventos');
                        },
                        function (xhr, textStatus, err) {
                            alert(err);
                        }
                        );
                }
            }]
        };

        // BOTONES GUARDAR
        public botonGuardar = {
            text: 'Guardar',
            icon: 'floppy',
            type: 'success',
            onClick: (e: any): void => {
                var result = e.validationGroup.validate();

                var EventoValidacion = {
                    Titulo: this.evento().titulo,
                    Descripcion: this.evento().descripcion
                };

                if (result.isValid) {
                    this.popUpCrearEvento(true);
                }
                else {
                    App.alertaFormulario(EventoValidacion);
                }
            }
        };

        // BOTONES CANCELAR
        public botonCancelar = {
            text: 'Cancelar',
            icon: 'close',
            type: 'danger',
            onClick: (e: any): void => {
                this.popUpCancelarCreacionUsuario(true);
            }
        };

        // VALIDADOR DE DATOS
        public validatorOptions: DevExpress.ui.dxValidatorOptions = {
            validationRules: [{
                type: 'required',
                message: 'Campo requerido'
            }]
        };

        // FORMULARIO
        public dxTitulo = {
            width: 'auto',
            editorOptions: {
                mode: 'text'
            },
            onKeyDown: (e) => {
                if (!/[a-zA-Z\s]$/.test(e.jQueryEvent.key)) {
                    e.jQueryEvent.preventDefault();
                }
                if (e.jQueryEvent.ctrlKey || e.jQueryEvent.altKey) {
                    e.jQueryEvent.preventDefault();
                }
            },
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.evento().titulo = e.value;
            }
        }

        public dxDescripcion = {
            width: 'auto',
            editorOptions: {
                mode: 'text'
            },
            maxLength: 120,
            height: 90,
            onKeyDown: (e) => {
                if (!/[a-zA-Z\s]$/.test(e.jQueryEvent.key)) {
                    e.jQueryEvent.preventDefault();
                }
                if (e.jQueryEvent.ctrlKey || e.jQueryEvent.altKey) {
                    e.jQueryEvent.preventDefault();
                }
            },
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.evento().descripcion = e.value;
            }
        }

        constructor() {

        }

    }
}