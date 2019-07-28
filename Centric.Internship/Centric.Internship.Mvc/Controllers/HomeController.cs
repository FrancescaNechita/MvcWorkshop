using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Centric.Internship.Mvc.Controllers
{
    [Authorize]
    [Route("home/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("error")]
        public ActionResult Error()
        {
            throw new ApplicationException();
        }
    }
}