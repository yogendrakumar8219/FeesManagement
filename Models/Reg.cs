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
        public string RegId { get; set; }
        public string RollNo { get; set; }
        [Required(ErrorMessage = "Please provide a value for Name field"), MaxLength(50, ErrorMessage = "Name cannot exceed 50 character")]
        public string StudentName { get; set; }
        [Required]
        public  Genders? Gender { get; set; }
        public string FatherName { get; set; }
        [Required]
        public string Categery { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public ICollection<Course> Course { get; set; }
        public ICollection<Fees> Fees { get; set; }
    }
}
