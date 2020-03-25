using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhotowalaWebsite.Models;

namespace PhotowalaWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogsController : Controller
    {
        private webmodel db = new webmodel();

        // GET: Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        public ActionResult WebView()
        {
            return View(db.Blogs.ToList());
        }
    

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.catgoryID = new SelectList(db.Catagories, "CatagoryId", "CatagoryName");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogID,Title,Discription,LogDiscription,Image,Date,catgoryID")] Blog blog, HttpPostedFileBase Image )
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var filename = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/img"), filename);
                    Image.SaveAs(path);
                    blog.Image = "/img/" + filename;
                }
                
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewBag.catgoryID = new SelectList(db.Catagories, "CatagoryId", "CatagoryName");
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogID,Title,Discription,LogDiscription,Image,Date")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
