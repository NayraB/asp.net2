using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Data
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "'Nome' é um campo obrigatório!")]
        [MaxLength(30, ErrorMessage ="Nome pode conter no máximo 30 caracteres")]
        public string Nome { get; set; }
        public string Senha { get; set; }
        [Required(ErrorMessage ="Esse é um campo obrigatório!")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage ="Email deve estar no formato exemplo@exemplo.com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Esse é um campo obrigatório!")]
        [DataType(DataType.Date)]
        public string DataNascimento { get; set; }
        [Required(ErrorMessage = "Esse é um campo obrigatório!")]
        [RegularExpression(@"\d\d\d.\d\d\d.\d\d\d-\d\d", ErrorMessage ="CPF deve estar no formato XXX.XXX.XXX-XX" )]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Esse é um campo obrigatório!")]
        [RegularExpression(@"\d\d\d\d\d-\d\d\d", ErrorMessage = "CEP deve estar no formato XXXXX-XXX")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}
