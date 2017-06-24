/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IUsuarioModel.d.ts' />

namespace Usuarios {

    export class MiPerfilViewModel {
        public usuario: KnockoutObservable<IUsuarioModel> = ko.observable<IUsuarioModel>({
            id: null, nombre: null, apellido: null, run: null, contrasena: null, telefono: null, fechaNacimiento: null,
            esActivo: false, esAdministrador: false, esAdminPublicacion: false, sitioWebUrl: null, categoria: null, foto: null,
            email: null
        });

        //PopUp
        private visiblePopupCambiarPass = ko.observable(false);
        public popUpCambiarPass = {
            width: 'auto',
            height: 'auto',
            contentTemplate: '¿Cambiar contraseña actual?',
            showTitle: true,
            showCloseButton: true,
            title: 'Password',
            visible: this.visiblePopupCambiarPass,
            dragEnabled: false,
            closeOnOutsideClick: false,
            toolbarItems: [{
                toolbar: 'bottom',
                widget: 'dxButton',
                options: { text: 'Aceptar' },
                onClick: (e: any): void => {
                    let that: any = this;
                    var pass: string = this.password().password;
                    var passConfirmar: string = this.password().confirmarPassword;
                    if ((pass === passConfirmar) && (pass !== null || pass !== undefined)) {
                        var UsuarioDTO = {
                            run: this.usuario().run,
                            contrasena: this.password().password
                        };
                        var info = JSON.stringify(UsuarioDTO);
                        $.ajax({
                            url: App.apiRoot + 'usuarios/cambiar-contrasena/',
                            cache: false,
                            type: 'PUT',
                            contentType: 'application/json; charset=utf-8',
                            data: info,
                            dataType: 'json'
                        }).then(
                            function (data) {
                                that.visiblePopupCambiarPass(false);       
                                DevExpress.ui.notify('Contraseña actualizada', 'success', 3000);
                            },
                            function (xhr, textStatus, err) {
                                alert(err);

                            });
                    } else {
                        this.visiblePopupCambiarPass(false);
                        DevExpress.ui.notify('Contraseñas no coinciden o no ha rellenado los campos', 'error', 3000);
                    }

                }
            }]
        };
        //Observables
        public password: KnockoutObservable<any> = ko.observable<any>({ password: null, confirmarPassword: null });

        //Buttons
        public applyButtonOptionsModificar = {
            text: 'Modificar',
            icon: 'edit',
            type: 'default',
            onClick: function (e: any) {
                var run = this.usuario().run;
                window.location.assign(App.appRoot + 'Usuarios/EditarUsuario?run=' + run);
            }
        };
        public applyButtonOptionsModificarContrasena = {
            text: 'Cambiar contrasena',
            icon: 'edit',
            type: 'success',
            onClick: function (e: any) {
                this.visiblePopupCambiarPass(true);         
            }
        };
        
        //Notificaciones
        public goBack = {
            icon: 'back',
            type: 'normal',
            onClick: (e: any): void => {
                window.history.back();
            }
        };

        //Formulario
        public form: DevExpress.ui.dxFormOptions = {
            formData: this.usuario,
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
                    caption: 'Información Personal',
                    items: ['nombre', 'apellido', 'run', 'telefono',
                        <DevExpress.ui.dxFormSimpleItem>{
                            dataField: 'fechaNacimiento',
                            editorType: 'dxDateBox',
                            editorOptions: {
                                displayFormat: 'dd/MM/yyyy',
                                width: 'auto'
                            }
                        }
                    ]
                },
                <DevExpress.ui.dxFormGroupItem>{
                    itemType: 'group',
                    caption: 'Información de Sistema',
                    items: [
                        <DevExpress.ui.dxFormSimpleItem>{
                            dataField: 'esAdministrador',
                            editorType: 'dxSwitch',
                            editorOptions: {
                                onText: 'SI',
                                offText: 'NO'
                            }
                        },
                        <DevExpress.ui.dxFormSimpleItem>{
                            dataField: 'esAdminPublicacion',
                            editorType: 'dxSwitch',
                            editorOptions: {
                                onText: 'SI',
                                offText: 'NO'
                            }
                        },
                        'sitioWebUrl',
                        'categoria']
                }                
            ]
        };

        public formContrasena: DevExpress.ui.dxFormOptions = {
            formData: this.password,
            readOnly: false,
            items: [<DevExpress.ui.dxFormGroupItem>{
                itemType: 'group',
                caption: 'Cambiar Contraseña',
                items: [
                    <DevExpress.ui.dxFormGroupItem>{
                        dataField: 'password',
                        label: { text: 'Nuevo Contraseña' }
                    },
                    <DevExpress.ui.dxFormGroupItem>{
                        dataField: 'confirmarPassword'
                    }
                ]
            }]            
        }
        public loading: KnockoutObservable<boolean> = ko.observable(false);
        constructor() {
            const run: string = window.location.search.replace('?run=', '');

            this.loading(true);
            $.getJSON(App.apiRoot + 'usuarios/get/' + run).then((result: IUsuarioModel): void => {
                this.usuario(result);
                $('#usuario-form').dxForm('instance').repaint();
                $('#usuario-form-contrasena').dxForm('instance').repaint();
                this.loading(false);
            });

        }
    }
}
