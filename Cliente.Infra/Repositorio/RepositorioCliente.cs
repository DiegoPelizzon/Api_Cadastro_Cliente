using Cliente.Dominio.Entidades;
using Cliente.Dominio.Interface;
using Cliente.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Infra.Repositorio
{
    public class RepositorioCliente:RepositorioGenerico<ClienteEntidade>, IRepositorioCliente
    {
        public RepositorioCliente(BancoContext bancocontext): base(bancocontext)
        {

        }

        public ClienteEntidade GetByName(string name)
        {
            return _DbSet.Where(entidade => entidade.nome == name).FirstOrDefault();
        }

        public ClienteEntidade GetByCpf(string cpf)
        {
            return _DbSet.Where(entidade => entidade.cpf == cpf).FirstOrDefault();
        }

        public List<ClienteEntidade> GetByBirthDate(DateTime nascimento)
        {
            return _DbSet.Where(entidade => entidade.datanascimento == nascimento).ToList();
        }

        public bool ValidandoUsoDoCpf(string cpf)
        {
            return _DbSet.Any(entidade => entidade.cpf == cpf);
        }

        public bool ValidadandoUsoDoEmail(string email)
        {
            return _DbSet.Any(entidade => entidade.email == email);
        }

        public bool ValidandoUsoDoContato(string contato)
        {
            return _DbSet.Any(entidade => entidade.contato == contato);
        }
    }
}
