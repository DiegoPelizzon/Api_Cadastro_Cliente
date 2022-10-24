using Cliente.Dominio.Dto;
using Cliente.Dominio.Entidades;
using Cliente.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Aplicacao.Aplicacao
{
    public class ClienteAplicacao : IClienteAplicacao
    {
        protected readonly IRepositorioCliente _repositorioCliente;

        public ClienteAplicacao(IRepositorioCliente repositoriocliente)
        {
            _repositorioCliente = repositoriocliente;
        }

        public void AdicionarCliente(ClienteDto dto)
        {
            if (dto.datanascimentoCliente > DateTime.Now)
            {
                throw new Exception("Data de nascimento não pode ser maior que a data atual");
            }
            if ((_repositorioCliente.ValidandoUsoDoCpf(dto.cpfCliente)) == true)
            {
                throw new Exception("O CPF informado já esta em uso");
            }
            if ((_repositorioCliente.ValidandoUsoDoContato(dto.contatoCliente)) == true)
            {
                throw new Exception("O contato informado já esta em uso");
            }
            if ((_repositorioCliente.ValidadandoUsoDoEmail(dto.emailCliente))== true)
            {
                throw new Exception("o email informado já esta em uso");
            }

            ClienteEntidade entidade = new ClienteEntidade()
            {
                nome = dto.nomeCliente,
                idade = dto.idadeCliente,
                sexo = dto.sexoCliente,
                email = dto.emailCliente,
                contato = dto.contatoCliente,
                cpf = dto.cpfCliente,
                datanascimento = dto.datanascimentoCliente,
                cep = dto.cepCliente
            };

            _repositorioCliente.create(entidade);
            _repositorioCliente.SalvarNoBanco();

        }

        public void AlterarCliente(int id,ClienteDto dto)
        {
            ClienteEntidade entidade = _repositorioCliente.FindById(id);
            entidade.nome = dto.nomeCliente;
            entidade.idade = dto.idadeCliente;
            entidade.sexo = dto.sexoCliente;
            entidade.email = dto.emailCliente;
            entidade.contato = dto.contatoCliente;
            entidade.cpf = dto.cpfCliente;
            entidade.datanascimento = dto.datanascimentoCliente;
            entidade.cep = dto.cepCliente;

            _repositorioCliente.Update(entidade);
            _repositorioCliente.SalvarNoBanco();

        }

        public List<ClienteEntidade> ListarTodosClientes()
        {
            return _repositorioCliente.GetAll();
        }

        public ClienteEntidade BuscarPorNomeCliente(string nome)
        {
            return _repositorioCliente.GetByName(nome);
        }

        public ClienteEntidade BuscarPorCpfCliente(string cpf)
        {
            return _repositorioCliente.GetByCpf(cpf);
        }

        public List<ClienteEntidade> BuscarPorNascimentoCliente(DateTime nascimento)
        {
            return _repositorioCliente.GetByBirthDate(nascimento);
        }

        public void RemoverCliente(int id)
        {
            _repositorioCliente.Delete(id);
            _repositorioCliente.SalvarNoBanco();
        }
    }
}
