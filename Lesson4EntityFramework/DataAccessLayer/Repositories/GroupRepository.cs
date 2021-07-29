using Lesson4EntityFramework.DataAccessLayer.Interfaces;
using Lesson4EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.DataAccessLayer.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context)
        {

        }
    }
}
