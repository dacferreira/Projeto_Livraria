  (function(angular) {

  'use strict';

    angular.module('myApp')
        .controller('LivroListController', LivroListController);

    LivroListController.$inject = ['$scope', '$location', 'LivroService', '$mdDialog'];
    function LivroListController($scope, $location, LivroService, $mdDialog) {
         
         $scope.Include = include;
         $scope.Edit = edit;
         $scope.Remove = remove;
         $scope.Livros = [];

         function showAlert(titulo, mensagem) {
            var alert = $mdDialog.alert({
                title: titulo,
                textContent: mensagem,
                ok: 'Ok'
            });

            $mdDialog.show(alert);
        };
       
        function livro(){
                LivroService.getAll().then(function (result) {

                $scope.Livros = result;
            }, function (err) { 
                console.error(err); 
            });
        };
        livro();

        function include() {
            $location.path('/livro/include');
        };
        
        function edit(livro){
            var url = '/livro/edit/' + livro.Id;
            $location.path(url);
        };
        
        function remove(livro){
            var confirm = $mdDialog.confirm()
                .title('Confirma exclusão?')
                .textContent('Os dados serão perdidos.')
                .ariaLabel('Lucky day')
                .targetEvent(livro)
                .ok('Confirmar')
                .cancel('Sair');

            $mdDialog.show(confirm).then(function() {
                LivroService.removeById(livro.Id).then(function (result) {                
                    showAlert('Sucesso.', 'Operação realizada com sucesso.');
                    var index = $scope.Livros.map(function (x) { return x.Id; }).indexOf(livro.Id);
                    $scope.Livros.splice(index, 1);
                }, function (err) { 
                    var back = err.data != null ? err.data.ExceptionMessage : "";
                    showAlert('Erro.', back ? back : 'Ocorreu um ao realizar a operação.');
                    console.error(err); 
                });
                }, function() {
                
                });
        };
    };    

})(angular);