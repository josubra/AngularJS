using Resource.Skills.Analysis.Domain.Gestao;
using Resource.Skills.Analysis.RepositoryDB.Gestao;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Resource.Skills.Analysis.WebApiControllers.Estoque
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController: ApiController
    {
        [HttpPost]
        public HttpResponseMessage Listar(HttpRequestMessage request)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, dados = new UsuarioRepositorio().Listar() });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
            }
        }

        [HttpPost]
        public HttpResponseMessage Incluir(HttpRequestMessage request, [FromBody]Usuario usuario)
        {
            try
            {
                usuario.Incluir(new UsuarioRepositorio());
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, mensagem = "Cadastro realizado com sucesso." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
            }
        }

        [HttpPost]
        public HttpResponseMessage Alterar(HttpRequestMessage request, [FromBody]Usuario usuario)
        {
            try
            {
                usuario.Alterar(new UsuarioRepositorio());
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, mensagem = "Cadastro alterado com sucesso." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
            }
        }

        [HttpPost]
        public HttpResponseMessage Remover(HttpRequestMessage request, [FromBody]Usuario usuario)
        {
            try
            {
                usuario.Remover(new UsuarioRepositorio());
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, mensagem = "Item removido com sucesso." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
            }
        }
    }
}