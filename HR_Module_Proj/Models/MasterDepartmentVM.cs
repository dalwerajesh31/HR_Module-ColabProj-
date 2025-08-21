using HR_Module_Proj.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace HR_Module_Proj.Models
{
    public class MasterDepartmentVM
    {
        public MasterDepartment department { get; set; } = new MasterDepartment();
        public List<MasterDepartment> departments { get; set; } = new List<MasterDepartment>();

    }
}
