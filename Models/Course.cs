using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeesManagement.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [Display(Name = "Course:")]
        public string StudentClass { get; set; }
        public string Year { get; set; }
        public string Session { get; set; }
        public decimal TotalFees { get; set; }
        [Display(Name = "Registration Number")]
        public string RegId { get; set; }
        public Reg Reg { get; set; }
        public ICollection<Fees> Fees { get; set; }
    }
}
