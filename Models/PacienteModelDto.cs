using System.ComponentModel.DataAnnotations;

namespace PacienteConsulta.Models
{
    public class PacienteModelDto
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        public string Idade { get; set; }

        public string Sexo { get; set; }

        [Display(Name = "Número do SUS")]
        public int NumeroDoSUS { get; set; }
    }
}