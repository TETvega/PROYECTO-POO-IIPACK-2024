using InmobiliariaUNAH.Dtos.CategoriesProduct;

namespace InmobiliariaUNAH.Dtos.CategoriesProduct.HelperDto
{
    public class ProductDtoForCategoryProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Cost { get; set; }
    }
}
