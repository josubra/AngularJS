using Resource.Data;
using Resource.Skills.Analysis.Domain.Gestao;
using Resource.Skills.Analysis.Domain.Interfaces;
using System.Collections.Generic;

namespace Resource.Skills.Analysis.RepositoryDB.Gestao
{
    public class UsuarioRepositorio : Repository, IUsuarioRepositorio
    {
        public IEnumerable<Usuario> Listar()
        {
            return Data.List<Usuario>("PRC_LISTAR_USUARIOS", new { });
        }

        public long Incluir(Usuario usuario)
        {
            return Data.Get<long>("PRC_INCLUIR_USUARIO", new
            {
                @NOME = usuario.nome,
                @SOBRENOME = usuario.sobrenome,
                @DATA_NASCIMENTO = usuario.dataNascimento,
                @EMAIL = usuario.email,
                @SENHA = usuario.senha
            });
        }

        public void Alterar(Usuario usuario)
        {
            Data.Execute("PRC_ALTERAR_USUARIO", new
            {
                @ID = usuario.id,
                @NOME = usuario.nome,
                @SOBRENOME = usuario.sobrenome,
                @DATA_NASCIMENTO = usuario.dataNascimento,
                @EMAIL = usuario.email,
                @SENHA = usuario.senha
            });
        }

        public void Remover(Usuario usuario)
        {
            Data.Execute("PRC_REMOVER_USUARIO", new { @ID = usuario.id });
        }
    }
}
