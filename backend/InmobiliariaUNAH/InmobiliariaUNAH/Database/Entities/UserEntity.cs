using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaUNAH.Database.Entities
{
    public class UserEntity : IdentityUser
    {
        public string Name { get; set; }
    } 
}
