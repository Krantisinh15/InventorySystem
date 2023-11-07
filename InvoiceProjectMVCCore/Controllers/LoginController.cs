using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InvoiceProjectMVCCore.Controllers
{
    public class LoginController : Controller
    {
        InvoiceProjectContext db;
        ITblUserRepository userrepo;
        public LoginController(ITblUserRepository userrepo, InvoiceProjectContext db)
        {
            this.db = db;
            this.userrepo = userrepo;
        }
        public IActionResult Login()
        
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult Login(Tbluser t)
        {
            Tbluser um = db.Tblusers.FirstOrDefault(e => e.UniqueCode.Equals(t.UniqueCode) && e.Password.Equals(t.Password));
            if (um != null)
            {
                //var userdetails = userrepo.Getallusers().ToList();
              UserModel userdetail = new UserModel() { User_id = um.UserId, Email_Address = um.EmailAddress, User_name = um.UserName,User_photo=um.UserPhoto };
                //HttpContext.Session.SetString("UniqueCode", um.UniqueCode);
                HttpContext.Session.SetString("Userdetails", JsonConvert.SerializeObject(userdetail));

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Login Credaintials";
                return View();
            }

        }
    }
}
