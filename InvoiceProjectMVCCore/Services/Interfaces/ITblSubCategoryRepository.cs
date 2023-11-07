using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblSubCategoryRepository
    {
        List<SubCategoryModel> getallsubcategory();
        SubCategoryModel getsubcategory(int subcategory_id);
        void AddSubcategory(Tblsubcategory subcategory);
        void UpdateSubcategory(Tblsubcategory subcategory);
        void DeleteSubcategory(int subcategory_id);

       
    }
}
