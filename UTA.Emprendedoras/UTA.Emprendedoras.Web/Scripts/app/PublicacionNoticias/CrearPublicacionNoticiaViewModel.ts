/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IPublicacionNoticiaModel.d.ts' />

namespace PublicacionNoticias {

    export class CrearPublicacionNoticiaViewModel {
        public noticia: KnockoutObservable<IPublicacionNoticiaModel> = ko.observable<IPublicacionNoticiaModel>({
            id: null, titulo: null, descripcion: null, fechaPublicacion: null, foto: null
        });

        //PopUp
        private popUpCancelarCreacionNoticia = ko.observable(false);
        private popUpCrearNoticia = ko.observable(false);

        // POP-UP CANCELAR
        public popUpCancelar = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Volver a la página anterior?',
            showTitle: true,
            showCloseButton: true,
            title: 'Alerta',
            visible: this.popUpCancelarCreacionNoticia,
            dragEnabled: false,
            closeOnOutsideClick: false,
            toolbarItems: [{
                toolbar: 'bottom',
                widget: 'button',
                options: { text: 'OK' },
                onClick: function (e: any) {
                    window.location.assign(App.appRoot + 'PublicacionNoticias/ListaNoticias');
                }
            }
            ]
        };
        // POP-UP CREAR
        public popUpCrear = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Quiere crear este nuevo noticia?',
            showTitle: true,
            showCloseButton: true,
            title: 'Alerta',
            visible: this.popUpCrearNoticia,
            dragEnabled: false,
            closeOnOutsideClick: false,
            toolbarItems: [{
                toolbar: 'bottom',
                widget: 'dxButton',
                options: { text: 'OK' },
                onClick: (e: any): void => {
                    //Volcando información de formulario
                    var NoticiaDTO = {
                        titulo: this.noticia().titulo,
                        descripcion: this.noticia().descripcion
                    };

                    var info = JSON.stringify(NoticiaDTO);
                    $.ajax({
                        url: App.apiRoot + 'publicacion-noticias/crear',
                        cache: false,
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        data: info,
                        dataType: 'json'
                    }).then(
                        function (data) {
                            DevExpress.ui.notify('NOTICIA CREADO', 'success', 3000);
                            window.location.assign(App.appRoot + 'PublicacionNoticias/ListasNoticias');
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

                var NoticiaValidacion = {
                    Titulo: this.noticia().titulo,
                    Descripcion: this.noticia().descripcion
                };

                if (result.isValid) {
                    this.popUpCrearNoticia(true);
                }
                else {
                    App.alertaFormulario(NoticiaValidacion);
                }
            }
        };

        // BOTONES CANCELAR
        public botonCancelar = {
            text: 'Cancelar',
            icon: 'close',
            type: 'danger',
            onClick: (e: any): void => {
                this.popUpCancelarCreacionNoticia(true);
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
                this.noticia().titulo = e.value;
            }
        }

        public dxDescripcion = {
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
                this.noticia().descripcion = e.value;
            }
        }

        constructor() {
            
        }
    }
}