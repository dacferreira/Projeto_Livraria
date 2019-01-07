(function(angular){

	var services = angular.module('myApp');

	services.factory('RestServiceBase', function(Restangular) {

		var _service = function(){

		
			this.mainRoute = undefined;
            
	        this.getFullRoute = function(){
				return  Restangular.configuration.baseUrl + '/' + this.mainRoute; 
			};
            
	        this.setMainRoute = function(mainRoute){
	        	this.mainRoute = mainRoute;
	        };

			this.getAll = function(){
				if (!this.mainRoute) throw "mainRoute not configured.";

				var promise = Restangular.all(this.mainRoute)
					.getList();

				return promise;
			};

			this.getById = function(id){
				if (!id) throw "id uninformed";
				if (!this.mainRoute) throw "mainRoute not configured.";

				var promise = Restangular.one(this.mainRoute, id)
					.get();

				return promise;
			};

			this.include = function(newObject){
				if (!this.mainRoute) throw "mainRoute not configured.";

				var promise = Restangular.all(this.mainRoute)
					.post(newObject);

				return promise;
			};


			this.change = function(model){
				var promise = Restangular.all(this.mainRoute).put(model);

				return promise;
			};

			this.removeById = function(id){
				if (!this.mainRoute) throw "mainRoute not configured.";

				var promise = Restangular.one(this.mainRoute, id)
					.remove();

				return promise;
			};

		};

		return _service;

	});


})(angular);