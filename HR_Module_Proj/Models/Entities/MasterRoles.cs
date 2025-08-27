using System.ComponentModel.DataAnnotations;

namespace HR_Module_Proj.Models.Entities
{
    public class MasterRoles
    {
        public int Id { get; set; } // Auto-incremented by convention
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; } // Will be varchar(50)
        [Required]
        [MaxLength(5)]
        public string ShortName { get; set; } // Will be varchar(5)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
