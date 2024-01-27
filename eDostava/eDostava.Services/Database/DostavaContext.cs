using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    public partial class DostavaContext : DbContext
    {
        public DostavaContext()
        {

        }
        public DostavaContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Kupci> Kupci { get; set; }
        public virtual DbSet<Dostavljac> Dostavljac { get; set; }
        public virtual DbSet<Jelo> Jelo { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<KorisnikUloga> KorisnikUloga { get; set; }
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<NarudzbaStavke> NarudzbaStavke { get; set; }
        public virtual DbSet<Favoriti> Favoriti { get; set; }
        public virtual DbSet<Restoran> Restoran { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<JeloKategorija> JeloKategorija { get; set; }
        public virtual DbSet<JelaOcjene> JelaOcjene { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost, 1401; Initial Catalog=Dostava; user=sa; Password=Konjic1981; TrustServerCertificate=True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>()
                .HasOne(k => k.Restoran)
                .WithOne(r => r.Korisnik)
                .HasForeignKey<Restoran>(r => r.KorisnikId)
                .OnDelete(DeleteBehavior.Restrict);

            onModelCreatingPartial(modelBuilder);
        }

        partial void onModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
