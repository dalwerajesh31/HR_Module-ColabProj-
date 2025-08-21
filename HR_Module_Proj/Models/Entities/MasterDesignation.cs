using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;

namespace HR_Module_Proj.Models.Entities
{
    public class MasterDesignation
    {
        [Key]   // <-- Mark as primary key
        public Guid DesignationID { get; set; }
        [Required]
        [MaxLength(200)]
        public string DesignationName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
    }
}
