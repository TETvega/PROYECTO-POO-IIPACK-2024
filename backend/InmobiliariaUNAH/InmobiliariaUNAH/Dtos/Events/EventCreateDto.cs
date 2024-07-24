using InmobiliariaUNAH.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.Events
{
    public class EventCreateDto
    {
        [Display(Name ="Nombre Del Evento")]
        [Required(ErrorMessage ="el {0} es Requerido")]
        public string Name { get; set; }

        [Display(Name = "Id del Usuario")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
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

        [Display(Name = "SubTotal")] 
        public decimal EventCost { get; set; }

        [Display(Name = "Descuento")] 
        public decimal Discount { get; set; }

        [Display(Name = "Total a pagar")]
        public decimal Total { get; set; }
        public virtual ICollection<DetailEntity> EventDetails { get; set; } = new List<DetailEntity>();
    }
}
