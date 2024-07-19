using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Database.Entities
{
    public class BaseEntity
    {
        [Key] 
        [Column("id")]
        public Guid Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoria es requerido.")]
        [Column("name")]
        public string Name { get; set; }

        //--------------------

        [StringLength(100)]
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        // ----------------------

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        // ----------------------

        [StringLength(100)]
        [Column("edited_by")]
        public string EditedBy { get; set; }
        [ForeignKey(nameof(EditedBy))]

        // ----------------------

        [Column("edited_date")]
        public DateTime EditedDate { get; set; }
    }
}
