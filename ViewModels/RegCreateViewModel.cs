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
        public string RegId { get; set; }
        public string RollNo { get; set; }
        [Required(ErrorMessage = "Please provide a value for Name field"), MaxLength(50, ErrorMessage = "Name cannot exceed 50 character")]
        public string StudentName { get; set; }
        [Required]
        public Genders? Gender { get; set; }
        public string FatherName { get; set; }
        [Required]
        public string Categery { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public IFormFile Photo { get; set; }
    }
}
