using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
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

        public ActionResult welcome_iframe()
        {
            //return Redirect("/Scripts/pages/welcome_iframe.html");
            //注意：把你的html文件放在Views文件夹外的任何文件夹中，就可以直接访问了，
            return View();
        }
    }
}