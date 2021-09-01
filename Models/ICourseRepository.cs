using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public interface ICourseRepository
    {
        Course GetCourse(int CourseId);
        IEnumerable<ViewModel> GetAllCourse();
        Course Add(Course reg);
        Course Update(Course reg);
        Course Delete(int CourseId);
    }
}
