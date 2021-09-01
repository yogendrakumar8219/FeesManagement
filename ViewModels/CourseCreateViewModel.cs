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
    public class CourseCreateViewModel
    {
        public string StudentClass { get; set; }
        public string Year { get; set; }
        public string Session { get; set; }
        public decimal TotalFees { get; set; }
        public string RegId { get; set; }
        public Reg Reg { get; set; }
    }
}
