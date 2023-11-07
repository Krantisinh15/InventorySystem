using Humanizer;
using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace InvoiceProjectMVCCore.Controllers
{
    public class MaintainStockController : Controller
    {
        ITblRecivedStockProductRepository recivedstock;
        InvoiceProjectContext db;
        ITblOrderstockRepository orderstock;
        ITblRecivedStockRepository recivedstockRepository;
        ITblOrderstockProductRepository orderstockproducts;
       
      
        public MaintainStockController(ITblRecivedStockProductRepository recivedstock, 
            InvoiceProjectContext db, ITblOrderstockRepository orderstock,
            ITblRecivedStockRepository recivedstockRepository, ITblOrderstockProductRepository orderstockproducts)
        {
            this.recivedstock = recivedstock;
            this.db = db;
            this.orderstock = orderstock;
            this.recivedstockRepository = recivedstockRepository;
          this.orderstockproducts = orderstockproducts;
          
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult AvailableStock()
        {        
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));   
                    return Json(recivedstock.GetAllRecivedStockProducts(userdata.User_id));

        }

        public List<SelectListItem> Getvenders()
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));

            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (Tblvender l in db.Tblvenders.ToList())
            {
                if (userdata.User_id.Equals(l.UserId))
                {
                    lst.Add(new SelectListItem() { Text = l.VenderName, Value = l.VenderId.ToString() });
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
        public IActionResult MaintainOrderStock()
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            var uid = userdata.User_id;
            if (userdata.User_id == uid)
            {
                var lst = orderstock.GetallStockorders(uid);
                ViewBag.totalorder = lst.Count;
              
            }

            return View();

        }

        public IActionResult MaintainReciveStock()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Orderproducts(TblorderStock o)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            o.UserId = userdata.User_id;
            orderstock.AddOrderStock(o);
            return Json("");
        }

        [HttpPost]
        public JsonResult ReciveStock(TblrecivedStock rs)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            rs.UserId = userdata.User_id;
          foreach(TblrecivedStockProduct p in rs.TblrecivedStockProducts.ToList())
            {
                p.UserId= userdata.User_id;
            }
          
            recivedstockRepository.AddRecivedStock(rs);
            return Json("");
        }

        public JsonResult getallorderhistory(int uid)
        {
            
          var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            uid= userdata.User_id;
            if(userdata.User_id== uid)
            {
               var lst=orderstock.GetallStockorders(uid);
                return Json(lst);
            }
            
            return Json("");
        }

        public JsonResult getproductbysid(int id)
        {
            var lst = orderstockproducts.getorderproductbystockid(id);
            ViewBag.orderdetail = lst;
            return Json(lst);
           
        }

        [HttpGet]
        public JsonResult Getreciveorder(int uid)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            uid = userdata.User_id;
            if(userdata.User_id== uid)
            {
                return Json(recivedstockRepository.getallrecivedstock(uid));
            }
            return Json("");
        }

     
        public JsonResult getdatewisedata(string startdate , string Enddate)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));

            List<OrderStockModel> lst = new List<OrderStockModel>();
            List<OrderStockModel> or = orderstock.GetallStockorders(userdata.User_id).ToList();
            string databaseDateFormat = "yyyy-MM-dd";
            //foreach( OrderStockModel ino in or)
            //{

            //DateTime startDate = DateTime.ParseExact(startdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //DateTime endDate = DateTime.ParseExact(Enddate, "yyyy-MM-dd", CultureInfo.InvariantCulture);  
            //DateTime Order_date = DateTime.ParseExact(ino.Order_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //    var filteredRecords = or
            //       .Where(or => DateTime.ParseExact(or.Order_date, databaseDateFormat, CultureInfo.InvariantCulture) >= startDate &&
            //                    DateTime.ParseExact(or.Order_date, databaseDateFormat, CultureInfo.InvariantCulture) <= endDate)
            //       .ToList();
            //    OrderStockModel mm = new OrderStockModel()
            //    {

            //    };
            //    lst.Add(filteredRecords.ToList());

            //}
            DateTime startDate = DateTime.ParseExact(startdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Enddate, "yyyy-MM-dd", CultureInfo.InvariantCulture);  
            foreach (OrderStockModel ino in or)
            {
                DateTime Order_date = DateTime.ParseExact(ino.Order_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);


                if (Order_date >= startDate && Order_date<= endDate)
                {                    OrderStockModel filteredRecord = new OrderStockModel
                    {
                       
                     OrderStock_id=ino.OrderStock_id,
                     Order_date=ino.Order_date,
                    
                    };

                    lst.Add(filteredRecord);
                }
            }


            return Json(lst);
        }


        
    }
}
