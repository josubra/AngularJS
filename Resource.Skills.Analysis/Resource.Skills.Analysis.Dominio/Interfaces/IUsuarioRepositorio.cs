using Resource.Skills.Analysis.Domain.Gestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Skills.Analysis.Domain.Interfaces
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> Listar();
        long Incluir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Remover(Usuario usuario);
    }
}
