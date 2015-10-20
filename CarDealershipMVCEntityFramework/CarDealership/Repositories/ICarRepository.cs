using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    public interface ICarRepository
    {
        List<OCar> GetAllCars();
        OCar GetCarById(int id);
        void AddCar(OCar oCar);
        void EditCar(OCar oCar);
        void DeleteCar(int carId);
        OCar GetCarByModel(string name);
        OCar GetCarByDetails(string year, string make, string model);
        User LoginUser(string username, string password);
       
    }
}
