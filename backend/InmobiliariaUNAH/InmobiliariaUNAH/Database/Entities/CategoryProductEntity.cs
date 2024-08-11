using InmobiliariaUNAH.Dtos.CategoriesProduct.HelperDto;
using InmobiliariaUNAH.Dtos.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("category_product", Schema = "dbo")]
    public class CategoryProductEntity : BaseEntity
    {
        [Display(Name = "Descripción")]
        [StringLength(100, ErrorMessage = "La {0} debe tener un maximo de {1} caracteres de longitud.")]
        [Column("description")]
        public string Description { get; set; }

        public virtual IEnumerable<ProductDtoForCategoryProduct> ProductsOfCategory { get; set; }
    }
}