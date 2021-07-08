using Lesson4EntityFramework.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.DataAccessLayer
{
    public class UsersAdoService
    {
        //get connection string
        //open connection
        //create sql command 
        //execute query
        public async Task CreateUserAsync(User user)
        {
            var connectionString = "Server=localhost; Database=myNewDb; Trusted_Connection=True;";

            var query = $"INSERT INTO users(firstName, lastName, email, phone, addressId) " +
                $"values ({user.FirstName},{user.LastName},{user.Email},{user.Phone}, {user.AddressId})";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            var connectionString = "Server=localhost; Database=myNewDb; Trusted_Connection=True;";

            var query = $"UPDATE users set firstName = {user.FirstName} " +
                $"where Id = {user.Id}";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            var connectionString = "Server=localhost; Database=myNewDb; Trusted_Connection=True;";

            var query = $"delete from users" +
                $"where Id = {userId}";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            var resultUsers = new List<User>();

            var connectionString = "Server=localhost; Database=myNewDb; Trusted_Connection=True;";

            var query = $"select * from users";  //Id = 0, Firstname = 1, Lastname = 2, Email = 3, Phone = 4, AddressId = 5

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                var reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    resultUsers.Add(new User
                    {
                        FirstName = reader.GetString(1),
                        Id = reader.GetInt32(0),
                        LastName = reader.GetString(2),
                        AddressId=reader.GetInt32(5),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4)
                    });
                }
            }

            return resultUsers;
        }
    }
}
