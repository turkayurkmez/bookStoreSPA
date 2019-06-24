using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Service.Models
{
    public class BookCategory
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Book Book { get; set; }
    }
}
