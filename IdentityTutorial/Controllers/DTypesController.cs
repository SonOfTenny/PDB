using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityTutorial.Models;

namespace IdentityTutorial.Controllers
{
    public class DTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DTypes
        public ActionResult Index()
        {
            return View(db.DTypes.ToList());
        }

        // GET: DTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DType dType = db.DTypes.Find(id);
            if (dType == null)
            {
                return HttpNotFound();
            }
            return View(dType);
        }

        // GET: DTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DTypeID,Type")] DType dType)
        {
            if (ModelState.IsValid)
            {
                db.DTypes.Add(dType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dType);
        }

        // GET: DTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DType dType = db.DTypes.Find(id);
            if (dType == null)
            {
                return HttpNotFound();
            }
            return View(dType);
        }

        // POST: DTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DTypeID,Type")] DType dType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dType);
        }

        // GET: DTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DType dType = db.DTypes.Find(id);
            if (dType == null)
            {
                return HttpNotFound();
            }
            return View(dType);
        }

        // POST: DTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DType dType = db.DTypes.Find(id);
            db.DTypes.Remove(dType);
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
