(function(angular) {

    'use strict'
    angular.module('projetolivro', [
        'restangular',
        'projetolivro.services'
        ]);

    angular.module('projetolivro.services', []);

    angular
        .module('myApp', [            
            'ngRoute',
            'ngMaterial',
            'projetolivro'
        ])
         .config(function (RestangularProvider) {

            var baseUrl = "http://localhost:8001/api";
            
            RestangularProvider.setBaseUrl(baseUrl);               
    });

})(angular);
