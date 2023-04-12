using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BD07.Models;

namespace BD07.Data
{
    public class MyMedContext : DbContext
    {
        public MyMedContext (DbContextOptions<MyMedContext> options)
            : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedEvent> MedEvents { get; set; }
        public DbSet<MedContainer> MedContainers { get; set; }
        public DbSet<Patient> Patients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().ToTable("Medicine");
            modelBuilder.Entity<MedEvent>().ToTable("MedEvent");
            modelBuilder.Entity<MedContainer>().ToTable("MedContainer");
            modelBuilder.Entity<Patient>().ToTable("Patient");
        }
    }
}
