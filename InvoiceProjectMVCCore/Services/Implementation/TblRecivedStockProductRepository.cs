using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblRecivedStockProductRepository : ITblRecivedStockProductRepository
    {
        InvoiceProjectContext db;
        public TblRecivedStockProductRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddRecivedStockProduct(TblrecivedStockProduct recivedstockproduct)
        {
           db.TblrecivedStockProducts.Add(recivedstockproduct);
            db.SaveChanges();
        }

        public void DeleteRecivedStockProduct(int recivedproduct_id)
        {
            TblrecivedStockProduct ts= db.TblrecivedStockProducts.Find(recivedproduct_id);
            db.TblrecivedStockProducts.Remove(ts);
            db.SaveChanges();
        }

        public List<RecivedStock_ProductModel> GetAllRecivedStockProducts(int id)
        {
            List<RecivedStock_ProductModel> lst = new List<RecivedStock_ProductModel>();
            foreach (TblrecivedStockProduct t in db.TblrecivedStockProducts.ToList())
            {
                if(t.UserId==id)
                {
                    Tblproduct p = db.Tblproducts.Find(t.ProductId);
                    TblrecivedStock rs = db.TblrecivedStocks.Find(t.RecivedStockId);
                    Tblvender v = db.Tblvenders.Find(rs.VenderId);
                    RecivedStock_ProductModel model = new RecivedStock_ProductModel()
                    {
                        RecivedStockProduct_id = t.RecivedStockProductsId,
                        RecivedProduct_quantity = (float)t.RecivedProductQuantity,
                        RecivedProduct_Rate = (float)t.RecivedProductRate,
                        Product_id = p.ProductId,
                        product_name=p.ProductName,
                        RecivedStock_id = rs.RecivedStockId,
                        Vendor_id = v.VenderId,
                        Vendor_name = v.VenderName,
                        user_id = (int)t.UserId,



                    };
                    lst.Add(model);

                }
              
            }
            return lst;
        }

        public RecivedStock_ProductModel getrecivedproductbyid(int recivedproduct_id)
        {
            throw new NotImplementedException();
        }

        //public  RecivedStock_ProductModel getbysubcategory_id(int subid)
        //{
        //    List<RecivedStock_ProductModel> lst = new List<RecivedStock_ProductModel>();
        //    foreach(TblrecivedStockProduct t in db.TblrecivedStockProducts)
        //    {
        //        Tblproduct p = db.Tblproducts.Find(t.ProductId);

        //        if(p.SubcategoryId==subid )
        //        {
        //            RecivedStock_ProductModel model = new RecivedStock_ProductModel()
        //            {
        //                RecivedStockProduct_id = t.RecivedStockProductsId,
        //                Product_id = (int)t.ProductId,
        //                product_name = p.ProductName,
        //                RecivedProduct_quantity = (int)t.RecivedProductQuantity,
        //                RecivedProduct_Rate = (float)t.RecivedProductRate,
        //                Selling_rate = (float)p.SellingRate,
        //                Tax = (float)p.Tax,
        //            };
        //            lst.Add(model) ;

        //        }

        //    }
        //    return lst;

        //}

        //public RecivedStock_ProductModel getrecivedproductbyid(int recivedproduct_id)
        //{
        //    RecivedStock_ProductModel rp = GetAllRecivedStockProducts().FirstOrDefault(e => e.RecivedStockProduct_id.Equals(recivedproduct_id));
        //    return rp;
        //}

        public void UpdateRecivedStockProduct(TblrecivedStockProduct recivedstockproduct)
        {
           db.TblrecivedStockProducts.Update(recivedstockproduct);
            db.SaveChanges();
        }
    }
}
