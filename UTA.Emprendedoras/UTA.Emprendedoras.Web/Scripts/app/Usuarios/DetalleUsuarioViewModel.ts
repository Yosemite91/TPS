﻿/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />
/// <reference path='IUsuarioModel.d.ts' />

namespace Usuarios {

    export class DetalleUsuarioViewModel {
        public usuario: KnockoutObservable<IUsuarioModel> = ko.observable<IUsuarioModel>({
            id: null, nombre: null, apellido: null, run: null, contrasena: null, telefono: null, fechaNacimiento: null,
            esActivo: false, esAdministrador: false, esAdminPublicacion: false, sitioWebUrl: null, categoria: null, foto: null,
            email: null
        });

        //PopUp

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
        public botonBloquear = {
            text: 'Bloquear',
            type: 'danger',
            icon: 'close',
            onClick: function (e: any) {
                var UsuarioDTO = {
                    run: this.usuario().run,
                };
                var info = JSON.stringify(UsuarioDTO);
                $.ajax({
                    url: App.apiRoot + 'usuarios/bloquear/',
                    cache: false,
                    type: 'PUT',
                    contentType: 'application/json; charset=utf-8',
                    data: info,
                    dataType: 'json'
                }).then(
                    function (data) {
                        DevExpress.ui.notify('Usuario Bloqueado', 'success', 3000);
                        window.location.assign(App.appRoot + 'Usuarios/ListaUsuarios');
                    },
                    function (xhr, textStatus, err) {
                        alert(err);
                    });
            }
        };
        public botonDesbloquear = {
            text: 'Desbloquear',
            icon: 'check',
            type: 'success',
            onClick: (e: any): void => {
                var UsuarioDTO = {
                    run: this.usuario().run,
                };
                var info = JSON.stringify(UsuarioDTO);
                $.ajax({
                    url: App.apiRoot + 'usuarios/desbloquear/',
                    cache: false,
                    type: 'PUT',
                    contentType: 'application/json; charset=utf-8',
                    data: info,
                    dataType: 'json'
                }).then(
                    function (data) {
                        DevExpress.ui.notify('Usuario Desbloqueado', 'success', 3000);
                        window.location.assign(App.appRoot + 'Usuarios/ListaUsuarios');
                    },
                    function (xhr, textStatus, err) {
                        alert(err);
                    });
            }
        };

        //Notificaciones
        public applyButtonOptionsRestaurarPass = {
            text: 'Restablecer Contraseña',
            icon: 'refresh',
            type: 'success',
            onClick: function (e: any): void {
                var UsuarioDTO = {
                    run: this.usuario().run,
                };
                var info = JSON.stringify(UsuarioDTO);
                $.ajax({
                    url: App.apiRoot + 'usuarios/restablecer-contrasena/',
                    cache: false,
                    type: 'PUT',
                    contentType: 'application/json; charset=utf-8',
                    data: info,
                    dataType: 'json'
                }).then(
                    function (data) {
                        DevExpress.ui.notify('Contraseña Restablecida', 'success', 3000);
                        window.location.assign(App.appRoot + 'Usuarios/ListaUsuarios');
                    },
                    function (xhr, textStatus, err) {
                        alert(err);
                    });
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
                        }, 'email'
                    ]
                },
                <DevExpress.ui.dxFormGroupItem>{
                    itemType: 'group',
                    caption: 'Información de Sistema',
                    items: [
                        <DevExpress.ui.dxFormSimpleItem>{
                        dataField: 'esActivo',
                        editorType: 'dxSwitch',
                        editorOptions: {
                            onText: 'SI',
                            offText: 'NO'
                        }
                        },
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

        //Foto
        public fotoPerfil: KnockoutObservable<IFoto> = ko.observable<IFoto>();
        public MakePhoto: (cuerpo: string) => void = (cuerpo: string): void => {
            let foto: IFoto = {
                id: null,
                cuerpo: cuerpo,
                nombre: null,
                usuarioID: null
            }
            this.fotoPerfil(foto);
        }

        public loading: KnockoutObservable<boolean> = ko.observable(false);
        constructor() {
            const run: string = window.location.search.replace('?run=', '');

            this.loading(true);
            $.getJSON(App.apiRoot + 'usuarios/get/' + run).then((result: IUsuarioModel): void => {
                this.usuario(result);
                this.MakePhoto(result.foto);
                $('#usuario-form').dxForm('instance').repaint();
                this.loading(false);
            });

        }
    }
    

}