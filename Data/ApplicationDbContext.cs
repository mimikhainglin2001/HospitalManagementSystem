using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Models;
namespace HospitalManagementSystem.Data;


    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<SystemCode> SystemCodes { get; set; }
        public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                builder.Entity<ApplicationUser>()
                    .HasOne(s => s.Gender)
                    .WithMany()
                    .HasForeignKey(s => s.GenderId)
                    .OnDelete(DeleteBehavior.Restrict);

                    builder.Entity<ApplicationUser>()
                    .HasOne(s => s.MaritalStatus)
                    .WithMany()
                    .HasForeignKey(s => s.MaritalStatusId)
                    .OnDelete(DeleteBehavior.Restrict);   

                    builder.Entity<ApplicationUser>()
                    .HasOne(s => s.BloodGroup)
                    .WithMany()
                    .HasForeignKey(s => s.BloodGroupId)
                    .OnDelete(DeleteBehavior.Restrict);

               
        }
    }
