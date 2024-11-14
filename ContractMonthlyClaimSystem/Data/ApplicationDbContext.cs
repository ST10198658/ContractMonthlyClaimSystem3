using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContractMonthlyClaimSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lecturers> Lecturer { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }
    }
}
