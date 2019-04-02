using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteleqtCapture.Models
{
    public class Annuity
    {
        [Key]
        public string EntityId { get; set; }
        public string EntityFullName { get; set; }
        public double AnnuityAmount { get; set; }
        public DateTimeOffset AnniversaryDate { get; set; }
        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset RenewalDate { get; set; }

    }
}
