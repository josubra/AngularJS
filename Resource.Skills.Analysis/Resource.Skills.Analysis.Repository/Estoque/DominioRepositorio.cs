using Resource.Data;
using Resource.Skills.Analysis.Domain.Dominio;
using Resource.Skills.Analysis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Skills.Analysis.RepositoryDB.Estoque
{
    public class DominioRepositorio : Repository, IDominioRepositorio
    {
        public IEnumerable<ProdutoCategoria> ListarProdutoCategoria(bool ativo)
        {
            return Data.List<ProdutoCategoria>("PRC_LISTAR_PRODUTO_CATEGORIA", new { @ATIVO = ativo });
        }
    }
}
