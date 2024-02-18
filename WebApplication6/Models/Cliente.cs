using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório!")]
        public string Sobrenome { get; set; }
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter exatamente 11 dígitos.")]
        public string Cpf { get; set; }
    }
}
