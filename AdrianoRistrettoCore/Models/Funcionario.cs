using System.ComponentModel.DataAnnotations;

namespace AdrianoRistrettoCore.Models
{
    public class Funcionario : Pessoa
    {
        [Required]
        public DateTime? DataNascimento { get; set; }
    }
}
