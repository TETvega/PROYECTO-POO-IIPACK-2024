using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("detail", Schema = "dbo")]
    public class DetailEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El {0} es Requerido")]
        [Column("id")]
        public Guid Id { get; set; }

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
        public virtual ProductEntity Product { get; set; }

        [Display(Name = "Cantidad del product")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("unit_price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Precio Total")]
        [Column("total_price")]
        //funcion fecha del total a pagar en un producto
        public decimal TotalPrice {  get; set; } // no pude expresarlo como funcion flecha en la base no aparecia
    }
}
