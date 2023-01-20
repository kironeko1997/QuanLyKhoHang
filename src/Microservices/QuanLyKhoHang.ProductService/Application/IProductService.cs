using QuanLyKhoHang.ProductService.Domain;
using QuanLyKhoHang.ProductService.Models;

namespace QuanLyKhoHang.ProductService.Application
{
    public interface IProductService
    {
        List<Product> GetAll(ProductSearchModel? searchModel);

        Product? Get(int id);

        Product Create(Product product);

        Product Update(Product product);

        void Delete(Product product);
    }
}
