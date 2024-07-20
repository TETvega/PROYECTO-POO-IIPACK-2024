using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("event", Schema = "dbo")]
    public class EventEntity : BaseEntity
    {
      
        [Display(Name = "Id del Usuario")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("user_id")]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserEntity User { get; set; } 

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("location")]
        public string Location { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("state")]
        public string State { get; set; }

        [Display(Name = "Costo sin Descuento")] // SIN REQUIRED
        [Column("cost_whitout_discount")]
        public decimal CostWhitoutDiscount { get; set; }

        [Display(Name = "Costo con Descuento")]
        [Column("cost_discount")]
        public decimal CostDiscount { get; set; }
    }
}
