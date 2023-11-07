using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class OrderStockProductRepository : ITblOrderstockProductRepository
    {
        InvoiceProjectContext db;
        public OrderStockProductRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }

        public void Addorderdproduct(TblorderStockProduct stockproduct)
        {
            db.TblorderStockProducts.Add(stockproduct);
            db.SaveChanges();
        }

        public void Deleteorderstockproduct(int orderstockproduct_id)
        {
            TblorderStockProduct order = db.TblorderStockProducts.Find(orderstockproduct_id);
            db.TblorderStockProducts.Remove(order);
            db.SaveChanges();
        }

        public List<OrderStock_ProductsModel> getorderdproducts()
        {
            List<OrderStock_ProductsModel> lst = new List<OrderStock_ProductsModel>();
            foreach (TblorderStockProduct i in db.TblorderStockProducts.ToList())
            {
                TblorderStock os = db.TblorderStocks.Find(i.OderStockId);
                Tblproduct p = db.Tblproducts.Find(i.ProductId);
             

                OrderStock_ProductsModel om = new OrderStock_ProductsModel()
                {
                    OrderStockProduct_id = i.OrderStockProductId,
                    order_product_Quantity = (int)i.OderProductQuantity,
                    Order_stock_id = os.OrderStockId,
                    Order_date = os.OderDate,
                    Product_id = p.ProductId,
                    Product_name = p.ProductName,
                    Unit_id = p.Unit.UnitId,
                    Unit_name = p.Unit.UnitName,

                };
                lst.Add(om);
            }
            return lst;
        }
        public List<OrderStock_ProductsModel> getallorderdproducts()
        {
            return getorderdproducts();
        }

        public List <OrderStock_ProductsModel>getorderproductbystockid(int order_id)
        {
           List< OrderStock_ProductsModel> model = new List<OrderStock_ProductsModel>();
            foreach(TblorderStockProduct p in db.TblorderStockProducts.ToList())
            {
                if(p.OderStockId == order_id)
                {
                    TblorderStock os = db.TblorderStocks.Find(p.OderStockId);
                    Tblproduct ps = db.Tblproducts.Find(p.ProductId);


                    OrderStock_ProductsModel om = new OrderStock_ProductsModel()
                    {
                        OrderStockProduct_id = p.OrderStockProductId,
                        order_product_Quantity = (int)p.OderProductQuantity,
                        Order_stock_id = (int)p.OderStockId,
                        Order_date = os.OderDate,
                        Product_id =(int)p.ProductId,
                        Product_name = ps.ProductName,
                      
                   
                    };
                    model.Add( om );
                }
            }
            return model;
          
        }
        public void Updateorderstockproduct(TblorderStockProduct stockproduct)
        {
            db.TblorderStockProducts.Update(stockproduct);
            db.SaveChanges();
        }

      
    }
}
