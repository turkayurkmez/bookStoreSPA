using BookStore.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookListViewModel>> GetBookLists();
        Task<BookListViewModel> GetBook(int id);
        Task<BookListViewModel> AddBook(BookListViewModel book);
        Task UpdateBook(BookListViewModel bookModel);
        Task DeleteBook(int id);
    }
}
