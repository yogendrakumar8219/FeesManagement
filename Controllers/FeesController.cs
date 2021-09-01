using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;
using FeesManagement.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FeesManagement.Controllers
{
    public class FeesController : Controller
    {
        private readonly IFeesRepository _feesRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IRegRepository _regRepository;
        private readonly AppDbContext _context;

        public FeesController(ICourseRepository courseRepository, IFeesRepository feesRepository, IRegRepository regRepository, AppDbContext context)
        {
            _courseRepository = courseRepository;
            _regRepository = regRepository;
            _feesRepository = feesRepository;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _feesRepository.GetAllFees();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FeesCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Fees newFees = new Fees
                {
                    Tran_date=model.Tran_date,
                    CourseId=model.CourseId,
                    RegId = model.RegId,
                    FeesDeposit=model.FeesDeposit,
                };
                _feesRepository.Add(newFees);
                return RedirectToAction("index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int FeesId,string RegId)
        {
            List<Reg> regs = _context.Regs.ToList();
            List<Course> courses = _context.Courses.ToList();
            List<Fees> feess = _context.Feess.ToList();
            var q = from r in regs
                    join c in courses on r.RegId equals c.RegId
                    join f in feess on c.CourseId equals f.CourseId
                    where f.FeesId == FeesId
                    select new ViewModel
                    {
                        reg = r,
                        course = c,
                        fees=f
                    };


            foreach (var t in q)
            {
                FeesEditViewModel feesEditViewModel = new FeesEditViewModel
                {
                    RollNo = t.reg.RollNo,
                    StudentName = t.reg.StudentName,
                    Gender = t.reg.Gender,
                    FatherName = t.reg.FatherName,
                    Categery = t.reg.Categery,
                    Address = t.reg.Address,
                    MobileNumber = t.reg.MobileNumber,
                    Email=t.reg.Email,
                    Tran_date =t.fees.Tran_date,
                    RegId = t.fees.RegId,
                    CourseId=t.fees.CourseId,
                    FeesId=t.fees.FeesId,
                    FeesDeposit=t.fees.FeesDeposit,
                    StudentClass=t.course.StudentClass,
                    Year=t.course.Year,
                    Session=t.course.Session,
                    CourseIdList= (from c in _context.Courses.ToList()
                                   where c.RegId == RegId
                                   select c.CourseId).ToList()
            };
                return View(feesEditViewModel);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(FeesEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Fees fees = _feesRepository.GetFees(model.FeesId);
                fees.Tran_date = model.Tran_date;
                fees.RegId = model.RegId;
                fees.CourseId = model.CourseId;
                fees.FeesDeposit = model.FeesDeposit;

                Fees updateFees = _feesRepository.Update(fees);

                return RedirectToAction("index");
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult Delete(int FeesId)
        {
            Fees fees = _feesRepository.GetFees(FeesId);
            if (fees == null)
            {
                Response.StatusCode = 404;
                return View("FeesNotFound", FeesId);
            }
            Fees deleteFees = _feesRepository.Delete(fees.FeesId);
            return RedirectToAction("index");
        }
    }
}
