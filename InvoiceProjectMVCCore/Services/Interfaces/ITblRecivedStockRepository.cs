using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblRecivedStockRepository
    {
        List<RecivedStockModel> getallrecivedstock(int uid);
       // RecivedStockModel Recivedstockbyid(int recivedstock_id);

        void AddRecivedStock(TblrecivedStock recivedstock);
        void UpdateRecivedStock(TblrecivedStock recivedstock);
        void DeleteRecivedStock(int recivedstock_id);
    }
}
