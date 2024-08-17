using InmobiliariaUNAH.Dtos.CategoriesProduct;

namespace InmobiliariaUNAH.Dtos.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public CategoryProductDto Category { get; set; } // estaba en 'CategoryProductEntity' y se cambió a 'CategoryProductDTO'
        // quite el virtal no se si eso se ocupa aqui para el Category Product
        public int Stock { get; set; }
        public decimal Cost { get; set; }
    }
}
