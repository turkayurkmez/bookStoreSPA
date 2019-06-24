using BookStore.Core.Repository;
using BookStore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IList<Book>> GetAllEntitiesWithCriteria(Expression<Func<Book, bool>> criteria)
        {
            return await bookDbContext.Books
                         .Include(x => x.Author)
                         .Include(x => x.Categories)
                         .ThenInclude(x => x.Category)
                         .Where(criteria)
                         .ToListAsync();

        }

        public async Task<Book> GetEntityById(int id)
        {
            return await bookDbContext.Books.Include(x => x.Author)
                                            .Include(x => x.Categories)
                                            .ThenInclude(c => c.Category)
                                            .Where(b => b.BookId == id)
                                            .FirstOrDefaultAsync();
        }
    }
}
