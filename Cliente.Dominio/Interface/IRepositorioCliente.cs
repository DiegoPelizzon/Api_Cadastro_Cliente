using Cliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Dominio.Interface
{
    public interface IRepositorioCliente: IRepositorioGenerico<ClienteEntidade>
    {

        public ClienteEntidade GetByName(string name);

        public ClienteEntidade GetByCpf(string cpf);

        public List<ClienteEntidade> GetByBirthDate(DateTime nascimento);

        public bool ValidandoUsoDoCpf(string cpf);

        public bool ValidadandoUsoDoEmail(string email);

        public bool ValidandoUsoDoContato(string contato);
    }
}
