using InmobiliariaUNAH.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual CategoryProductEntity Category { get; set; } // cambiar a CategoryProductDTO
        public int Stock { get; set; }
        public decimal Cost { get; set; }
    }
}
