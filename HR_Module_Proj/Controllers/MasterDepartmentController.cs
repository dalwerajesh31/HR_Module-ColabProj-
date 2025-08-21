using HR_Module_Proj.Models;
using HR_Module_Proj.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_Module_Proj.Controllers
{
    public class MasterDepartmentController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public MasterDepartmentController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            MasterDepartmentVM model = new MasterDepartmentVM();
            model.departments = await _context.MasterDepartments.ToListAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert([Bind(Prefix = "department")] MasterDepartment model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    //Create new department
                    _context.MasterDepartments.Add(model);
                }
                else
                {
                    //Update existing department
                    var existingDepartment = await _context.MasterDepartments.FindAsync(model.Id);
                    if (existingDepartment == null)
                    {
                        return NotFound();
                    }
                    existingDepartment.DepartmentName = model.DepartmentName;
                    existingDepartment.ShortName = model.ShortName;
                    existingDepartment.IsActive = model.IsActive;
                    existingDepartment.UpdatedAt = DateTime.UtcNow;
                    _context.MasterDepartments.Update(existingDepartment);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var vmInValid = new MasterDepartmentVM
                {
                    department = model,
                    departments = await _context.MasterDepartments.ToListAsync()
                };
                return View("Index", vmInValid);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await _context.MasterDepartments.FindAsync(id);
            if (s == null) return NotFound();
            _context.MasterDepartments.Remove(s);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

