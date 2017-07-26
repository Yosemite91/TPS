/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IPublicacionEventoModel.d.ts' />

namespace PublicacionEventos {
    export class EditarPublicacionEventoViewModel {
        public evento: KnockoutObservable<IPublicacionEventoModel> = ko.observable<IPublicacionEventoModel>({
            id: null, titulo: null, descripcion: null, fechaPublicacion: null, foto: null, fechaRealizacion: null
        });

        //PopUp
        private popUpCancelarModificar = ko.observable(false);
        private popUpModificarUsuario = ko.observable(false);

        public popUpModificar = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Modificar evento actual?',
            showTitle: true,
            showCloseButton: true,
            title: 'Alerta',
            visible: this.popUpModificarUsuario,
            dragEnabled: false,
            closeOnOutsideClick: false,
            toolbarItems: [{
                toolbar: 'bottom',
                widget: 'button',
                options: { text: 'OK' },
                onClick: (e: any): void => {
                    this.loading(true);
                    if (this.FotoUsuario() === undefined) {
                        let foto: IFoto = {
                            cuerpo: this.fotoDX(),
                            usuarioID: null,
                            nombre: "foto",
                            id: null
                        }
                        this.FotoUsuario(foto);
                    }

                    var EventoDTO = {
                        id: this.evento().id,
                        titulo: this.evento().titulo,
                        descripcion: this.evento().descripcion,
                        foto: this.FotoUsuario().cuerpo,
                        fechaRealizacion: this.evento().fechaRealizacion
                    };
                    var info = JSON.stringify(EventoDTO);

                    $.ajax({
                        url: App.apiRoot + 'publicacion-eventos/editar/',
                        cache: false,
                        type: 'PUT',
                        contentType: 'application/json; charset=utf-8',
                        data: info,
                        dataType: 'json'
                    }).then(
                        function (data) {
                            DevExpress.ui.notify('Evento Modificado', 'success', 3000);
                            window.location.assign(App.appRoot + 'PublicacionEventos/ListaPublicacionEventos');
                        },
                        function (xhr, textStatus, err) {
                            this.loading(false);
                            alert(err);
                        });
                }
            }]
        };

        public popUpCancelar = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Volver a la página principal?',
            showTitle: true,
            showCloseButton: true,
            title: 'Alerta',
            visible: this.popUpCancelarModificar,
            dragEnabled: false,
            closeOnOutsideClick: false,
            toolbarItems: [{
                toolbar: 'bottom',
                widget: 'button',
                options: { text: 'OK' },
                onClick: function (e: any) {
                    window.history.back();
                }
            }]
        };

        //Buttons
        public botonGuardar = {
            text: 'Guardar',
            type: 'success',
            icon: 'floppy',
            onClick: function (e: any) {
                var result = e.validationGroup.validate();

                var UsuarioValidacion = {
                    nombre: this.evento().titulo,
                    descripcion: this.evento().descripcion,
                };

                if (result.isValid) {
                    this.popUpModificarUsuario(true);
                }
                else {
                    App.alertaFormulario(UsuarioValidacion);
                }
            }
        };
        public botonCancelarEdicion = {
            text: 'Cancelar',
            icon: 'close',
            type: 'danger',
            onClick: (e: any): void => {
                this.popUpCancelarModificar(true);
            }
        };

        //Declaración de observables
        public tituloDX: KnockoutObservable<string> = ko.observable<string>();
        public descripcionDX: KnockoutObservable<string> = ko.observable<string>();
        public fechaRealizacionDX: KnockoutObservable<Date> = ko.observable<Date>();
        public fotoDX: KnockoutObservable<string> = ko.observable<string>();

        public loadObject: (result: IPublicacionEventoModel) => void = (result: IPublicacionEventoModel): void => {
            this.tituloDX(result.titulo);
            this.descripcionDX(result.descripcion);
            this.fotoDX(result.foto);
            this.fechaRealizacionDX(result.fechaRealizacion);
        }

        // VALIDADOR DE DATOS
        public validatorOptions: DevExpress.ui.dxValidatorOptions = {
            validationRules: [{
                type: 'required',
                message: 'Campo requerido'
            }]
        };

        // FORMULARIO
        public dxTitulo = {
            value: this.tituloDX,
            width: 'auto',
            editorOptions: {
                mode: 'text'
            },            
            validationRules: [{
                type: 'required',
                message: 'Campo requerido'
            }],
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.evento().titulo= e.value;
            }
        }
        public dxDescripcion = {
            value: this.descripcionDX,
            width: 'auto',
            editorOptions: {
                mode: 'text'
            },
            maxLength: 120,
            height: 90,            
            validationRules: [{
                type: 'required',
                message: 'Campo requerido'
            }],
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.evento().descripcion = e.value;
            }
        }
        public dxFechaRealizacion = {
            value: this.fechaRealizacionDX,
            editorOptions: {
                format: 'dd/MM/yyyy'
            },
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.evento().fechaRealizacion = new Date(e.value);
            }
        }
        public dxSubirImagen = {
            allowCanceling: true,
            multiple: false,
            readyToUploadMessage: 'Listo para cargar achivo',
            selectButtonText: 'Seleccionar imagen',
            uploadButtonText: 'Subir',
            uploadedMessage: 'Archivo cargado',
            uploadedFailMessage: 'Error al cargar archivo',
            uploadMethod: 'POST',
            uploadMode: 'useForm',
            focusStateEnabled: true,
            uploadUrl: '/',
            showFileList: true,
            labelText: '',
            accept: 'image/*',
            onValueChanged: (e) => {
                let createLoadHandler = (nombre: string) => {
                    return (event) => {
                        let foto: IFoto = {
                            cuerpo: event.target.result,
                            usuarioID: null,
                            nombre: nombre,
                            id: null
                        }
                        this.FotoUsuario(foto);
                    }
                }
                let frb = new FileReader();
                frb.onload = createLoadHandler(e.value[0].name);
                frb.readAsDataURL(e.value[0]);
            }
        }

        public FotoUsuario: KnockoutObservable<IFoto> = ko.observable<IFoto>();
        public loading: KnockoutObservable<boolean> = ko.observable(false);

        constructor() {
            this.loading(true);
            const id: string = window.location.search.replace('?id=', '');
                        
            $.getJSON(App.apiRoot + 'publicacion-eventos/get/' + id).then((result: IPublicacionEventoModel): void => {
                this.loadObject(result);
                this.fotoDX(result.foto);
                this.evento().id = result.id;
                this.loading(false);
            });
        }

    }
}
