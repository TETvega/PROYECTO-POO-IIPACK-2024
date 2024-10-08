﻿using InmobiliariaUNAH.Database.Entities;
using Microsoft.EntityFrameworkCore;
namespace InmobiliariaUNAH.Database
{
    public class InmobiliariaUNAHContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

        public DbSet<UserEntity> Users { get; set; }


    }
}