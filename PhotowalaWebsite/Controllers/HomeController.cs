using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotowalaWebsite.Models;

namespace PhotowalaWebsite.Controllers
{
    public class HomeController : Controller
    {
        private webmodel db = new webmodel();
        public ActionResult Index()
        {
            var ind = db.Images.Where(x => x.Location == "Home").ToList();
            return View(ind);
            
        }

        public ActionResult About()
        {

            var photos = db.Images.OrderByDescending(x => x.ImageID).FirstOrDefault();
            return View(photos);
        }

        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact()
        {
            var con = db.Images.Where(x => x.Location == "Contact").ToList();
            return View(con);
        }

        public ActionResult Packages()
        {
            return View(db.Works.ToList());
        }

        public ActionResult Review()
        {
            return View();
        }

        public ActionResult Blog()
        {

            var blogs = db.Blogs.ToList();
            return View(blogs);
        }
        public ActionResult Gallery()
        {
            return View(db.Images.Where(x => x.Location == "Gallery").ToList());
        }
        public ActionResult Single(int? ID)
        {

            var singlepage = db.Blogs.Where(p=>p.BlogID == ID).ToList();
            return View(singlepage);
        }
    }
}