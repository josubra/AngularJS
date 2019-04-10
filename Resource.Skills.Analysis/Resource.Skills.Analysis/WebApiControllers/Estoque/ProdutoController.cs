using Resource.Skills.Analysis.Domain.Estoque;
using Resource.Skills.Analysis.RepositoryDB.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Resource.Skills.Analysis.WebApiControllers.Estoque
{
    [RoutePrefix("api/Produto")]
    public class ProdutoController: ApiController
    {
        [HttpPost]
        public HttpResponseMessage Listar(HttpRequestMessage request)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, dados = new ProdutoRepositorio().Listar() });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
            }
        }

        [HttpPost]
        public HttpResponseMessage Incluir(HttpRequestMessage request, [FromBody]Produto produto)
        {
            try
            {
                produto.Incluir(new ProdutoRepositorio());
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, mensagem = "Cadastro realizado com sucesso." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
            }
        }

        [HttpPost]
        public HttpResponseMessage Alterar(HttpRequestMessage request, [FromBody]Produto produto)
        {
            try
            {
                produto.Alterar(new ProdutoRepositorio());
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, mensagem = "Cadastro alterado com sucesso." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
            }
        }

        [HttpPost]
        public HttpResponseMessage Remover(HttpRequestMessage request, [FromBody]Produto produto)
        {
            try
            {
                produto.Remover(new ProdutoRepositorio());
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, mensagem = "Item removido com sucesso." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
            }
        }
    }
}