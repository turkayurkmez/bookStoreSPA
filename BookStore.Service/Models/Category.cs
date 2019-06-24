using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Service.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori adını belirtin")]
        public string Name { get; set; }
        public int? TopCategoryId { get; set; }
        public virtual Category TopCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<BookCategory> Books { get; set; }

    }
}
