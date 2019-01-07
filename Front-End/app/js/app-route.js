(function(angular) {

    'use strict'

    angular
        .module('myApp')
        .config(function($routeProvider) {

    		$routeProvider.otherwise('/');

            $routeProvider
                .when('/', {
                    templateUrl: 'views/home.html',
                    controller: 'HomeController'
                });
    	});

})(angular);
