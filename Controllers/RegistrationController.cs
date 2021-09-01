
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
        private readonly IRegRepository _regRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        
        public RegistrationController(IRegRepository regRepository, IHostingEnvironment hostingEnvironment)
        {
            _regRepository = regRepository;
            this.hostingEnvironment = hostingEnvironment;
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
            if (reg == null)
            {
                Response.StatusCode = 404;
                return View("RegNotFound", RegId.ToString());
            }
            if (reg.PhotoPath != null)
            {
                 string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", reg.PhotoPath);
                 System.IO.File.Delete(filePath);
            }
            Reg deleteReg = _regRepository.Delete(reg.RegId);
            return RedirectToAction("index");
        }
    }
}
