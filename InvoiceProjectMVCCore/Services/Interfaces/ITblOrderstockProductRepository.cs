using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblOrderstockProductRepository
    {
        List<OrderStock_ProductsModel> getallorderdproducts();
        void Addorderdproduct(TblorderStockProduct stockproduct);
        void Updateorderstockproduct(TblorderStockProduct stockproduct);
        void Deleteorderstockproduct(int orderstockproduct_id);
        List<OrderStock_ProductsModel> getorderproductbystockid(int orderstockproduct_id );
    }
}
