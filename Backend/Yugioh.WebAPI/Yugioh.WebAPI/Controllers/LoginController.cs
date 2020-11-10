using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        public IActionResult Login(string loginName)
        {
            try
            {
                var message = new Message();
                message.MessageText = "Prisijungimas pavyko:" + loginName;
                return Ok(message);
            }
            catch
            {
                return BadRequest();
            }
        }
    }

    public class Message
    {
        public string MessageText { get; set; }
    }
}
