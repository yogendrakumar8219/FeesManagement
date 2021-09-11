using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.ViewModels;

namespace FeesManagement.Models
{
    public class ViewModel
    {
        public Reg reg { get; set; }
        public Course course { get; set; }
        public Fees fees { get; set; }
    }
}
