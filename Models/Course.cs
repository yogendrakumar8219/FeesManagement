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
        [Required(ErrorMessage = "Please provide a value for Student Class field"), MaxLength(50, ErrorMessage = "Student Class cannot exceed 50 character")]
        public string StudentClass { get; set; }
        
        [Required(ErrorMessage = "Please provide a value for Year field"), MaxLength(5, ErrorMessage = "Year cannot exceed 5 character")]
        public string Year { get; set; }
        
        [Required(ErrorMessage = "Please provide a value for Session field"), MaxLength(7, ErrorMessage = "Session cannot exceed 7 character")]
        public string Session { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal TotalFees { get; set; }
        
        [Display(Name = "Registration Number")]
        [Required,MaxLength(30, ErrorMessage = "Reg. Id cannot exceed 30 characters")]
        public string RegId { get; set; }
        public Reg Reg { get; set; }
        public ICollection<Fees> Fees { get; set; }
    }
}
