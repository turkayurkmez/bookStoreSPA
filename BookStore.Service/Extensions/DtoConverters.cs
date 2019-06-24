﻿using BookStore.DataAccess.Models;
using BookStore.Service.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Service.Extensions
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
        public static List<CategoryListDto> ConvertToCategoryListDto(this ICollection<Category> categories)
        {
            List<CategoryListDto> categoryListDtos = new List<CategoryListDto>();
            categories.ToList().ForEach(x => categoryListDtos.Add(new CategoryListDto
            {
                Id = x.Id,
                Name = x.Name,
                SubCategoriesCount = x.SubCategories?.Count,
                TopCategoryId = x.TopCategoryId
            }));
            return categoryListDtos;
        }

        public static IEnumerable<BookListViewModel> ConvertToBookListViewModels(this IEnumerable<Book> books)
        {
            List<BookListViewModel> result = new List<BookListViewModel>();

            books.ToList().ForEach(x => result.Add(new BookListViewModel
            {
                BookId = x.BookId,
                CoverImage = x.CoverImage,
                CoverImagePath = x.CoverImagePath,
                Description = x.Description,
                Name = x.Name,
                Price = x.Price,
                Rate = x.Rate,
                Author = new AuthorModel { AuthorId = x.Author.AuthorId, FullName = x.Author.GetFullName },
                Categories = x.Categories?.Select(c => new CategoryModel
                {
                    CategoryId = c.CategoryId,
                    Name = c.Category.Name
                }).ToList()

            }));

            return result;


        }
    }
}