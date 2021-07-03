using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary_Clinic_Test.Models;

namespace Veterinary_Clinic_Test.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasOne(p => p.Doctor)
                .WithMany(x => x.Animals)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Diagnosis>()
                .HasOne(p => p.Doctor)
                .WithMany(x => x.Diagnoses)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Vaccination>()
                .HasOne(p => p.Doctor)
                .WithMany(x => x.Vaccinations)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Vaccination>()
                .HasOne(p => p.Animal)
                .WithMany(x => x.Vaccinations)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Vaccination>()
                .HasOne(p => p.Diagnosis)
                .WithMany(x => x.Vaccinations)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Animal>()
                .HasOne(p => p.Diagnosis)
                .WithMany(x => x.Animals)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Animal>()
                .HasOne(p => p.Owner)
                .WithMany(x => x.Animals)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
    }
}
