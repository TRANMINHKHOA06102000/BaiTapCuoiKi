using ModelEF.DAO;
using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TranMinhKhoa_TestUngDung.Common;

namespace TranMinhKhoa_TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var user = new UserDAO();
            if (!string.IsNullOrEmpty(searchString))
            {
                var model = user.ListWhereAll(searchString, page, pageSize);
                ViewBag.SearchString = searchString;
                return View(model.ToPagedList(page, pageSize));
            }
            else
            {
                var model = user.ListAll();
                return View(model.ToPagedList(page, pageSize));
            }
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            new UserDAO().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}