using Resource.Skills.Analysis.Domain.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Skills.Analysis.Domain.Interfaces
{
    public interface IDominioRepositorio
    {
        IEnumerable<ProdutoCategoria> ListarProdutoCategoria(bool ativo);
    }
}
