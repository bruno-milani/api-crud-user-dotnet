using System;
using myApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace myApi.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "AdminAPI",
                    Email = "admin@api.com",
                    DateOfBird = Convert.ToDateTime("17/07/1996"),
                    Sex = "Masculino",
                    Role = "Manager"
                }
            );
        }
    }
}
