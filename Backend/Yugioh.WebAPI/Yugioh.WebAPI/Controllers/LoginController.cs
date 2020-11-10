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
        public IActionResult Login()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
