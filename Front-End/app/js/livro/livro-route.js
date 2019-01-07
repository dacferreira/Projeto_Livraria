(function(angular) {

    'use strict'

    angular
        .module('myApp')
        .config(function($routeProvider) {

    		$routeProvider.otherwise('/');

            $routeProvider
                .when('/livro', {
                    templateUrl: 'views/livro/livro-list.html',
                    controller: 'LivroListController'
                })
                .when('/livro/edit/:id', {
                    templateUrl: 'views/livro/livro-include-edit.html',
                    controller: 'LivroIncludeEditController'
                })
                .when('/livro/include', {
                    templateUrl: 'views/livro/livro-include-edit.html',
                    controller: 'LivroIncludeEditController'
                })
                ;
    	});

})(angular);
