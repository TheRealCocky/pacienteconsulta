using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PacienteConsulta.Models
{
    public class ConsultaModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A data da consulta é obrigatória.")]
        public DateTime DataConsulta { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        // Relacionamento com Paciente
        [Required(ErrorMessage = "O ID do paciente é obrigatório.")]
        public Guid PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public PacienteModel Paciente { get; set; }
    }
}