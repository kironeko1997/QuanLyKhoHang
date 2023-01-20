using Microsoft.AspNetCore.Mvc;
using QuanLyKhoHang.ProductService.Application;
using QuanLyKhoHang.ProductService.Domain;
using QuanLyKhoHang.ProductService.Models;

namespace QuanLyKhoHang.ProductService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll(ProductSearchModel searchModel)
        {
            var products = _productService.GetAll(searchModel);

            if (products.Count > 0)
            {
                return Ok(products);
            }
            else
            {
                return Ok("Product list empty or search not matches!");
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var product = _productService.Get(id);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest("Product not available or has been deleted!");
            }
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.Create(product);

            if (product.Id != 0)
            {
                return Ok("Product has been created successfully! Product id is: " + product.Id);
            }
            else
            {
                return BadRequest("Something wrong!");
            }
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _productService.Update(product);

            return Ok("Product has been updated successfully!");
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            _productService.Delete(product);

            return Ok("Product has been deleted successfully!");
        }
    }
}
