using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.WebAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Yazar adı belirtilmelidir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş olamaz")]
        public string LastName { get; set; }
        [MaxLength]
        public string Biography { get; set; }
        [NotMapped]
        public string GetFullName { get { return Name + " " + LastName; } }
        public ICollection<Book> Books { get; set; }
    }
}
