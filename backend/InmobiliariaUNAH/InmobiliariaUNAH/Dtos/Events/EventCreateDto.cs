using InmobiliariaUNAH.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.Events
{
    public class EventCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del evento es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Id del Usuario")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public Guid UserId { get; set; } 

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public string Location { get; set; }

        public IEnumerable<ProductQuantity> Productos { get; set; }
    }
}
