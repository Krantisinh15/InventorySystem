using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace InvoiceProjectMVCCore.Controllers
{
    public class InvoiceController : Controller
    {
        InvoiceProjectContext db;
        ITblProductRepository productrepo;
        ITblRecivedStockProductRepository recivedstockproductrepo;
        ITblCustomerInvoiceRepository customerinvoicerepo;
        IinvoicePaymentRepository paymentrepo;
        public InvoiceController(InvoiceProjectContext db, ITblCustomerInvoiceRepository customerinvoicerepo, ITblProductRepository productrepo,
            ITblRecivedStockProductRepository recivedstockproductrepo, IinvoicePaymentRepository paymentrepo)
        {
            this.db = db;
            this.productrepo = productrepo;
            this.recivedstockproductrepo=recivedstockproductrepo;
            this.customerinvoicerepo = customerinvoicerepo;
            this.paymentrepo = paymentrepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InvoiceDetails()
        {
            return View();
        }
        public List<SelectListItem> GetCustomers()
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));

            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (Tblcustomer c in db.Tblcustomers.ToList())
            {
                if (userdata.User_id.Equals(c.UserId))
                {
                    lst.Add(new SelectListItem() { Text = c.CustomerName, Value = c.CustomerId.ToString() });
                }
            }
            return lst;
        }

        public List<SelectListItem> GetCategories()
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));

            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (Tblcategory l in db.Tblcategories.ToList())
            {
                if (userdata.User_id.Equals(l.UserId))
                {
                    lst.Add(new SelectListItem() { Text = l.Category, Value = l.CategoryId.ToString() });
                }
            }
            return lst;
        }

        public List<SelectListItem> GetSubCategoriebyid(int id)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));

            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (Tblsubcategory l in db.Tblsubcategories.ToList())
            {
                if (l.CategoryId == id && userdata.User_id.Equals(l.UserId))
                {
                    lst.Add(new SelectListItem() { Text = l.Subcategory, Value = l.SubcategoryId.ToString() });

                }
            }
            return lst;
        }
        public List<SelectListItem> GetProductbysubcategoryid(int id)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));

            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (Tblproduct l in db.Tblproducts.ToList())
            {
                if (l.SubcategoryId == id && userdata.User_id.Equals(l.UserId))
                {
                    lst.Add(new SelectListItem() { Text = l.ProductName, Value = l.ProductId.ToString() });

                }
            }
            return lst;
        }
        //public JsonResult GetProductdetailsbyid(int id)
        //{
        //   var s= productrepo.getproductbyid(id);
        //   return Json(s);


        //}

        public JsonResult GetProductdetailsbyid(int id)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));

            RecivedStock_ProductModel lst = new RecivedStock_ProductModel();
            foreach(TblrecivedStockProduct t in db.TblrecivedStockProducts.ToList())
            {
                if(t.ProductId== id && t.UserId==userdata.User_id) 
                {
                    Tblproduct p=db.Tblproducts.Find(t.ProductId);
                    RecivedStock_ProductModel model= new RecivedStock_ProductModel()
                    {
                        Product_id=p.ProductId,
                        product_name=p.ProductName,
                        RecivedProduct_quantity=(int)t.RecivedProductQuantity,
                        RecivedProduct_Rate=(float)t.RecivedProductRate,
                        Selling_rate=(float)p.SellingRate,
                        Tax=(float)p.Tax,
                        
                    };
                lst=model;
                }
              
            }

            return Json(lst);
        }

        [HttpPost]
        public JsonResult CustInvoice(TblcustomerInvoice c)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            c.UserId = userdata.User_id;
           float remainingamount = 0;
            foreach (TblinvoiceProduct t in c.TblinvoiceProducts.ToList())
            {
               foreach(TblrecivedStockProduct sp in db.TblrecivedStockProducts.ToList())
                {
                    if(t.ProductId== sp.ProductId)
                    {
                        remainingamount = (float)sp.RecivedProductQuantity - (float)t.PurchaseQuantity;
                        sp.RecivedProductQuantity = remainingamount;
                        recivedstockproductrepo.UpdateRecivedStockProduct(sp);
                    }
                  
                }
              
            }
            customerinvoicerepo.AddCustomerInvoice(c);
            return Json("Invoice Generated Successfully");
        }

        public List<Invoice> GetallInvoices()
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));

            List<Invoice> lst = new List<Invoice>();
            foreach(TblcustomerInvoice c in db.TblcustomerInvoices.ToList())
            {
                float totalamount = 0;
                float remainingamount = 0;
                float paidamount = 0;
                totalamount = (float)c.TotalAmount;

                foreach (InvoicePayment p in db.InvoicePayments)
                {
                    if (p.InvoiceId==c.InvoiceId)
                    {

                        paidamount +=(float) p.PaymentAmount;
                    }
                }
                remainingamount = totalamount - paidamount;

                string status = "";

                if(remainingamount==0)
                {
                    status = "Paid";
                }
                else if(remainingamount==totalamount)
                {
                    status = "Un paid";
                }

                else
                {
                    status = "Partial Paid";
                }
               
                Tblcustomer tc = db.Tblcustomers.Find(c.CustomerId);
                if(userdata.User_id==c.UserId)
                {
                    Invoice model = new Invoice()
                    {
                        Invoice_id=c.InvoiceId,
                     Customer_id=tc.CustomerId,
                      Customer_name=tc.CustomerName,
                      Invoice_date=c.InvoiceDate,
                      Total_Amount=totalamount,
                      Remaining_amount=remainingamount,
                      Paid_Amount=paidamount,
                      status=status,
                    };
                    ViewBag.totalamount = totalamount;
                    ViewBag.remainingamount = remainingamount;
                    ViewBag.paidamount = paidamount;
                    lst.Add(model);
                }
                
            }
            
            return lst;
        }

        public IActionResult PaymentInvoice(int id)
        {
            Invoice lst = GetallInvoices().FirstOrDefault(e => e.Invoice_id == id);
            InvoicePayment p = new InvoicePayment()
            {
                InvoiceId = lst.Invoice_id,

            };
            ViewBag.Invoicedetails = lst;
          
            return View(lst);
        }
        [HttpPost]
        public JsonResult AddPayment(InvoicePayment p)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            p.UserId = userdata.User_id;
            paymentrepo.AddPayment(p);
            return Json("Payment Sucessfully");

        }

        public JsonResult getpaymentdetailsbyinvoiceid(int id)
        {
            List< InvoicePaymentModel> lst = new List<InvoicePaymentModel>();

            foreach(InvoicePayment p in db.InvoicePayments)
            {
                if(p.InvoiceId==id)
                {
                    InvoicePaymentModel model = new InvoicePaymentModel()
                    {
                        Payment_date=p.PaymentDate,
                        Payment_Amount=(float)p.PaymentAmount,
                        Payment_mode=p.PaymentMode,
                        Payment_description=p.PaymentDescription,

                    };
                    lst.Add(model);
                }
            }
            return Json(lst);

        }

        public List<customerpurchasehistory> GetAllInvoiceProductbycustomerid(int id)
        {
            List<customerpurchasehistory> lst = new List<customerpurchasehistory>();
            List<Invoice> lst1 = new List<Invoice>();
            List<InvoiceProductModel> lst2 = new List<InvoiceProductModel>();
            foreach (var i in GetallInvoices().ToList())
            {


                if (i.Customer_id == id)
                {
                    Invoice model = new Invoice()
                    {
                        Customer_id = i.Customer_id,
                        Invoice_id = i.Invoice_id,
                        Invoice_date = i.Invoice_date,
                        Total_Amount = i.Total_Amount,
                        Remaining_amount = i.Remaining_amount,
                        Paid_Amount = i.Paid_Amount,
                       
                    };
                    lst1.Add(model);
                }
            }
            foreach (TblinvoiceProduct iv in db.TblinvoiceProducts.ToList())
            {
                Tblproduct p = db.Tblproducts.Find(iv.ProductId);
                foreach (var v in lst1)
                {
                    if (v.Invoice_id == iv.InvoiceId)
                    {
                        InvoiceProductModel mod = new InvoiceProductModel()
                        {
                            Invoice_id = v.Invoice_id,
                            Product_id = (int)iv.ProductId,
                            Product_name = p.ProductName,
                            Purchase_Quantity = (int)iv.PurchaseQuantity,

                        };
                        lst2.Add(mod);
                    }
                }
            }foreach(Tblcustomer b in db.Tblcustomers.ToList())
            {
               if(b.CustomerId==id)
                {
                    customerpurchasehistory pur = new customerpurchasehistory()
                    {
                        InvoiceProductModel = lst2,
                        InvoiceModel = lst1,
                        customer_mail=b.EmailAddress,
                        customer_mobile_no=b.MobileNo,
                        Customer_name=b.CustomerName,
                    };
                    lst.Add(pur);
                }

            }

            return lst;
        }

    }
}
