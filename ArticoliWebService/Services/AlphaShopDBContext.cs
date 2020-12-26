using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticoliWebService.Services
{
    public class AlphaShopDBContext : DbContext
    {
        public AlphaShopDBContext(DbContextOptions<AlphaShopDBContext> options)
            :base(options)
        {

        }

        public virtual DbSet<Articoli> Articoli { get; set; }
        public virtual DbSet<Ean> Barcode { get; set; }
        public virtual DbSet<FamAssort> FamAssort { get; set; }
        public virtual DbSet<Ingredienti> Ingredienti { get; set; }
        public virtual DbSet<Iva> Iva { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articoli>()
                .HasKey(a => new { a.CodArt });

            //Relazione one to many fra articoli e barcode
            modelBuilder.Entity<Ean>()
                .HasOne<Articoli>(s => s.articolo) //ad un articoli...
                .WithMany(g => g.barcode) //Corrispondono molti barcode
                .HasForeignKey(s => s.CodArt);

            //Relazione one to one tra articoli e ingedienti
            modelBuilder.Entity<Articoli>()
               .HasOne<Ingredienti>(s => s.Ingredienti) //ad un articoli...
               .WithOne(g => g.Articolo) //Corrispondono molti barcode
               .HasForeignKey<Ingredienti>(s => s.CodArt);

            //Relazione one to many tra iva e articoli
            modelBuilder.Entity<Articoli>()
                .HasOne<Iva>(s => s.Iva) //ad un articoli...
                .WithMany(g => g.Articoli) //Corrispondono molti barcode
                .HasForeignKey(s => s.IdIva);

            //Relazione one to many tra FamAssort e articoli
            modelBuilder.Entity<Articoli>()
                .HasOne<FamAssort>(s => s.FamAssort) //ad un articoli...
                .WithMany(g => g.Articoli) //Corrispondono molti barcode
                .HasForeignKey(s => s.IdFamAss);
        }
    }
}
