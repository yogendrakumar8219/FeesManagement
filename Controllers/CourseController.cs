using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;
using FeesManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace FeesManagement.Controllers
{
        public class CourseController : Controller
        {
            private readonly ICourseRepository _courseRepository;
            private readonly IRegRepository _regRepository;
            private readonly IHostingEnvironment hostingEnvironment;
            private readonly AppDbContext _context;

            public CourseController(ICourseRepository courseRepository,IRegRepository regRepository, IHostingEnvironment hostingEnvironment, AppDbContext context)
            {
                _courseRepository = courseRepository;
                _regRepository = regRepository;
                this.hostingEnvironment = hostingEnvironment;
                _context = context;
        }

            public IActionResult Index()
            {
            var model = _courseRepository.GetAllCourse();
            return View(model);
            }

            [HttpPost]
            public JsonResult GetReg_with_CourseId_Detail(string RegId)
            {
                List<Reg> regs = _context.Regs.ToList();
                List<Course> courses = _context.Courses.ToList();
                var q = from r in regs
                        join c in courses on r.RegId equals c.RegId
                        where r.RegId == RegId
                        select new ViewModel
                        {
                            reg = r,
                            course = c
                        };

            CourseViewModel courseViewModel;
            foreach (var t in q)
            {
                courseViewModel = new CourseViewModel
                {
                    RollNo = t.reg.RollNo,
                    StudentName = t.reg.StudentName,
                    Gender = t.reg.Gender,
                    FatherName = t.reg.FatherName,
                    Categery = t.reg.Categery,
                    Address=t.reg.Address,
                    MobileNumber=t.reg.MobileNumber,
                    Email=t.reg.Email,
                    CourseId = (from c in _context.Courses.ToList()
                                where c.RegId == RegId
                                select c.CourseId).
                              ToList()

                };
                return Json(courseViewModel);
            }
            return Json("");

            }
        [HttpPost]
        public JsonResult Get_CourseId_Detail(int CourseId)
        {
            Course course = _courseRepository.GetCourse(CourseId);
            Course newCourse = new Course
            {
                StudentClass=course.StudentClass,
                Year=course.Year,
                Session=course.Session
            };
            return Json(newCourse);

        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course newCourse = new Course
                {
                    StudentClass = model.StudentClass,
                    Year = model.Year,
                    Session = model.Session,
                    TotalFees = model.TotalFees,
                    RegId = model.RegId
                };
                _courseRepository.Add(newCourse);
                return RedirectToAction("index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int CourseId)
        {
            List<Reg> regs = _context.Regs.ToList();
            List<Course> courses = _context.Courses.ToList();
            var q = from r in regs
                    join c in courses on r.RegId equals c.RegId
                    where c.CourseId == CourseId
                    select new ViewModel
                    {
                        reg = r,
                        course = c
                    };
            foreach (var t in q)
            {
                CourseEditViewModel courseEditViewModel = new CourseEditViewModel
                {
                    StudentClass = t.course.StudentClass,
                    Year = t.course.Year,
                    Session = t.course.Session,
                    TotalFees = t.course.TotalFees,
                    RegId = t.course.RegId,
                    StudentName = t.reg.StudentName,
                    FatherName = t.reg.FatherName
                };
                return View(courseEditViewModel);
            }
           return View();
        }
            [HttpPost]
            public IActionResult Edit(CourseEditViewModel model)
            {
                if (ModelState.IsValid)
                {
                    Course course = _courseRepository.GetCourse(model.CourseId);
                    course.StudentClass = model.StudentClass;
                    course.Year = model.Year;
                    course.Session = model.Session;
                    course.TotalFees = model.TotalFees;
                    course.RegId = model.RegId;

                    Course updateCourse = _courseRepository.Update(course);

                    return RedirectToAction("index");
                }
                return View(model);

            }
            [HttpPost]
            public IActionResult Delete(int CourseId)
            {
                Course course = _courseRepository.GetCourse(CourseId);
                if (course == null)
                {
                    Response.StatusCode = 404;
                    return View("CourseNotFound", CourseId);
                }
                Course deleteCourse = _courseRepository.Delete(course.CourseId);
                return RedirectToAction("index");
            }
        }
    }
