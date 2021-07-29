using Lesson4EntityFramework.BusinessLogicLayer.Interfaces;
using Lesson4EntityFramework.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserAsync([FromRoute] int id)
        {
            await _userService.GetAndUpdate(id);
            return Ok();
        }
    }
}
