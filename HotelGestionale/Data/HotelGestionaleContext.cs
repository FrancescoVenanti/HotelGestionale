using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelGestionale.Models;

namespace HotelGestionale.Data
{
    public class HotelGestionaleContext : DbContext
    {
        public HotelGestionaleContext (DbContextOptions<HotelGestionaleContext> options)
            : base(options)
        {
        }

        public DbSet<HotelGestionale.Models.Camere> Camere { get; set; } = default!;
        public DbSet<HotelGestionale.Models.Clienti> Clienti { get; set; } = default!;
        public DbSet<HotelGestionale.Models.Servizi> Servizi { get; set; } = default!;
        public DbSet<HotelGestionale.Models.TipoPensione> TipoPensione { get; set; } = default!;
        public DbSet<HotelGestionale.Models.Prenotazioni> Prenotazioni { get; set; } = default!;
        public DbSet<HotelGestionale.Models.Login> Login { get; set; } = default!;
        public DbSet<HotelGestionale.Models.Checkout> Checkout { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Checkout>().HasNoKey();
        }
    }
}
