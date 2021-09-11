using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;

namespace FeesManagement.ViewModels
{
    public class FeesCreateViewModel
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Tran_date { get; set; }
        public string RegId { get; set; }
        public int CourseId { get; set; }
        public decimal FeesDeposit { get; set; }
        public Reg Reg { get; set; }
        public Course Course { get; set; }
    }
}
