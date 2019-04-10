using Resource.Skills.Analysis.Domain.Estoque;
using Resource.Skills.Analysis.RepositoryDB.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Resource.Skills.Analysis.WebApiControllers.Util
{
    [RoutePrefix("api/Helper")]
    public class HelperController: ApiController
    {
        [HttpPost]
        public HttpResponseMessage ListarProdutoCategoria(HttpRequestMessage request, [FromUri]bool ativo)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, dados = new DominioRepositorio().ListarProdutoCategoria(ativo) });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
            }
        }

     }
}