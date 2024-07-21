using InmobiliariaUNAH.Dtos.CategoriesProduct;

namespace InmobiliariaUNAH.Dtos.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual CategoryProductDto Category { get; set; } // estaba en 'CategoryProductEntity' y se cambió a 'CategoryProductDTO'
        public int Stock { get; set; }
        public decimal Cost { get; set; }
    }
}
