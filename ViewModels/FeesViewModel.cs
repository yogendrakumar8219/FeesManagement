using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;
namespace FeesManagement.ViewModels
{
    public class FeesViewModel
    {
        public string RegId { get; set; }
        public string RollNo { get; set; }
        public string StudentName { get; set; }
        public Genders? Gender { get; set; }
        public string FatherName { get; set; }
        public string Categery { get; set; }
        public string MobileNumber { get; set; }
        public decimal TotalFees { get; set; }
        public decimal Fees_Total { get;set; }
        public decimal Bal { get; set; }
    }
}

