using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GlassProject.Models;
using Newtonsoft.Json;
using static GlassProject.Filter;

namespace GlassProject.Controllers
{
    [NoDirectAccess]
    public class HomeController : Controller
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
        public HomeController()
        {
            repository = new AddCustomer();
        }
        public ActionResult Index()
        {
            if (Session["Id"] == null && Session["Name"] == null)
            {
                FormsAuthentication.SignOut();
                return View();
            }
            else 
            { 
                return View();
            }
        }
        [NoDirectAccess]

        [Authorize]
        public ActionResult GlassProducts()
        {
            return View();
        }
        [Authorize]
        public ActionResult NormalGlasses()
        {
            return View();
        }
        [Authorize]
        public ActionResult OtherGlasses()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public JsonResult ManageProfiles(decimal id, SignUp model)
        {
            repository.UpdateCustomer(model.id, model);
            Session["Name"] = model.MName;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult MirrorGlasses()
        {
            return View();
        }
        [Authorize]
        public ActionResult PlaneGlasses()
        {
            return View();
        }

        [Authorize]
        public ActionResult FigureGlasses()
        {
            return View();
        }

        [Authorize]
        public ActionResult PlaneMirrorDescription()
        {
            ViewBag.Active = "PlaneM";
            return View();
        }
        [Authorize]
        public ActionResult BlackMirrorDescription()
        {
            ViewBag.Active = "BlackM";
            return View();
        }

        [Authorize]
        public ActionResult FishTank()
        {
            return View();
        }
        [Authorize]
        public ActionResult BrownMirrorDescription()
        {
            ViewBag.list = StateList;
            ViewBag.Active = "BrownM";
            return View();
        }
        public ActionResult OrdersBypass() 
        {
            Session["Order"] = Session["Mail"];
            return RedirectToAction("Orders");
        }
        [Authorize]

        public ActionResult Orders(Product model) 
        {
            model.PMail = Session["Order"].ToString();
            var result = repository.GetProducts(model);
            return View(result);
        }
        [Authorize]

        public ActionResult PlaneGlass() 
        {

            return View();
        }
        [Authorize]

        public ActionResult BrownGlass()
        {

            return View();
        }
        [Authorize]

        public ActionResult BlackGlass()
        {

            return View();
        }
        [Authorize]

        public ActionResult ExtraClearGlass()
        {

            return View();
        }
        [Authorize]


        public ActionResult OnewayGlass()
        {

            return View();
        }
        [Authorize]


        public ActionResult ToughenedGlass()
        {

            return View();
        }
        [Authorize]

        public ActionResult FancyMandir()
        {

            return View();
        }
        [Authorize]

        public ActionResult TableTop()
        {
            return View();
        }
        [Authorize]

        public ActionResult GlassTable()
        {
            return View();
        }
        [Authorize]

        public ActionResult GlassToGlassPillars()
        {
            return View();
        }
        [Authorize]

        public ActionResult FancyMirrors()
        {
            return View();
        }
        [Authorize]

        public ActionResult WashBasin()
        {
            return View();
        }
        [Authorize]

        public ActionResult TamatarGlass()
        {
            ViewBag.Polish = "FigureGlass";
            return View();
        }
        [Authorize]

        public ActionResult BajriGlass()
        {
            ViewBag.Polish = "FigureGlass";

            return View();
        }
        
        [Authorize]

        public ActionResult ThumpsUpGlass()
        {
            ViewBag.Polish = "FigureGlass";

            return View();
        }
        
        [Authorize]

        public ActionResult StarGlass()
        {
            ViewBag.Polish = "FigureGlass";

            return View();
        }
        [Authorize]
        public ActionResult KalaKachiGlass()
        {
            ViewBag.Polish = "FigureGlass";

            return View();
        }
        [Authorize]
        public ActionResult AnarkaliGlass()
        {
            ViewBag.Polish = "FigureGlass";
            return View();
        }

        [Authorize]
        public ActionResult FancyMandirDescription()
        {
            return View();
        }

        [Authorize]
        public ActionResult FancyMandirFancyGlass()
        {
            return View();
        }

        [Authorize]
        public ActionResult FancyMandirMirrorGlass()
        {
            return View();
        }
        

        [Authorize]
        public ActionResult FancyMandirDescription2()
        {
            return View();
        }

        [Authorize]
        public ActionResult FancyMandirFancyGlass2()
        {
            return View();
        }

        [Authorize]
        public ActionResult FancyMandirShinyGlass2()
        {
            return View();
        }

        [Authorize]
        public ActionResult FancyMandirShinyGlass()
        {
            return View();
        }
        [Authorize]
        public ActionResult FishTank1ft()
        {
            return View();
        }
        [Authorize]
        public ActionResult FishTank2ft()
        {
            return View();
        }
        [Authorize]
        public ActionResult FishTank3ft()
        {
            return View();
        }
        [Authorize]
        public ActionResult FishTank1_5ft()
        {
            return View();
        }
        [Authorize]
        public ActionResult FishTank2_5ft()
        {
            return View();
        }
        [Authorize]
        public ActionResult TableTopBrown()
        {
            return View();
        }
        [Authorize]
        public ActionResult TableTopBlack()
        {
            return View();
        }
        
        [Authorize]
        public ActionResult TableTopPlane()
        {
            return View();
        }
        
        [Authorize]
        public ActionResult TableTopPlaneGlass()
        {
            return View();
        }
        
        [Authorize]
        public ActionResult FancyMirror1()
        {
            return View();
        }
        [Authorize]
        public ActionResult FancyMirror2()
        {
            return View();
        }
        [Authorize]
        public ActionResult FancyMirror3()
        {
            return View();
        }
        [Authorize]
        public ActionResult FancyMirror4()
        {
            return View();
        }
        [Authorize]
        public ActionResult FancyMirror5()
        {
            return View();
        }
        [Authorize]
        public ActionResult FancyMirror6()
        {
            return View();
        }

        [Authorize]

        public JsonResult Delete(int id)
        {
            repository.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
            
        }
        
    }

}