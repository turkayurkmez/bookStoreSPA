using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebAPI.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public double? Rate { get; set; }
        public string CoverImagePath { get; set; }
        public byte[] CoverImage { get; set; }
        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<BookCategory> Categories { get; set; }
    }
}
