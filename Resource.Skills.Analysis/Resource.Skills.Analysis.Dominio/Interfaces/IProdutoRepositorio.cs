using Resource.Skills.Analysis.Domain.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Skills.Analysis.Domain.Interfaces
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> Listar();
        long Incluir(Produto produto);
        void Alterar(Produto produto);
        void Remover(Produto produto);
    }
}
