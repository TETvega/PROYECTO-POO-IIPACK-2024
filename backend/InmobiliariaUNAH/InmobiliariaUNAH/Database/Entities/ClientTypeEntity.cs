﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    [Table("client_type", Schema = "dbo")]
    public class ClientTypeEntity : BaseEntity
    {
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [Column("description")]
        public string Description { get; set; }

        [Display(Name = "Descuento")] // SIN REQUIRED
        [Column("discount")]
        public decimal Discount { get; set; }


    }
}
