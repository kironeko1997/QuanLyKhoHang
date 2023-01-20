using QuanLyKhoHang.CategoryService.Domain;
using QuanLyKhoHang.CategoryService.Models;

namespace QuanLyKhoHang.CategoryService.Application
{
    public interface ICategoryService
    {
        List<Category> GetAll(CategorySearchModel? searchModel);

        Category? Get(int id);

        Category Create(Category category);

        Category Update(Category category);

        void Delete(Category category);
    }
}
