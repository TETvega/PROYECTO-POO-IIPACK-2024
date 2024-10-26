using InmobiliariaUNAH.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace InmobiliariaUNAH.Database
{
    public class InmobiliariaUNAHContext : IdentityDbContext<UserEntity>
    {
        public InmobiliariaUNAHContext(DbContextOptions options) : base(options)
        { // aqui se plantea toda la configuracion de la base de datos

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");
                       

            // Creando Security Schema
            modelBuilder.HasDefaultSchema("security");

            modelBuilder.Entity<UserEntity>().ToTable("users"); 
            modelBuilder.Entity<IdentityRole>().ToTable("roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("users_roles");

            //Estos son los permisos
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("users_claims");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("roles_claims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("users_logins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("users_tokens");

            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new PostConfiguration());
            //modelBuilder.ApplyConfiguration(new PostTagConfiguration());
            //modelBuilder.ApplyConfiguration(new TagConfiguration());

            

            // Configuraciones de precisión y escala para las propiedades decimal
            modelBuilder.Entity<ClientTypeEntity>()
                .Property(e => e.Discount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<DetailEntity>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 2);

            modelBuilder.Entity<EventEntity>()
                .Property(e => e.Discount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<EventEntity>()
                .Property(e => e.EventCost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<EventEntity>()
                .Property(e => e.Total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.Cost)
                .HasPrecision(18, 2);
            modelBuilder.Entity<DetailEntity>()
            .Property(d => d.UnitPrice)
            .HasColumnType("decimal(18,2)");
            // Ignorar la propiedad calculada TotalPrice
            modelBuilder.Entity<DetailEntity>()
            .Property(d => d.TotalPrice)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ReservationEntity>()
                .Property(r => r.Count)
                .HasColumnType("decimal(18,2)"); // Ajusta la precisión y escala según tus necesidades

        }


        public DbSet<CategoryProductEntity> CategoryProducts { get; set; }
        public DbSet<ClientTypeEntity> TypesOfClient { get; set; }
        public DbSet<DetailEntity> Details { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }


    }
}