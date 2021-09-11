using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public class Reg
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SNo { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(30, ErrorMessage = "Reg. Id cannot exceed 30 characters")]
        public string RegId { get; set; }
        
        [MaxLength(30,ErrorMessage ="Roll Number cannot exceed 30 characters")]
        public string RollNo { get; set; }
        
        [Required(ErrorMessage = "Please provide a value for Student Name field"), MaxLength(50, ErrorMessage = "Name cannot exceed 50 character")]
        public string StudentName { get; set; }
        
        [Required(ErrorMessage = "Please provide a value for Gender field"), MaxLength(10, ErrorMessage = "Gender cannot exceed 10 character")]
        public  Genders? Gender { get; set; }
        
        [Required(ErrorMessage = "Please provide a value for Father Name field"), MaxLength(50, ErrorMessage = "Father Name cannot exceed 50 character")]
        public string FatherName { get; set; }
        
        [Required, MaxLength(30, ErrorMessage = "Categery cannot exceed 50 character")]
        public string Categery { get; set; }
        
        [MaxLength(150, ErrorMessage = "Address cannot exceed 150 character")]
        public string Address { get; set; }
        
        [MaxLength(30, ErrorMessage = "Mobile Number cannot exceed 30 characters")]
        public string MobileNumber { get; set; }
        [MaxLength(50, ErrorMessage = "Email Address cannot exceed 50 character")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        
        public string PhotoPath { get; set; }
        public ICollection<Course> Course { get; set; }
        public ICollection<Fees> Fees { get; set; }
    }
}
