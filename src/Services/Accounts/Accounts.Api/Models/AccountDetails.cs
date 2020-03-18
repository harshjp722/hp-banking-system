using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Models
{
    public class AccountDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public int AccountTypeId { get; set; }

        [Required]
        public string AccountHolder { get; set; }

        [Required]
        public string AccountBranch { get; set; }

        [Required]
        public decimal AccountBalance { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public bool IsActive { get; set; }

        public AccountTypes AccountTypes { get; set; }
    }
}
