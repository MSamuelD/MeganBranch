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
            List<Timeslot> timeslots = new List<Timeslot>();
            DateTime startDateTime = new DateTime(1, 1, 1, 9, 0, 0);  
            DateTime endDateTime = new DateTime(1, 1, 1, 17, 0, 0);  
            for (int minutes = 0; startDateTime.AddMinutes(minutes) <= endDateTime; minutes += 30)
            {
                timeslots.Add(new Timeslot { Time = startDateTime.AddMinutes(minutes) });
            }
            //https://github.com/MSamuelD/BeanSceneNew/blob/master/BeanSceneNew/Data/ApplicationDbContext.cs line 94. 
            //MSamuelD, Original code idea was from Michael Kirkwood-Smith (TAFE NSW Hornsby) a.k.a the GOAT in programming - Diploma in Advanced Programming - https://www.linkedin.com/in/michaelkirkwoodsmith/
            modelBuilder.Entity<Timeslot>().HasData(timeslots);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Type>().HasData(
                new Models.Type { Id = 1, Name = "Dog" },
                new Models.Type { Id = 2, Name = "Cat" },
                new Models.Type { Id = 3, Name = "Bird" },
                new Models.Type { Id = 4, Name = "Fish" },
                new Models.Type { Id = 5, Name = "Reptile" }
            );
            modelBuilder.Entity<Appointment>().HasOne(e => e.StartTime).WithMany().OnDelete(DeleteBehavior.NoAction);

        }
    }
}
