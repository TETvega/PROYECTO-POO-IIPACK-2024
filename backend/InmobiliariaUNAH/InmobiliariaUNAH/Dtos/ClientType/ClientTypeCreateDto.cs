using System.ComponentModel.DataAnnotations;
namespace InmobiliariaUNAH.Dtos.ClientType
{
    public class ClientTypeCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del tipo de cliente es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} del tipo de cliente es requerido.")]
        public string Description { get; set; }

        [Display(Name = "Descuento")]
        [Required(ErrorMessage = "La cantidad del {0} para este tipo de cliente es requerido.")]
        [Range(0, 1.0, ErrorMessage = "El {0} debe estar entre 0 y 1.00.")]
        //[RegularExpression(@"0(\.\d{1,2})?", ErrorMessage = "El {0} debe ser un número decimal válido, por ejemplo: 0.10, 0.1, 0.5, 0.05.")]
        public decimal Discount { get; set; }
    }
}