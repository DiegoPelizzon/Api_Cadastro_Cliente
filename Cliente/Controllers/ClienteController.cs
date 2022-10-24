using Cliente.Dominio.Dto;
using Cliente.Dominio.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Api.Controllers
{
    [ApiController]
    [Route("Controler")]
    public class ClienteController:Controller
    {
        protected readonly IClienteAplicacao _clienteAplicacao;

        public ClienteController(IClienteAplicacao clienteaplicacao)
        {
            _clienteAplicacao = clienteaplicacao;
        }

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult Adicionar(ClienteDto dto)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }

                _clienteAplicacao.AdicionarCliente(dto);

                return Ok("Cliente adicionado com sucesso");

            }catch (Exception ex)
            {
                return StatusCode(500, "Erro ao adicionar o cliente. Detalhes do erro: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public IActionResult Alterar(int id, ClienteDto dto)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                _clienteAplicacao.AlterarCliente(id, dto);

                return Ok("Cliente alterado com sucesso");

            }catch(Exception ex)
            {
                return StatusCode(500,"Erro ao alterar os dados do cliente. Detalhes do erro: "+ ex.Message);
            }
        }

        [HttpGet]
        [Route("ListaClientes")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_clienteAplicacao.ListarTodosClientes());

            }catch(Exception ex)
            {
                return StatusCode(500, "Erro ao obter lista de clientes. Detalhes do erro: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("BuscarPorNome")]
        public IActionResult BuscarPorNome(string nome)
        {
            try
            {
                return Ok(_clienteAplicacao.BuscarPorNomeCliente(nome));          

            }catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar cliente pelo nome. Detalhes do erro: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("BuscarPorCpf")]
        public IActionResult BuscarPorCpf(string cpf)
        {
            try
            {
                return Ok(_clienteAplicacao.BuscarPorCpfCliente(cpf));

            }catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar cliente pelo CPF. Detalhes do erro: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("BuscarPorNascimento")]
        public IActionResult BuscarPorNascimento(DateTime nascimento)
        {
            try
            {
                return Ok(_clienteAplicacao.BuscarPorNascimentoCliente(nascimento));

            }catch(Exception ex)
            {
                return StatusCode(500, "Erro ao buscar clientes pela data de nascimento. Detalhes do erro: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remover")]
        public IActionResult Remover(int id)
        {
            try
            {

                _clienteAplicacao.RemoverCliente(id);
                return Ok("Cliente removido com sucesso");

            }catch (Exception ex)
            {
                return StatusCode(500, "Erro ao Remover Cliente. Detalhes do Erro: " + ex.Message);
            }

        }

    }
}
