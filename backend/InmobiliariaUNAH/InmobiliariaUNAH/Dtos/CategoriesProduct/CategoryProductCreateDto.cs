using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.CategoriesProduct
{
    public class CategoryProductCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoria es requerido.")]
        public string Name { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} de la categoria es requerido.")]
        public string Description { get; set; }
    }
}
