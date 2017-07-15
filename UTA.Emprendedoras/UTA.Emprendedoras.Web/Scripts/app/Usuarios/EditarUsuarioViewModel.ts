/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IUsuarioModel.d.ts' />

namespace Usuarios {

    export class EditarUsuarioViewModel {
        public usuario: KnockoutObservable<IUsuarioModel> = ko.observable<IUsuarioModel>({
            id: null, nombre: null, apellido: null, run: null, contrasena: null, telefono: null, fechaNacimiento: null,
            esActivo: false, esAdministrador: false, esAdminPublicacion: false, sitioWebUrl: null, categoria: null, foto: null,
            email: null
        });

        //PopUp
        private popUpCancelarModificar = ko.observable(false);
        private popUpModificarUsuario = ko.observable(false);
        public popUpModificar = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Modificar usuario actual?',
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
                    if (this.FotoUsuario() === undefined) {
                        let foto: IFoto = {
                            cuerpo: this.fotoDX(),
                            usuarioID: null,
                            nombre: "foto",
                            id: null
                        }
                        this.FotoUsuario(foto);
                    }

                    var UsuarioDTO = {
                        nombre: this.usuario().nombre,
                        apellido: this.usuario().apellido,
                        telefono: this.usuario().telefono,
                        run: this.usuario().run,
                        fechaNacimiento: this.usuario().fechaNacimiento,
                        esActivo: this.usuario().esActivo,
                        esAdministrador: this.usuario().esAdministrador,
                        esAdminPublicacion: this.usuario().esAdminPublicacion,
                        sitioWebUrl: this.usuario().sitioWebUrl,
                        categoria: this.usuario().categoria,
                        email: this.usuario().email,
                        foto: this.FotoUsuario().cuerpo
                    };
                    var info = JSON.stringify(UsuarioDTO);

                    $.ajax({
                        url: App.apiRoot + 'usuarios/editar/',
                        cache: false,
                        type: 'PUT',
                        contentType: 'application/json; charset=utf-8',
                        data: info,
                        dataType: 'json'
                    }).then(
                        function (data) {
                            DevExpress.ui.notify('Usuario Modificado', 'success', 3000);
                            window.location.assign(App.appRoot + 'Usuarios/ListaUsuarios');
                        },
                        function (xhr, textStatus, err) {
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
                    Nombre: this.usuario().nombre,
                    Apellido: this.usuario().apellido,
                    Run: this.usuario().run,
                    FechaNacimiento: this.usuario().fechaNacimiento
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
        public nombreDX: KnockoutObservable<string> = ko.observable<string>();
        public apellidoDX: KnockoutObservable<string> = ko.observable<string>();
        public runDX: KnockoutObservable<string> = ko.observable<string>();
        public contrasenaDX: KnockoutObservable<string> = ko.observable<string>();
        public telefonoDX: KnockoutObservable<string> = ko.observable<string>();
        public fechaNacimientoDX: KnockoutObservable<Date> = ko.observable<Date>();
        public esActivoDX: KnockoutObservable<boolean> = ko.observable<boolean>();
        public esAdministradorDX: KnockoutObservable<boolean> = ko.observable<boolean>();
        public esAdminPublicacionDX: KnockoutObservable<boolean> = ko.observable<boolean>();
        public sitioWebUrlDX: KnockoutObservable<string> = ko.observable<string>();
        public categoriaDX: KnockoutObservable<string> = ko.observable<string>();
        public emailDX: KnockoutObservable<string> = ko.observable<string>();
        public fotoDX: KnockoutObservable<string> = ko.observable<string>();

        //Estableciendo el enlace
        public loadObject: (result: IUsuarioModel) => void = (result: IUsuarioModel): void => {
            this.nombreDX(result.nombre);
            this.apellidoDX(result.apellido);
            this.runDX(result.run);
            this.contrasenaDX(result.contrasena);
            this.telefonoDX(result.telefono);
            this.fechaNacimientoDX(result.fechaNacimiento);
            this.esActivoDX(result.esActivo);
            this.esAdministradorDX(result.esAdministrador);
            this.esAdminPublicacionDX(result.esAdminPublicacion);
            this.sitioWebUrlDX(result.sitioWebUrl);
            this.categoriaDX(result.categoria);    
            this.emailDX(result.email);
            this.fotoDX(result.foto);
        }

        // VALIDADOR DE DATOS
        public validatorOptions: DevExpress.ui.dxValidatorOptions = {
            validationRules: [{
                type: 'required',
                message: 'Campo requerido'
            }]
        };
        public emailValidatorOptions: DevExpress.ui.dxValidatorOptions = {
            validationRules: [{
                type: "pattern",
                pattern: /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i,
                message: 'Formato inválido'
            }, {
                    type: 'required',
                    message: 'Campo requerido'
                }]
        };
        public telefonoValidatorOptions: DevExpress.ui.dxValidatorOptions = {
            validationRules: [{
                type: "pattern",
                pattern: /^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$/,
                message: 'Formato inválido'
            }, {
                    type: 'required',
                    message: 'Campo requerido'
                }]
        };
        public urlValidatorOptions: DevExpress.ui.dxValidatorOptions = {
            validationRules: [{
                type: "pattern",
                pattern: /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/,
                message: 'Formato inválido'
            }, {
                    type: 'required',
                    message: 'Campo requerido'
                }]
        };

        // FORMULARIO
        public dxNombre = {
            value: this.nombreDX,
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
                this.usuario().nombre = e.value;
            }
        }
        public dxApellido = {
            value: this.apellidoDX,
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
                this.usuario().apellido = e.value;
            }
        }
        public dxRun = {
            value: this.runDX,
            width: 'auto',
            mask: 'ZZ.ZZZ.ZZZYK',
            maskRules: {
                'Z': /\d/,
                'K': /[0-9kK]/,
                'Y': /-/
            },
            validationRules: [{
                type: 'required',
                message: 'Campo requerido'
            }],
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.usuario().run = e.value
            }
        }
        public dxTelefono = {
            value: this.telefonoDX,
            width: 'auto',
            placeholder: '+56 9 1234 5678',
            editorOptions: {
                mode: 'tel',
                value: 0
            },
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.usuario().telefono = e.value;
            }
        }
        public dxFechaNacimiento = {
            value: this.fechaNacimientoDX,
            width: 'auto',
            editorOptions: {
                format: 'dd/MM/yyyy',
                width: 'auto',
                adaptivityEnabled: true,
                dateOutOfRangeMessage: 'Valor fuera de rango'
            },
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.usuario().fechaNacimiento = new Date(e.value);
            }
        }
        public dxEsAdminSistema = {
            value: this.esAdministradorDX,
            onText: 'SI',
            offText: 'NO',
            onValueChanged: (e: any) => {
                this.usuario().esAdministrador = e.value;
            }
        }
        public dxEsAdminPublicacion = {
            value: this.esAdminPublicacionDX,
            onText: 'SI',
            offText: 'NO',
            onValueChanged: (e: any) => {
                this.usuario().esAdminPublicacion = e.value;
            }
        }
        public dxActivo = {
            value: this.esActivoDX,
            onText: 'SI',
            offText: 'NO',
            onValueChanged: (e: any) => {
                this.usuario().esActivo = e.value;
            }
        }
        public dxSitioWeb = {
            value: this.sitioWebUrlDX,
            width: 'auto',
            placeholder: 'http://www.miPagina.com',
            editorOptions: {
                mode: 'text'
            },
            validationRules: [{
                type: 'required',
                message: 'Campo requerido'
            }],
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.usuario().sitioWebUrl = e.value;
            }
        }
        public dxCategoria = {
            value: this.categoriaDX,
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
                this.usuario().categoria = e.value;
            }
        }
        public dxEmail = {
            value: this.emailDX,
            width: 'auto',
            placeholder: 'ejemplo@tpa.cl',           
            editorOptions: {
                mode: 'email',
            },
            validationRules: [{
                type: 'required',
                message: 'Campo requerido'
            }],
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.usuario().email = e.value;
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
        public esNuevo: KnockoutObservable<boolean> = ko.observable(false);

        constructor() {
            this.loading(true);
            const run: string = window.location.search.replace('?run=', '');
            
            $.getJSON(App.apiRoot + 'usuarios/get/' + run).then((result: IUsuarioModel): void => {
                this.loadObject(result);
                this.fotoDX(result.foto);
                this.loading(false);
            });
        }

    }

}