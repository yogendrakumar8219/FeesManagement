using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;

namespace FeesManagement.ViewModels
{
    public class FeesCreateViewModel
    {
        public DateTime Tran_date { get; set; }
        public string RegId { get; set; }
        public int CourseId { get; set; }
        public decimal FeesDeposit { get; set; }
        public Reg Reg { get; set; }
        public Course Course { get; set; }
    }
}
