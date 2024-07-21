using System.ComponentModel.DataAnnotations;
namespace InmobiliariaUNAH.Dtos.ClientType
{
    public class ClientTypeCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del tipo de cliente es requerido.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener un maximo de {1} caracteres de longitud.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} del tipo de cliente es requerido.")]
        [StringLength(50, ErrorMessage = "La {0} debe tener un maximo de {1} caracteres de longitud.")]
        public string Description { get; set; }

        [Display(Name = "Descuento")] 
        [Required(ErrorMessage = "La cantidad del {0} para este tipo de cliente es requerido.")]
        public decimal Discount { get; set; }
    }
}