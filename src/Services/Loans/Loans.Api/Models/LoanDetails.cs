using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Models
{
    public class LoanDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public int LoanTypeId { get; set; }

        [Required]
        public string LoanHolder { get; set; }

        [Required]
        public string LoanBranch { get; set; }

        [Required]
        public decimal LoanAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public bool IsActive { get; set; }

        public LoanTypes LoanTypes { get; set; }
    }
}
