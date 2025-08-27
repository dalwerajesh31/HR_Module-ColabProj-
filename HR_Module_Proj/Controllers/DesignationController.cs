using HR_Module_Proj.Models;
using HR_Module_Proj.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_Module_Proj.Controllers
{
    public class DesignationController : Controller
    {
		private readonly Data.ApplicationDbContext _context;

		public DesignationController(Data.ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> MasterDesignation()
		{
			Designations model = new Designations();
			
			model.designations = await _context.MasterDesignation.ToListAsync();
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SaveAndUpdate([Bind(Prefix = "designation")] MasterDesignation model)
		{
			if (ModelState.IsValid)
			{
				if (model.DesignationId == 0)
				{
					_context.MasterDesignation.Add(model);
				}
				else
				{
					var existingDesignation = await _context.MasterDesignation.FindAsync(model.DesignationId);
					if (existingDesignation == null)
					{
						return NotFound();
					}
					existingDesignation.DesignationName = model.DesignationName;
					existingDesignation.ShortName = model.ShortName;
					existingDesignation.IsActive = model.IsActive;
					existingDesignation.UpdatedAt = DateTime.UtcNow;
					_context.MasterDesignation.Update(existingDesignation);
				}
				await _context.SaveChangesAsync();
				//return RedirectToAction(nameof(Index));
				return RedirectToAction(nameof(MasterDesignation));
			}
			else
			{
				var vmInValid = new Designations
				{
					designation = model,
					designations = await _context.MasterDesignation.ToListAsync()
				};
				return View("MasterDesignation", vmInValid);
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			var s = await _context.MasterDesignation.FindAsync(id);
			if (s == null) return NotFound();
			_context.MasterDesignation.Remove(s);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(MasterDesignation));
		}
	}
}
