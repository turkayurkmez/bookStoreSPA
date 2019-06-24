using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebAPI.Extensions;
using BookStore.WebAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookDbContext bookDbContext;
        public BookController(BookDbContext bookDbContext)
        {
            this.bookDbContext = bookDbContext;
        }
        [EnableCors("Allow")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookListViewModel>>> GetBooks()
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
                                      })
                                      .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookListViewModel>> GetBook(int id)
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
                                   }).Where(x => x.BookId == id).FirstOrDefaultAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            bookDbContext.Books.Add(book);
            await bookDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookListViewModel bookModel)
        {
            Book book = bookModel.ConvertToBookFromModel();
            if (id != book.BookId)
            {
                return BadRequest();
            }
            var stateChanger = bookDbContext.Entry<Book>(book);
            stateChanger.State = EntityState.Modified;
            await bookDbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var item = await bookDbContext.Books.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
           bookDbContext.Books.Remove(item);
            await bookDbContext.SaveChangesAsync();
            return NoContent();
        }


    }
}