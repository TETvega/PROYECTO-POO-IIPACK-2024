using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("product", Schema = "dbo")]
    public class ProductEntity : BaseEntity
    {
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("description")]
        [StringLength(501, ErrorMessage = "La {0} no puede tener más de {1} caracteres.")]
        public string Description { get; set; }


        [Display(Name = "Imagen Url del Producto")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [RegularExpression(@"^(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?$", ErrorMessage = "La URL de la imagen no es válida.")]
        [Column("url_image")]
        public string UrlImage { get; set; }

        [Display(Name = "Categoría Id")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("category_id")]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual CategoryProductEntity Category { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("stock")]
        public int Stock { get; set; }

        [Display(Name = "Costo")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("cost")]
        public decimal Cost { get; set; }
    }
}
