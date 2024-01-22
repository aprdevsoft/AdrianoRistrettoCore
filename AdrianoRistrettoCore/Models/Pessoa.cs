using System.ComponentModel.DataAnnotations;

namespace AdrianoRistrettoCore.Models
{
    public abstract class Pessoa : Entity
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string? Nome { get; set; }
    }
}
