using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Repository;
using BookStore.DataAccess.Models;
using BookStore.Service.Dtos;
using BookStore.Service.Extensions;

namespace BookStore.Service
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> repository;
        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<CategoryListDto>> GetCategoryLists()
        {
            var list = repository.GetAllEntities().Result.ConvertToCategoryListDto();
            IEnumerable<CategoryListDto> actualList = GetMenu(null, list); 
            return await Task.Run(() => actualList);

        }

        private List<CategoryListDto> menu = new List<CategoryListDto>();

        private IEnumerable<CategoryListDto> GetMenu(CategoryListDto root, List<CategoryListDto> list)
        {
            foreach (var category in list)
            {

                var childCategories = repository.GetAllEntitiesWithCriteria(x => x.TopCategoryId == category.Id).Result.ConvertToCategoryListDto();



                if (category.SubCategoriesCount != null && category.SubCategoriesCount != 0)
                {
                    category.Categories = new List<CategoryListDto>();
                    GetMenu(category,childCategories);
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

        public string GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
