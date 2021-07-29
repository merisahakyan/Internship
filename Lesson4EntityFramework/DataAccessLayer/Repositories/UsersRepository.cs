using Lesson4EntityFramework.DataAccessLayer.Interfaces;
using Lesson4EntityFramework.Entities;
using Lesson4EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.DataAccessLayer.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AddressUserCountModel>> GetAddressWithUsersCount()
        {
            var query = from a in _dbContext.Address
                        join u in _dbContext.Users on a.Id equals u.AddressId
                        where u.FirstName.Contains("meri") && a.City == "yerevan"
                        group a by a.Id into addressGroup
                        orderby addressGroup.Key
                        select new AddressUserCountModel
                        {
                            AddressId = addressGroup.Key,
                            UsersCount = addressGroup.Count()
                        };

            var addressList = await query.ToListAsync();

            return addressList;
        }

        public async Task<User> GetUserById(int userId)
        {
            var query = from u in _dbContext.Users
                        where u.Id == userId
                        select u;

            var user = await query.FirstOrDefaultAsync();

            return user;
        }

        public async Task CreateNewUser(int addressId)
        {
            var user = new User
            {
                AddressId = addressId,
                Email = "test email",
                FirstName = "Meri",
                LastName = "Sahakyan",
                Phone = "11111"
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserEmail(User user, string email)
        {
            if (user == null)
                return;

            user.Email = "test email 2";
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveUser(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);

            if (user == null)
            {
                //TODO : needs to be implemented custom NotFoundException
                return;
            }
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        //ՉԻ ԿԱՐԵԼԻ 2 գործողություն մեկ ֆունկցիայում
        //public async Task<User> GetAndUpdateUserById(int userId)
        //{
        //    var query = from u in _dbContext.Users
        //                where u.Id == userId
        //                select u;

        //    var user = await query.FirstOrDefaultAsync();

        //    user.FirstName = "test";

        //    _dbContext.Users.Update(user);
        //    await _dbContext.SaveChangesAsync();

        //    return user;
        //}
    }

}
