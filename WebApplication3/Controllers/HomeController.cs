using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.signalrChatApp;
using WebApplication3.Models;
using WebApplication3.signalrChatApp;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Microsoft.AspNetCore.SignalR.IHubContext<ChatHub, IChatHub> _hubContext;
        private static Random random = new Random();

        public HomeController(ILogger<HomeController> logger, Microsoft.AspNetCore.SignalR.IHubContext<ChatHub, IChatHub> chatHubContext)
        {
            _logger = logger;
            // _hub = hub;
            _hubContext = chatHubContext;//;GlobalHost.ConnectionManager.GetHubContext("ChatHub");
            //_hubContext = hubContext;
        }

        public async Task<ActionResult> Index()
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string user = new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            await _hubContext.Clients.All.PlayerJoined(user);


            return View("Index", user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
