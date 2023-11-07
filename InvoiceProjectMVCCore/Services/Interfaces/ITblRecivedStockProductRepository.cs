using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblRecivedStockProductRepository
    {
        List<RecivedStock_ProductModel> GetAllRecivedStockProducts(int user_id);
       // RecivedStock_ProductModel getrecivedproductbyid(int recivedproduct_id);

        void AddRecivedStockProduct(TblrecivedStockProduct recivedstockproduct);
        void UpdateRecivedStockProduct(TblrecivedStockProduct recivedstockproduct);
        void DeleteRecivedStockProduct(int recivedproduct_id);

      
    }
}
