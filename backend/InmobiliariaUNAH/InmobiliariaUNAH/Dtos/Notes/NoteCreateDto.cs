using InmobiliariaUNAH.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.Notes
{
    public class NoteCreateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Evento Id")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public Guid EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public virtual EventEntity Event { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(500, ErrorMessage = "La {0} no puede tener más de {1} caracteres.")]
        public string Description { get; set; }
    }
}
