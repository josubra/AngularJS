angular.module('resourceSkillsAnalysis').service('helperService', ['$http', function ($http) {
    var pf = this;
    this.temValor = function (valor) {
        if (Array.isArray(valor))
            return valor.length > 0;
        return valor != null && valor != undefined && valor != 0 && valor != '';
    };
    this.obterCaminhoBase = function () {
        return $("base").first().attr("href");
    };
    this.ajaxPost = function (rota, dados, funcaoSucesso, funcaoErro) {
        return $http.post(pf.obterCaminhoBase() + rota, dados, { cache: false }).then(function sucesso(response, status, headers, config) {
            if (response.data.sucesso) {
                if (pf.temValor(funcaoSucesso))
                    return funcaoSucesso(response, status);
            }
            else
                alert(response.data.mensagem);
        }, function erro(response) {
            if (pf.temValor(funcaoErro))
                funcaoErro(response);
        });
    };
}]);