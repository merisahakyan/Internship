using Lesson4EntityFramework.DataAccessLayer.CreditCardsFactory;
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
    public class CardsController : ControllerBase
    {
        private ICreditCardService _cardService;
        public CardsController(ICreditCardService service)
        {
            _cardService = service;
        }

        [HttpGet]
        public ActionResult MakeTransaction([FromQuery] int amount)
        {
            _cardService.MakeTransaction(amount);
            return Ok();
        }

    }
}
