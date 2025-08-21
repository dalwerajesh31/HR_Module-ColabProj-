using HR_Module_Proj.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_Module_Proj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
       public DbSet<Staffs> MasterStaffDetails { get; set; } = null!;
       public DbSet<MasterDesignation> MasterDesignation { get; set; } = null!;
    }
}
