using CarDealership.Models;
using CarDealership.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarDealership.Controllers
{
    public class CarController : Controller
    {
        ICarRepository _repo = new EfCarRepository();

        // GET: Car
        public ActionResult Index()
        {
            var cars = _repo.GetAllCars();
            return View(cars);
        }

        public ActionResult Details(int id)
        {
            var car = _repo.GetCarById(id);
            return View(car);
        }

        // This gets a car by the details in the url   year/make/model
        public ActionResult DetailsByFields(string year, string make, string model)
        {
            // gets the car associated with the associated values
            var car = _repo.GetCarByDetails(year, make, model);
            
            return View("Details", car);
        }

        public ActionResult Add()
        {
            return View(new OCar());
        }

        [HttpPost]
        public ActionResult Add(OCar oCar)
        {
            if (ModelState.IsValid)
            {
                _repo.AddCar(oCar);
                var cars = _repo.GetAllCars();
                return View("Index", cars);

            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string username, string password)
        {
            var user = _repo.LoginUser(username, password);
            ViewBag.User = user;
            if (user == null)
            {
                return View("Login");
            }
            else { 
                var cars = _repo.GetAllCars();
                return View("Index", cars);
            }
        }
    }
}