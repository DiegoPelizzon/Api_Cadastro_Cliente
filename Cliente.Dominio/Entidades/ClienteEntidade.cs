using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Dominio.Entidades
{
    [Table("cliente")]
    public class ClienteEntidade
    {
        [Key]

        public int id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
        public string contato { get; set; }
        public string cpf { get; set; }
        public DateTime datanascimento { get; set; }
        public string cep { get; set; }

    }
}
