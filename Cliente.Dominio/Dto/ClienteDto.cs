using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Dominio.Dto
{
    public class ClienteDto
    {
        [Required(ErrorMessage ="O campo não pode ficar em branco")]
        public string nomeCliente { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        public int idadeCliente { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        public string sexoCliente { get; set; }

        [EmailAddress(ErrorMessage ="Email digitado não é valido")]
        public string emailCliente { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        [Phone(ErrorMessage ="Contato digitado não confere com o padrão telefonico")]
        public string contatoCliente { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        [StringLength(11,MinimumLength =11, ErrorMessage = "CPF deve ter 11 caracteres")]
        public string cpfCliente { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        public DateTime datanascimentoCliente { get; set; }
        [StringLength(8,MinimumLength =8,ErrorMessage ="CEP deve conter 8 caracteres")]
        public string cepCliente { get; set; }
    }
}
