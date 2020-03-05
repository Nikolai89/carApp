using CarApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarApplication.Controllers
{
    public class CarController : Controller
    {

        CarContext db = new CarContext();

        [Authorize]
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<Car> carsPerPages = db.Cars
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Cars.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Cars = carsPerPages };

            return View(ivm);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.CarId = id;

            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            //int carId = ViewBag.CarId;
            //Car car = db.Cars.FirstOrDefault(c => c.Id == carId);

            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо," + purchase.Name + ", за покупку !!!";
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();

            return RedirectToAction("Index");

        }


        [Authorize(Roles = "admin")]
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