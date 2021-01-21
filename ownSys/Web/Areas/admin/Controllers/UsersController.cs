using BLL.System;
using Entity.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Areas.admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: admin/Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetList(int page, int limit)
        {
            int totle = 0;
            sys_Users obj = new sys_Users() { name = "" };
            List<sys_Users> list = B_sys_Users.GetList(obj, page, limit, out totle);
            //var model = new { page = 1, data = list, total = list.Count, records = list.Count };
            var mode2 = new { code = 0, msg = "", data = list, count = totle };
            return Json(mode2);
        }


        [HttpPost]
        public JsonResult Add(sys_Users menu)
        {
            bool res = B_sys_Users.Insert(menu);

            return Json(new ResponseModel<sys_Users> { code = res ? 1 : 0, msg = "", data = null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(sys_Users menu)
        {
            bool res = B_sys_Users.Update(menu);

            return Json(new ResponseModel<sys_Users> { code = res ? 1 : 0, msg = "", data = null }, JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool res = B_sys_Users.Delete(id);

            return Json(new ResponseModel<sys_Users> { code = res ? 1 : 0, msg = "", data = null }, JsonRequestBehavior.AllowGet);
        }


    }
}