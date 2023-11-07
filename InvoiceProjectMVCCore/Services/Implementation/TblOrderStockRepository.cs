using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblOrderStockRepository : ITblOrderstockRepository
    {
        InvoiceProjectContext db;
        
        public TblOrderStockRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddOrderStock(TblorderStock stockorder)
        {
            db.TblorderStocks.Add(stockorder);
            db.SaveChanges();
        }

        public void DeleteOrderStock(int stockorder_id)
        {
            TblorderStock order=db.TblorderStocks.Find(stockorder_id);
            db.TblorderStocks.Remove(order);
            db.SaveChanges();
        }

        public List<OrderStockModel> GetallStockorders(int user_id)
        {
           List<OrderStockModel>lst=new List<OrderStockModel> ();
            foreach (TblorderStock s in db.TblorderStocks.ToList())
            {
               if(s.UserId== user_id)
                {
                    Tblvender v = db.Tblvenders.Find(s.VenderId);
                    OrderStockModel model = new OrderStockModel()
                    {
                        OrderStock_id = s.OrderStockId,
                        Order_date = s.OderDate,
                        User_id = (int)s.UserId,
                        Vender_id = v.VenderId,
                        Vender_mail = v.VenderName,
                        Vender_Mobile_number = v.MobileNo,
                        Vender_name = v.VenderName

                    };
                    lst.Add(model);
                }
              
            }
            return lst;
        }

        //public OrderStockModel getorderstockbyid(int stockorder_id)
        //{
        //    OrderStockModel model = GetallStockorders(int user_id).FirstOrDefault(e => e.OrderStock_id.Equals(stockorder_id));
        //    return model;
        //}

        public void UpdateOrderStock(TblorderStock stockorder)
        {
           db.TblorderStocks.Update(stockorder);
            db.SaveChanges();
        }
    }
}
