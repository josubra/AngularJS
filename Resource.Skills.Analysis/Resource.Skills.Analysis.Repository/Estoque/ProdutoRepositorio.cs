using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Data;
using Resource.Skills.Analysis.Domain.Interfaces;
using Resource.Skills.Analysis.Domain.Estoque;

namespace Resource.Skills.Analysis.RepositoryDB.Estoque
{
    public class ProdutoRepositorio : Repository, IProdutoRepositorio
    {
        public IEnumerable<Produto> Listar()
        {
            return Data.List<Produto>("PRC_LISTAR_PRODUTOS", new { });
        }

        public long Incluir(Produto produto)
        {
            return Data.Get<long>("PRC_INCLUIR_PRODUTO", new
            {
                @DESCRICAO = produto.desc,
                @VALOR = produto.valor,
                @ID_CATEGORIA = produto.idCategoria,
                @CODIGO_MANUAL = produto.codigoManual,
                @OBSERVACOES = produto.observacoes
            });
        }

        public void Alterar(Produto produto)
        {
            Data.Execute("PRC_ALTERAR_PRODUTO", new
            {
                @ID = produto.id,
                @DESCRICAO = produto.desc,
                @VALOR = produto.valor,
                @ID_CATEGORIA = produto.idCategoria,
                @CODIGO_MANUAL = produto.codigoManual,
                @OBSERVACOES = produto.observacoes
            });
        }

        public void Remover(Produto produto)
        {
            Data.Execute("PRC_REMOVER_PRODUTO", new { @ID = produto.id });
        }
    }
}
