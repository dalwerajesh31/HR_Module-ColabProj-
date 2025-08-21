using HR_Module_Proj.Models.Entities;

namespace HR_Module_Proj.Models
{
    public class Designations
    {
        //public Guid DesignationID { get; set; }
        //public string DesignationName { get; set; }
        //public string ShortName { get; set; }
        //public bool IsActive { get; set; }

        public MasterDesignation DesignationForm { get; set; }   // For Add/Edit
        public List<MasterDesignation> DesignationList { get; set; } // For Table List

    }
}
