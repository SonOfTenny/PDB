using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityTutorial.Models;
using PagedList;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace IdentityTutorial.Controllers
{
    [Authorize(Roles = "Administrators, User")]
    public class DowntimeAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private User user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        // GET: Downtime
        public ActionResult Index(String sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.UserSortParm = String.IsNullOrEmpty(sortOrder) ? "User_desc" : "";
            ViewBag.ShiftSortParm = String.IsNullOrEmpty(sortOrder) ? "Shift_desc" : "";
            ViewBag.PlantSortParm = String.IsNullOrEmpty(sortOrder) ? "Plant_desc" : "";
            ViewBag.DurationSortParm = String.IsNullOrEmpty(sortOrder) ? "Duration_desc" : "";
            ViewBag.DownTypeSortParm = String.IsNullOrEmpty(sortOrder) ? "DownType_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var downtimedata = from s in db.Downtime
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                downtimedata = downtimedata.Where(s => s.User.UserName.ToUpper().Contains(searchString.ToUpper()) ||
                                                    s.DowntimeType.Name.ToUpper().Contains(searchString.ToUpper()) ||
                                                    s.DowntimeType.Plant.Name.ToUpper().Contains(searchString.ToUpper()));

            }
            switch (sortOrder)
            {
                case "User_desc":
                    downtimedata = downtimedata.OrderByDescending(s => s.User.UserName);
                    break;
                case "Shift_desc":
                    downtimedata = downtimedata.OrderByDescending(s => s.Shift.Name);
                    break;
                case "Plant_desc":
                    downtimedata = downtimedata.OrderByDescending(s => s.DowntimeType.Plant.Name);
                    break;
                case "DownType_desc":
                    downtimedata = downtimedata.OrderByDescending(s => s.DowntimeType.Name);
                    break;
                case "Date_desc":
                    downtimedata = downtimedata.OrderBy(s => s.Date);
                    break;
                default:
                    downtimedata = downtimedata.OrderBy(s => s.Date);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(downtimedata.ToPagedList(pageNumber, pageSize));
        }

        // GET: Downtime/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Downtime downtime = db.Downtime.Find(id);
            if (downtime == null)
            {
                return HttpNotFound();
            }
            return View(downtime);
        }

        // GET: Downtime/Create
        public ActionResult Create()
        {
            ViewBag.PlantID = new SelectList(db.Plants, "PlantID", "Name");
            ViewBag.DowntimeTypeID = new SelectList(db.DowntimeTypes, "DowntimeTypeID", "Name");
            ViewBag.ShiftID = new SelectList(db.Shifts, "ShiftID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Downtime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DowntimeID,UserID,ShiftID,PlantID,DowntimeTypeID,Reason,Action,Date,StartTime,EndTime")] Downtime downtime)
        {
            TimeSpan span = (downtime.EndTime - downtime.StartTime);
            double totalMins = span.TotalMinutes;

            try
            {

                if (ModelState.IsValid)
                {
                    downtime.TotalDownMins = totalMins;
                    downtime.UserID = user.Id;
                    db.Downtime.Add(downtime);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.PlantID = new SelectList(db.DowntimeTypes, "DowntimeTypeID", "Plant", downtime.DowntimeType.Plant);
            ViewBag.DowntimeTypeID = new SelectList(db.DowntimeTypes, "DowntimeTypeID", "Name", downtime.DowntimeType.Name);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ShiftID", "Name", downtime.ShiftID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName", downtime.UserID);
            return View(downtime);
        }

        // GET: Downtime/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Downtime downtime = db.Downtime.Find(id);
            if (downtime == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantID = new SelectList(db.DowntimeTypes, "DowntimeTypeID", "Plant", downtime.DowntimeType.Plant);
            ViewBag.DowntimeTypeID = new SelectList(db.DowntimeTypes, "DowntimeTypeID", "Name", downtime.DowntimeType.Name);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ShiftID", "Name", downtime.ShiftID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName", downtime.UserID);
            return View(downtime);
        }

        // POST: Downtime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DowntimeID,UserID,ShiftID,PlantID,DowntimeTypeID,Reason,Action,Date,StartTime,EndTime")] Downtime downtime)
        {
            TimeSpan span = (downtime.EndTime - downtime.StartTime);
            double totalMins = span.TotalMinutes;
            try
            {
                if (ModelState.IsValid)
                {
                    //downtime.UserID = user.Id;
                    downtime.TotalDownMins = totalMins;
                    db.Entry(downtime).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.PlantID = new SelectList(db.DowntimeTypes, "DowntimeTypeID", "Plant", downtime.DowntimeType.Plant);
            ViewBag.DowntimeTypeID = new SelectList(db.DowntimeTypes, "DowntimeTypeID", "Name", downtime.DowntimeType.Name);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ShiftID", "Name", downtime.ShiftID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName", downtime.UserID);
            return View(downtime);
        }

        // GET: Downtime/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Downtime downtime = db.Downtime.Find(id);
            if (downtime == null)
            {
                return HttpNotFound();
            }
            return View(downtime);
        }

        // POST: Downtime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {

                Downtime downtime = db.Downtime.Find(id);
                db.Downtime.Remove(downtime);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                // uncomment dex and log error. 
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
