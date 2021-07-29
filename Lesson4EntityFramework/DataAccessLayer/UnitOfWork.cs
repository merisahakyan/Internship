using Lesson4EntityFramework.DataAccessLayer.AdoServices;
using Lesson4EntityFramework.DataAccessLayer.Interfaces;
using Lesson4EntityFramework.DataAccessLayer.Repositories;
using Lesson4EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUsersRepository Users
        {
            get
            {
                return new UsersRepository(_context);
            }
        }

        public UsersAdoService AdoUsers
        {
            get
            {
                return new UsersAdoService();
            }
        }
        public IGroupRepository Groups
        {
            get
            {
                return new GroupRepository(_context);
            }
        }

    }
}
