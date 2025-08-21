//using HR_Module_Proj.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using HR_Module_Proj.Data;
//using HR_Module_Proj.Models.Entities;

//namespace HR_Module_Proj.Controllers
//{
//    [Route("Staff")]
//    public class StaffController : Controller
//    {
//        //private readonly ApplicationDbContext _dbContext;

//        //public StaffController(ApplicationDbContext dbContext)
//        //{
//        //    _dbContext = dbContext;
//        //}

//        private readonly ApplicationDbContext dbContext;

//        public StaffController(ApplicationDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        // GET: Add or Edit Staff
//        [HttpGet]
//        [Route("Form/{id?}")]
//        public async Task<IActionResult> StaffForm(Guid? id)
//        {
//            if (id == null) // Add Mode
//            {
//                return View(new MasterStaff());
//            }

//            // Edit Mode
//            var staff = await dbContext.MasterStaffDetails.FindAsync(id.Value);
//            if (staff == null)
//                return NotFound();

//            return View(staff);
//        }

//        // POST: Save Staff (Add or Update)
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [Route("Form/{id?}")]
//        public async Task<IActionResult> StaffForm(Staffs model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            if (model.StaffId == Guid.Empty) // Add
//            {
//                model.StaffId = Guid.NewGuid();
//                dbContext.MasterStaffDetails.Add(model);
//            }
//            else // Update
//            {
//                dbContext.MasterStaffDetails.Update(model);
//            }
//            await dbContext.SaveChangesAsync();
//            return RedirectToAction("StaffList");
//        }

//        // GET: List
//        [HttpGet]
//        [Route("List")]
//        public async Task<IActionResult> StaffList()
//        {
//            var staffList = await dbContext.MasterStaffDetails.ToListAsync();
//            return View(staffList);
//        }

//        // POST: Delete
//        [HttpPost]
//        [Route("Delete/{id}")]
//        public async Task<IActionResult> DeleteStaff(Guid id)
//        {
//            var staff = await dbContext.MasterStaffDetails.FindAsync(id);
//            if (staff != null)
//            {
//                dbContext.MasterStaffDetails.Remove(staff);
//                await dbContext.SaveChangesAsync();
//            }
//            return RedirectToAction("StaffList");
//        }
//    }

//    //public class StaffController : Controller
//    //{
//    //    private readonly ApplicationDbContext dbContext;

//    //    public StaffController(ApplicationDbContext dbContext)
//    //    {
//    //        this.dbContext = dbContext;
//    //    }
//    //    public IActionResult Index()
//    //    {
//    //        return View();
//    //    }
//    //    private List<SelectListItem> GetDepartments()
//    //    {
//    //        return new List<SelectListItem>
//    //        {
//    //            new SelectListItem{Text="Teaching", Value="1"},
//    //            new SelectListItem{Text="Non-Teaching", Value="2"},
//    //            new SelectListItem{Text="IT", Value="3"},
//    //            new SelectListItem{Text="HR", Value="4"},
//    //            new SelectListItem{Text="Admin", Value="5"},
//    //        };
//    //    }
//    //    private List<SelectListItem> GetDesignations()
//    //    {
//    //        return new List<SelectListItem>
//    //        {
//    //            new SelectListItem{Text="Teacher", Value="1"},
//    //            new SelectListItem{Text="Staff", Value="2"},
//    //            new SelectListItem{Text="Software Developer", Value="3"},
//    //            new SelectListItem{Text="HR", Value="4"},
//    //            new SelectListItem{Text="Admin", Value="5"},
//    //        };
//    //    }
//    //    private List<SelectListItem> GetMaritalStatusList()
//    //    {
//    //        return new List<SelectListItem>
//    //        {
//    //            new SelectListItem{Text="Married", Value="Married"},
//    //            new SelectListItem{Text="UnMarried", Value="UnMarried"},
//    //        };
//    //    }
//    //    [HttpGet]
//    //    public IActionResult AddStaff()
//    //    {
//    //        var model = new MasterStaff
//    //        {
//    //            DepartmentList = GetDepartments(),
//    //            MaritalStatusList = GetMaritalStatusList(),
//    //            DesignationList = GetDesignations()
//    //        };
//    //        return View(model);
//    //    }
//    //    [HttpPost]
//    //    public async Task<IActionResult> AddStaff(MasterStaff model)
//    //    {
//    //        if (!ModelState.IsValid)
//    //        {
//    //            model.DepartmentList = GetDepartments();
//    //            model.MaritalStatusList = GetMaritalStatusList();
//    //            model.DesignationList = GetDesignations();
//    //        }
//    //        var StaffList = new Staffs
//    //        {
//    //            StaffName = model.StaffName,
//    //            EMPStaffID = model.EMPStaffID,
//    //            MobileNo = model.MobileNo,
//    //            Email = model.Email,
//    //            DOB = model.DOB,
//    //            Gender = model.Gender,
//    //            MaritalStatus = model.MaritalStatus,
//    //            BloodGroup = model.BloodGroup,
//    //            JoiningDate = model.JoiningDate,
//    //            WorkGroup = model.WorkGroup,
//    //            Religion = model.Religion,
//    //            Category = model.Category,
//    //            Caste = model.Caste,
//    //            SubCaste = model.SubCaste,
//    //            HighestQualification = model.HighestQualification,
//    //            DeptID = model.DeptID,
//    //            DesignationID = model.DesignationID,
//    //            Address = model.Address,
//    //            Country = model.Country,
//    //            State = model.State,
//    //            City = model.City,
//    //            Pincode = model.Pincode,
//    //        };
//    //        await dbContext.MasterStaffDetails.AddAsync(StaffList);
//    //        await dbContext.SaveChangesAsync();
//    //        return RedirectToAction("StaffRegister");
//    //    }
//    //    [HttpGet]
//    //    public async Task<IActionResult> StaffRegister()
//    //    {
//    //        var staffs = await dbContext.MasterStaffDetails.ToListAsync();
//    //        return View(staffs);
//    //    }
//    //    [HttpGet]
//    //    [Route("Staff/Edit/{StaffId}")]
//    //    public async Task<IActionResult> EditStaffDetails(Guid StaffId)
//    //    {
//    //        var staffEntity = await dbContext.MasterStaffDetails.FindAsync(StaffId);

//    //        if (staffEntity == null)
//    //        {
//    //            return View(null);
//    //        }

//    //        var model = new MasterStaff
//    //        {
//    //            StaffId = staffEntity.StaffId,
//    //            StaffName = staffEntity.StaffName,
//    //            EMPStaffID = staffEntity.EMPStaffID,
//    //            MobileNo = staffEntity.MobileNo,
//    //            Email = staffEntity.Email,
//    //            DOB = staffEntity.DOB,
//    //            Gender = staffEntity.Gender,
//    //            MaritalStatus = staffEntity.MaritalStatus,
//    //            BloodGroup = staffEntity.BloodGroup,
//    //            JoiningDate = staffEntity.JoiningDate,
//    //            WorkGroup = staffEntity.WorkGroup,
//    //            Religion = staffEntity.Religion,
//    //            Category = staffEntity.Category,
//    //            Caste = staffEntity.Caste,
//    //            SubCaste = staffEntity.SubCaste,
//    //            HighestQualification = staffEntity.HighestQualification,
//    //            DeptID = staffEntity.DeptID,
//    //            DesignationID = staffEntity.DesignationID,
//    //            DepartmentList = GetDepartments(),
//    //            DesignationList = GetDesignations(),
//    //            MaritalStatusList = GetMaritalStatusList(),
//    //            Address = staffEntity.Address,
//    //            Country = staffEntity.Country,
//    //            State = staffEntity.State,
//    //            City = staffEntity.City,
//    //            Pincode = staffEntity.Pincode,
//    //        };

//    //        return View(model);
//    //    }
//    //    [HttpPost]
//    //    [ValidateAntiForgeryToken]
//    //    [Route("Staff/Edit/{StaffId}")]
//    //    public async Task<IActionResult> EditStaffDetails(MasterStaff model, string command)
//    //    {
//    //        if (command == "Update")
//    //        {
//    //            if (!ModelState.IsValid)
//    //            {
//    //                model.MaritalStatusList = GetMaritalStatusList();
//    //                model.DepartmentList = GetDepartments();
//    //                model.DesignationList = GetDesignations();
//    //                return View(model);
//    //            }

//    //            var staff = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);

//    //            if (staff != null)
//    //            {
//    //                dbContext.Entry(staff).CurrentValues.SetValues(model);
//    //                await dbContext.SaveChangesAsync();
//    //            }

//    //            return RedirectToAction("StaffRegister", "Staff");
//    //        }
//    //        else if (command == "Delete")
//    //        {
//    //            var staff = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
//    //            if (staff != null)
//    //            {
//    //                dbContext.MasterStaffDetails.Remove(staff);
//    //                await dbContext.SaveChangesAsync();
//    //            }

//    //            return RedirectToAction("StaffRegister", "Staff");
//    //        }

//    //        return View(model);
//    //    }

//    //    //[HttpGet]
//    //    //[Route("Staff/Edit/{StaffId}")]
//    //    //public async Task<IActionResult> EditStaffDetails(Guid StaffId)
//    //    //{
//    //    //    var StaffList = await dbContext.MasterStaffDetails.FindAsync(StaffId);
//    //    //    if (StaffList == null)
//    //    //    {
//    //    //        return View(StaffList);
//    //    //    }
//    //    //    var model = new MasterStaff
//    //    //    {
//    //    //        StaffName = StaffList.StaffName,
//    //    //        EMPStaffID = StaffList.EMPStaffID,
//    //    //        MobileNo = StaffList.MobileNo,
//    //    //        Email = StaffList.Email,
//    //    //        DOB = StaffList.DOB,
//    //    //        Gender = StaffList.Gender,
//    //    //        MaritalStatus = StaffList.MaritalStatus,
//    //    //        BloodGroup = StaffList.BloodGroup,
//    //    //        JoiningDate = StaffList.JoiningDate,
//    //    //        WorkGroup = StaffList.WorkGroup,
//    //    //        Religion = StaffList.Religion,
//    //    //        Category = StaffList.Category,
//    //    //        Caste = StaffList.Caste,
//    //    //        SubCaste = StaffList.SubCaste,
//    //    //        HighestQualification = StaffList.HighestQualification,
//    //    //        DeptID = StaffList.DeptID,
//    //    //        DesignationID = StaffList.DesignationID,
//    //    //        DepartmentList = GetDepartments(),
//    //    //        DesignationList = GetDesignations(),
//    //    //        MaritalStatusList = GetMaritalStatusList(),
//    //    //        Address = StaffList.Address,
//    //    //        Country = StaffList.Country,
//    //    //        State = StaffList.State,
//    //    //        City = StaffList.City,
//    //    //        Pincode = StaffList.Pincode,
//    //    //    };
//    //    //    return View(model);
//    //    //}
//    //    //[HttpPost]
//    //    //[ValidateAntiForgeryToken]
//    //    //public async Task<IActionResult> EditOrDelete(MasterStaff model, string command)
//    //    //{
//    //    //    if (command == "Update")
//    //    //    {
//    //    //        if (!ModelState.IsValid)
//    //    //        {
//    //    //            model.MaritalStatusList = GetMaritalStatusList();
//    //    //            model.DepartmentList = GetDepartments();
//    //    //            model.DesignationList = GetDesignations();
//    //    //            return View(model);
//    //    //        }

//    //    //        var staff = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
//    //    //        if (staff != null)
//    //    //        {*
//    //    //            dbContext.Entry(staff).CurrentValues.SetValues(model);
//    //    //            await dbContext.SaveChangesAsync();
//    //    //        }

//    //    //        return RedirectToAction("StaffRegister", "Staff");
//    //    //    }
//    //    //    else if (command == "Delete")
//    //    //    {
//    //    //        var staff = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
//    //    //        if (staff != null)
//    //    //        {
//    //    //            dbContext.MasterStaffDetails.Remove(staff);
//    //    //            await dbContext.SaveChangesAsync();
//    //    //        }

//    //    //        return RedirectToAction("StaffRegister", "Staff");
//    //    //    }
//    //    //    return View(model);
//    //    //}

//    //    //[HttpPost]
//    //    //public async Task<IActionResult> EditStaffDetails(MasterStaff model)
//    //    //{
//    //    //    if (!ModelState.IsValid)
//    //    //    {
//    //    //        model.MaritalStatusList = GetMaritalStatusList();
//    //    //        model.DepartmentList = GetDepartments();
//    //    //        model.DesignationList = GetDesignations();
//    //    //        return View(model);
//    //    //    }
//    //    //    var StaffList = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
//    //    //    if (StaffList != null)
//    //    //    {
//    //    //        StaffList.StaffName = model.StaffName;
//    //    //        StaffList.EMPStaffID = model.EMPStaffID;
//    //    //        StaffList.MobileNo = model.MobileNo;
//    //    //        StaffList.Email = model.Email;
//    //    //        StaffList.DOB = model.DOB;
//    //    //        StaffList.Gender = model.Gender;
//    //    //        StaffList.MaritalStatus = model.MaritalStatus;
//    //    //        StaffList.BloodGroup = model.BloodGroup;
//    //    //        StaffList.JoiningDate = model.JoiningDate;
//    //    //        StaffList.WorkGroup = model.WorkGroup;
//    //    //        StaffList.Religion = model.Religion;
//    //    //        StaffList.Category = model.Category;
//    //    //        StaffList.Caste = model.Caste;
//    //    //        StaffList.SubCaste = model.SubCaste;
//    //    //        StaffList.HighestQualification = model.HighestQualification;
//    //    //        StaffList.DeptID = model.DeptID;
//    //    //        StaffList.DesignationID = model.DesignationID;
//    //    //        StaffList.Address = model.Address;
//    //    //        StaffList.Country = model.Country;
//    //    //        StaffList.State = model.State;
//    //    //        StaffList.City = model.City;
//    //    //        StaffList.Pincode = model.Pincode;
//    //    //        await dbContext.SaveChangesAsync();
//    //    //    }
//    //    //    return RedirectToAction("EditStaffDetails", new { StaffId = model.StaffId });
//    //    //}
//    //    //[HttpPost]  
//    //    //public async Task<IActionResult> Delete(MasterStaff viewmodel)
//    //    //{
//    //    //    var StaffList= await dbContext.MasterStaffDetails.AsNoTracking().FirstOrDefaultAsync(x=>x.StaffId == viewmodel.StaffId);
//    //    //    if (StaffList is not null)
//    //    //    {
//    //    //        dbContext.MasterStaffDetails.Remove(StaffList);
//    //    //        await dbContext.SaveChangesAsync();
//    //    //    }
//    //    //    return RedirectToAction("StaffRegister","Staff");
//    //    //}


//    //}
//}

using HR_Module_Proj.Models;
using HR_Module_Proj.Models.Entities;
using HR_Module_Proj.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

    namespace HR_Module_Proj.Controllers
    {
        public class StaffController : Controller
        {
            private readonly ApplicationDbContext dbContext;

            public StaffController(ApplicationDbContext context)
            {
                dbContext = context;
            }

        // ----------------- LIST -----------------
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> StaffList()
        {
            var staffList = await dbContext.MasterStaffDetails.ToListAsync();
            return View(staffList);
        }

        // ----------------- ADD/EDIT FORM (GET) -----------------
        [HttpGet]
        [Route("Form/{id?}")]
        public async Task<IActionResult> StaffForm(Guid? id)
        {
            MasterStaff model;

            if (id == null || id == Guid.Empty)
            {
                // Create new
                model = new MasterStaff
                {
                    StaffId = Guid.Empty,
                    GenderList = GetGenderList(),
                    MaritalStatusList = GetMaritalStatusList()
                };
            }
            else
            {
                // Edit existing
                var staff = await dbContext.MasterStaffDetails.FindAsync(id);
                if (staff == null)
                {
                    return RedirectToAction("StaffList");
                }

                model = new MasterStaff
                {
                    StaffId = staff.StaffId,
                    StaffName = staff.StaffName,
                    Gender = staff.Gender,
                    MaritalStatus = staff.MaritalStatus,
                    DOB = staff.DOB,
                    GenderList = GetGenderList(),
                    MaritalStatusList = GetMaritalStatusList()
                };
            }

            return View(model);
        }

        // ----------------- ADD/EDIT/DELETE (POST) -----------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Form/{id?}")]
        public async Task<IActionResult> StaffForm(MasterStaff model, string? command)
        {
            if (command == "Delete")
            {
                if (model.StaffId != Guid.Empty)
                {
                    var toDelete = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
                    if (toDelete != null)
                    {
                        dbContext.MasterStaffDetails.Remove(toDelete);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return RedirectToAction("StaffList");
            }

            if (!ModelState.IsValid)
            {
                // Reload dropdowns before returning view
                model.GenderList = GetGenderList();
                model.MaritalStatusList = GetMaritalStatusList();
                return View(model);
            }
            if (model.StaffId == Guid.Empty)
            {
                var newStaff = new Staffs
                {
                    StaffId = Guid.NewGuid(),
                    StaffName = model.StaffName,
                    Gender = model.Gender,
                    MaritalStatus = model.MaritalStatus,
                    DOB = (DateTime)model.DOB
				};
                await dbContext.MasterStaffDetails.AddAsync(newStaff);
            }
            else
            {
                // Update
                var existing = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
                if (existing != null)
                {
                    existing.StaffName = model.StaffName;
                    existing.Gender = model.Gender;
                    existing.MaritalStatus = model.MaritalStatus;
                    existing.DOB = (DateTime)model.DOB;
                    dbContext.MasterStaffDetails.Update(existing);
                }
            }
            await dbContext.SaveChangesAsync();
            return RedirectToAction("StaffList");
        }
        // ----------------- HELPER METHODS -----------------
        private List<SelectListItem> GetGenderList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Male", Text = "Male" },
                new SelectListItem { Value = "Female", Text = "Female" }
            };
        }
        private List<SelectListItem> GetMaritalStatusList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Single", Text = "Single" },
                new SelectListItem { Value = "Married", Text = "Married" }
            };
        }
    }
    }

    //[Route("Staff")]
    //public class StaffController : Controller
    //{
    //    private readonly ApplicationDbContext dbContext;
    //    public StaffController(ApplicationDbContext dbContext) => this.dbContext = dbContext;

    //    // ------- Lookup lists (same as your old code) -------
    //    private List<SelectListItem> GetDepartments() => new()
    //    {
    //        new SelectListItem{Text="Teaching", Value="1"},
    //        new SelectListItem{Text="Non-Teaching", Value="2"},
    //        new SelectListItem{Text="IT", Value="3"},
    //        new SelectListItem{Text="HR", Value="4"},
    //        new SelectListItem{Text="Admin", Value="5"},
    //    };

    //    private List<SelectListItem> GetDesignations() => new()
    //    {
    //        new SelectListItem{Text="Teacher", Value="1"},
    //        new SelectListItem{Text="Staff", Value="2"},
    //        new SelectListItem{Text="Software Developer", Value="3"},
    //        new SelectListItem{Text="HR", Value="4"},
    //        new SelectListItem{Text="Admin", Value="5"},
    //    };

    //    private List<SelectListItem> GetMaritalStatusList() => new()
    //    {
    //        new SelectListItem{Text="Married", Value="Married"},
    //        new SelectListItem{Text="UnMarried", Value="UnMarried"},
    //    };
    //    [HttpGet]
    //    [Route("List")]
    //    public async Task<IActionResult> StaffList()
    //    {
    //        var staffList = await dbContext.MasterStaffDetails.AsNoTracking().ToListAsync();
    //        return View(staffList);
    //    }

    //    [HttpGet]
    //    [Route("Form/{id?}")]
    //    public async Task<IActionResult> StaffForm(Guid? id)
    //    {
    //        MasterStaff vm;
    //        if (id == null || id == Guid.Empty)
    //        {
    //            vm = new MasterStaff(); // Add mode
    //        }
    //        else
    //        {
    //            var e = await dbContext.MasterStaffDetails.FindAsync(id.Value);
    //            if (e == null) return NotFound();

    //            vm = new MasterStaff
    //            {
    //                StaffId = e.StaffId,
    //                StaffName = e.StaffName,
    //                EMPStaffID = e.EMPStaffID,
    //                MobileNo = e.MobileNo,
    //                Email = e.Email,
    //                DOB = e.DOB,
    //                Gender = e.Gender,
    //                MaritalStatus = e.MaritalStatus,
    //                BloodGroup = e.BloodGroup,
    //                JoiningDate = e.JoiningDate,
    //                WorkGroup = e.WorkGroup,
    //                Religion = e.Religion,
    //                Category = e.Category,
    //                Caste = e.Caste,
    //                SubCaste = e.SubCaste,
    //                HighestQualification = e.HighestQualification,
    //                DeptID = e.DeptID,
    //                DesignationID = e.DesignationID,
    //                Address = e.Address,
    //                Country = e.Country,
    //                State = e.State,
    //                City = e.City,
    //                Pincode = e.Pincode,
    //            };
    //        }
    //        // dropdowns
    //        vm.DepartmentList = GetDepartments();
    //        vm.DesignationList = GetDesignations();
    //        vm.MaritalStatusList = GetMaritalStatusList();
    //        return View(vm);
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    [Route("Form/{id?}")]
    //    public async Task<IActionResult> StaffForm(MasterStaff model, string? command)
    //    {
    //        // ----- Handle Delete -----
    //        if (command == "Delete")
    //        {
    //            if (model.StaffId != Guid.Empty)
    //            {
    //                var toDel = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
    //                if (toDel != null)
    //                {
    //                    dbContext.MasterStaffDetails.Remove(toDel);
    //                    await dbContext.SaveChangesAsync();
    //                }
    //            }
    //            return RedirectToAction(nameof(StaffList));
    //        }

    //        // ----- Validation Check -----
    //        if (!ModelState.IsValid)
    //        {
    //            // Log validation errors (useful for debugging)
    //            foreach (var state in ModelState)
    //            {
    //                foreach (var error in state.Value.Errors)
    //                {
    //                    Console.WriteLine($"Property: {state.Key}, Error: {error.ErrorMessage}");
    //                }
    //            }

    //            // Re-populate dropdowns
    //            model.DepartmentList = GetDepartments();
    //            model.DesignationList = GetDesignations();
    //            model.MaritalStatusList = GetMaritalStatusList();
    //            return View(model);
    //        }

    //        // ----- Add -----
    //        if (model.StaffId == Guid.Empty)
    //        {
    //            var e = new Staffs
    //            {
    //                StaffId = Guid.NewGuid(),
    //                StaffName = model.StaffName,
    //                EMPStaffID = model.EMPStaffID,
    //                MobileNo = model.MobileNo,
    //                Email = model.Email,
    //                DOB = model.DOB,                   // Nullable safe
    //                Gender = model.Gender,
    //                MaritalStatus = model.MaritalStatus,
    //                BloodGroup = model.BloodGroup,
    //                JoiningDate = model.JoiningDate,   // Nullable safe
    //                WorkGroup = model.WorkGroup,
    //                Religion = model.Religion,
    //                Category = model.Category,
    //                Caste = model.Caste,
    //                SubCaste = model.SubCaste,
    //                HighestQualification = model.HighestQualification,
    //                DeptID = model.DeptID,
    //                DesignationID = model.DesignationID,
    //                Address = model.Address,
    //                Country = model.Country,
    //                State = model.State,
    //                City = model.City,
    //                Pincode = model.Pincode
    //            };

    //            await dbContext.MasterStaffDetails.AddAsync(e);
    //        }
    //        else
    //        {
    //            // ----- Update -----
    //            var e = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
    //            if (e == null) return NotFound();

    //            e.StaffName = model.StaffName;
    //            e.EMPStaffID = model.EMPStaffID;
    //            e.MobileNo = model.MobileNo;
    //            e.Email = model.Email;
    //            e.DOB = model.DOB;                   // Nullable safe
    //            e.Gender = model.Gender;
    //            e.MaritalStatus = model.MaritalStatus;
    //            e.BloodGroup = model.BloodGroup;
    //            e.JoiningDate = model.JoiningDate;   // Nullable safe
    //            e.WorkGroup = model.WorkGroup;
    //            e.Religion = model.Religion;
    //            e.Category = model.Category;
    //            e.Caste = model.Caste;
    //            e.SubCaste = model.SubCaste;
    //            e.HighestQualification = model.HighestQualification;
    //            e.DeptID = model.DeptID;
    //            e.DesignationID = model.DesignationID;
    //            e.Address = model.Address;
    //            e.Country = model.Country;
    //            e.State = model.State;
    //            e.City = model.City;
    //            e.Pincode = model.Pincode;
    //        }
    //        await dbContext.SaveChangesAsync();
    //        return RedirectToAction(nameof(StaffList));
    //    }

    //[HttpGet]
    //[Route("List")]
    //public async Task<IActionResult> StaffList()
    //{
    //    var staffList = await dbContext.MasterStaffDetails.AsNoTracking().ToListAsync();
    //    return View(staffList);   // View name: StaffList.cshtml (or change to "StaffRegister" if you keep your old file)
    //}

    //// ------- Shared Form (Add/Edit) - GET -------
    //[HttpGet]
    //[Route("Form/{id?}")]
    //public async Task<IActionResult> StaffForm(Guid? id)
    //{
    //    MasterStaff vm;
    //    if (id == null || id == Guid.Empty)
    //    {
    //        // Add mode
    //        vm = new MasterStaff();
    //    }
    //    else
    //    {
    //        // Edit mode
    //        var e = await dbContext.MasterStaffDetails.FindAsync(id.Value);
    //        if (e == null) return NotFound();

    //        vm = new MasterStaff
    //        {
    //            StaffId = e.StaffId,
    //            StaffName = e.StaffName,
    //            EMPStaffID = e.EMPStaffID,
    //            MobileNo = e.MobileNo,
    //            Email = e.Email,
    //            DOB = e.DOB,
    //            Gender = e.Gender,
    //            MaritalStatus = e.MaritalStatus,
    //            BloodGroup = e.BloodGroup,
    //            JoiningDate = e.JoiningDate,
    //            WorkGroup = e.WorkGroup,
    //            Religion = e.Religion,
    //            Category = e.Category,
    //            Caste = e.Caste,
    //            SubCaste = e.SubCaste,
    //            HighestQualification = e.HighestQualification,
    //            DeptID = e.DeptID,
    //            DesignationID = e.DesignationID,
    //            Address = e.Address,
    //            Country = e.Country,
    //            State = e.State,
    //            City = e.City,
    //            Pincode = e.Pincode,
    //        };
    //    }
    //    // dropdowns for both modes
    //    vm.DepartmentList = GetDepartments();
    //    vm.DesignationList = GetDesignations();
    //    vm.MaritalStatusList = GetMaritalStatusList();
    //    return View(vm); // View name: StaffForm.cshtml
    //}

    //// ------- Shared Form (Add/Edit/Delete) - POST -------
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //[Route("Form/{id?}")]
    //public async Task<IActionResult> StaffForm(MasterStaff model, string? command)
    //{
    //    // Handle Delete from the same form
    //    if (command == "Delete")
    //    {
    //        if (model.StaffId != Guid.Empty)
    //        {
    //            var toDel = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
    //            if (toDel != null)
    //            {
    //                dbContext.MasterStaffDetails.Remove(toDel);
    //                await dbContext.SaveChangesAsync();
    //            }
    //        }
    //        return RedirectToAction(nameof(StaffList));
    //    }
    //    // Validation failed → re-show with dropdowns
    //    if (!ModelState.IsValid)
    //    {
    //        model.DepartmentList = GetDepartments();
    //        model.DesignationList = GetDesignations();
    //        model.MaritalStatusList = GetMaritalStatusList();
    //        return View(model);
    //    }
    //    // Add
    //    if (model.StaffId == Guid.Empty)
    //    {
    //        var e = new Staffs
    //        {
    //            StaffId = Guid.NewGuid(),
    //            StaffName = model.StaffName,
    //            EMPStaffID = model.EMPStaffID,
    //            MobileNo = model.MobileNo,
    //            Email = model.Email,
    //            DOB = model.DOB,
    //            Gender = model.Gender,
    //            MaritalStatus = model.MaritalStatus,
    //            BloodGroup = model.BloodGroup,
    //            JoiningDate = model.JoiningDate,
    //            WorkGroup = model.WorkGroup,
    //            Religion = model.Religion,
    //            Category = model.Category,
    //            Caste = model.Caste,
    //            SubCaste = model.SubCaste,
    //            HighestQualification = model.HighestQualification,
    //            DeptID = model.DeptID,
    //            DesignationID = model.DesignationID,
    //            Address = model.Address,
    //            Country = model.Country,
    //            State = model.State,
    //            City = model.City,
    //            Pincode = model.Pincode,
    //        };
    //        dbContext.MasterStaffDetails.Add(e);
    //    }
    //    else
    //    {
    //        // Update
    //        var e = await dbContext.MasterStaffDetails.FindAsync(model.StaffId);
    //        if (e == null) return NotFound();
    //        e.StaffName = model.StaffName;
    //        e.EMPStaffID = model.EMPStaffID;
    //        e.MobileNo = model.MobileNo;
    //        e.Email = model.Email;
    //        e.DOB = model.DOB;
    //        e.Gender = model.Gender;
    //        e.MaritalStatus = model.MaritalStatus;
    //        e.BloodGroup = model.BloodGroup;
    //        e.JoiningDate = model.JoiningDate;
    //        e.WorkGroup = model.WorkGroup;
    //        e.Religion = model.Religion;
    //        e.Category = model.Category;
    //        e.Caste = model.Caste;
    //        e.SubCaste = model.SubCaste;
    //        e.HighestQualification = model.HighestQualification;
    //        e.DeptID = model.DeptID;
    //        e.DesignationID = model.DesignationID;
    //        e.Address = model.Address;
    //        e.Country = model.Country;
    //        e.State = model.State;
    //        e.City = model.City;
    //        e.Pincode = model.Pincode;

    //        dbContext.MasterStaffDetails.Update(e);
    //    }
    //    await dbContext.SaveChangesAsync();
    //    return RedirectToAction(nameof(StaffList));
    //}

    //// ------- Optional: delete directly from list (POST) -------
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //[Route("Delete/{id:guid}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    var e = await dbContext.MasterStaffDetails.FindAsync(id);
    //    if (e != null)
    //    {
    //        dbContext.MasterStaffDetails.Remove(e);
    //        await dbContext.SaveChangesAsync();
    //    }
    //    return RedirectToAction(nameof(StaffList));
    //}

