using System.ComponentModel.DataAnnotations;

namespace AdrianoRistrettoCore.Models
{
    public class Empresa : Pessoa
    {
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string? Telefone { get; set; } 
        
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string? Url { get; set; }
    }
}
