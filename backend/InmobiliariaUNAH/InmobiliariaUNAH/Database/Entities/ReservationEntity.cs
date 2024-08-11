using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("reservation", Schema = "dbo")]
    public class ReservationEntity : BaseEntity
    {
        [Display(Name = "Producto Id")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity Product { get; set; } 

        [Display(Name = "Evento Id")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("event_id")]
        public Guid EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public virtual EventEntity Event { get; set; } 

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("date")]
        public DateTime Date { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("count")]
        public decimal Count { get; set; } // esta propiedad deberia ser INT ?
    }
}
