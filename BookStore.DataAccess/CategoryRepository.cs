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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly BookDbContext bookDbContext;
        public CategoryRepository(BookDbContext bookDbContext)
        {
            this.bookDbContext = bookDbContext;
        }

        public Task<int> Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllEntities()
        {
            return await bookDbContext.Categories.Include("SubCategories").Where(x => x.TopCategoryId == null).ToListAsync();
        }

        public async Task<IList<Category>> GetAllEntitiesWithCriteria(Expression<Func<Category, bool>> criteria)
        {
            return await bookDbContext.Categories.Include("SubCategories").Where(criteria).ToListAsync();
        }

        public Task<Category> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
