using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Placement.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Placement.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly INotyfService _notyf;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(EmployeeDbContext employeeDbContext, INotyfService notyfService, IWebHostEnvironment webHostEnvironment)
        {
            _employeeDbContext = employeeDbContext;
            _notyf = notyfService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int ID)
        {
            if (ID != 0)
            {
                _notyf.Information("Edit Your Details Then Click on Confirm");
                var model = _employeeDbContext.Employee.FirstOrDefault(x => x.ID == ID);
                return View(model);
            }
            return View();

        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                model.ProfilePicture = uniqueFileName;
                var old_student_entries = _employeeDbContext.Employee.FirstOrDefault(e => e.ID == model.ID);
                _employeeDbContext.Entry(old_student_entries).CurrentValues.SetValues(model);
                _employeeDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            //_notyf.Information("Go To Homepage To Create Your New Account.", 10);
            var employee = _employeeDbContext.Employee.ToList();
            return View(employee);
        }

        public IActionResult CreateEmployee() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee model, Register email)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                // Save the unique file name (image path) in the database
                model.ProfilePicture = uniqueFileName;

                model.CreateDate = DateTime.Now;
                

                _employeeDbContext.Employee.Add(model);
                _employeeDbContext.SaveChanges();
                _notyf.Success("Your New Account Created Successfully");
                return RedirectToAction("Index");
            }
            return View(model);

        }
        private string UploadedFile(Employee model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
                
            }
            return uniqueFileName;
        }



        //private string UploadedFile(Employee model)
        //{
        //    string uniqueFileName = null;

        //    if (model.ProfileImage != null)
        //    {
        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.ProfileImage.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}

        [HttpGet]
        public IActionResult DeleteEmployee(int ID)
        {
            var model = _employeeDbContext.Employee.FirstOrDefault(x => x.ID == ID);
            _employeeDbContext.Employee.Remove(model);
            _notyf.Custom("Account Deleted", 5,"whitesmoke", "fa fa-trash");
            _employeeDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult YourProfile(int ID)
        {
            if (ID != 0)
            {
                var model = _employeeDbContext.Employee.FirstOrDefault(x => x.ID == ID);
                return View(model);
            }
            return View();
        }
    }
}
