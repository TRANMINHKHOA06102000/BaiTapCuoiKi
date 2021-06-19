using ModelEF.DAO;
using ModelEF.EF;
using PagedList;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
namespace TranMinhKhoa_TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var result = new ProductDAO();
            var model = result.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var result = new ProductDAO();
            var model = result.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        //tạo thêm sản phẩm
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new ProductDAO();
                    var kq = dao.Insert(model);
                    if (kq == true)
                    {
                        setAlert("Tạo mới sản phẩm thành công", "success");
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        setAlert("Tạo mới sản phẩm không thành công", "error");
                        return RedirectToAction("Create", "Product");
                    }
                }
                return View("Index");
            }
            catch (Exception)
            {
                return null;
            }
        }
        //xem chi tiết
        public ActionResult Detail(int id)
        {
            var detail = new ProductDAO().Find(id);
            return View(detail);
        }
        [HttpGet]
        // sửa thông tin sản phẩm
        public ActionResult Edit(int sp)
        {
            SetViewBag();
            var product = new ProductDAO().Find(sp);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                if (string.IsNullOrEmpty(product.Name) && string.IsNullOrEmpty(product.UnitCost.ToString()) && string.IsNullOrEmpty(product.Quantity.ToString()) && string.IsNullOrEmpty(product.CategoryID.ToString()))
                {
                    setAlert("Thông tin không được cập nhật trống", "error");
                    return RedirectToAction("Edit", "Product");
                }
                var kq = dao.Update(product);
                if (kq == true)
                {
                    setAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    setAlert("Cập nhật sản phẩm không thành công", "error");
                    return RedirectToAction("Edit", "Product");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDAO().Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "CategoryID", "Name", selectedId);
        }
    }
}
