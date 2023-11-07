using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Tls;

namespace InvoiceProjectMVCCore.Controllers
{
    public class ProductController : Controller
    {
        ITblProductRepository productrepo;
        ITblSubCategoryRepository subcategoryrepo;
        ICategoryRepository categoryrepo;
        ItblUnitsRepository unitsrepo;
        InvoiceProjectContext db;
        public ProductController(ITblProductRepository productrepo, ITblSubCategoryRepository subcategoryrepo,
        ICategoryRepository categoryrepo, ItblUnitsRepository unitsrepo, InvoiceProjectContext db) 
        {
        this.productrepo = productrepo;
            this.subcategoryrepo = subcategoryrepo;
            this.categoryrepo = categoryrepo;
            this.unitsrepo = unitsrepo;
            this.db = db;

        }
        public IActionResult Index()
        {
            string userdata = (HttpContext.Session.GetString("Userdetails"));
            UserModel userd = JsonConvert.DeserializeObject<UserModel>(userdata);
            ViewBag.UserData = userd;


            return View();
        }
        public IActionResult GetallProducts()
        {
           
            return View();
        }

        public IActionResult GetallProductsByUserID(object allowGet)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            
            List<ProductModel> lst = new List<ProductModel>();
            foreach (Tblproduct p in db.Tblproducts.ToList())
            {
             
                if (userdata.User_id==p.UserId)
                {
                    return Json(productrepo.GetproductsbyuserID(userdata.User_id));
                }
             
            }
            return Json("");
           
        }

        [HttpPost]
       public ActionResult Addcategorybyuser(Tblcategory t)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            t.UserId = userdata.User_id;
            categoryrepo.AddCategory(t);
            return Json(t);
        }
        //public ActionResult GetCategories()
        //{
        //    var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));

        //    List<CategoryModel> lst = new List<CategoryModel>();
        //    foreach (Tblcategory l in db.Tblcategories.ToList())
        //    {
        //        if(userdata.User_id.Equals(l.UserId))
        //            {
        //          return Json (categoryrepo.GetCategories().ToList());
        //           }
            
        //    }
        //    return Json("");
        //}
       
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
            foreach(Tblsubcategory l in db.Tblsubcategories.ToList())
            {
                    if (l.CategoryId == id && userdata.User_id.Equals(l.UserId))
                    {
                        lst.Add(new SelectListItem() { Text = l.Subcategory, Value = l.SubcategoryId.ToString() });

                    }
            }
            return lst;
        }

        [HttpPost]
        public ActionResult AddSubcategorybyuser(Tblsubcategory s)
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            s.UserId = userdata.User_id;
            subcategoryrepo.AddSubcategory(s);
            return Json(s);
        }

        public List<SelectListItem> GetProductsbysubcategoryid(int id)
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
        public List<SelectListItem> GetUnits()
        {
            var userdata = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Userdetails"));
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (Tblunit u in db.Tblunits.ToList())
            {
                    lst.Add(new SelectListItem() { Text = u.UnitName, Value = u.UnitId.ToString() });

                
            }
            return lst;
        }
        [HttpPost]
        public ActionResult AddSubProduct(Tblproduct p)
        {
            productrepo.Addproduct(p);
            return Json(p);
        }

        public IActionResult Getcategoriesfortextbox(string term)
        {
            var filteredFruits = categoryrepo.GetCategories().Where(e => e.Category.Contains(term.ToLower()));
            return Json(filteredFruits);
        }

    }
}
