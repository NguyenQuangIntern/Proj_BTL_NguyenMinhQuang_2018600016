using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj_BTL_NguyenMinhQuang_2018600016.Models;

namespace Proj_BTL_NguyenMinhQuang_2018600016.Controllers
{
    public class AdminController : Controller
    {
        Flute db = new Flute();
        // GET: LogIn
        public ActionResult Index(string message)
        {
            ViewBag.msg = message;
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(string accountname, string password)
        {
            var account = db.tblAccounts.FirstOrDefault(tk => tk.AccountName == accountname);
            if(account != null && account.Password == password)
            {
                if (account.Type == true)
                {
                    Session["account"] = accountname;
                    return RedirectToAction("Welcome", "Admin");
                }
            }
            else
            {
                var message = "Sai tên đăng nhập hoặc mật khẩu!";
                Index(message);
            }
            return View("Index");
        }

        public ActionResult Welcome(string displayName)
        {
            ViewBag.displayName = displayName;
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("account");
            return View("Index");
        }
    }
}