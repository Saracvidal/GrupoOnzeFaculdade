using System.ComponentModel.DataAnnotations;

namespace GrupoOnzeFaculdade.Models
{
    public class CadastroAluno
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public required string nome { get; set; }
        [Display(Name = "Sobrenome")]
        public string? sobrenome { get; set; }
        [Display(Name = "Matrícula")]
        public string? matricula { get; set; }
        [Display(Name = "Endereço")]
        public string? endereco { get; set; }

        [Display(Name = "Telefone")]
        public string? telefone { get; set; }

    }
}
