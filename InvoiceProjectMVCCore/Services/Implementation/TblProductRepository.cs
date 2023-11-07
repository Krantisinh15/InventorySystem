using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblProductRepository : ITblProductRepository
    {
        InvoiceProjectContext db;
        public TblProductRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void Addproduct(Tblproduct product)
        {
            db.Tblproducts.Add(product);
            db.SaveChanges();
        }

        public void Deleteproduct(int product_id)
        {
           Tblproduct product= db.Tblproducts.Find(product_id);
            db.Tblproducts.Remove(product);
            db.SaveChanges();
        }

        public List<ProductModel> getallproducts()
        {
           List<ProductModel>lst=new List<ProductModel> ();
            foreach (Tblproduct t in db.Tblproducts.ToList())
            {
                Tblsubcategory sc = db.Tblsubcategories.Find(t.SubcategoryId);
                Tblcategory c = db.Tblcategories.Find(sc.CategoryId);
                Tblunit u = db.Tblunits.Find(t.UnitId);
                Tbluser user=db.Tblusers.Find(t.UserId);
                ProductModel model = new ProductModel()
                {
                    Product_id= t.ProductId,
                    Product_name=t.ProductName,
                    Selling_rate=(float)t.SellingRate,
                    Tax=(float)t.Tax,
                    Unit_id=u.UnitId,
                    Unit_name=u.UnitName,
                    Subcategory_id = sc.SubcategoryId,
                    Subcategory_name = sc.Subcategory,
                    category_id = c.CategoryId,
                    category_name = c.Category,
                    user_id =user.UserId,
                    user_name=user.UserName
                    
                };
                lst.Add(model);
            }
            return lst;
        }

        public ProductModel getproductbyid(int product_id)
        {
            ProductModel model=getallproducts().FirstOrDefault(e=>e.Product_id.Equals(product_id));
            return model;
        }

        public List<ProductModel> GetproductsbyuserID(int user_id)
        {
            List<ProductModel> lst = new List<ProductModel>();
            foreach(Tblproduct p in db.Tblproducts.ToList())
            {
                if(p.UserId.Equals(user_id))
                
                {

                    p.TblinvoiceProducts.Clear();
                    p.TblorderStockProducts.Clear();
                    p.TblrecivedStockProducts.Clear();
                    Tblsubcategory sc = db.Tblsubcategories.Find(p.SubcategoryId);
                    Tblcategory c = db.Tblcategories.Find(sc.CategoryId);
                    Tblunit u = db.Tblunits.Find(p.UnitId);
                    Tbluser user = db.Tblusers.Find(p.UserId);
                    

                    ProductModel model = new ProductModel()
                    {
                        Product_id = p.ProductId,
                        Product_name = p.ProductName,
                        Selling_rate = (float)p.SellingRate,
                        Tax = (float)p.Tax,
                        Unit_id = u.UnitId,
                        Unit_name = u.UnitName,
                        Subcategory_id = sc.SubcategoryId,
                        Subcategory_name = sc.Subcategory,
                        category_id = c.CategoryId,
                        category_name = c.Category,
                        user_id = user.UserId,
                        user_name = user.UserName

                    };
                    lst.Add(model);

                }
               

            }
            return lst;
        }

        public void Updateproduct(Tblproduct product)
        {
           db.Tblproducts.Update(product);
            db.SaveChanges();
        }



       
    }
}
