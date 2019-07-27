using System.Linq;
using Centric.Internship.Mvc.Models;
using Centric.Internship.Mvc.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Centric.Internship.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}