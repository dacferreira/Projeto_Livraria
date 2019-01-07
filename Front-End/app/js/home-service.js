(function(angular){

	var module = angular.module('projetolivro.services');

	module.factory('HomeService', ['Restangular', 'RestServiceBase', function(Restangular, RestServiceBase){


		var HomeService = function() {
			this.setMainRoute('home');
		}
		HomeService.prototype = new RestServiceBase();

		return new HomeService();

	}]);

})(angular);