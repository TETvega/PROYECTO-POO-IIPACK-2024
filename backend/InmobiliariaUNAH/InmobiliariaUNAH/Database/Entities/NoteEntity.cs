using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("notes", Schema = "dbo")]
    public class NoteEntity : BaseEntity
    {

        [Display(Name = "Evento Id")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("event_id")]
        public Guid EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public virtual EventEntity Event { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("description")]
        public string Description { get; set; }
    }
}
