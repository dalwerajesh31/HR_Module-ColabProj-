using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HR_Module_Proj.Models
{
    public class MasterStaff
    {
        public Guid StaffId { get; set; }
        public string EMPStaffID { get; set; }
        public string StaffName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public List<SelectListItem> MaritalStatusList { get; set; }
        public string BloodGroup { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Religion { get; set; }
        public string Category { get; set; }
        public string Caste { get; set; }
        public string SubCaste { get; set; }
        public string HighestQualification { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Pincode { get; set; }  // you said it's string
        public int? DeptID { get; set; }
        public int? DesignationID { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> DesignationList { get; set; }
        public string WorkGroup { get; set; }
        public List<SelectListItem> GenderList { get; internal set; }
    }
}
