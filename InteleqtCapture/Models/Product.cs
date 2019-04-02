using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InteleqtCapture.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
