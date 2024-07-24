using InmobiliariaUNAH.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.EventDetails
{
    public class EventDetailCreateDto
    {
        [Display(Name = "Id del Evento")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [ForeignKey(nameof(EventId))]
        public Guid EventId { get; set; }
        public virtual EventEntity Event { get; set; }

        [Display(Name = "Id del Producto")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity Product { get; set; }

        // Sobre Precios y Cantidades
        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public int Quantity { get; set; }

        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Precio Total")]
        //funcion fecha del total a pagar en un producto
        public decimal TotalPrice => (Quantity * UnitPrice);
    }
}
