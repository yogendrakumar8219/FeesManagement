using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeesManagement.Models
{
    public class Fees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeesId { get; set; }
        public DateTime Tran_date { get; set; }
        public string RegId { get; set; }
        public int CourseId { get; set; }
        public decimal FeesDeposit { get; set; }
        public Reg Reg { get; set; }
        public Course Course { get; set; }
    }
}
