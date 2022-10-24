using Cliente.Dominio.Dto;
using Cliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Dominio.Interface
{
    public interface IClienteAplicacao
    {
        public void AdicionarCliente(ClienteDto dto);

        public void AlterarCliente(int id, ClienteDto dto);

        public List<ClienteEntidade> ListarTodosClientes();

        public void RemoverCliente(int id);

        public ClienteEntidade BuscarPorNomeCliente(string nome);

        public ClienteEntidade BuscarPorCpfCliente(string cpf);

        public List<ClienteEntidade> BuscarPorNascimentoCliente(DateTime nascimento);

    }
}
