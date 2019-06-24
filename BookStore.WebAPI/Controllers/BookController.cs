using BookStore.Service;
using BookStore.Service.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;
        public BookController(IBookService service)
        {
            this.service = service;
        }
        [EnableCors("Allow")]
        [HttpGet]
        public async Task<IEnumerable<BookListViewModel>> GetBooks()
        {
            return await service.GetBookLists();
        }


        [HttpGet("{id}")]
        public async Task<BookListViewModel> GetBook(int id)
        {
            return await service.GetBook(id);
         
           
        }
        //[HttpPost]
        //public async Task<ActionResult<Book>> AddBook(Book book)
        //{
        //    //bookDbContext.Books.Add(book);
        //    //await bookDbContext.SaveChangesAsync();
        //    //return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
        //    throw new NotImplementedException("");
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookListViewModel bookModel)
        {
            //Book book = bookModel.ConvertToBookFromModel();
            //if (id != book.BookId)
            //{
            //    return BadRequest();
            //}
            //var stateChanger = bookDbContext.Entry<Book>(book);
            //stateChanger.State = EntityState.Modified;
            //await bookDbContext.SaveChangesAsync();
            //return NoContent();
            throw new NotImplementedException("");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            throw new NotImplementedException("");
            //var item = await bookDbContext.Books.FindAsync(id);
            //if (item == null)
            //{
            //    return NotFound();
            //}
            //bookDbContext.Books.Remove(item);
            //await bookDbContext.SaveChangesAsync();
            //return NoContent();
        }


    }
}