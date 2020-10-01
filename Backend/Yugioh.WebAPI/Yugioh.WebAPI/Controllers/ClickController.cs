﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Yugioh.Services.Hubs;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/click")]
    public class ClickController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private static int count = 0;

        public ClickController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Click()
        {
            count++;

            _hubContext.Clients.All.SendAsync("SendMessage",
                new
                {
                    val1 = "Click" + count,
                    val2 = "Click" + count,
                    val3 = "Click" + count,
                    val4 = "Click" + count
                });

            return Ok();
        }
    }
}