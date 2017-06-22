/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IUsuarioModel.d.ts' />

namespace Usuarios {
    export class CrearUsuarioViewModel {
        public usuario: KnockoutObservable<IUsuarioModel> = ko.observable<IUsuarioModel>({
            id: null, nombre: null, apellido: null, run: null, contrasena: null, telefono: null, fechaNacimiento: null,
            esActivo: false, esAdministrador: false, esAdminPublicacion: false, sitioWebUrl: null, categoria: null, foto: null,
            correo: null,email: null
        });

        //PopUp
        private popUpCancelarCreacionUsuario = ko.observable(false);
        private popUpCrearUsuario = ko.observable(false);

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
                    window.location.assign(App.appRoot + 'Usuarios/ListaUsuarios');
					// CORREGIR PARA CUANDO SE TENGA LA LISTA DE USUARIOS
                }
            }
            ]
        };

        // POP-UP CREAR
        public popUpCrear = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Quiere crear este nuevo usuario?',
            showTitle: true,
            showCloseButton: true,
            title: 'Alerta',
            visible: this.popUpCrearUsuario,
            dragEnabled: false,
            closeOnOutsideClick: false,
            toolbarItems: [{
                toolbar: 'bottom',
                widget: 'dxButton',
                options: { text: 'OK' },
                onClick: (e: any): void => {
                    //Volcando información de formulario
                    var UsuarioDTO = {
                        nombre: this.usuario().nombre,
                        apellido: this.usuario().apellido,
                        telefono: this.usuario().telefono,
                        run: this.usuario().run,
                        contrasena: this.usuario().contrasena,
                        fechaNacimiento: this.usuario().fechaNacimiento,
                        esActivo: true,
                        esAdministrador: this.usuario().esAdministrador,
                        esAdminPublicacion: this.usuario().esAdminPublicacion,
                        sitioWebUrl: this.usuario().sitioWebUrl,
                        categoria: this.usuario().categoria,
                        correo: this.usuario().correo
                    };

                    var info = JSON.stringify(UsuarioDTO);
                    $.ajax({
                        url: App.apiRoot + 'usuarios/crear',
                        cache: false,
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        data: info,
                        dataType: 'json'
                    }).then(
                        function (data) {
                            DevExpress.ui.notify('USUARIO CREADO', 'success', 3000);
                            window.location.assign(App.appRoot + 'Usuarios/ListaUsuarios');
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

                var UsuarioValidacion = {
                    Nombre: this.usuario().nombre,
                    Apellido: this.usuario().apellido,
                    Run: this.usuario().run,
                    Correo: this.usuario().correo,
                    Telefono: this.usuario().telefono,
                    SitioWeb: this.usuario().sitioWebUrl,
                    Categoria: this.usuario().categoria
                };

                if (result.isValid) {
                    this.popUpCrearUsuario(true);
                }
                else {
                    App.alertaFormulario(UsuarioValidacion);
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

		// FORMULARIO
        public dxNombre = {
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
                this.usuario().nombre = e.value;
            }
        }
        public dxApellido = {
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
            width: 'auto',
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
        public dxEmail = {
            width: 'auto',
            placeholder: 'ejemplo@uta.cl',
            onKeyDown: (e: any) => {
                if (!/[_a-zA-Z0-9-@.]$/.test(e.jQueryEvent.key)) {
                    e.jQueryEvent.preventDefault();
                }
            },
            showClearButton: true,
            onValueChanged: (e: any) => {
                this.usuario().correo = e.value;
            }
        }		
        public dxEsAdminSistema = {
            value: false,
            onText: 'SI',
            offText: 'NO',
            onValueChanged: (e: any) => {
                this.usuario().esAdministrador = e.value;
            }
        }
        public dxEsAdminPublicacion = {
            value: false,
            onText: 'SI',
            offText: 'NO',
            onValueChanged: (e: any) => {
                this.usuario().esAdminPublicacion = e.value;
            }
        }
        public dxSitioWeb = {
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
                this.usuario().sitioWebUrl = e.value;
            }
        }
        public dxCategoria = {
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
        
        constructor() {

        }
    }
}
