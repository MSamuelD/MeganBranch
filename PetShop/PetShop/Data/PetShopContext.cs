using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Models;
using System.Reflection.Metadata;

namespace PetShop.Data
{
    public class PetShopContext : DbContext
    {

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Staff> Staff {  get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet <Models.Type> Types { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PetShopDB;Trusted_Connection=True;TrustServerCertificate=True");
            return;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Type>().HasData(
                new Models.Type { Id = 1, Name = "Dog" },
                new Models.Type { Id = 2, Name = "Cat" },
                new Models.Type { Id = 3, Name = "Bird" },
                new Models.Type { Id = 4, Name = "Fish" },
                new Models.Type { Id = 5, Name = "Reptile" }
            );
            for (int i = 9; i <= 17; i++)
            {
                modelBuilder.Entity<Timeslot>().HasData(
                );
            }
            modelBuilder.Entity<Timeslot>().HasData();

            
        }
    }
}
