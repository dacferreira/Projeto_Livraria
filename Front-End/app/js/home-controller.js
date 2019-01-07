  'use strict';

  angular.module('myApp')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$scope', '$location', 'HomeService'];
    function HomeController($scope, $location, HomeService) {

    $scope.CreateLivro = createLivro;

     function createLivro() {
              $location.path('/livro/include');
     };

    };        
