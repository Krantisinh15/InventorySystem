using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class InvoiceProductRepository : IinvoiceProductRepository
    {
        InvoiceProjectContext db;
        ITblCustomerInvoiceRepository custrepo;
        public InvoiceProductRepository(InvoiceProjectContext db, ITblCustomerInvoiceRepository custrepo)
        {
            this.db = db;
            this.custrepo = custrepo;
        }
        public void AddInvoiceProduct(TblinvoiceProduct product)
        {
           db.TblinvoiceProducts.Add(product);
            db.SaveChanges();
        }

        public void DeleteInvoiceProduct(int Invoiceproduct_Id)
        {
            TblinvoiceProduct invoice = db.TblinvoiceProducts.Find(Invoiceproduct_Id);
            db.TblinvoiceProducts.Remove(invoice);
            db.SaveChanges();
        }

        public List<InvoiceProductModel> GetInvoiceProduct()
        {
           List<InvoiceProductModel>lst=new List<InvoiceProductModel>();
            foreach(TblinvoiceProduct ip in db.TblinvoiceProducts.ToList())
            {
                TblcustomerInvoice ci = db.TblcustomerInvoices.Find(ip.InvoiceId);
                Tblproduct p = db.Tblproducts.Find(ip.ProductId);
                InvoiceProductModel em = new InvoiceProductModel()
                {
                   Invoice_Product_id=ip.InvoiceProductId,
                   Invoice_id=ci.InvoiceId,
                   Invoice_date=ci.InvoiceDate,
                   Product_id=p.ProductId,
                   Product_name=p.ProductName,
                   Unit_id=p.Unit.UnitId,
                   Unit_name=p.Unit.UnitName,
                   Purchase_Quantity=(float)ip.PurchaseQuantity,
                   Total_amount=(float)ci.TotalAmount,
                  
                };
                lst.Add(em);
            }
            return lst;
        }
        public List<InvoiceProductModel> GetAllInvoiceProduct()
        {
            return GetInvoiceProduct();
        }

        public InvoiceProductModel GetInvoiceProductbyid(int Invoiceproduct_id)
        {
            InvoiceProductModel model = GetInvoiceProduct().FirstOrDefault(e => e.Invoice_Product_id.Equals(Invoiceproduct_id));
            return model;
        }

        public void UpdateInvoiceProduct(TblinvoiceProduct product)
        {
            db.TblinvoiceProducts.Update(product);
            db.SaveChanges();
        }

      

        public List<customerpurchasehistory> GetAllInvoiceProductbycustomerid(int id)
        {
            List<customerpurchasehistory> lst = new List<customerpurchasehistory>();
            List<Invoice> lst1 = new List<Invoice>();
            List<InvoiceProductModel>lst2= new List<InvoiceProductModel>();
            foreach(var i in custrepo.GetAllCustomerInvoice().ToList())
            {


                if(i.Customer_id== id)
                {
                    Invoice model = new Invoice()
                    {
                        Customer_id = i.Customer_id,
                        Invoice_id = i.Invoice_id,
                        Invoice_date = i.Invoice_date,
                        Total_Amount = i.Total_Amount,
                        Remaining_amount=i.Remaining_Amount,
                        Paid_Amount=i.Paid,
                    };
                    lst1.Add(model);
                }
            }
            foreach(TblinvoiceProduct iv in db.TblinvoiceProducts.ToList())
            {
                Tblproduct p = db.Tblproducts.Find(iv.ProductId);
                foreach(var v in lst1)
                {
                    if(v.Invoice_id==iv.InvoiceId)
                    {
                        InvoiceProductModel mod = new InvoiceProductModel()
                        {
                            Invoice_id=v.Invoice_id,
                            Product_id=(int)iv.ProductId,
                            Product_name=p.ProductName,
                            Purchase_Quantity=(int)iv.PurchaseQuantity,

                        };
                        lst2.Add(mod);
                    }
                }
            }
          customerpurchasehistory pur= new customerpurchasehistory()
          {
              InvoiceProductModel=lst2,
              InvoiceModel=lst1,

          };
            lst.Add(pur);
            return lst;
        }

    }
}
