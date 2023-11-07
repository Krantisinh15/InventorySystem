using InvoiceProjectMVCCore.BL;
using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace InvoiceProjectMVCCore.Controllers
{
    public class CustomerController : Controller
    {
        InvoiceProjectContext db;
        ITblLocationRepository locationrepo;
        ITblCustomerRepository customerrepo;
        ITblCustomerInvoiceRepository customerinvoicerepo;
        IinvoiceProductRepository invoiceproductrepo;
        public CustomerController(InvoiceProjectContext db, ITblLocationRepository locationrepo, 
            ITblCustomerRepository customerrepo, ITblCustomerInvoiceRepository customerinvoicerepo, IinvoiceProductRepository invoiceproductrepo)
        {
            this.db = db;
            this.locationrepo = locationrepo;
            this.customerrepo = customerrepo;
            this.customerinvoicerepo = customerinvoicerepo;
            this.invoiceproductrepo = invoiceproductrepo;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public JsonResult GetAllCustomers()
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            List<CustomerModel> lst = new List<CustomerModel>();
            foreach (Tblcustomer c in db.Tblcustomers.ToList())
            {
                if (c.UserId.Equals(userdata.User_id))
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
            return Json(lst);
        }

        public List<SelectListItem> Getlocations()
        {

            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (Tbllocation l in db.Tbllocations.ToList())
            {
                lst.Add(new SelectListItem() { Text = l.Location, Value = l.LocationId.ToString() });
            }
            return lst;
        }
        [HttpPost]
        public ActionResult AddCustomer(Tblcustomer c, object AllowGet)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            c.UserId = userdata.User_id;
            customerrepo.AddCustomer(c);
            //string msg = "<h2>Dear " + c.CustomerName + "</h2>,<p> Welcome to The Ysaas Inventory System..</p><p>From OnWord Your Visit code for Our System Will .</p><p>Customer ID:<b>" + c.CustomerId +  "</b><br/></p><p><br/><br/><br/><br/><br/><h4>Thanks & Regards</h4><h4>Ysaas Inventory System</h4></p>";
            //string subject = "Customer Registration";
            //// ExtraBl.Send_Email(c.EmailAddress, subject, msg);
            //try
            //{
            //    ExtraBl.Send_Email(c.EmailAddress, subject, msg);
            //}
            //catch (Exception ex)
            //{
            //    // Log or display the error message
            //    Console.WriteLine("Error sending email: " + ex.Message);
            //}
            return Json("Customer Added Sucessfully");
        }

        public JsonResult Getcustomerid(int id)
        {
            Tblcustomer c = db.Tblcustomers.Find(id);

            return Json(c);
        }
        [HttpPost]
        public string UpdateCus(Tblcustomer c)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            c.UserId = userdata.User_id;
            customerrepo.UpdateCustomer(c);
            return "Customer update successfully";
        }

        public ActionResult CustomerDelete(int id)
        {
            customerrepo.DeleteCustomer(id);
            return Json("");
        }

        public IActionResult GetcustomerHistory()
        {

            return View();
        }

        [HttpGet]
        public JsonResult Getinvoicehistorybycustomerid(int id)
        {

            return Json(invoiceproductrepo.GetAllInvoiceProductbycustomerid(id));


        }
        public IActionResult GetcustomerinvoiceHistory(int id)
        {
            ViewBag.invoice_id = id;
            return View();

        }

        public IActionResult CustomerInfo()
        {
            return View();
        }

    }
}
