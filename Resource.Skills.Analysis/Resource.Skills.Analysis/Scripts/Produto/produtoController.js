angular.module("resourceSkillsAnalysis").register.controller('produtoController', ['$scope', '$http', 'helperService', function ($scope, $http, helperService) {
    $scope.inicializar = function () {
        $scope.mostrarCadastroProduto = false;
        $scope.mostrarListaRegistros = true;
        $scope.produtos = [];
        $scope.produtoCategorias = [];
        $scope.resetarModel();
        $scope.listarProdutos();
        $scope.listarProdutoCategorias();
    };
    $scope.aoClicarNovoProduto = function () {
        $scope.resetarModel();
        $scope.habilitarListaRegistros(false);
    };
    $scope.habilitarListaRegistros = function (habilitar) {
        $scope.mostrarCadastroProduto = !habilitar;
        $scope.mostrarListaRegistros = habilitar;
    };
    $scope.aoClicarVoltar = function () {
        $scope.habilitarListaRegistros(true);
    };
    $scope.aoEditarProduto = function (produto) {
        $scope.resetarModel();
        $scope.model.id = produto.id;
        $scope.model.desc = produto.desc;
        $scope.model.valor = produto.valor;
        $scope.model.idCategoria = produto.idCategoria;
        $scope.model.codigoManual = produto.codigoManual;
        $scope.model.observacoes = produto.observacoes;
        $scope.habilitarListaRegistros(false);
    };
    $scope.aoRemoverProduto = function (produto) {
        helperService.ajaxPost('api/Produto/Remover', produto,
                function (response) {
                    $scope.listarProdutos();
                }, null);
    };
    $scope.aoClicarSalvar = function () {
        var url = helperService.temValor($scope.model.id) ? 'api/Produto/Alterar' : 'api/Produto/Incluir';
        helperService.ajaxPost(url, $scope.model,
                function (response) {
                    alert(response.data.mensagem);
                    $scope.listarProdutos();
                    $scope.habilitarListaRegistros(true);
                }, null);
    };
    $scope.resetarModel = function () {
        $scope.model = {
            id: null,
            desc: null,
            valor: null,
            idCategoria: null,
            codigoManual: null,
            observacoes: null
        };
    };
    $scope.listarProdutos = function () {
        helperService.ajaxPost('api/Produto/Listar', null,
                function (response) {
                    $scope.produtos = response.data.dados;
                }, null);
    }
    $scope.listarProdutoCategorias = function () {
        helperService.ajaxPost('api/Helper/ListarProdutoCategoria?ativo=true', null,
                function (response) {
                    $scope.produtoCategorias = response.data.dados;
                }, null);
    }
    $scope.inicializar();
}]);