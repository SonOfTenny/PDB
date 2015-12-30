using IdentityTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTutorial.ViewModels;

namespace IdentityTutorial.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var viewModel = new DashboardData();
            viewModel.Downtime = db.Downtime;
            viewModel.Production = db.Productions;
            viewModel.MonthlyDowntime = db.Downtime;
            viewModel.MonthlyProduction = db.Productions;
            viewModel.Production = viewModel.Production.Where(s => s.Date >= DateTime.Now.Date.AddDays(-7));
            viewModel.Downtime = viewModel.Downtime.Where(s => s.Date >= DateTime.Now.Date.AddDays(-7));
            viewModel.MonthlyProduction = viewModel.MonthlyProduction.Where(s => s.Date >= DateTime.Now.Date.AddMonths(-1));
            viewModel.MonthlyDowntime = viewModel.MonthlyDowntime.Where(s => s.Date >= DateTime.Now.Date.AddMonths(-1));
            var last7days = DateTime.Now.Date.AddDays(-7);
            var production = from s in db.Productions
                                 where s.Date >= last7days
                                 select s;
            var downtime = from s in db.Downtime
                           where s.Date >= last7days
                           select s;
            
          
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}