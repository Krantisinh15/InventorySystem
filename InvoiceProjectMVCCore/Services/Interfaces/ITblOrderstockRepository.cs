using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblOrderstockRepository
    {
        List<OrderStockModel> GetallStockorders(int user_id);
        //OrderStockModel getorderstockbyid(int stockorder_id);
        void AddOrderStock(TblorderStock stockorder);
        void UpdateOrderStock(TblorderStock stockorder);
        void DeleteOrderStock(int stockorder_id);

    }
}
