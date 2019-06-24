using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Repository
{
   public interface IRepository<T> where T :class
    {
      Task<IEnumerable<T>> GetAllEntities();

    }
}
