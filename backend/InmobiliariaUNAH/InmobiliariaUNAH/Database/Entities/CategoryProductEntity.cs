using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("category_product", Schema = "dbo")]
    public class CategoryProductEntity : BaseEntity
    {
        [Display(Name = "Descripción")]
        [Column("description")]
        public string Description { get; set; }
    }
}
