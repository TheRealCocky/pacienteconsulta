using System.ComponentModel.DataAnnotations;

namespace PacienteConsulta.Models
{
    public class ConsultaModelDto
    {
        [Required(ErrorMessage = "A data da consulta é obrigatória.")]
        public DateTime DataConsulta { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O ID do paciente é obrigatório.")]
        public Guid PacienteId { get; set; }
    }
}