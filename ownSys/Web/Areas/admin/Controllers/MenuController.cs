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
    //系统菜单
    [Route("/Menu")]
    public class MenuController : Controller
    {
        // GET: admin/Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList()
        {
            List<sys_Menu> list = B_sys_Menu.GetList();

            return Json(new ResponseModel<sys_Menu> { code = 1, msg = "", data = list }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(sys_Menu menu)
        {
            bool res = B_sys_Menu.Insert(menu);

            return Json(new ResponseModel<sys_Menu> { code = res ? 1 : 0, msg = "", data = null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(sys_Menu menu)
        {
            bool res = B_sys_Menu.Update(menu);

            return Json(new ResponseModel<sys_Menu> { code = res ? 1 : 0, msg = "", data = null }, JsonRequestBehavior.AllowGet);
        }

        [Route("/Delete")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool res = B_sys_Menu.Delete(id);

            return Json(new ResponseModel<sys_Menu> { code = res ? 1 : 0, msg = "", data = null }, JsonRequestBehavior.AllowGet);
        }


    }
}