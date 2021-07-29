using Lesson4EntityFramework.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.DataAccessLayer
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }
        IGroupRepository Groups { get; }
    }
}
