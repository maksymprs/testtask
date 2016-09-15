using DataService;
using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTask.Controllers
{
    public class DriversController : Controller
    {

        TestDbContext _db = new TestDbContext();
        // GET: Driver
        public ActionResult Index()
        {
            IEnumerable <Driver> drivers = _db.Drivers.OrderBy(a => a.LastName).ToList();
            return View(drivers);
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            return View();
        }
// POST: Driver/Create
        [HttpPost]
        public ActionResult Create(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _db.Drivers.Add(driver);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
         
            return View();
        }
        // GET: Driver/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(Driver driver)
        {
            try
            {
                _db.Entry(driver).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(driver);
            }
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int id)
        {
            Driver driver = _db.Drivers.FirstOrDefault(b => b.Id == id);
            return View(driver);
        }

        // POST: Driver/Delete/5
        [HttpPost]
        public ActionResult Delete(Driver driver)
        {
            try
            {
                _db.Entry(driver).State = EntityState.Deleted;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(driver);
            }
        }
        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                this._db.Dispose();
            }

            base.Dispose(Disposing);
        }
    }
}
