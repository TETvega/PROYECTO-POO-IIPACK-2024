using InmobiliariaUNAH.Dtos.CategoriesProduct;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Dtos.CategoriesProduct.HelperDto
{
    [NotMapped]
    public class ProductDtoForCategoryProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public Guid CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Cost { get; set; }
    }
}
