using BookStore.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebAPI.Extensions
{
    public static class DtoConverters
    {
        public static List<BookCategory> ConvertToBookCategoryList(this List<CategoryModel> categories)
        {
            List<BookCategory> bookCategories = new List<BookCategory>();
            categories.ForEach(c => bookCategories.Add(new BookCategory { CategoryId = c.CategoryId }));
            return bookCategories;
        }
        public static Book ConvertToBookFromModel(this BookListViewModel bookModel)
        {
            Book book = new Book
            {
                BookId = bookModel.BookId,
                AuthorId = bookModel.AuthorId,
                Categories = bookModel.Categories.ConvertToBookCategoryList(),
                CoverImage = bookModel.CoverImage,
                CoverImagePath = bookModel.CoverImagePath,
                Description = bookModel.Description,
                Name = bookModel.Name,
                Price = bookModel.Price,
                Rate = bookModel.Rate
            };

            return book;
        }
        public static List<CategoryListDto> ConvertToCategoryListDto(this ICollection<Category> categories )
        {
            List<CategoryListDto> categoryListDtos = new List<CategoryListDto>();
            categories.ToList().ForEach(x => categoryListDtos.Add(new CategoryListDto { Id = x.Id, Name = x.Name, SubCategoriesCount = x.SubCategories?.Count, TopCategoryId = x.TopCategoryId }));
            return categoryListDtos;
        }
    }
}
