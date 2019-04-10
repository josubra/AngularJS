using Resource.Skills.Analysis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Skills.Analysis.Domain.Gestao
{
    public class Usuario
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public long Incluir(IUsuarioRepositorio repositorio)
        {
            return repositorio.Incluir(this);
        }

        public void Alterar(IUsuarioRepositorio repositorio)
        {
            repositorio.Alterar(this);
        }

        public void Remover(IUsuarioRepositorio repositorio)
        {
            repositorio.Remover(this);
        }
    }
}
