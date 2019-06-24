using BookStore.Service.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public class BookService :IBookService
    {
        private BookDbContext bookDbContext;

        public BookService(BookDbContext bookDbContext)
        {
            this.bookDbContext = bookDbContext;
        }
        public async Task<IEnumerable<BookListViewModel>> GetBookLists()
        {
            return await bookDbContext.Books
                  .Include(x => x.Author)
                  .Include(x => x.Categories)
                  .ThenInclude(x => x.Book)
                  .Select(x => new BookListViewModel
                  {
                      BookId = x.BookId,
                      CoverImage = x.CoverImage,
                      CoverImagePath = x.CoverImagePath,
                      Description = x.Description,
                      Name = x.Name,
                      Price = x.Price,
                      Rate = x.Rate,
                      Author = new AuthorModel { AuthorId = x.Author.AuthorId, FullName = x.Author.GetFullName },
                      Categories = x.Categories.Select(c => new CategoryModel
                      {
                          CategoryId = c.CategoryId,
                          Name = c.Category.Name
                      }).ToList()
                  }).ToListAsync();
                 
        }

       
    }
}
