using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Reg> Regs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Fees> Feess { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Foreign key with NO ACTION ON DELETE

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            /*
             //The.OnDelete(DeleteBehavior.Restrict) assigns the delete Behavior to this relationship
            modelBuilder.Entity<Course>()
            .HasOne<Reg>(e => e.Reg)
            .WithMany(c => c.Course)
            .HasForeignKey(e => e.RegId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);
            */

          
        }


    }
}
