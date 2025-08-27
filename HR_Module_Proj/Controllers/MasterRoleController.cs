using HR_Module_Proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_Module_Proj.Controllers
{
    public class MasterRoleController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public MasterRoleController(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            MasterRoleVM model = new MasterRoleVM();
            model.roles = await _context.MasterRoles.ToListAsync();
            return View(model);
            //return View();
        }
    }
}
    