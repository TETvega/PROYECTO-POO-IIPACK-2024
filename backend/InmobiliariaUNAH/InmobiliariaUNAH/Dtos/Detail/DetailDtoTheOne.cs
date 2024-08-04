using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.Products;

namespace InmobiliariaUNAH.Dtos.Detail
{
    public class DetailDtoTheOne
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid ProductId { get; set; }
        public virtual ProductEntity Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
