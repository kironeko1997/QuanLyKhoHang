using Microsoft.AspNetCore.Mvc;
using QuanLyKhoHang.CategoryService.Application;
using QuanLyKhoHang.CategoryService.Domain;
using QuanLyKhoHang.CategoryService.Models;

namespace QuanLyKhoHang.CategoryService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll(CategorySearchModel searchModel)
        {
            var categories = _categoryService.GetAll(searchModel);

            if (categories.Count > 0)
            {
                return Ok(categories);
            }
            else
            {
                return Ok("Category list empty or search not matches!");
            }            
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);

            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return BadRequest("Category not available or has been deleted!");
            }
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.Create(category);

            if (category.Id != 0)
            {
                return Ok("Category has been created successfully! Category id is: " + category.Id);
            }
            else
            {
                return BadRequest("Something wrong!");
            }
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            _categoryService.Update(category);

            return Ok("Category has been updated successfully!");
        }

        [HttpDelete]
        public IActionResult Delete(Category category)
        {
            _categoryService.Delete(category);

            return Ok("Category has been deleted successfully!");
        }
    }
}
