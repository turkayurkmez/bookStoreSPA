using BookStore.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookListViewModel>> GetBookLists();
    }
}
