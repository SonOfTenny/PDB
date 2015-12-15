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
using Microsoft.AspNet.Identity;
using System.Web.Security;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityTutorial.Controllers
{
    public class ProductionAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private User user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<User> UserManager { get; set; }

        // GET: Production
        public ActionResult Index(String sortOrder, string currentFilter, string searchString, int? page)
        {


            ViewBag.UserSortParm = String.IsNullOrEmpty(sortOrder) ? "User_desc" : "";
            ViewBag.ShiftSortParm = String.IsNullOrEmpty(sortOrder) ? "Shift_desc" : "";
            ViewBag.PlantSortParm = String.IsNullOrEmpty(sortOrder) ? "Plant_desc" : "";
            ViewBag.ActualMixSortParm = String.IsNullOrEmpty(sortOrder) ? "ActualMix_desc" : "";
            ViewBag.CrumbSortParm = String.IsNullOrEmpty(sortOrder) ? "Crumb_desc" : "";
            ViewBag.CMPSortParm = String.IsNullOrEmpty(sortOrder) ? "CMP_desc" : "";
            ViewBag.ManningSortParm = String.IsNullOrEmpty(sortOrder) ? "Manning_desc" : "";
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

            var productiondata = from s in db.Productions
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                productiondata = productiondata.Where(s => s.Plant.Name.ToUpper().Contains(searchString.ToUpper()) ||
                                    s.User.FirstName.ToUpper().Contains(searchString.ToUpper()) ||
                                    s.User.LastName.ToUpper().Contains(searchString.ToUpper()) ||
                                    s.Shift.Name.ToUpper().Contains(searchString.ToUpper()));
            }


            switch (sortOrder)
            {
                case "User_desc":
                    productiondata = productiondata.OrderByDescending(s => s.User);
                    break;
                case "Shift_desc":
                    productiondata = productiondata.OrderByDescending(s => s.Shift);
                    break;
                case "Plant_desc":
                    productiondata = productiondata.OrderByDescending(s => s.Plant);
                    break;
                case "ActualMix_desc":
                    productiondata = productiondata.OrderByDescending(s => s.ActualMix);
                    break;
                case "Crumb_desc":
                    productiondata = productiondata.OrderByDescending(s => s.CrumbWaste);
                    break;
                case "CMP_desc":
                    productiondata = productiondata.OrderByDescending(s => s.Cmp_Waste);
                    break;
                case "Manning_desc":
                    productiondata = productiondata.OrderByDescending(s => s.Manning);
                    break;
                case "Date_desc":
                    productiondata = productiondata.OrderBy(s => s.Date);
                    break;
                default:
                    productiondata = productiondata.OrderBy(s => s.Date);
                    break;

            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(productiondata.ToPagedList(pageNumber, pageSize));
        }


        // GET: Production/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production production = db.Productions.Find(id);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
        }

        // GET: Production/Create
        public ActionResult Create()
        {

            //var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            User user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.UserID = user.Id;
            ViewBag.PlantID = new SelectList(db.Plants, "PlantID", "Name");
            ViewBag.ShiftID = new SelectList(db.Shifts, "ShiftID", "Name");
            return View();
        }

        // POST: Production/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShiftID, PlantID, StartTime, EndTime, ActualMix, CrumbWaste, Cmp_Waste,Manning, Date")]Production production)
        {
            User user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.UserID = user.Id.ToString();
            try
            {

                if (ModelState.IsValid)
                {
                    production.UserID = user.Id;
                    db.Productions.Add(production);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //User user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.UserID = user.Id.ToString();
            ViewBag.currentUser = user.UserName;
            ViewBag.ShiftID = new SelectList(db.Shifts, "ShiftID", "Name", production.ShiftID);
            ViewBag.PlantID = new SelectList(db.Plants, "PlantID", "Name", production.PlantID);
            return View(production);
        }

        // GET: Production/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production production = db.Productions.Find(id);
            if (production == null)
            {
                return HttpNotFound();
            }
            User user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.UserID = user.Id;
            ViewBag.PlantID = new SelectList(db.Plants, "PlantID", "Name", production.PlantID);
            ViewBag.ShiftID = new SelectList(db.Shifts, "ShiftID", "Name", production.ShiftID);
            return View(production);
        }

        // POST: Production/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionID, UserID, ShiftID, PlantID,StartTime, EndTime, ActualMix, CrumbWaste, Cmp_Waste, Manning, Date ")]Production production)
        {

            User user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            try
            {
                if (ModelState.IsValid)
                {
                    // production.UserID = user.Id;
                    db.Entry(production).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //User user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.UserID = user.Id;
            ViewBag.ShiftID = new SelectList(db.Shifts, "ShiftID", "Name", production.ShiftID);
            ViewBag.PlantID = new SelectList(db.Plants, "PlantID", "Name", production.PlantID);
            return View(production);
        }

        // GET: Production/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Production production = db.Productions.Find(id);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
        }

        // POST: Production/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Production production = db.Productions.Find(id);
                db.Productions.Remove(production);
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
