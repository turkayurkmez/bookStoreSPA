using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebAPI.Models
{
    public class BookListViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double? Rate { get; set; }
        public string CoverImagePath { get; set; }
        public byte[] CoverImage { get; set; }
        public AuthorModel Author { get; set; }
        public int AuthorId { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }

}
