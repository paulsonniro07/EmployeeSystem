using EmployeeSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Attendance>()
                .Property(e => e.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }

                ((BaseEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;
            }
        }
    }
}
