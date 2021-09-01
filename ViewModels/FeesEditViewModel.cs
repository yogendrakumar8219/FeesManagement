using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;

namespace FeesManagement.ViewModels
{
    public class FeesEditViewModel
    {
        public int FeesId { get; set; }
        public DateTime Tran_date { get; set; }
        public string RegId { get; set; }
        public int CourseId { get; set; }
        public decimal FeesDeposit { get; set; }
        public string RollNo { get; set; }
        public string StudentName { get; set; }
        public Genders? Gender { get; set; }
        public string FatherName { get; set; }
        public string Categery { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string StudentClass { get; set; }
        public string Year { get; set; }
        public string Session { get; set; }
        public List<int> CourseIdList { get; set; }

    }
}
