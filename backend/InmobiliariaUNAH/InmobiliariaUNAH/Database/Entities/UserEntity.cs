using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("user", Schema = "dbo")]
    public class UserEntity : BaseEntity
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El {0} no es una dirección de correo electrónico válida.")]
        [Column("email")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [Column("password")]
        public string Password { get; set; } // contraseña tenga al menos 6 caracteres y no más de 100

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "La {0} es obligatorio.")]
        [Column("rol")]
        public string Rol { get; set; }


        [Display(Name = "Id del tipo de Cliente")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Column("clientType_id")]
        public Guid ClientTypeId { get; set; }
        [ForeignKey(nameof(ClientTypeId))]

    } // OJITO AQUÍ
}
