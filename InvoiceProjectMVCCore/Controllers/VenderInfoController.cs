using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace InvoiceProjectMVCCore.Controllers
{
    public class VenderInfoController : Controller
    {
        InvoiceProjectContext db;
        ITblVenderRepository venderrepo;
        public VenderInfoController(InvoiceProjectContext db, ITblVenderRepository venderrepo)
        {
            this.db = db;
            this.venderrepo = venderrepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult Getvenders(int id)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            id = userdata.User_id;
            foreach (Tblvender l in db.Tblvenders.ToList())
            {
                if (userdata.User_id.Equals(l.UserId))
                {
                    return Json(venderrepo.getallvender(id));
                }
            }
            return Json("");
        }
        public JsonResult Addvenderss(Tblvender v)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            v.UserId = userdata.User_id;
            venderrepo.Addvender(v);
            return Json("Vender Added Sucessfully");

        }
        [HttpPost]
        public JsonResult Updatevender(Tblvender v)
        
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            v.UserId = userdata.User_id;
            venderrepo.Updatevender(v);
            return Json("Vender Updated Sucessfully");
        }
        
        public JsonResult Deletevender(int id)
        {
            venderrepo.Deletevender(id);
            return Json("Vender Deleted Successfully");
        }
    }
}
