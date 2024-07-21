using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.CategoriesProduct
{
    public class CategoryProductCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoria es requerido.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener un maximo de {1} caracteres de longitud.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} de la categoria es requerido.")]
        [StringLength(50, ErrorMessage = "La {0} debe tener un maximo de {1} caracteres de longitud.")]
        public string Description { get; set; }
    }
}
