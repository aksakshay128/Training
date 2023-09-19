
using MessagePack;
using Microsoft.EntityFrameworkCore;
namespace WebApplicationProject.Models
{
        public class EmployeeData
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public string Job { get; set; }
            public int Salary {  get; set; }
            public string Department { get; set; }
        }

        public class UserData
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }

        public class ProjectDbContext : DbContext
        {
            public DbSet<EmployeeData> EmployeeSet { get; set; }

            public DbSet<UserData> UserSet { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<EmployeeData>().HasKey(x => x.EmployeeId);
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<UserData>().HasKey(x => x.UserId);
                base.OnModelCreating(modelBuilder);
            }

            public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
             : base(options)
            {

            }
        }
    }

