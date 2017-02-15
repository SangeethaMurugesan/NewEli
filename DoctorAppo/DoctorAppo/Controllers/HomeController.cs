using DoctorAppo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Logi c)
        {
            doctorappoEntities4 db = new doctorappoEntities4();

            if (true)
            {
                var item = db.Logis.Where(model => model.UserID.Equals(c.UserID) && model.Pwd.Equals(c.Pwd) && model.UserRole.Equals(c.UserRole)).FirstOrDefault();
                if (item is Logi)
                {
                    Session["UserName"] = item.UserID;
                    if(item.UserRole=="admin")
                    {
                        return RedirectToAction("Admin");
                    }
                    else if(item.UserRole=="receptionist")
                    {
                        return RedirectToAction("Receptionist");
                    }
                    else
                    {
                        return RedirectToAction("Doctor");
                    }
                    
                }
                else
                {
                    return View(c);
                }
            }
            //else
            //    return View(c);

        }​
    }
}