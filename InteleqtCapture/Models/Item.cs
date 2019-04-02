using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteleqtCapture.Models
{
    public class Item
    {
        [NotMapped]
        private string _name;

        [Key]
        public int Id { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = string.IsNullOrEmpty(value) ? value.Trim() : value;
            }
        }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
