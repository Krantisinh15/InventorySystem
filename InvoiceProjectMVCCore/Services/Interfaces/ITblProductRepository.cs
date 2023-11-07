using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblProductRepository
    {
        List<ProductModel> getallproducts();
        ProductModel getproductbyid(int product_id);
        void Addproduct(Tblproduct product);
        void Updateproduct(Tblproduct product);
        void Deleteproduct(int product_id);
        List<ProductModel> GetproductsbyuserID(int user_id);
    }
}
