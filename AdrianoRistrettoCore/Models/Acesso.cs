using System.ComponentModel.DataAnnotations;

namespace AdrianoRistrettoCore.Models
{
    public class Acesso
    {
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string? Login { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 6)]
        public string? Senha { get; set;}

        public bool IsAtivo { get; set; }
    }
}
