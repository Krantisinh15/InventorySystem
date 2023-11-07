using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InvoiceProjectMVCCore.Controllers
{
    public class DashboardController : Controller
    {
        InvoiceProjectContext db;
        ITblProductRepository productrepo;
        public DashboardController(InvoiceProjectContext db, ITblProductRepository productrepo)
        {
            this.db = db;
            this.productrepo = productrepo;
        }

        public IActionResult Index()
        {
            string str = HttpContext.Session.GetString("Userdetails");
            UserModel st = JsonConvert.DeserializeObject<UserModel>(str);

            try
            {
                // var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
             
                if (st != null)
                {
                    List<CustomerModel> lst = new List<CustomerModel>();
                    foreach (Tblcustomer c in db.Tblcustomers.ToList())
                    {
                        if (c.UserId.Equals(st.User_id))
                        {
                            Tbllocation l = db.Tbllocations.Find(c.LocationId);
                            CustomerModel model = new CustomerModel()
                            {
                                Customer_id = c.CustomerId,
                                Customer_name = c.CustomerName,
                                Email_address = c.EmailAddress,
                                Mobile_No = c.MobileNo,
                                location_id = l.LocationId,
                                location_name = l.Location,
                                User_id = (int)c.UserId

                            };
                            lst.Add(model);
                        }
                    }
                 
                    var lst1 = productrepo.GetproductsbyuserID(st.User_id);
                    ViewBag.productcount = lst1.Count();
                    ViewBag.totalcustomer = lst.Count();

                    return View();
                }

            }
            catch (Exception e)
            {
               
            }

            return RedirectToAction("Login", "Login");


        }
       
    }
}
