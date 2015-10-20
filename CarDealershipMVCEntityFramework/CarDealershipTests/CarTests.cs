using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership.Repositories;
using CarDealership.Models;
using System.Linq;

namespace CarDealershipTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void SqlAttack()
        {
            var _repo = new MockCarRepository();
            OCar theAccord = _repo.GetCarByModel("' GO DROP DATABASE CarDB GO --");
            var x = "x";
        }

        [TestMethod]
        public void TestAddToRepo()
        {
            OCar c = new OCar()
            {
                Description = "Spam",
                Title = "Spam",
                Year = "1987",
                Make = "Nissan",
                Model = "Stanza",
                Price = 9999.00M,
                ImageUrl = "http://carphotos.cardomain.com/ride_images/1/1287/3601/3216800003_large.jpg"
            };

            var _repo = new MockCarRepository();
            _repo.AddCar(c);

        }

        [TestMethod]
        public void TestEditRepo()
        {
            var _repo = new MockCarRepository();
            var car = _repo.GetAllCars().FirstOrDefault(x => x.Make == "Nissan" && x.Model == "Stanza" && x.Year == "1987");

            if (car != null)
            {
                OCar c = new OCar()
                {
                    Id = car.Id,
                    Description = "Well, well, well, what do we have here? A car with four doors? Check. A car with a solid roof? Check. A car with rearview mirrors so you can really connect with that Pearl Jam song? Psh, DOUBLE CHECK. We here at SWCG understand that your discriminating tastes demand that you're able to stand up to authority in style, and this 1987 Nissan Stanza virtually screams: \"Live free or die!\". Rest assured, the seat belts will help ensure that you can live free AND live. That's the SWCG guarentee. You're welcome. ",
                    Title = "PATRIOTIC Nissan Stanza from the year of our Lord 1987",
                    Year = "1987",
                    Make = "Nissan",
                    Model = "Stanza",
                    Price = 9999.00M,
                    ImageUrl = "http://carphotos.cardomain.com/ride_images/1/1287/3601/3216800003_large.jpg"
                };

                _repo.EditCar(c);
            }
        }

        [TestMethod]
        public void TestDeleteRepo()
        {
            var _repo = new MockCarRepository();
            var car = _repo.GetAllCars().FirstOrDefault(x => x.Make == "Nissan" && x.Model == "Stanza" && x.Year == "1987");

            if (car != null)
            {
                //_repo.DeleteCar(car.Id);
            }
        }
    }
}
