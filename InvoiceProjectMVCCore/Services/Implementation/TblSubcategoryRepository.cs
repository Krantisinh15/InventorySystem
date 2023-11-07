using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblSubcategoryRepository : ITblSubCategoryRepository
    {
        InvoiceProjectContext db;
        public TblSubcategoryRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddSubcategory(Tblsubcategory subcategory)
        {
            db.Tblsubcategories.Add(subcategory);   
            db.SaveChanges();
        }

        public void DeleteSubcategory(int subcategory_id)
        {
           Tblsubcategory sub=db.Tblsubcategories.Find(subcategory_id);
            db.Tblsubcategories.Remove(sub);
            db.SaveChanges();
        }

        public List<SubCategoryModel> getallsubcategory()
        {
           List<SubCategoryModel>lst=new List<SubCategoryModel>();
            foreach (Tblsubcategory s in db.Tblsubcategories.ToList())
            {
                Tblcategory t = db.Tblcategories.Find(s.CategoryId);
                SubCategoryModel model = new SubCategoryModel()
                {
                    Subcategory_id=s.SubcategoryId,
                    Subcategory_name=s.Subcategory,
                    Category_id=t.CategoryId,
                    category_name=t.Category
                    
                };
                lst.Add(model);
            }
            return lst;
        }

        public SubCategoryModel getsubcategory(int subcategory_id)
        {
            SubCategoryModel model = getallsubcategory().FirstOrDefault(e => e.Subcategory_id.Equals(subcategory_id));
            return model;
        }        

        public void UpdateSubcategory(Tblsubcategory subcategory)
        {
           db.Tblsubcategories.Update(subcategory);
            db.SaveChanges();
        }
    }
}
