using System.ComponentModel.DataAnnotations;

namespace AdrianoRistrettoCore.Models
{
    public class Contrato : Entity
    {
        [Required]
        public Acesso? Acesso { get; set; }
        
        [Required]
        public string? CodigoEmpresa { get; set; }
        
        [Required]
        public string? CodigoFuncionario { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string? Cargo { get; set; }
    }
}
