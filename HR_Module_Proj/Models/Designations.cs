using HR_Module_Proj.Models.Entities;

namespace HR_Module_Proj.Models
{
    public class Designations
    {
        public MasterDesignation designation { get; set; }   // For Add/Edit
        public List<MasterDesignation> designations { get; set; } // For Table List

    }
}
