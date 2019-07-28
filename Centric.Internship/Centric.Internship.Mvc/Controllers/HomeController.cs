using System;
using Centric.Internship.Mvc.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Centric.Internship.Mvc.Controllers
{
    [Authorize]
    [Route("home/")]
    [CacheResource]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["CachedMessage"] = "This is some cached content: " + DateTime.Now;
            return View();
        }
    }
}