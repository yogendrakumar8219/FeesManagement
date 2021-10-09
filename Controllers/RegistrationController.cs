
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;
using Microsoft.AspNetCore.Mvc;
using FeesManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace FeesManagement.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IFeesRepository _feesRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IRegRepository _regRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly AppDbContext _context;

        public RegistrationController(IFeesRepository feesRepository, IRegRepository regRepository, ICourseRepository courseRepository, IHostingEnvironment hostingEnvironment, AppDbContext context)
        {
            _regRepository = regRepository;
            _courseRepository = courseRepository;
            _feesRepository = feesRepository;
            this.hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        [HttpPost]
        public JsonResult GetRegDetail(string RegId)
        {
            Reg reg = _regRepository.GetReg(RegId);
            Reg newReg = new Reg
            {
                RegId = reg.RegId,
                RollNo = reg.RollNo,
                StudentName = reg.StudentName,
                Gender = reg.Gender,
                FatherName = reg.FatherName,
                Categery =  reg.Categery,
                Address = reg.Address,
                MobileNumber = reg.MobileNumber,
                Email = reg.Email
            };
            return Json(newReg);
            //FeesManagement.Models.Categerys.OBC
        }
        [HttpGet]
        public ViewResult Index()
        {
            var model = _regRepository.GetAllReg();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RegCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Reg newReg = new Reg
                {
                    RegId=model.RegId,
                    RollNo = model.RollNo,
                    StudentName = model.StudentName,
                    Gender = model.Gender,
                    FatherName = model.FatherName,
                    Categery = model.Categery,
                    Address = model.Address,
                    MobileNumber = model.MobileNumber,
                    Email = model.Email,
                    PhotoPath = uniqueFileName
                };
                _regRepository.Add(newReg);
                RedirectToAction("index");
            }
            return View();

        }

        private string ProcessUploadedFile(RegCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        [HttpGet]
        public ViewResult Edit(string RegId)
        {
            Reg reg = _regRepository.GetReg(RegId);

            RegEditViewModel regEditViewModel = new RegEditViewModel
            {
                RollNo = reg.RollNo,
                StudentName = reg.StudentName,
                Gender = reg.Gender,
                FatherName = reg.FatherName,
                Categery = reg.Categery,
                Address = reg.Address,
                MobileNumber = reg.MobileNumber,
                Email = reg.Email,
                ExistingPhotPath = reg.PhotoPath
            };
            return View(regEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(RegEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Reg reg = _regRepository.GetReg(model.RegId);
                reg.RollNo = model.RollNo;
                reg.StudentName = model.StudentName;
                reg.Gender = model.Gender;
                reg.FatherName = model.FatherName;
                reg.Categery = model.Categery;
                reg.Address = model.Address;
                reg.MobileNumber = model.MobileNumber;
                reg.Email = model.Email;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotPath);
                        System.IO.File.Delete(filePath);
                    }
                    reg.PhotoPath = ProcessUploadedFile(model);
                }
                Reg updateReg = _regRepository.Update(reg);
                return RedirectToAction("index");
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult Delete(string RegId)
        {
            Reg reg = _regRepository.GetReg(RegId.ToString());

            List<Fees> fees = _context.Feess.ToList();
            var _f = from f in fees
                    where f.RegId == RegId
                    select f;

            if (_f.Count() > 0)
            {
                int id = 0;
                Response.StatusCode = 404;
                foreach (var t in _f)
                {
                    id = t.FeesId;
                }
                ViewBag.ErrorTitle = "Registration Id is used";
                ViewBag.ErrorMessage = "The Reg Id  " + RegId + " is used in Fees " + id;
                return View("Error", id);
            }



            List<Course> courses = _context.Courses.ToList();
            var q = from c in courses
                    where c.RegId == RegId
                    select c;
            
            if(q.Count()>0)
            {
                int id=0;
                Response.StatusCode = 404;
                foreach (var t in q)
                {
                    id = t.CourseId;
                }
                ViewBag.ErrorTitle = "Registration Id is used";
                ViewBag.ErrorMessage = "The Reg Id  "+RegId+" is used in Course "+id;
                return View("Error", id);
            }

            if (reg == null)
            {
                Response.StatusCode = 404;
                return View("RegistrationNotFound", RegId.ToString());
            }
            else
            {
                try
                {
                    Reg deleteReg = _regRepository.Delete(reg.RegId);
                    if (reg.PhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", reg.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    return RedirectToAction("index");
                }
                catch(Exception ex)
                {

                }
                
            }
            return View("");
            
        }
    }
}
