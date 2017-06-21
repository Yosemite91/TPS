/// <reference path='Utils.ts' />

namespace App {
    'use strict';
    export var appRoot: string;
    export var apiRoot: string;
    export var appPrefix: string = 'PERSONAS.';    
    export var esJefe: boolean = localStorage.getItem(App.appPrefix + 'login.esJefe');
    export var esGerente: boolean = localStorage.getItem(App.appPrefix + 'login.esGerente');
    export var esAdminPersona: boolean = localStorage.getItem(App.appPrefix + 'login.esAdminPersona');
    export var esAdminSistema: boolean = localStorage.getItem(App.appPrefix + 'login.esAdminSistema');
    export var runColaborador: string  = localStorage.getItem(App.appPrefix + 'login.run');
    
    $.ajaxSetup({
        headers: GetAutorizationHeaders(),
        error: (jqXHR: any, textStatus: any, errorThrown: any): void => {
            Utils.getErrores('', jqXHR, textStatus, errorThrown);
        }
    });

    function GetAutorizationHeaders(): { [key: string]: any; } {
        let token: string = localStorage.getItem(appPrefix + 'login.token');
        if (token) {
            return { 'Authorization': 'Basic ' + token };
        } else {
            return { 'Authorization': 'Anonymous' };
        }
    }

    export function goToLogin(): any {
        localStorage.removeItem(appPrefix + 'login.esJefe');
        localStorage.removeItem(appPrefix + 'login.esGerente');
        localStorage.removeItem(appPrefix + 'login.esAdminPersona');
        localStorage.removeItem(appPrefix + 'login.esAdminSistema');
        localStorage.removeItem(appPrefix + 'login.token');
        localStorage.removeItem(appPrefix + 'login.run');
        let urlLogin: string = 'http://' + window.location.host + App.apiRoot.replace('/api/', '/');
        window.location.href = urlLogin;
        return false;
    };
      
    export function anioMinimo(): any {
        var actual = new Date(); 
        var anioMinimo = actual.getFullYear() - 18;
        return anioMinimo;
    };
   
    export function alertaFormulario(anyObj: any): void {
        var i: number;
      
        for (i = 0; i < Object.keys(anyObj).length; i++) {                
            if (anyObj[Object.keys(anyObj)[i]] === null || anyObj[Object.keys(anyObj)[i]] === '' || anyObj[Object.keys(anyObj)[i]] === 0 ) {
                let name:any = Object.keys(anyObj)[i];
                DevExpress.ui.notify('Ingrese : ' + name, 'error', 3000);
                break;
            }
        }        
    }
}
