using System;
using Microsoft.EntityFrameworkCore;
using PersonDiary.Entities;

namespace PersonDiary.Contexts
{
    public class SqlContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<LifeEvent> LifeEvents { get; set; }

        public SqlContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=persondiarydb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person[]
                {
                    new Person {Id =1,Name = "Michael",Surname="Jackson"},
                    new Person {Id =2,Name = "Tom",Surname="Jones"}
                });

            modelBuilder.Entity<LifeEvent>().HasData(
                new LifeEvent[]
                {
                            new LifeEvent() { Id =1, Name="born", EventDate = new DateTime(1958,08,29), PersonId  =1},
                            new LifeEvent() { Id =2, Name="die", EventDate = new DateTime(2009,06,25), PersonId  =1 },
                            new LifeEvent() { Id = 3, Name = "born", EventDate = new DateTime(1940, 06, 07), PersonId = 2 },
                            new LifeEvent() { Id = 4, Name = "first album", EventDate = new DateTime(1965, 07, 01) , PersonId = 2}

                });
            //modelBuilder.Entity<LifeEvent>().HasOne(le => le.Person).WithMany(p => p.LifeEvents).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
