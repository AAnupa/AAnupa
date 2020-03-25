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
    
    public class ImagesController : Controller
    {
        private webmodel db = new webmodel();

        // GET: Images
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }

        public ActionResult HomePhoto()
        {
            return View(db.Images.Where(x=>x.Location == "Home").ToList());
        }

        public ActionResult GalleryPhoto()
        {
            return View(db.Images.Where(x => x.Location == "Gallery").ToList());
        }

        public ActionResult AboutPhoto()
        {
            return View(db.Images.Where(x=>x.Location=="About").ToList());
        }

        public ActionResult TeamPhoto()
        {
            return View(db.Images.Where(x => x.Location == "Team").ToList());
        }

        public ActionResult webTeamPhoto()
        {
            return View(db.Images.Where(x => x.Location == "Team").ToList());
        }


        // GET: Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageID,Title,Location,ImagePath,Description,Position,TeamName,Tag")] Image image, HttpPostedFileBase ImagePath)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(ImagePath.FileName);
                var path = Path.Combine(Server.MapPath("~/img"), filename);
                ImagePath.SaveAs(path);
                image.ImagePath = "/img/" + filename;

                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("create");
            }

            return View(image);
        }

        // GET: Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageID,Title,Location,ImagePath,Description,Tag")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }

        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
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
