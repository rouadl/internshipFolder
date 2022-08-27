using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using GP.Domain.Entities;
using GP.Data.Configurations;
using System.Linq;

namespace GP.Data
{
    public class ExamenContext : DbContext
    {
        public ExamenContext()
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options)
        {

        }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source= (localdb)\MSSQLLOCALDB; INITIAL CATALOG= GestionMedical; INTEGRATED SECURITY= TRUE").UseLazyLoadingProxies();
            //     optionsBuilder.UseLazyLoadingProxies()
            //        .UseSqlServer(@"Server=localhost;Database=GestionProduitDb;Trusted_Connection=True;");
        }
   
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<DossierMedical> Dossier { get; set; }
        public DbSet<User> User { get; set; }


    }
}
