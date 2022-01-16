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



        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Villa>().HasOne<City>().WithMany().OnDelete(DeleteBehavior.Restrict);

        //    builder.Entity<Country>().HasMany<City>().WithOne().OnDelete(DeleteBehavior.Restrict);

        //    builder.Entity<City>().HasMany<Villa>().WithOne().OnDelete(DeleteBehavior.Restrict);

        //    builder.Entity<Category>().HasMany<Villa>().WithOne().OnDelete(DeleteBehavior.Restrict);

        //}
    }
}
