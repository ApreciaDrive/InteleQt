using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteleqtCapture.Models
{
    public class Maintenance
    {
        [Key]
        public string EntityId { get; set; }
        public string EntityFullName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset RenewalDate { get; set; }
        public string Product { get; set; }
        public string ProductCategory { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public int Value { get; set; }
        public int YearlyMaintenance { get; set; }
        public string Item { get; set; }
    }
}
