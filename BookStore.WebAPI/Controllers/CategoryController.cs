using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Service;
using BookStore.WebAPI.Extensions;
using BookStore.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class CategoryController : ControllerBase
    //{
    //    //private BookDbContext dbContext;
    //    public CategoryController(BookDbContext bookDbContext)
    //    {
    //        dbContext = bookDbContext;
    //    }
    //    // GET: api/Category
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<CategoryListDto>>> Get()
    //    {
    //        var result = await dbContext.Categories.Include("SubCategories").Where(x => x.TopCategoryId == null).Select(c => new CategoryListDto { Id = c.Id, Name = c.Name, TopCategoryId = c.TopCategoryId, SubCategoriesCount = c.SubCategories.Count, Categories = c.SubCategories.ConvertToCategoryListDto() }).ToListAsync();

          
    //        return GetMenu(null, result);
           

    //    }
    //    List<CategoryListDto> menu = new List<CategoryListDto>();
    //    private ActionResult<IEnumerable<CategoryListDto>> GetMenu(CategoryListDto root, List<CategoryListDto> result)
    //    {
    //        foreach (var category in result)
    //        {

    //            var childCategories = dbContext.Categories.Include("SubCategories").Where(x => x.TopCategoryId == category.Id).Select(c => new CategoryListDto { Id = c.Id, Name = c.Name, TopCategoryId = c.TopCategoryId, SubCategoriesCount=c.SubCategories.Count }).ToList();
              
    //            if (category.SubCategoriesCount != null && category.SubCategoriesCount != 0)
    //            {
    //                category.Categories = new List<CategoryListDto>();
    //                GetMenu(category, childCategories);
    //            }
    //            if (root==null)
    //            {
    //                menu.Add(category);
    //            }
    //            else
    //            {
    //                root.Categories.Add(category);
    //            }

    //        }
    //        return menu;
    //    }

    //    private List<CategoryListDto> categoryListDtos;


    //    private List<CategoryListDto> GetChildCategories(CategoryListDto categoryListDto)
    //    {

    //        List<CategoryListDto> categoryListDtos = new List<CategoryListDto>();
    //        if (categoryListDto.SubCategoriesCount > 0)
    //        {
    //            var subCategories = dbContext.Categories.Include("SubCategories").Where(x => x.TopCategoryId == categoryListDto.Id).ToList();

    //            categoryListDto.Categories = subCategories.ConvertToCategoryListDto();
    //            foreach (var subCategory in categoryListDto.Categories)
    //            {

    //                GetChildCategories(subCategory);
    //            }

    //        }
    //        categoryListDtos.Add(categoryListDto);
    //        return categoryListDtos;

    //    }

    //    // GET: api/Category/5
    //    [HttpGet("{id}", Name = "Get")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST: api/Category
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT: api/Category/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE: api/ApiWithActions/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    //}
}
