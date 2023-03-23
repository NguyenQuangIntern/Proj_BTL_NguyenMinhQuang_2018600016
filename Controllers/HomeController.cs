using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj_BTL_NguyenMinhQuang_2018600016.Models;

namespace Proj_BTL_NguyenMinhQuang_2018600016.Controllers
{
    public class HomeController : Controller
    {
        Flute db = new Flute();
        public ActionResult Index()
        {
            var popular_products = from prod in db.tblProducts orderby prod.Price ascending select prod;
            return View(popular_products.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Experience()
        {
            return View();
        }

        public ActionResult Maintain()
        {
            return View();
        }

        public ActionResult Intro()
        {
            return View();
        }

        public ActionResult Tutorial()
        {
            return View();
        }

        public ActionResult Select()
        {
            return View();
        }

    }
}