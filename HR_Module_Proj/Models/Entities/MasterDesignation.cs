using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Module_Proj.Models.Entities
{
    public class MasterDesignation
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DesignationId { get; set; } // after (identity)
		[Required]
        [MaxLength(200)]
        public string DesignationName { get; set; }
        public string ShortName { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
		public bool IsActive { get; set; }
    }
}
