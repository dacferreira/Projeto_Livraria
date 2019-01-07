  (function(angular) {

  'use strict';

    angular.module('myApp')
        .controller('NavController', NavController);

    NavController.$inject = ['$scope', '$location'];
    function NavController($scope, $location) {
         
         $scope.GoToView = goToView;

        function goToView(view) {
            $location.path(view);
        };        
    };    

})(angular);