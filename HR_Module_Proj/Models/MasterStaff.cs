using HR_Module_Proj.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HR_Module_Proj.Models
{
    public class MasterStaff
    {
		//public MasterDesignation designation { get; set; } = new MasterDesignation();
		//public List<MasterDesignation> designations { get; set; } = new List<MasterDesignation>();
		//public MasterDepartment department { get; set; } = new MasterDepartment();
		//public List<MasterDepartment> departments { get; set; } = new List<MasterDepartment>();
		public MasterStaff MasterStaffDetail { get; set; } = new MasterStaff();
		public List<MasterStaff> MasterStaffDetails { get; set; } = new List<MasterStaff>();
	}
}
