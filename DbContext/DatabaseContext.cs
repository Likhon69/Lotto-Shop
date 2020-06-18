
using Microsoft.EntityFrameworkCore;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApp.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }

        public DbSet<Shoe> Shoes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Category>()
                    .HasKey(c => c.C_Id);
            modelBuilder.Entity<Category>()
                        .Property(c => c.description)
                        .IsRequired();
            modelBuilder.Entity<Category>()
                        .Property(c => c.shortName)
                        .IsRequired();
           
                    
        }
    }
}
