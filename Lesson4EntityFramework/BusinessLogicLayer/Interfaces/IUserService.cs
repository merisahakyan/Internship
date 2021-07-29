﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<int> GetAndUpdate(int userId);
    }
}
