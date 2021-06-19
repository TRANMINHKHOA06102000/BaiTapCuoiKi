using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TranMinhKhoa_TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new ProductDAO();
            var categoryDao = new CategoryDAO();
            ViewBag.NewProducts = productDao.ListNewProduct(9);
            ViewBag.NewCategorys = categoryDao.ListNewCate(8);
            return View();
        }
    }
}