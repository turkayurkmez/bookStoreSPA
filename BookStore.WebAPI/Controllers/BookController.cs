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

        [EnableCors("Allow")]
        [HttpGet("{id}")]
        public async Task<BookListViewModel> GetBook(int id)
        {
            return await service.GetBook(id);


        }
        [EnableCors("Allow")]
        [HttpPost]
        public async Task<ActionResult<BookListViewModel>> AddBook(BookListViewModel book)
        {
            var addedBook = await service.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = addedBook.BookId }, addedBook);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromBody]BookListViewModel bookModel)
        {

            if (id != bookModel.BookId)
            {
                return BadRequest();
            }
            await service.UpdateBook(bookModel);
            return CreatedAtAction(nameof(GetBook),new { id = bookModel.BookId },bookModel);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var item = service.GetBook(id);
            if (item == null)
            {
                return NotFound();
            }
            await service.DeleteBook(id);
            return NoContent();

           
        }


    }
}