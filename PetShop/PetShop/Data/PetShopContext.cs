using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Models;

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

        }
    }
}
