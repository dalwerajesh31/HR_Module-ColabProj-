using System.ComponentModel.DataAnnotations;

namespace HR_Module_Proj.Models.Entities
{
    public class Staffs
    {
        [Key]
        //public int StaffId { get; set; }
        public Guid StaffId { get; set; }

        [StringLength(20)]
        public string EMPStaffID { get; set; }

        [Required]
        [StringLength(200)]
        public string StaffName { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        [StringLength(20)]
        public string MaritalStatus { get; set; }

        public string BloodGroup { get; set; }

        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(10)]
        [Phone]
        public string MobileNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [StringLength(50)]
        public string Religion { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Caste { get; set; }

        [StringLength(50)]
        public string SubCaste { get; set; }

        [StringLength(250)]
        public string HighestQualification { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(250)]
        public string State { get; set; }

        [StringLength(250)]
        public string City { get; set; }

        [StringLength(20)]
        public string Pincode { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [StringLength(150)]
        public string Department { get; set; }

        [StringLength(150)]
        public string Designation { get; set; }

        [StringLength(50)]
        public string WorkGroup { get; set; }
    }

}
