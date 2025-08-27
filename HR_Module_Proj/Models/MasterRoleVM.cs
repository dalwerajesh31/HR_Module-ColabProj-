namespace HR_Module_Proj.Models
{
    public class MasterRoleVM
    {
        public Models.Entities.MasterRoles role { get; set; } = new Models.Entities.MasterRoles();
        public List<Models.Entities.MasterRoles> roles { get; set; } = new List<Models.Entities.MasterRoles>();
    }
}
