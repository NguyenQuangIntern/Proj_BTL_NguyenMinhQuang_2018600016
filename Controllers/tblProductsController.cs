using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proj_BTL_NguyenMinhQuang_2018600016.Models;
using PagedList;

namespace Proj_BTL_NguyenMinhQuang_2018600016.Controllers
{
    public class tblProductsController : Controller
    {
        private Flute db = new Flute();

        // GET: tblProducts
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SapTheoGia = sortOrder == "Gia" ? "gia_desc" : "Gia";

            //Lấy giá trị của bộ lọc hiện tại
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = db.tblProducts.Select(p => p);
            //Lọc theo tên hàng
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.Contains(searchString));
            }
            //Sắp xếp theo tên và giá
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s=>s.ProductName);
                    break;
                case "Gia":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "gia_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.ProductName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ClientIndex()
        {
            var popular_products = from prod in db.tblProducts orderby prod.Price ascending select prod;
            return View(popular_products.ToList());
        }

        public ActionResult AllProduct(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SapTheoGia = sortOrder == "Gia" ? "gia_desc" : "Gia";

            //Lấy giá trị của bộ lọc hiện tại
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = db.tblProducts.Select(p => p);
            //Lọc theo tên hàng
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.Contains(searchString));
            }
            //Sắp xếp theo tên và giá
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.ProductName);
                    break;
                case "Gia":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "gia_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.ProductName);
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 2);

            return View(products.ToPagedList(pageNumber, pageSize));
        }

        [ChildActionOnly]
        public PartialViewResult CategoryMenu()
        {
            CategoryDAO cd = new CategoryDAO();
            var li = cd.ListCategory();
            return PartialView(li);
        }

        [ChildActionOnly]
        public PartialViewResult ClientCategoryMenu()
        {
            CategoryDAO cd = new CategoryDAO();
            var li = cd.ListCategory();
            return PartialView(li);
        }

        public ActionResult ProductByCat(int cat)
        {
            ProductDAO p = new ProductDAO();
            var li = p.ListProductsByCate(cat);
            var catename =  (from cate in db.tblCategories where cate.Categoryid == cat select cate.CategoryName).ToList();
            ViewBag.Category = catename.ElementAt(0).ToString();
            return View(li);
        }

        public ActionResult ClientProductByCat(int cat)
        {
            ProductDAO p = new ProductDAO();
            var li = p.ListProductsByCate(cat);
            var catename = (from cate in db.tblCategories where cate.Categoryid == cat select cate.CategoryName).ToList();
            ViewBag.Category = catename.ElementAt(0).ToString();
            return View(li);
        }

        // GET: tblProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        public ActionResult ClientDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // GET: tblProducts/Create
        public ActionResult Create()
        {
            ViewBag.Categoryid = new SelectList(db.tblCategories, "Categoryid", "CategoryName");
            return View();
        }

        // POST: tblProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pid,Categoryid,ProductName,MetaTittle,Description,ImagePath,Price")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                db.tblProducts.Add(tblProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoryid = new SelectList(db.tblCategories, "Categoryid", "CategoryName", tblProduct.Categoryid);
            return View(tblProduct);
        }

        // GET: tblProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoryid = new SelectList(db.tblCategories, "Categoryid", "CategoryName", tblProduct.Categoryid);
            return View(tblProduct);
        }

        // POST: tblProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pid,Categoryid,ProductName,MetaTittle,Description,ImagePath,Price")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoryid = new SelectList(db.tblCategories, "Categoryid", "CategoryName", tblProduct.Categoryid);
            return View(tblProduct);
        }

        // GET: tblProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // POST: tblProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProduct tblProduct = db.tblProducts.Find(id);
            db.tblProducts.Remove(tblProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
