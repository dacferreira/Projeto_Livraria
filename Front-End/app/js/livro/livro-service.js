(function(angular){

	var module = angular.module('projetolivro.services');

	module.factory('LivroService', ['Restangular', 'RestServiceBase', function(Restangular, RestServiceBase){


		var LivroService = function() {
			this.setMainRoute('livro');

            this.changeLivro = function (url) {
				if (!this.mainRoute) throw "mainRoute não configurada.";

                 return Restangular.all(this.mainRoute)
					.one(url)
					.post();
			}
		}
		LivroService.prototype = new RestServiceBase();

		return new LivroService();

	}]);

})(angular);