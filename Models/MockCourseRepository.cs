using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public class MockCourseRepository:ICourseRepository
    {
        private List<Course> _courseList;
        private List<Reg> _regList;
        public MockCourseRepository()
        {
            _courseList = new List<Course>()
            {
                new Course(){CourseId=1,StudentClass="BCA",Year="I",Session="2021-22",TotalFees=18925,RegId="19G121121"},
                new Course(){CourseId=1,StudentClass="BBA",Year="I",Session="2021-22",TotalFees=18925,RegId="18G121121"}
            };
            _regList = new List<Reg>()
            {
                new Reg(){SNo=1,RegId="19G121121",RollNo="101",StudentName="Pakhi",Gender=Genders.Female,FatherName="Yogendra Kumar",Categery="O.B.C",Address="House No.-227 South Bhopa Road, New Manadi Mzn",MobileNumber="9897505503",Email="yogendrakumar8219@gmail.com",PhotoPath=""},
                new Reg(){SNo=2,RegId="18G121121",RollNo="102",StudentName="Manu",Gender=Genders.Male,FatherName="Sanjay Kumar",Categery="O.B.C",Address="House No.-227 South Bhopa Road, New Manadi Mzn",MobileNumber="9897653676",Email="sanjaykumar@gmail.com",PhotoPath=""}
            };
        }

        public Course Add(Course course)
        {
            course.CourseId = _courseList.Max(e => e.CourseId) + 1;
            _courseList.Add(course);
            return course;
        }
        public IEnumerable<ViewModel> GetAllCourse()
        {
            List<Reg> regs = _regList;
            List<Course> courses = _courseList;

            var q = from r in regs
                    join c in courses on r.RegId equals c.RegId
                    orderby c.RegId
                    select new ViewModel
                    {
                        reg = r,
                        course = c
                    };
            return q;
        }
        public Course GetCourse(int CourseId)
        {
            return this._courseList.FirstOrDefault(e => e.CourseId == CourseId);
        }

        public Course Update(Course courseChanges)
        {
            Course course = _courseList.FirstOrDefault(e => e.CourseId == courseChanges.CourseId);
            if (course != null)
            {
                course.StudentClass = courseChanges.StudentClass;
                course.Year = courseChanges.Year;
                course.Session = courseChanges.Session;
                course.TotalFees = courseChanges.TotalFees;
                course.RegId = courseChanges.RegId;
            }
            return course;
        }

        public Course Delete(int CourseId)
        {
            Course course = _courseList.FirstOrDefault(e => e.CourseId == CourseId);
            if (course != null)
            {
                _courseList.Remove(course);
            }
            return course;
        }

    }
}
