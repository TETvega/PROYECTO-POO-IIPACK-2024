using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.CategoriesProduct.HelperDto;

namespace InmobiliariaUNAH.Dtos.CategoriesProduct
{
    public class CategoryProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<ProductDtoForCategoryProduct> ProductsOfCategory { get; set; }
    }
}
