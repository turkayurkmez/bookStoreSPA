using BookStore.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListDto>> GetCategoryLists();
        Task<IEnumerable<CategoryListDto>> GetAll();
    }
}
