using Resource.Skills.Analysis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Skills.Analysis.Domain.Estoque
{
    public class Produto
    {
        public long id { get; set; }
        public string desc { get; set; }
        public decimal? valor { get; set; }
        public byte? idCategoria { get; set; }
        public string codigoManual { get; set; }
        public string observacoes { get; set; }

        public long Incluir (IProdutoRepositorio repositorio)
        {
            return repositorio.Incluir(this);
        }

        public void Alterar(IProdutoRepositorio repositorio)
        {
            repositorio.Alterar(this);
        }

        public void Remover(IProdutoRepositorio repositorio)
        {
            repositorio.Remover(this);
        }
    }
}
