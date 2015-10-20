using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Repositories
{
    public class MockCarRepository : ICarRepository
    {
        public static List<OCar> Cars = new List<OCar>()
        {
            new OCar()
            {
                Id = 1,
                Make = "Honda",
                Model = "Accord",
                Year = "1996",
                ImageUrl = @"https://igcdn-photos-e-a.akamaihd.net/hphotos-ak-xpt1/t51.2885-15/10561187_765036253561100_1999913933_n.jpg",
                Title = "BITCHIN' 96 HONDA ACCORD",
                Description = "This could be the greatest car of all time. No in fact it is. 110k miles, runs like a dream. Comes with steering wheel, tape deck, and seats. Pearly white-ish. Personally owned by the man himself, Alec Wojo. I can't even believe we're selling it at this low, low price. Why are we doing it? BECAUSE WE'RE CRAZY PEOPLE WITH CRAZY DREAMS!! ACT NOW BEFORE MY BOSS COMES TO HIS SENSES AND TAKES IT OFF THE MARKET!!!!",
                Price = 10000000M
            },
            new OCar()
            {
                Id = 2,
                Make = "Toyota",
                Model = "Camry",
                Year = "1999",
                ImageUrl = @"http://www.curbsideclassic.com/wp-content/uploads/2012/08/DSC00560-1024x768.jpg",
                Title = "WICKED fast 1999 Toyta Camry",
                Description = "Do you enjoy the finer things in life? Maybe a glass of Dom Perginon, well aged scotch, and any furniture that are French words? Hell yes you do. And now you've found the car to compliment your luxury tastes. Imagine speeding down the interstate at a whiplash inducing fourty miles an hour as you sip fine artisnal water from the foothills of Tuscany. And you can stay environmentally consious too as the car sips it's own artisnal 87 octane fire juice at a mere rate of 15 miles per gallon. Well, what are you waiting for, champ?",
                Price = 5995M
            },
            new OCar()
            {
                Id = 3,
                Make = "Suburu",
                Model = "Legacy",
                Year = "1992",
                ImageUrl = @"http://carphotos.cardomain.com/ride_images/1/868/2881/2168940001_large.jpg",
                Title = "This Subaru is SICK!!!",
                Description = "CALL THE POLICE, BECAUSE THESE PRICES ARE CRIMINALLY LOW!!! This 1992 Subaru Legacy is indeed a legacy 'round these parts. Legend has it that a former SWCG employee named Jerry used it as a getaway car when robbing a bank. Unfortunately for Jerry, the bank had already gone out of business and it was an empty building at that point. Jerry doesn't work here anymore. Point is, Jerry's gone, he's not coming back and after a length court battle, we now can offer you this fine speciman with features such as 4(ish) wheels, floormats, and an vague hint of cheap cologne. ACT NOW! JERRY WOULD BE PROUD!",
                Price = 2699M
            },
            new OCar()
            {
                Id = 4,
                Make = "Nissan",
                Model = "Stanza",
                Year = "1987",
                ImageUrl = @"http://carphotos.cardomain.com/ride_images/1/1287/3601/3216800003_large.jpg",
                Title = "PATRIOTIC Nissan Stanza from the year of our Lord 1987",
                Description = "Well, well, well, what do we have here? A car with four doors? Check. A car with a solid roof? Check. A car with rearview mirrors so you can really connect with that Pearl Jam song? Psh, DOUBLE CHECK. We here at SWCG understand that your discriminating tastes demand that you're able to stand up to authority in style, and this 1987 Nissan Stanza virtually screams: \"Live free or die!\". Rest assured, the seat belts will help ensure that you can live free AND live. That's the SWCG guarentee. You're welcome. ",
                Price = 9999M
            },
        };

        public void AddCar(OCar oCar)
        {
            oCar.Id = Cars.Max(c => c.Id) + 1; 
            Cars.Add(oCar);
        }

        public void DeleteCar(int carId)
        {
            Cars.RemoveAll(x => x.Id == carId);
        }

        public void EditCar(OCar oCar)
        {
            this.DeleteCar(oCar.Id);
            Cars.Add(oCar);
        }

        public List<OCar> GetAllCars()
        {
            return Cars;
        }

        public OCar GetCarById(int id)
        {
            return Cars.First(x => x.Id == id);
        }

        public OCar GetCarByModel(string name)
        {
            return Cars.First(x => x.Model == name);
        }


        public OCar GetCarByDetails(string year, string make, string model)
        {
          
            return Cars.FirstOrDefault(c => c.Make == make
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
