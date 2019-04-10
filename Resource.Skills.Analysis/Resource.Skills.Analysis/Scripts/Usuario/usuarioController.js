angular.module("resourceSkillsAnalysis").register.controller('usuarioController', ['$scope', '$http', 'helperService', function ($scope, $http, helperService) {
    $scope.inicializar = function () {
        $scope.mostrarCadastroUsuario = false;
        $scope.mostrarListaUsuarios = true;
        $scope.usuarios = [];
        $scope.resetarModel();
        $scope.listarUsuarios();
    };
    $scope.aoClicarNovoUsuario = function () {
        $scope.resetarModel();
        $scope.habilitarListaUsuarios(false);
    };
    $scope.habilitarListaUsuarios = function (habilitar) {
        $scope.mostrarCadastroUsuario = !habilitar;
        $scope.mostrarListaUsuarios = habilitar;
    };
    $scope.aoClicarVoltar = function () {
        $scope.habilitarListaUsuarios(true);
    };
    $scope.aoEditarUsuario = function (usuario) {
        $scope.model.nome = usuario.nome;
        $scope.model.sobrenome = usuario.sobrenome;
        $scope.model.dataNascimento = usuario.dataNascimento;
        $scope.model.email = usuario.email;
        $scope.model.senha = usuario.senha;
        $scope.habilitarListaUsuarios(false);
    };
    $scope.aoRemoverUsuario = function (usuario) {
        helperService.ajaxPost('api/Usuario/Remover', usuario,
            function (response) {
                $scope.listarUsuarios();
            }, null);
    };
    $scope.aoClicarSalvar = function () {
        var url = helperService.temValor($scope.model.id) ? 'api/Usuario/Atualizar' : 'api/Usuario/Incluir';
        helperService.ajaxPost(url, $scope.model,
            function (response) {
                alert(response.data.mensagem);
                $scope.listarUsuarios();
                $scope.habilitarListaUsuarios(true);
            }, null);
    };
    $scope.resetarModel = function () {
        $scope.model = {
            id: null,
            nome: null,
            sobrenome: null,
            dataNascimento: null,
            email: null,
            senha: null
        };
    };
    $scope.listarUsuarios = function () {
        helperService.ajaxPost('api/Usuario/Listar', null,
            function (response) {
                $scope.usuarios = response.data.dados;
            }, null);
    }
    $scope.inicializar();
}]);