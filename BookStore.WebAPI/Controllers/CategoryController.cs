using BookStore.Service;
using BookStore.Service.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: api/Category
        [EnableCors("Allow")]
        [HttpGet]
        public async Task<IEnumerable<CategoryListDto>> Get()
        {
            Task<IEnumerable<CategoryListDto>> result = categoryService.GetCategoryLists();
            return await result;
        }

        // GET: api/Category/5
        [Route("All")]
        [HttpGet]
        public async Task<IEnumerable<CategoryListDto>> All()
        {
            Task<IEnumerable<CategoryListDto>> result = categoryService.GetAll();
            return await result;
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
