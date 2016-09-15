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
    public class CarsController : Controller
    {
        TestDbContext _db = new TestDbContext();

    // GET: Cars
    public ActionResult Index()
    {
        IEnumerable<Car> cars = _db.Cars.OrderBy(b => b.Price).ToList();
        return View(cars);
    }

        /// GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Cars.Add(car);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Details(int id)
    {
        Car car = _db.Cars.FirstOrDefault(x => x.Id == id);
        return View(car);
    }

    // GET: Car/Edit/5
    public ActionResult Edit(int id)
    {
        Car car = _db.Cars.FirstOrDefault(b => b.Id == id);
            _db.Cars.Add(car);
            _db.SaveChanges();

            return View(car);
    }

    // POST: Car/Edit
    [HttpPost]
    public ActionResult Edit(Car car)
    {
        try
        {
                _db.Entry(car).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
        catch
        {
            return View();
        }
    }

    // GET: Car/Delete/5
    [HttpGet]
    public ActionResult Delete(int id)
    {
        Car car = _db.Cars.FirstOrDefault(x => x.Id == id);
        return View(car);
    }

    // POST: Books/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, Car car)
    {
        try
        {
            Car b = _db.Cars.FirstOrDefault(x => x.Id == id);
            _db.Cars.Remove(b);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // Check and make sure, that all connections to the database were closed
    // and memory was exempted 
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
