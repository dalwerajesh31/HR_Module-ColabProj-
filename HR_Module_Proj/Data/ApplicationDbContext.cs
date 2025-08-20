using HR_Module_Proj.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_Module_Proj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterDepartment>(entity =>
            {
               entity.HasKey(e => e.Id);

                entity.Property(e => e.DepartmentName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ShortName).IsRequired().HasMaxLength(5);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });
                
        }
        public DbSet<Staffs> MasterStaffDetails { get; set; } = null!;
        public DbSet<MasterDepartment> MasterDepartments { get; set; } = null!;    
    }
}
