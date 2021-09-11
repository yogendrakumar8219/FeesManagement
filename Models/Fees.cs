using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FeesManagement.Models
{
    public class Fees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeesId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Tran_date { get; set; }

        [Required,MaxLength(30, ErrorMessage = "Reg. Id cannot exceed 30 characters")]
        public string RegId { get; set; }
        
        [Required]
        public int CourseId { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal FeesDeposit { get; set; }
        
        public Reg Reg { get; set; }
        public Course Course { get; set; }
    }
}
