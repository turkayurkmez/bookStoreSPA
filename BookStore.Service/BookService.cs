using BookStore.Core.Repository;
using BookStore.DataAccess.Models;
using BookStore.Service.Dtos;
using BookStore.Service.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<BookListViewModel> AddBook(BookListViewModel book)
        {
            Book newBook = book.ConvertToBookFromModel();
            await bookRepository.Add(newBook);
            return await Task.Run(() => newBook.ConvertToBookListViewModel());

        }

        public async Task DeleteBook(int id)
        {
            Book book = await bookRepository.GetEntityById(id);
            await bookRepository.Remove(book);
        }

        public async Task<BookListViewModel> GetBook(int id)
        {
            BookListViewModel model = bookRepository.GetEntityById(id).Result.ConvertToBookListViewModel();
            return await Task.Run(() => model);
        }

        public async Task<IEnumerable<BookListViewModel>> GetBookLists()
        {
            IEnumerable<BookListViewModel> list = bookRepository.GetAllEntities().Result.ConvertToBookListViewModels();
            return await Task.Run(() => list);

        }

        public async Task UpdateBook(BookListViewModel bookModel)
        {
            Book book = bookModel.ConvertToBookFromModel();
            await bookRepository.Update(book);
        }
    }
}
