using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("clients", Schema = "dbo")]
    public class ClientEntity
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Display(Name = "Usuario Id")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [Column("user_id")]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserEntity User { get; set; }


        [Display(Name = "Tipo de Cliente Id")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [Column("client_type_id")]
        public Guid ClientTypeId { get; set; }
        [ForeignKey(nameof(ClientTypeId))]
        public virtual ClientTypeEntity ClientType { get; set; }
    }
}
