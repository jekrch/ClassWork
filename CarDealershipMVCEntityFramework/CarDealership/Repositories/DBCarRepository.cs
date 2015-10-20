using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealership.Repositories
{
    public class DBCarRepository : ICarRepository
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CarDB;Integrated Security=True";

        public List<OCar> GetAllCars()
        {
            List<OCar> cars = new List<OCar>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Car", conn);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OCar newOCar = new OCar();
                    newOCar.Id = reader.GetInt32(0);
                    newOCar.Make = reader.GetString(1);
                    newOCar.Model = reader.GetString(2);
                    newOCar.Year = reader.GetString(3);
                    newOCar.ImageUrl = reader.GetString(4);
                    newOCar.Title = reader.GetString(5);
                    newOCar.Description = reader.GetString(6);
                    newOCar.Price = reader.GetDecimal(7);
                    cars.Add(newOCar);
                }
            }

            return cars;
        }

        public OCar GetCarById(int id)
        {
            return GetAllCars().FirstOrDefault(x => x.Id == id);
        }

        public OCar GetCarByDetails(string year, string make, string model)
        {
            //this will get filled in once we move on to this topic
            return null; 
        }

        public User LoginUser(string username, string password)
        {
            User theUser = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Users WHERE Username = '" + username + "' AND [Password] = '" + password + "'", conn);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    theUser = new User();
                    theUser.UserId = reader.GetInt32(0);
                    theUser.Username = reader.GetString(1);
                    theUser.Password = reader.GetString(2);
                    theUser.UserMessage = reader.GetString(3);
                }
            }
            return theUser;
        }

        public OCar GetCarByModel(string name)
        {
            OCar newOCar = new OCar();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Car WHERE Model = '" + name + "'", conn);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    newOCar = new OCar();
                    newOCar.Id = reader.GetInt32(0);
                    newOCar.Make = reader.GetString(1);
                    newOCar.Model = reader.GetString(2);
                    newOCar.Year = reader.GetString(3);
                    newOCar.ImageUrl = reader.GetString(4);
                    newOCar.Title = reader.GetString(5);
                    newOCar.Description = reader.GetString(6);
                    newOCar.Price = reader.GetDecimal(7);
                }
            }
            return newOCar;
        }

        public void AddCar(OCar oCar)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Car (Make, Model, Year, ImageUrl, Title, Description, Price) VALUES (@Make, @Model, @Year, @ImageUrl, @Title, @Description, @Price)";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@Make", oCar.Make);
                command.Parameters.AddWithValue("@Model", oCar.Model);
                command.Parameters.AddWithValue("@Year", oCar.Year);
                command.Parameters.AddWithValue("@ImageUrl", oCar.ImageUrl);
                command.Parameters.AddWithValue("@Description", oCar.Description);
                command.Parameters.AddWithValue("@Title", oCar.Title);
                command.Parameters.AddWithValue("@Price", oCar.Price);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditCar(OCar oCar)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText = "UPDATE Car SET Make = @Make, Model = @Model, Year = @Year, ImageUrl = @ImageUrl, Title = @Title, Description = @Description, Price = @Price WHERE Id = @Id";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@Id", oCar.Id);
                command.Parameters.AddWithValue("@Make", oCar.Make);
                command.Parameters.AddWithValue("@Model", oCar.Model);
                command.Parameters.AddWithValue("@Year", oCar.Year);
                command.Parameters.AddWithValue("@ImageUrl", oCar.ImageUrl);
                command.Parameters.AddWithValue("@Description", oCar.Description);
                command.Parameters.AddWithValue("@Title", oCar.Title);
                command.Parameters.AddWithValue("@Price", oCar.Price);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int carId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText = "DELETE FROM Car WHERE Id = @Id";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@Id", carId);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}