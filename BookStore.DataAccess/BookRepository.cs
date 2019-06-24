using BookStore.Core.Repository;
using BookStore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace BookStore.DataAccess
{
    public class BookRepository : IRepository<Book>
    {
        private readonly BookDbContext bookDbContext;
        public BookRepository(BookDbContext dbContext)
        {
            bookDbContext = dbContext;
        }
        public async Task<IEnumerable<Book>> GetAllEntities()
        {
            return await bookDbContext.Books
                         .Include(x => x.Author)
                         .Include(x => x.Categories)
                         .ThenInclude(x => x.Category)
                         .ToListAsync();



        }
    }
}
