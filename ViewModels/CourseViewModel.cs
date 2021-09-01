using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;

namespace FeesManagement.ViewModels
{
    public class CourseViewModel
    {
        public string RollNo { get; set; }
        public string StudentName { get; set; }
        public Genders? Gender { get; set; }
        public string FatherName { get; set; }
        public string Categery { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public List<int> CourseId { get; set; }
    }
}
