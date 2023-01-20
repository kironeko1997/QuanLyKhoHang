using QuanLyKhoHang.CategoryService.Domain;
using QuanLyKhoHang.CategoryService.Models;

namespace QuanLyKhoHang.CategoryService.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryDbContext _categoryDbContext;

        public CategoryService(CategoryDbContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;
        }

        public List<Category> GetAll(CategorySearchModel? searchModel)
        {
            var categories = _categoryDbContext.Categories.ToList();

            if (searchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Filter))
                {
                    categories = categories.Where(x => x.Name.Trim().ToLower().Contains(searchModel.Filter.Trim().ToLower())).ToList();
                }

                if (searchModel.Active.HasValue)
                {
                    categories = categories.Where(x => x.Active == searchModel.Active.Value).ToList();
                }
            }

            return categories;
        }

        public Category? Get(int id)
        {
            return _categoryDbContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Category Create(Category category)
        {
            _categoryDbContext.Categories.Add(category);
            _categoryDbContext.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            _categoryDbContext.Categories.Update(category);
            _categoryDbContext.SaveChanges();
            return category;
        }

        public void Delete(Category category)
        {
            _categoryDbContext.Categories.Remove(category);
            _categoryDbContext.SaveChanges();
        }
    }
}
