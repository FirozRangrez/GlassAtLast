using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlassProject.Models;
using System.Web.Security;
using static GlassProject.Filter;

namespace GlassProject.Controllers
{
    public class AccountController : Controller
    {
        private List<string> StateList = new List<String>() 
            { 
            "Andhra Pradesh",
             "Arunachal Pradesh",
             "Assam",
             "Bihar",
             "Chhattisgarh",
             "Goa",
             "Gujarat",
             "Haryana",
             "Himachal Pradesh",
             "Jammu and Kashmir",
             "Jharkhand",
             "Karnataka",
             "Kerala",
             "Madhya Pradesh",
             "Maharashtra",
             "Manipur",
             "Meghalaya",
             "Mizoram",
             "Nagaland",
             "Odisha",
             "Punjab",
             "Rajasthan",
             "Sikkim",
             "Tamil Nadu",
             "Telangana",
             "Tripura",
             "Uttar Pradesh",
             "Uttarakhand",
             "West Bengal"
            };
        AddCustomer repository = null;
        public AccountController()
        {
            repository = new AddCustomer();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            var Name = (from u in new GlassDatabaseEntities().GlassCustomerSignup
                        where u.Mail == model.LoginEmailAddress
                        select u.Name).FirstOrDefault();
            Session["Name"] = Name;
            var id = (from u in new GlassDatabaseEntities().GlassCustomerSignup
                      where u.Mail == model.LoginEmailAddress
                      select u.id).FirstOrDefault();
            Session["Id"] = id;

            var Mail = (from u in new GlassDatabaseEntities().GlassCustomerSignup
                        where u.Mail == model.LoginEmailAddress
                        select model.LoginEmailAddress).FirstOrDefault();
            Session["Mail"] = Mail;
            using (var context = new GlassDatabaseEntities())
            {
                bool isValid = context.GlassCustomerSignup.Any(x => x.Mail == model.LoginEmailAddress && x.Password == model.LoginPassword);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.LoginEmailAddress, false);
                    return RedirectToAction("Index", "Home",Session["Id"]);
                }
                else 
                {
                    ModelState.AddModelError("", "Inavlid UserName or Password");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            ViewBag.list = StateList;
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUp model)
        {
            if (ModelState.IsValid)
            {
                var Name = (from u in new GlassDatabaseEntities().GlassCustomerSignup
                                where u.Mail == model.MMail
                                select model.MMail).FirstOrDefault();

                var Phone = (from u in new GlassDatabaseEntities().GlassCustomerSignup
                            where u.PhoneNum == model.MMobileNumber
                            select model.MMobileNumber).FirstOrDefault();


                if (Name == model.MMail)
                {
                    ViewBag.Mail = "Mail is already occupied";
                    ViewBag.list = StateList;
                    return View();
                }
                else
                {
                    if (Phone == model.MMobileNumber) 
                    {
                        ViewBag.Mobile = "Mobile number is already occupied";
                        ViewBag.list = StateList;
                        return View();

                    }

                    int id = repository.Addcustomer(model);
                    if (id > 0)
                    {
                        ModelState.Clear();
                        return RedirectToAction("Login");
                    }
                }
            }
            ViewBag.list = StateList;
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //return Redirect(Request.UrlReferrer.PathAndQuery);
            return RedirectToAction("Login");
        }
        public ActionResult BuynowBypass(int id) 
        {
            Session["Buynow"] = id;
            return RedirectToAction("Buynow");
        }
        public ActionResult BuyNow()
        {
            int id = int.Parse(Session["Buynow"].ToString());
            if ((int)Session["Id"] == id)
            {
                var cus = repository.Details(id);
                ViewBag.list = StateList;
                return View(cus);
            }
            else
            {
                return RedirectToAction("Logout");
            }
        }
        [Authorize]
        [NoDirectAccess]
        public ActionResult Details(SignUp model)
        {
            if ((int)Session["Id"] == model.id)
            {
                var cus = repository.Details(model.id);
                ViewBag.list = StateList;
                return View(cus);
            }
            else 
            {
                return RedirectToAction("Logout");
            }
        }
        public JsonResult Addproduct(Product model,SignUp s) 
        {
            repository.AddProduct(model);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}