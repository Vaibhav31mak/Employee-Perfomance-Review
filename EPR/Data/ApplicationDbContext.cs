using EPR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EPR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<LeaveApplication>()
                .HasOne(f => f.Status)
                .WithMany()
                .HasForeignKey(f => f.StatusId)
                .OnDelete(DeleteBehavior.Cascade);

            string adminRoleId = "eaddeb3d-dcbf-423c-9e40-3d9a0f1e7dba";
            string adminUserId = "b5197a51-c458-46ba-b85a-3404ac3e9f51";

            // ✅ Always seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "HR", NormalizedName = "HR" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Applicant", NormalizedName = "APPLICANT" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Employee", NormalizedName = "EMPLOYEE" }
            );

            var hasher = new PasswordHasher<IdentityUser>();
            var admin = new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin@epr.com",
                NormalizedUserName = "ADMIN@EPR.COM",
                Email = "admin@epr.com",
                NormalizedEmail = "ADMIN@EPR.COM",
                EmailConfirmed = true,
            };

            admin.PasswordHash = hasher.HashPassword(admin, "Admin@123"); 

            modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminUserId }
            );
        }



        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<SystemCode> SystemCodes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

    }
}
