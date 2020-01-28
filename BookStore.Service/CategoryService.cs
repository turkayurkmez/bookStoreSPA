using BookStore.Core.Repository;
using BookStore.DataAccess.Models;
using BookStore.Service.Dtos;
using BookStore.Service.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repository;
        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<CategoryListDto>> GetCategoryLists()
        {
            List<CategoryListDto> list = repository.GetAllEntities().Result.ConvertToCategoryListDto();
            IEnumerable<CategoryListDto> actualList = GetMenu(null, list);
            return await Task.Run(() => actualList);

        }

        private readonly List<CategoryListDto> menu = new List<CategoryListDto>();

        private IEnumerable<CategoryListDto> GetMenu(CategoryListDto root, List<CategoryListDto> list)
        {
            foreach (CategoryListDto category in list)
            {

                List<CategoryListDto> childCategories = repository.GetAllEntitiesWithCriteria(x => x.TopCategoryId == category.Id).Result.ConvertToCategoryListDto();

                if (category.SubCategoriesCount != null && category.SubCategoriesCount != 0)
                {
                    category.Categories = new List<CategoryListDto>();
                    GetMenu(category, childCategories);
                }
                if (root == null)
                {
                    menu.Add(category);
                }
                else
                {
                    root.Categories.Add(category);
                }

            }
            return menu;
        }

        public async Task<IEnumerable<CategoryListDto>> GetAllCategories()
        {
            List<CategoryListDto> allCategories = repository.GetAllEntities().Result.ConvertToCategoryListDto();
            return await Task.Run(() => allCategories);

        }

        public async Task<IEnumerable<CategoryListDto>> GetAll()
        {
            List<CategoryListDto> allCategories = repository.GetAllEntities().Result.ConvertToCategoryListDto();
            return await Task.Run(() => allCategories);
        }
    }
}
