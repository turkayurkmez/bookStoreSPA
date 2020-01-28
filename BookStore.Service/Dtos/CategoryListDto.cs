using System.Collections.Generic;

namespace BookStore.Service.Dtos
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryListDto> Categories { get; set; }

        public int? SubCategoriesCount { get; set; }
        public int? TopCategoryId { get; set; }
    }
}
