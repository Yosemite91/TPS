/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../../typings/devextreme/devextreme.d.ts" />
/// <reference path="../app.ts" />

namespace Index {

    export class IndexViewModel {

        public galleryOptions: DevExpress.ui.dxGalleryOptions = {
            dataSource: [
                "https://js.devexpress.com/Content/images/doc/17_1/PhoneJS/person1.png",
                "https://js.devexpress.com/Content/images/doc/17_1/PhoneJS/person2.png",
                "https://js.devexpress.com/Content/images/doc/17_1/PhoneJS/person3.png",
                "https://js.devexpress.com/Content/images/doc/17_1/PhoneJS/person4.png"                
            ],            
            animationDuration: 500,
            animationEnabled: true,
            slideshowDelay: 4000,
            loop: true,
            showNavButtons: true,
            showIndicator: true,
            stretchImages: true,
            swipeEnabled: true,
            onItemClick: null
        }

        constructor() {

        }
    }   
}
