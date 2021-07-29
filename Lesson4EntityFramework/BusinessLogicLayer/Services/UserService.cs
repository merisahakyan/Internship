﻿using Lesson4EntityFramework.BusinessLogicLayer.Interfaces;
using Lesson4EntityFramework.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.BusinessLogicLayer.Services
{
    public class UserService: IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task GetAndUpdate(int userId)
        {
            var user = await _unitOfWork.Users.GetUserById(userId);

            await _unitOfWork.Users.UpdateUserEmail(user, "test email");
        }
    }
}