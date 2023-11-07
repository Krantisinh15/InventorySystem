using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblCategoryRepository : ICategoryRepository
    {
        InvoiceProjectContext db;
        public TblCategoryRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddCategory(Tblcategory category)
        {
           db.Tblcategories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int category_id)
        {
           Tblcategory category = db.Tblcategories.Find(category_id);
            db.Tblcategories.Remove(category);
            db.SaveChanges();
        }

        public List<CategoryModel> GetCategories()
        {
           List<CategoryModel>lst=new List<CategoryModel>();
            foreach(Tblcategory c in db.Tblcategories.ToList())
            {
               
               
                CategoryModel cm = new CategoryModel()
                {
                    Category_id = c.CategoryId,
                    Category = c.Category,
                   
                };
                lst.Add(cm);
            }
            return lst;
        }
        public List<CategoryModel> GetAllCategories()
        {
            return GetCategories();
        }

        public CategoryModel GetCategoryById(int id)
        {
            CategoryModel category = GetCategories().FirstOrDefault(e => e.Category_id.Equals(id));
            return category;
        }

        public void UpdateCategory(Tblcategory category)
        {
           db.Tblcategories.Update(category);
            db.SaveChanges();
        }
    }
}
