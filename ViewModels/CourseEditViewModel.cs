using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.ViewModels
{
    public class CourseEditViewModel:CourseCreateViewModel
    {
        public int CourseId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
    }
}
