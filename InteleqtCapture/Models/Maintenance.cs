using System;
using System.ComponentModel.DataAnnotations;

namespace InteleqtCapture.Models
{
    public class Maintenance
    {
        [Key]
        public string EntityId { get; set; }
        public string EntityFullName { get; set; }
        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset RenewalDate { get; set; }
        public string Product { get; set; }
        public string ProductCategory { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public int Value { get; set; }
    }
}
