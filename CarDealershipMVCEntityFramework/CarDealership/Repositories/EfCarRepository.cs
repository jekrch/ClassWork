using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealership;
using CarDealership.Models; 

namespace CarDealership.Repositories
{
    public class EfCarRepository : ICarRepository
    {



        public static List<OCar> Cars()
        {
            var carsList = new List<OCar>(); 

            using (CarDBEntities2 cars = new CarDBEntities2())
            {

        
                foreach (Car c in cars.Cars)
                {
                    carsList.Add(new OCar()
                    {
                        ImageUrl = c.ImageUrl,
                        Year = c.Year,
                        Description = c.Description,
                        Id = c.Id,
                        Model = c.Model,
                        Make = c.Make,
                        Price = c.Price,
                        Title = c.Title
                    });
                }


            }
            return carsList; 
        }

        public List<OCar> GetAllCars()
        {
            return Cars();
        }

        public void AddCar(OCar oCar)
        {

            //car.Id = Cars.Max(c => c.Id) + 1;
            using (CarDBEntities2 cars = new CarDBEntities2())
            {
                cars.Cars.Add(new Car()
                {
                    Model = oCar.Model,
                    Make = oCar.Make,
                    Description = oCar.Description,
                    ImageUrl = oCar.ImageUrl,
                    Price = oCar.Price,
                    Title = oCar.Title,
                    Year = oCar.Year
                });

                cars.SaveChanges(); 

            }

        }

        public void DeleteCar(int carId)
        {

     
        }

        public void EditCar(OCar oCar)
        {

          
        }

       

        public OCar GetCarById(int id)
        {
            var cars = Cars();
            
            return cars.First(x => x.Id == id);

        }

        public OCar GetCarByModel(string name)
        {
            var cars = Cars();

            return cars.First(x => x.Model == name);
       
        }


        public OCar GetCarByDetails(string year, string make, string model)
        {
            var cars = Cars();
            return cars.FirstOrDefault(c => c.Make == make
                                      && c.Model == model
                                     && c.Year == year);
        
        }

        public User LoginUser(string username, string password)
        {
            return new User()
            {
                Password = password,
                UserId = 1,
                UserMessage = "Some message",
                Username = "fakeuser"
            };
        }
    }
}