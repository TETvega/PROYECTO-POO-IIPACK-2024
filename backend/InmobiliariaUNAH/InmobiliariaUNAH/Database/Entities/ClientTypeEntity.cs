using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("client_type", Schema = "dbo")]
    public class ClientTypeEntity : BaseEntity
    {
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("description")]
        public string Description { get; set; }

        [Display(Name = "Descuento")]
        [Required(ErrorMessage = "La cantidad del {0} para este tipo de cliente es requerido.")]
        [Column("discount")]
        public decimal Discount { get; set; }
    }
}
