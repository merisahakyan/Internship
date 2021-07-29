using Lesson4EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.DataAccessLayer.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetUserById(int userId);
        Task<int> CreateNewUser(int addressId);
        Task UpdateUserEmail(User user, string email);
        Task RemoveUser(int userId);
    }
}
