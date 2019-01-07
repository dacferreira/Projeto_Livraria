(function (angular) {

    'use strict';

    angular.module('myApp')
        .controller('LivroIncludeEditController', LivroIncludeEditController);

    LivroIncludeEditController.$inject = ['$scope', 'LivroService', '$mdDialog', '$location', '$routeParams', '$http'];
    function LivroIncludeEditController($scope, LivroService, $mdDialog, $location, $routeParams, $http) {
        var id = $routeParams.id;
        $scope.isEdit = false;
        $scope.disableButton = false;
        $scope.Create = create;
        
        var self = this;

        (function init() {
            if (id) {
                $scope.livro = [];
                LivroService.getById(id).then(function (result) {
                    $scope.isEdit = true;
                    $scope.livro.Id = result.Id;
                    $scope.livro.ISBN = result.ISBN;
                    $scope.livro.Autor = result.Autor;
                    $scope.livro.Nome = result.Nome;
                    $scope.livro.Preco = result.Preco;
                    $scope.livro.DataPublicacao = new Date(result.DataPublicacao);
                }, function (err) {
                    showAlert('Erro.', 'Ocorreu um ao realizar a operação.');
                    console.error(err);
                });
            }
        })();

        function showAlert(titulo, mensagem) {
            var alert = $mdDialog.alert({
                title: titulo,
                textContent: mensagem,
                ok: 'Ok'
            });

            $mdDialog.show(alert);
        };

        $scope.add = function () {
            var f = document.getElementById('imagemCapa').files[0],
                r = new FileReader();
            
            r.onload = function (e) {
                var byteString = r.result;
                const arrayBuffer = new ArrayBuffer(byteString.length);
                const array = new Array(arrayBuffer);
                for (let i = 0; i < byteString.length; i++) {
                    array[i] = byteString.charCodeAt(i);
                }

                $scope.livro.ImagemCapa = array;
            }

            r.readAsBinaryString(f);
        }
        function create(livro) {
            $scope.disableButton = true;
            if (livro !== undefined && livro.Id)
                saveChange($scope.livro);
            else {
                LivroService.include(livro).then(function (result) {
                    $scope.disableButton = false;
                    showAlert('Sucesso.', 'Operação realizada com sucesso.');
                    $location.path('/livro');
                }, function (err) {
                    showAlert('Erro.', err.data.Message);
                    console.error(err);
                    $scope.disableButton = false;
                });
            }
        };
        function saveInclude(livro) {
            LivroService.include(livro).then(function (result) {
                $scope.disableButton = false;
                showAlert('Sucesso.', 'Operação realizada com sucesso.');
                $location.path('/livro');
            }, function (err) {
                showAlert('Erro.', err.data.Message);
                console.error(err);
                $scope.disableButton = false;
            });
        };
        function saveChange(livro) {
            var urlCompleta = livro.Id + "?preco="+ livro.Preco;
            LivroService.changeLivro(urlCompleta).then(function (result) {
                $scope.disableButton = false;
                showAlert('Sucesso.', 'Operação realizada com sucesso.');
                $location.path('/livro');
            }, function (err) {
                showAlert('Erro.', err.data.Message);
                console.error(err);
                $scope.disableButton = false;
            });
        };
    };

})(angular);