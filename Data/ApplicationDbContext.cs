using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VillaBNB.Data.Models;

namespace VillaBNB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Villa> Villas { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Villa>()
                .HasOne(v => v.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId)
                .HasForeignKey(c => c.CategoryId)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Country>()
                .HasMany(c => c.Cities)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<City>()
                .HasMany(v => v.Villas)
                .WithOne()
                .HasForeignKey(c=>c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>()
                .HasMany(v => v.Villas)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Amenity>()
                .HasOne(c => c.Villa)
                .WithMany()
                .HasForeignKey(c=>c.VillaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Image>()
                .HasOne(c => c.Villa)
                .WithMany()
                .HasForeignKey(c => c.VillaId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
