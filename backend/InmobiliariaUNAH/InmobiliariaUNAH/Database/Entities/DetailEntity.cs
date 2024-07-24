using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("detail", Schema = "dbo")]
    public class DetailEntity : BaseEntity
    {
        [Display(Name = "Id del Evento")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("event_id")]
        [ForeignKey(nameof(EventId))]
        public Guid EventId { get; set; }
        public virtual EventEntity Event { get; set; } 

        [Display(Name = "Id del Producto")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public ProductEntity Product { get; set; } 

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("count")]
        public int Count { get; set; }

        [Display(Name = "Monto")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Costo")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("cost")]
        public decimal Cost { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("state")]
        [StringLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        public string State { get; set; }
    }
}
