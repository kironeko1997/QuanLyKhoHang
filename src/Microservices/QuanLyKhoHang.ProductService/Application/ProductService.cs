using QuanLyKhoHang.CategoryService.Domain;
using QuanLyKhoHang.CategoryService;
using QuanLyKhoHang.ProductService.Domain;
using QuanLyKhoHang.ProductService.Models;

namespace QuanLyKhoHang.ProductService.Application
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _productDbContext;

        public ProductService(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public List<Product> GetAll(ProductSearchModel? searchModel)
        {
            var products = _productDbContext.Products.ToList();

            if (searchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Filter))
                {
                    products = products.Where(x => x.Name.Trim().ToLower().Contains(searchModel.Filter.Trim().ToLower())).ToList();
                }

                if (searchModel.CategoryId.HasValue && searchModel.CategoryId.Value != 0)
                {
                    products = products.Where(x => x.CategoryId == searchModel.CategoryId.Value).ToList();
                }

                if (searchModel.Active.HasValue)
                {
                    products = products.Where(x => x.Active == searchModel.Active.Value).ToList();
                }
            }

            return products;
        }

        public Product? Get(int id)
        {
            return _productDbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product Create(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            _productDbContext.Products.Update(product);
            _productDbContext.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            _productDbContext.Products.Remove(product);
            _productDbContext.SaveChanges();
        }
    }
}
