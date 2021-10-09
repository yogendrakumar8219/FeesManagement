using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FeesManagement.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeesManagement.ViewModels
{
    public class RegCreateViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(30, ErrorMessage = "Reg. Id cannot exceed 30 characters")]
        public string RegId { get; set; }

        [MaxLength(30, ErrorMessage = "Roll Number cannot exceed 30 characters")]
        public string RollNo { get; set; }

        [Required(ErrorMessage = "Please provide a value for Student Name field"), MaxLength(50, ErrorMessage = "Name cannot exceed 50 character")]
        public string StudentName { get; set; }

        public Genders? Gender { get; set; }

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
        public IFormFile Photo { get; set; }
    }
}
