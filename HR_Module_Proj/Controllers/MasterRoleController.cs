using HR_Module_Proj.Models;
using HR_Module_Proj.Models.Entities;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndUpdate([Bind(Prefix = "role")] MasterRoles model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    //Create new department
                    _context.MasterRoles.Add(model);
                }
                else
                {
                    //Update existing department
                    var existingDepartment = await _context.MasterRoles.FindAsync(model.Id);
                    if (existingDepartment == null)
                    {
                        return NotFound();
                    }
                    existingDepartment.RoleName = model.RoleName;
                    existingDepartment.ShortName = model.ShortName;
                    existingDepartment.IsActive = model.IsActive;
                    existingDepartment.UpdatedAt = DateTime.UtcNow;
                    _context.MasterRoles.Update(existingDepartment);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var vmInValid = new MasterRoleVM
                {
                    role = model,
                    roles = await _context.MasterRoles  .ToListAsync()
                };
                return View("Index", vmInValid);
            }
        }
    }
}
    