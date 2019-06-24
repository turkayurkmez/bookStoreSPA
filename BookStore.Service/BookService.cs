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
        public async Task<IEnumerable<BookListViewModel>> GetBookLists()
        {
            IEnumerable<BookListViewModel> list = bookRepository.GetAllEntities().Result.ConvertToBookListViewModels();
            return await Task.Run(() => list);



        }


    }
}
