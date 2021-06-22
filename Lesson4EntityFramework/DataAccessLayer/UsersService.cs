using Lesson4EntityFramework.Entities;
using Lesson4EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.DataAccessLayer
{
    public class UsersService
    {
        private readonly ApplicationDbContext _dbContext;
        public UsersService()
        {
            _dbContext = new ApplicationDbContext();
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

        public async Task UpdateNewUser(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);

            if (user == null)
            {
                //TODO : needs to be implemented custom NotFoundException
                return;
            }

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
    }
}
