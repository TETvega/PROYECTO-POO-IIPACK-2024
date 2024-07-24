using InmobiliariaUNAH.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.Events
{
    public class EventCreateDto
    {
        [Display(Name = "Id del Usuario")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public Guid UserId { get; set; } // AQUI NO SE CUAL DEJAR. SI LA PROPIEDAD 'UserId' O 'User'.
        public virtual UserEntity User { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public string Location { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string State { get; set; }

        [Display(Name = "Costo sin Descuento")] // SIN REQUIRED
        public decimal CostWhitoutDiscount { get; set; }

        [Display(Name = "Costo con Descuento")] // SIN REQUIRED
        public decimal CostDiscount { get; set; }
    }
}
