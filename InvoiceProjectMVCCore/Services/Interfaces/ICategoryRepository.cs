using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ICategoryRepository
    {
        public List<CategoryModel> GetCategories();
        public CategoryModel GetCategoryById(int id);
        void AddCategory(Tblcategory category);
        void UpdateCategory(Tblcategory category);
        public void DeleteCategory(int category_id);

    }
}
