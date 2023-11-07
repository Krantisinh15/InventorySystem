using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblRecivedStockRepository : ITblRecivedStockRepository
    {
        InvoiceProjectContext db;
        public TblRecivedStockRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddRecivedStock(TblrecivedStock recivedstock)
        {
            db.TblrecivedStocks.Add(recivedstock);
            db.SaveChanges();
        }

        public void DeleteRecivedStock(int recivedstock_id)
        {
            TblrecivedStock res= db.TblrecivedStocks.Find(recivedstock_id);
            db.TblrecivedStocks.Remove(res);
            db.SaveChanges();
        }

        public List<RecivedStockModel> getallrecivedstock(int uid)
        {
            List<RecivedStockModel>lst=new List<RecivedStockModel>();

            foreach(TblrecivedStock r in db.TblrecivedStocks.ToList())
            {
                if(r.UserId == uid)
                {
                    Tblvender v = db.Tblvenders.Find(r.VenderId);

                    RecivedStockModel model = new RecivedStockModel()
                    {
                        RecivedStock_id = r.RecivedStockId,
                        Recived_date = r.RecivedDate,
                        User_id = (int)r.UserId,
                        Vendor_id = (int)r.VenderId,
                        Vendor_name = v.VenderName
                    };
                    lst.Add(model);
                }
              
            }
            return lst;
        }

        //public RecivedStockModel Recivedstockbyid(int recivedstock_id)
        //{
        //    RecivedStockModel model=getallrecivedstock(id).FirstOrDefault(e=>e.RecivedStock_id.Equals(recivedstock_id));
        //    return model;
        //}

        public void UpdateRecivedStock(TblrecivedStock recivedstock)
        {
            db.TblrecivedStocks.Update(recivedstock);
            db.SaveChanges();
        }
    }
}
