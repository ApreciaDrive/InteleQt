﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InteleqtCapture.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
