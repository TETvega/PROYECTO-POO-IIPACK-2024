using InmobiliariaUNAH.Database.Entities;
using Microsoft.EntityFrameworkCore;
namespace InmobiliariaUNAH.Database
{
    public class InmobiliariaUNAHContext : DbContext
    {
        public InmobiliariaUNAHContext(DbContextOptions options) : base(options)
        { // aqui se plantea toda la configuracion de la base de datos
            
        }

        public DbSet<CategoryProductEntity> CategoryProducts { get; set; }
        public DbSet<ClientTypeEntity> TypesOfClient { get; set; }
        public DbSet<DetailEntity> Details { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
       
        //public DbSet<UserEntity> Users { get; set; }
       

    }
}
