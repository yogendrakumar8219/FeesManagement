using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;
using FeesManagement.ViewModels;

namespace FeesManagement.Models
{
    public class SQLCourseRepository : ICourseRepository
    {
        private readonly AppDbContext context;
        public SQLCourseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Course Add(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }
        public Course Delete(int CourseId)
        {
            Course course = context.Courses.Find(CourseId);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
            return course;
        }
        
        public IEnumerable<ViewModel> GetAllCourse()
        {
            List<Reg> regs = context.Regs.ToList();
            List<Course> courses = context.Courses.ToList();

            var q = from r in regs
                    join c in courses on r.RegId equals c.RegId
                    orderby c.RegId
                    select new ViewModel
                    {
                        reg = r,
                        course = c
                    };
            return (q);
        }
        
        
        public Course GetCourse(int CourseId)
        {
            return context.Courses.Find(CourseId);
        }
        public Course Update(Course courseChanges)
        {
            var course = context.Courses.Attach(courseChanges);
            course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return courseChanges;
        }
    }
}
