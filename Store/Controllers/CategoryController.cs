using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.DTOs.CategoryDTOs;
using Store.Repository.CategoryRepos;

namespace Store.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;
        public CategoryController(ICategoryService categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActiveCategories()
        {
            var result = await _categoryServices.getAllActive();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryServices.getAll();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDTO addCategoryDTO)
        {
            var errors = await _categoryServices.addCategory(addCategoryDTO);
            if (errors.IsValid != true)
                return BadRequest(errors);
            else
                return Ok(errors);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO categoryDTO)
        {
            var errors = await _categoryServices.updateCategory(categoryDTO);
            if (errors.IsValid != true)
                return BadRequest(errors);
            else
                return Ok(errors);
        }
        [HttpPut]
        public async Task<IActionResult> RemoveCategory(int Id)
        {
            var errors = await _categoryServices.removeCategory(Id);
            if (errors.IsValid != true)
                return BadRequest(errors);
            else
                return Ok(errors);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategoryFromDataBase(int Id)
        {
            var errors = await _categoryServices.removeCategoryFinally(Id);
            if (errors.IsValid != true)
                return BadRequest(errors);
            else
                return Ok(errors);
        }
    }
}

