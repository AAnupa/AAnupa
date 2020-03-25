
using PhotowalaWebsite.Models;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PhotowalaWebsite;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PasswordSecurity;

namespace PhotowalaWebsite.Controllers
{
    public class AccountController : Controller
    {
        webmodel db = new webmodel();

        [Authorize(Roles = "Admin")]
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
  
        public ActionResult Register()
        {
            return View();
        }
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string Username, string Password, string Role, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Username = Username;
                user.Password = PasswordStorage.CreateHash(Password);

                user.Role = Role;
                if (Image != null)
                {
                    var filename = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/img"), filename);
                    Image.SaveAs(path);
                    user.Image = "/img/" + filename;
                }
                db.Users.Add(user);
                db.SaveChanges();
                FormsAuthentication.SignOut();

                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User U)
        {
            var count = db.Users.Where(x => x.Username == U.Username).SingleOrDefault();
            if (count == null)
            {
                ViewBag.Msg = "Invalid Login Attempt........";
                return View();
            }

            bool result = PasswordStorage.VerifyPassword(U.Password, count.Password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(U.Username, false);
                return RedirectToAction("Index", "Home");
             }
             
            return View(); 

        }
        [Authorize(Roles = "Admin")]
        public ActionResult Dashbord()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}